using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TGMT;
using TGMTcs;
using System.IO;

namespace UI
{
    public partial class FormImage : Form
    {
        static FormImage m_instance;
        Stopwatch watch;

        public FormImage()
        {
            InitializeComponent();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static FormImage GetInstance()
        {
            if (m_instance == null)
                m_instance = new FormImage();
            return m_instance;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormImage_Load(object sender, EventArgs e)
        {
            chk_draw.Checked = Program.reader.DrawRectangle;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_select_Click(object sender, EventArgs e)
        {
            txt_fileName.Text = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image file |*.jpg;*.png*.bmp;*.PNG;";
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                txt_fileName.Text = ofd.FileName;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txt_fileName_TextChanged(object sender, EventArgs e)
        {
            Read();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_read_Click(object sender, EventArgs e)
        {
            Read();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Read()
        {

            if (txt_fileName.Text == "")
                return;

            string filePath = txt_fileName.Text.Replace("\"", "");

            if (!File.Exists(filePath))
                return;

            btn_select.Enabled = false;
            btn_read.Enabled = false;
            lbl_result.Text = "";

            Bitmap bmp = TGMTimage.LoadBitmapWithoutLock(filePath);
            if (bmp != null)
            {
                picInput.Image = bmp;
                FormMain.GetInstance().PrintMessage("");
                FormMain.GetInstance().StartProgressbar();
            }


            watch = Stopwatch.StartNew();
            CardInfo result = Program.reader.Read(filePath);
            watch.Stop();

            FormMain.GetInstance().StopProgressbar();

            if (result.type == CardInfo.CardType.CMND9)
                lbl_type.Text = "CMND9";
            else if (result.type == CardInfo.CardType.CMND12)
                lbl_type.Text = "CMND12";
            else if (result.type == CardInfo.CardType.CCCD_Barcode)
                lbl_type.Text = "CCCD Barcode";
            else if (result.type == CardInfo.CardType.CCCD_Chip)
                lbl_type.Text = "CCCD Chip";
            else if (result.type == CardInfo.CardType.CCCD_Chip)
                lbl_type.Text = "CCCD Chip Back";

            lbl_result.Text = result.cardNumber;

            if (result.bitmap == null)
            {
                FormMain.GetInstance().PrintMessage(result.error);
            }
            else
            {                    
                picResult.Image = result.bitmap;
                FormMain.GetInstance().PrintMessage("Elapsed: " + watch.ElapsedMilliseconds.ToString() + "ms");
            }

            btn_select.Enabled = true;
            btn_read.Enabled = true;

        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chk_draw_CheckedChanged(object sender, EventArgs e)
        {
            Program.reader.DrawRectangle = chk_draw.Checked;            
        }

        
    }
}
