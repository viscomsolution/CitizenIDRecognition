using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGMT;
using TGMTcs;

namespace UI
{
    public partial class FormFolder : Form
    {
        string m_folderOutput = "";

        static FormFolder m_instance;
        Stopwatch watch;

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public FormFolder()
        {
            InitializeComponent();

            Control.CheckForIllegalCrossThreadCalls = false;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormFolder_Load(object sender, EventArgs e)
        {
            txtFolderInput.Text = TGMTregistry.GetInstance().ReadString("folderInput");
            txtFailedDir.Text = TGMTregistry.GetInstance().ReadString("txtFailedDir");
            txt_CMND9dir.Text = TGMTregistry.GetInstance().ReadString("txt_CMND9dir");
            txt_CMND12dir.Text = TGMTregistry.GetInstance().ReadString("txt_CMND12dir");
            txt_CCCDBarcodeDir.Text = TGMTregistry.GetInstance().ReadString("txt_CCCDBarcodeDir");
            txt_CCCDChipdir.Text = TGMTregistry.GetInstance().ReadString("txt_CCCDChipdir");
            txt_CCCDChipbackDir.Text = TGMTregistry.GetInstance().ReadString("txt_CCCDChipbackDir");
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormFolder_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopDetectMultiple();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormFolder_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                StartDetectMultiple();
            }
            else if (e.KeyCode == Keys.F6)
            {
                DetectSingle();
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static FormFolder GetInstance()
        {
            if (m_instance == null)
                m_instance = new FormFolder();
            return m_instance;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bgLoadFile_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> files = new List<string>();
            lstImage.Items.Clear();

            string[] fileList = Directory.GetFiles(txtFolderInput.Text, "*.jpg");
            foreach (string filePath in fileList)
            {
                files.Add(Path.GetFileName(filePath));
            }

            fileList = Directory.GetFiles(txtFolderInput.Text, "*.png");
            foreach (string filePath in fileList)
            {
                files.Add(Path.GetFileName(filePath));
            }

            fileList = Directory.GetFiles(txtFolderInput.Text, "*.bmp");
            foreach (string filePath in fileList)
            {
                files.Add(Path.GetFileName(filePath));
            }

            e.Result = files;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bgLoadFile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<string> files = (List<string>)e.Result;
            for (int i = 0; i < files.Count; i++)
            {
                lstImage.Items.Add(files[i]);
            }
            FormMain.GetInstance().PrintMessage("Loaded " + lstImage.Items.Count + " images");
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void lstImage_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lstImage.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                DisplayResultImage();
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void lstImage_KeyDown(object sender, KeyEventArgs e)
        {
            string filePath = TGMTutil.CorrectPath(txtFolderInput.Text);
            filePath += lstImage.SelectedItems[0].Text;
            if (e.KeyCode == Keys.Enter)
            {
                System.Diagnostics.Process.Start(filePath);
            }
            else if (e.KeyCode == Keys.Delete)
            {
                FileSystem.DeleteFile(filePath, UIOption.AllDialogs, RecycleOption.SendToRecycleBin);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void DisplayResultImage()
        {
            if (lstImage.Items.Count == 0 || lstImage.SelectedItems.Count == 0)
            {
                return;
            }

            string fileName = lstImage.SelectedItems[0].Text;


            string inputPath = TGMTutil.CorrectPath(txtFolderInput.Text);
            string failedDir = txtFailedDir.Text != "" ? TGMTutil.CorrectPath(txtFailedDir.Text) : "";
            

            if (m_folderOutput != "" && File.Exists(m_folderOutput + fileName))
            {
                picResult.ImageLocation = m_folderOutput + fileName;
                FormMain.GetInstance().PrintMessage(m_folderOutput + fileName);
            }
            else if (File.Exists(inputPath + fileName))
            {
                picResult.ImageLocation = inputPath + fileName;
                FormMain.GetInstance().PrintMessage(inputPath + fileName);
            }
            else if (txtFailedDir.Text != "" && File.Exists(failedDir + fileName))
            {
                picResult.ImageLocation = failedDir + fileName;
                FormMain.GetInstance().PrintMessage(failedDir + fileName);
            }
            else
            {
                FormMain.GetInstance().PrintError("File " + inputPath + fileName + " does not exist");
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void lstImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayResultImage();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txtFolderInput_TextChanged(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtFolderInput.Text))
                return;

            TGMTregistry.GetInstance().SaveValue("folderInput", txtFolderInput.Text);
            FormMain.GetInstance().PrintMessage("Loading files...");
            lstImage.Items.Clear();
            bgLoadFile.RunWorkerAsync();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string filePath = TGMTutil.CorrectPath(txtFolderInput.Text);
            filePath += lstImage.SelectedItems[0].Text;
            if (!File.Exists(filePath))
            {
                FormMain.GetInstance().PrintMessage("File does not exist");
                return;
            }


            if (e.ClickedItem.Name == "btnCopyPath")
            {
                Clipboard.SetText(filePath);
                FormMain.GetInstance().PrintMessage("Copied path to clipboard");
            }
            else if (e.ClickedItem.Name == "btnCopyImage")
            {
                StringCollection paths = new StringCollection();
                paths.Add(filePath);
                Clipboard.SetFileDropList(paths);
                FormMain.GetInstance().PrintMessage("Copied image to clipboard");
            }
            else if (e.ClickedItem.Name == "btnOpenImage")
            {
                System.Diagnostics.Process.Start(filePath);
            }
            else if (e.ClickedItem.Name == "btnDelete")
            {
                FileSystem.DeleteFile(filePath, UIOption.AllDialogs, RecycleOption.SendToRecycleBin);
            }
            else if (e.ClickedItem.Name == "btn_detect")
            {
                FormImage.GetInstance().txt_fileName.Text = filePath;
                FormMain.GetInstance().btnImage.PerformClick();
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void DetectSingle()
        {
            spinningCircles1.Visible = true;
            string filePath = TGMTutil.CorrectPath(txtFolderInput.Text);
            filePath += lstImage.SelectedItems[0].Text;
            

            if (!File.Exists(filePath))
            {
                FormMain.GetInstance().PrintMessage("File does not exist");
                spinningCircles1.Visible = false;
                return;
            }

            watch = Stopwatch.StartNew();
            CardInfo result = Program.reader.Read(filePath);
            watch.Stop();


            if (result.bitmap == null)
            {
                FormMain.GetInstance().PrintMessage(result.error);
            }
            else
            {
                picResult.Image = result.bitmap;
                FormMain.GetInstance().PrintMessage("Elapsed: " + watch.ElapsedMilliseconds.ToString() + "ms");
            }
            spinningCircles1.Visible = false;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_detectSingle_Click(object sender, EventArgs e)
        {
            DetectSingle();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bgWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string inputPath = "";
            if (txtFolderInput.Text != "")
                inputPath = TGMTutil.CorrectPath(txtFolderInput.Text);
            string failedDir = "";
            if (txtFailedDir.Text != "")
                failedDir = TGMTutil.CorrectPath(txtFailedDir.Text);

            string CMND9Dir = "";
            if (txt_CMND9dir.Text != "")
                CMND9Dir = TGMTutil.CorrectPath(txt_CMND9dir.Text);

            string CMND12Dir = "";
            if (txt_CMND12dir.Text != "")
                CMND12Dir = TGMTutil.CorrectPath(txt_CMND12dir.Text);

            string CCCDBarcodedir = "";
            if (txt_CCCDChipdir.Text != "")
                CCCDBarcodedir = TGMTutil.CorrectPath(txt_CCCDBarcodeDir.Text);

            string CCCDChipdir = "";
            if (txt_CCCDChipdir.Text != "")
                CCCDChipdir = TGMTutil.CorrectPath(txt_CCCDChipdir.Text);

            string CCCDChipbackDir = "";
            if (txt_CCCDChipdir.Text != "")
                CCCDChipbackDir = TGMTutil.CorrectPath(txt_CCCDChipbackDir.Text);

            int exactlyCount = 0;
            string content = "";

            

            for (int i = 0; i < lstImage.Items.Count; i++)
            {
                if (bgWorker1.CancellationPending)
                    return;
                //bgWorker1.ReportProgress(i + 1);

                //Program.reader.OutputFileName = lstImage.Items[i].Text;
                string fileName = lstImage.Items[i].Text;
                string filePath = inputPath + fileName;
                string ext = filePath.Substring(filePath.Length - 4).ToLower();
                content += Path.GetFileName(filePath) + ",";

                

                if (ext != ".jpg" && ext != ".png" && ext != ".bmp")
                    continue;
                FormMain.GetInstance().PrintMessage(i + " / " + lstImage.Items.Count + " " + filePath);

                Bitmap bmp;
                try
                {
                    bmp = (Bitmap)Bitmap.FromFile(filePath);
                }
                catch (Exception ex)
                {
                    continue;
                }

                CardInfo result = Program.reader.Read(bmp);
                bmp.Dispose();

                if (result.cardNumber != "" && result.cardNumber != "Not found")
                {
                    string type = "";
                    
                    if (result.type == CardInfo.CardType.CMND9)
                        type = "CMND9";
                    else if (result.type == CardInfo.CardType.CMND12)
                        type = "CMND12";
                    if (result.type == CardInfo.CardType.CCCD_Barcode)
                        type = "CCCD Barcode";
                    else if (result.type == CardInfo.CardType.CCCD_Chip)
                        type = "CMND Chip";
                    else if (result.type == CardInfo.CardType.CCCD_ChipBack)
                        type = "CMND Chipback";

                    if (lstImage.Items[i].SubItems.Count == 1)
                    {
                        lstImage.Items[i].SubItems.Add(result.cardNumber);
                        lstImage.Items[i].SubItems.Add(type);
                    }
                    else
                    {
                        lstImage.Items[i].SubItems[1].Text = result.cardNumber;
                        lstImage.Items[i].SubItems[2].Text = type;
                    }

                    
                    //lstImage.Items[i].ForeColor = result.isValid ? Color.Blue : Color.Black;
                    content += "x,";
                    

                    if (result.type == CardInfo.CardType.CMND9)
                    {
                        if (chkMoveCMND9.Checked)
                        {
                            Task.Run(() => File.Move(inputPath + fileName, CMND9Dir + fileName));
                        }
                    }
                    else if(result.type == CardInfo.CardType.CMND12)
                    {
                        exactlyCount++;
                        if (chkMoveCMND12.Checked)
                        {
                            Task.Run(() => File.Move(inputPath + fileName, CMND12Dir + fileName));
                        }
                    }
                    else if (result.type == CardInfo.CardType.CCCD_Barcode)
                    {
                        if (chkMoveCCCDbarcode.Checked)
                        {
                            Task.Run(() => File.Move(inputPath + fileName, CCCDBarcodedir + fileName));
                        }
                    }
                    else if (result.type == CardInfo.CardType.CCCD_Chip)
                    {
                        if (chkMoveCCCDChip.Checked)
                        {
                            Task.Run(() => File.Move(inputPath + fileName, CCCDChipdir + fileName));
                        }
                    }
                    else if (result.type == CardInfo.CardType.CCCD_ChipBack)
                    {
                        if (chkMoveCCCDChipback.Checked)
                        {
                            Task.Run(() => File.Move(inputPath + fileName, CCCDChipbackDir + fileName));
                        }
                    }
                }
                else
                {
                    if (lstImage.Items[i].SubItems.Count == 1)
                    {
                        lstImage.Items[i].SubItems.Add(result.error);
                    }
                    else
                    {
                        lstImage.Items[i].SubItems[1].Text = result.error;
                    }
                    if (chkMoveFail.Checked)
                    {
                        Task.Run(() => File.Move(inputPath + fileName, failedDir + fileName));
                    }

                    lstImage.Items[i].ForeColor = Color.Red;
                    content += ",";
                }

                content += result.cardNumber;
                content += "\r\n";


                //result.Dispose();


                lstImage.EnsureVisible(i);
            }

            if (inputPath != "")
            {
                content += "Exactly " + exactlyCount + " / " + lstImage.Items.Count + " plates\r\n";
                File.WriteAllText(Path.GetDirectoryName(inputPath) + "\\_report.csv", content);
            }

        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bgWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            FormMain.GetInstance().PrintMessage(e.ProgressPercentage + "/" + lstImage.Items.Count + "(" + (100 * e.ProgressPercentage / lstImage.Items.Count) + " %)");
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bgWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            spinningCircles1.Visible = false;

            btnDetect.Text = "Detect (F5)";
            if (m_folderOutput != "")
                FormMain.GetInstance().PrintMessage("Save report to " + TGMTutil.CorrectPath(txtFolderInput.Text) + "_report.csv");
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnSelectFolderInput_Click(object sender, EventArgs e)
        {
            OpenFileDialog folderBrowser = new OpenFileDialog();
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            // Always default to Folder Selection.
            folderBrowser.FileName = "Select folder contain image";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                txtFolderInput.Text = folderPath;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chkMoveFail_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMoveFail.Checked)
            {
                errorProvider1.Clear();

                if (txtFailedDir.Text == "")
                {
                    chkMoveFail.Checked = false;
                    FormMain.GetInstance().PrintError("Target directory is empty");
                }
                else if (!Directory.Exists(txtFailedDir.Text))
                {
                    //does not create new dir to avoid replace existed file
                    errorProvider1.SetError(txtFailedDir, "Dir does not exist");

                    chkMoveFail.Checked = false;
                }
                else
                {
                    TGMTregistry.GetInstance().SaveValue("txtFailedDir", txtFailedDir.Text);
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chkMoveCMND9_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMoveCMND9.Checked)
            {
                errorProvider1.Clear();

                if (txt_CMND9dir.Text == "")
                {
                    FormMain.GetInstance().PrintError("Directory is empty");
                    chkMoveCMND9.Checked = false;
                }
                else if (!Directory.Exists(txt_CMND9dir.Text))
                {
                    //does not create new dir to avoid replace existed file
                    errorProvider1.SetError(txt_CMND9dir, "Dir does not exist");
                    chkMoveCMND9.Checked = false;
                }
                else
                {
                    TGMTregistry.GetInstance().SaveValue("txt_CMND9dir", txt_CMND9dir.Text);
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chkMoveCMND12_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMoveCMND12.Checked)
            {
                errorProvider1.Clear();

                if (txt_CMND12dir.Text == "")
                {
                    FormMain.GetInstance().PrintError("Directory is empty");
                    chkMoveCMND12.Checked = false;
                }
                else if (!Directory.Exists(txt_CMND12dir.Text))
                {
                    //does not create new dir to avoid replace existed file
                    errorProvider1.SetError(txt_CMND12dir, "Dir does not exist");
                    chkMoveCMND12.Checked = false;
                }
                else
                {
                    TGMTregistry.GetInstance().SaveValue("txt_CMND12dir", txt_CMND12dir.Text);
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chkMoveCCCDbarcode_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMoveCCCDbarcode.Checked)
            {
                errorProvider1.Clear();

                if (txt_CCCDBarcodeDir.Text == "")
                {
                    FormMain.GetInstance().PrintError("Invalid directory is empty");
                    chkMoveCCCDChip.Checked = false;
                }
                else if (!Directory.Exists(txt_CCCDBarcodeDir.Text))
                {
                    //does not create new dir to avoid replace existed file
                    errorProvider1.SetError(txt_CCCDBarcodeDir, "Dir does not exist");
                    chkMoveCCCDbarcode.Checked = false;
                }
                else
                {
                    TGMTregistry.GetInstance().SaveValue("txt_CCCDBarcodeDir", txt_CCCDBarcodeDir.Text);
                }
            }
        }        

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chkMoveCCCDChip_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMoveCCCDChip.Checked)
            {
                errorProvider1.Clear();

                if (txt_CCCDChipdir.Text == "")
                {
                    FormMain.GetInstance().PrintError("Invalid directory is empty");
                    chkMoveCCCDChip.Checked = false;
                }
                else if (!Directory.Exists(txt_CCCDChipdir.Text))
                {
                    //does not create new dir to avoid replace existed file
                    errorProvider1.SetError(txt_CCCDChipdir, "Dir does not exist");
                    chkMoveCCCDChip.Checked = false;
                }
                else
                {
                    TGMTregistry.GetInstance().SaveValue("txt_CCCDChipdir", txt_CCCDChipdir.Text);
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chkMoveCCCDChipback_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMoveCCCDChip.Checked)
            {
                errorProvider1.Clear();

                if (txt_CCCDChipbackDir.Text == "")
                {
                    FormMain.GetInstance().PrintError("Invalid directory is empty");
                    chkMoveCCCDChip.Checked = false;
                }
                else if (!Directory.Exists(txt_CCCDChipbackDir.Text))
                {
                    //does not create new dir to avoid replace existed file
                    errorProvider1.SetError(txt_CCCDChipbackDir, "Dir does not exist");
                    chkMoveCCCDChip.Checked = false;
                }
                else
                {
                    TGMTregistry.GetInstance().SaveValue("txt_CCCDChipbackDir", txt_CCCDChipbackDir.Text);
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnDetect_Click(object sender, EventArgs e)
        {
            if (btnDetect.Text.Contains("Detect"))
            {
                StartDetectMultiple();
            }
            else
            {
                StopDetectMultiple();                
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void StartDetectMultiple()
        {
            bgWorker1.RunWorkerAsync();
            btnDetect.Text = "Stop (F5)";
            spinningCircles1.Visible = true;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void StopDetectMultiple()
        {
            bgWorker1.CancelAsync();
            btnDetect.Text = "Detect (F5)";
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void lstImage_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DetectSingle();
        }
    }
}
