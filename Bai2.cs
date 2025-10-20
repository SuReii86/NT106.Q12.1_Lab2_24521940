using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NT106.Q12._1_Lab2_24521940
{
    public partial class Bai2 : Form
    {
        public Bai2()
        {
            InitializeComponent();
        }

        private void btn_exe_Click(object sender, EventArgs e)
        {
            tb_Output.Clear();
            if (string.IsNullOrWhiteSpace(tb_NFile.Text))
            {
                MessageBox.Show("Chưa Nhập Tên File", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (!File.Exists(tb_NFile.Text))
            {
                MessageBox.Show("Tên File Nhập Vào Không Tồn Tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }    
            string file = tb_NFile.Text;
            tb_url.Text = Path.GetFullPath(file);
            using (StreamReader read = new StreamReader(file))
            {
                tb_Size.Text = new FileInfo(file).Length.ToString();
                int lines_count = 0;
                string line;
                while ((line = read.ReadLine()) != null)
                {
                    lines_count++;
                    tb_Output.AppendText(line + Environment.NewLine);
                }
                tb_lines.Text = lines_count.ToString();

                char[] delimiter = {' ', '\n'};
                string[] words = tb_Output.Text.Split(delimiter);
                int words_count = words.Length - 1;
                tb_words.Text = words_count.ToString();
                tb_chars.Text = tb_Output.Text.Length.ToString();
            }    
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
