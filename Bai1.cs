using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NT106.Q12._1_Lab2_24521940
{
    public partial class Bai1 : Form
    {
        public Bai1()
        {
            InitializeComponent();
        }

        private void btn_READ_Click(object sender, EventArgs e)
        {
            String file = "Cau1_OUT.txt";
            tb_label.Text = file;
            if (File.Exists(file))
            { 
                using (StreamReader sr = new StreamReader(file))
                {
                    tb_IO.Text = sr.ReadToEnd();
                }
            }

        }  



        private void btn_Write_Click(object sender, EventArgs e)
        {
            string file = "Cau1_IN.txt";
           
            try
            {
                tb_label.Text = file;
                using (StreamWriter sw = new StreamWriter(file))
                {
                    sw.Write(tb_IO.Text.ToUpper());
                }
                MessageBox.Show("Ghi file thành công", "Thông Báo", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_RESET_Click(object sender, EventArgs e)
        {
            tb_label.Clear();
            tb_IO.Clear();
        }
    }
}
