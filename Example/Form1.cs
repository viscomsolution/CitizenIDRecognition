using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//sử dụng namespace TGMT (Cty Thị Giác Máy Tính)
using TGMT;

namespace Example
{
    public partial class Form1 : Form
    {
        //khởi tạo biến 
        CitizenIDReader reader = new CitizenIDReader();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //đọc kết quả từ ảnh
            string result = reader.Read("cccd.jpg");

            //gán kết quả đọc được vào textbox
            textBox1.Text = result;
        }
    }
}
