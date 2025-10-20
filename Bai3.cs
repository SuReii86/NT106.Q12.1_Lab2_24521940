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
    public partial class Bai3 : Form
    {
        public Bai3()
        {
            InitializeComponent();
        }

        private void btn_READ_Click(object sender, EventArgs e)
        {
            string file = "input3.txt";
            using (StreamReader read = new StreamReader(file))
            {
                string line;
                while ((line = read.ReadLine()) != null)
                {
                    tb_IN.AppendText(line + Environment.NewLine);
                }
            }
        }

        private void btn_CALC_Click(object sender, EventArgs e)
        {

            string file = "input3.txt";
            using (StreamReader read = new StreamReader(file))
            {
                string line;
                while ((line = read.ReadLine()) != null)
                {
                    line = line.Trim();

                    char[] del_char = { '+', '-', '*', '/', ' '};
                    string check_line = line;

                    foreach (char c in del_char)
                    {
                        check_line = check_line.Replace(c.ToString(), "");
                    }

                    if (!double.TryParse(check_line, out _))
                    {
                        MessageBox.Show("Dữ Liệu Nhập vào có kí tự không phải số.", "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    List<string> tokens = new List<string>(); 

                    for (int i = 0; i < line.Length; i++)
                    {
                        char current = line[i];

                        if (char.IsDigit(current) || current == '.')
                        {

                            string number = "";

                            while ((i < line.Length && char.IsDigit(line[i])) || (i < line.Length && line[i] == '.'))
                            {
                                number += line[i];
                                i++;
                            }
                            tokens.Add(number);
                            i--;
                        }
                        else if (current == '+' || current == '-' || current == '*' || current == '/')
                        {
                            tokens.Add(current.ToString());
                        }
                        else if (char.IsWhiteSpace(current))
                        {
                            continue;
                        }
                        else
                        {
                            MessageBox.Show($"Kí tự {current} không hợp lệ.", "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    double result = double.Parse(tokens[0]);

                    // Kiểm tra lỗi cú pháp cơ bản (ví dụ: "1+" hoặc "++2")
                    if (tokens.Count == 0 || tokens.Count % 2 == 0)
                    {
                        MessageBox.Show("Lỗi cú pháp biểu thức (thiếu toán hạng/toán tử).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    for (int i = 0; i < tokens.Count; i++)
                    {
                        string token = tokens[i];

                        if (token == "*" || token == "/")
                        {
                            if (i == 0 || i + 1 >= tokens.Count)
                            {
                                MessageBox.Show("Lỗi cú pháp: Toán tử ở vị trí không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            double left = double.Parse(tokens[i - 1]);
                            double right = double.Parse(tokens[i + 1]);
                            double calculationResult = 0;

                            if (token == "*") calculationResult = left * right;

                            if (token == "/")
                            {
                                if (right == 0)
                                {
                                    MessageBox.Show("Lỗi: Chia cho 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                calculationResult = left / right;
                            }

                            // Thay thế 3 tokens bằng 1 token kết quả
                            tokens[i - 1] = calculationResult.ToString();
                            tokens.RemoveAt(i + 1);
                            tokens.RemoveAt(i);

                            i = -1;
                        }
                    }

                    double finalResult = double.Parse(tokens[0]);

                    for (int i = 1; i < tokens.Count; i += 2)
                    {
                        double right = double.Parse(tokens[i + 1]);

                        switch (tokens[i])
                        {
                            case "+":
                                finalResult += right;
                                break;
                            case "-":
                                finalResult -= right;
                                break;
                        }
                    }
                    tb_Prc.AppendText(line + " = " + finalResult + Environment.NewLine);
                }
            }

        }

        private void btn_WRITE_Click(object sender, EventArgs e)
        {
            string file = "output3.txt";
            using (StreamWriter write = new StreamWriter(file))
            {
                write.WriteLine(tb_Prc.Text);
            }

            using (StreamReader read = new StreamReader(file))
            {
                string line;
                while ((line = read.ReadLine()) != null)
                {
                    tb_OUT.AppendText(line + Environment.NewLine);
                }
            }
        }
    }
}
