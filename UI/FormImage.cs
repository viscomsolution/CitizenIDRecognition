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
            if (txt_fileName.Text == "")
                return;

            lbl_result.Text = "";
            Bitmap bmp = TGMTimage.LoadBitmapWithoutLock(txt_fileName.Text);
            if(bmp != null)
            {
                picInput.Image = bmp;
                FormMain.GetInstance().PrintMessage("");
                FormMain.GetInstance().StartProgressbar();

                watch = Stopwatch.StartNew();
                Thread t = new Thread(() => Read(txt_fileName.Text));
                t.Start();
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void Read(string imagePath)
        {
            CardInfo result = Program.reader.Read(imagePath);
            this.Invoke(new Action(() =>
            {
                FormMain.GetInstance().StopProgressbar();
                lbl_result.Text = result.cardNumber;
                picResult.Image = result.bitmap;

                watch.Stop();
                FormMain.GetInstance().PrintMessage("Elapsed: " + watch.ElapsedMilliseconds.ToString() + "ms");
            }));
        }
    }
}
