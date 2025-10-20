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

                    // Kiểm tra dữ liệu đầu vào
                    char[] del_char = { '+', '-', '*', '/', ' ', '(', ')' };
                    string check_line = line;
                    foreach (char c in del_char)
                    {
                        check_line = check_line.Replace(c.ToString(), "");
                    }

                    if (!double.TryParse(check_line, out _) && check_line != "")
                    {
                        MessageBox.Show("Dữ liệu nhập vào chứa ký tự không phải số.", "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }

                    List<string> tokens = new List<string>();
                    string number = "";

                    // Phân tích biểu thức thành các token
                    for (int i = 0; i < line.Length; i++)
                    {
                        char current = line[i];

                        if (char.IsDigit(current) || current == '.')
                        {
                            number += current;
                        }
                        else if (current == '+' || current == '-' || current == '*' || current == '/' || current == '(' || current == ')')
                        {
                            if (number != "")
                            {
                                tokens.Add(number);
                                number = "";
                            }
                            tokens.Add(current.ToString());
                        }
                        else if (char.IsWhiteSpace(current))
                        {
                            if (number != "")
                            {
                                tokens.Add(number);
                                number = "";
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Ký tự {current} không hợp lệ.", "Cảnh Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }
                    }
                    if (number != "")
                    {
                        tokens.Add(number);
                    }

                    
                    while (tokens.Contains("("))
                    {
                        int openIndex = -1; // Xác định vị trí bắt đầu của SubTokens
                        int closeIndex = -1; // Xác định vị trí kết thúc của SubTokens
                        int openCount = 0; // Dùng để kiểm tra khi đến vị trí kết thúc

                        // Tìm cặp dấu ngoặc trong cùng
                        for (int i = 0; i < tokens.Count; i++)
                        {
                            if (tokens[i] == "(")
                            {
                                if (openCount == 0)
                                    openIndex = i;
                                openCount++;
                            }
                            else if (tokens[i] == ")")
                            {
                                openCount--;
                                if (openCount == 0)
                                {
                                    closeIndex = i;
                                    break;
                                }
                            }
                        }

                        if (openIndex == -1 || closeIndex == -1 || openCount != 0)
                        {
                            MessageBox.Show("Lỗi cú pháp: Dấu ngoặc không khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }

                        List<string> subTokens = tokens.GetRange(openIndex + 1, closeIndex - openIndex - 1);
                        
                        // Thực Hiện Tính Toán Theo thứ tự giống với Tokens bình thường
                        for (int i = 0; i < subTokens.Count; i++)
                        {
                            string token = subTokens[i];
                            if (token == "*" || token == "/")
                            {
                                if (i == 0 || i + 1 >= subTokens.Count)
                                {
                                    MessageBox.Show("Lỗi cú pháp: Toán tử ở vị trí không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                                double left = double.Parse(subTokens[i - 1]);
                                double right = double.Parse(subTokens[i + 1]);
                                double calculationResult = 0;

                                if (token == "*") calculationResult = left * right;
                                if (token == "/")
                                {
                                    if (right == 0)
                                    {
                                        MessageBox.Show("Lỗi: Chia cho 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        break;
                                    }
                                    calculationResult = left / right;
                                }

                                subTokens[i - 1] = calculationResult.ToString();
                                subTokens.RemoveAt(i + 1);
                                subTokens.RemoveAt(i); // Giống với logic Tính toán và gán lại giá trị của Phép Nhân, Chia
                                i = -1;
                            }
                        }

                        double subResult = double.Parse(subTokens[0]);
                        for (int i = 1; i < subTokens.Count; i += 2)
                        {
                            double right = double.Parse(subTokens[i + 1]);
                            switch (subTokens[i])
                            {
                                case "+":
                                    subResult += right;
                                    break;
                                case "-":
                                    subResult -= right;
                                    break;
                            }
                        }

                        tokens[openIndex] = subResult.ToString();
                        for (int i = closeIndex; i > openIndex; i--)
                        {
                            tokens.RemoveAt(i);
                        }
                    }

                    if (tokens.Count == 0 || tokens.Count % 2 == 0)
                    {
                        MessageBox.Show("Lỗi cú pháp: Biểu thức thiếu toán hạng hoặc toán tử.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }

                    for (int i = 0; i < tokens.Count; i++)
                    {
                        string token = tokens[i];
                        if (token == "*" || token == "/")
                        {
                            if (i == 0 || i + 1 >= tokens.Count)
                            {
                                MessageBox.Show("Lỗi cú pháp: Toán tử ở vị trí không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                continue;
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
                                    continue;
                                }
                                calculationResult = left / right;
                            }

                            tokens[i - 1] = calculationResult.ToString();
                            tokens.RemoveAt(i + 1);
                            tokens.RemoveAt(i);
                            i = -1;
                        }
                    }

                    // Xử lý cộng và trừ
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