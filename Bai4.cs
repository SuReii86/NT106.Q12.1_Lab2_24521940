using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace NT106.Q12._1_Lab2_24521940
{
    public partial class Bai4 : Form
    {
        private List<SinhVien> danhSachSV = new List<SinhVien>();
        private const string InputFile = "input4.txt";
        private const string OutputFile = "output4.txt";
        private int currentPage = 0; 

        public Bai4()
        {
            InitializeComponent();
            UpdatePageLabel();
        }

        [Serializable]
        public class SinhVien
        {
            public string HoTen { get; set; }
            public int MSSV { get; set; }
            public string DienThoai { get; set; }
            public float DiemMon1 { get; set; }
            public float DiemMon2 { get; set; }
            public float DiemMon3 { get; set; }
            public float DiemTB { get; set; }

            public void TinhDiemTB()
            {
                DiemTB = (DiemMon1 + DiemMon2 + DiemMon3) / 3f;
            }

            public bool KiemTraDuLieu(out string error)
            {
                error = "";

                if (string.IsNullOrWhiteSpace(HoTen))
                    error += "Họ và tên không được để trống." + Environment.NewLine;

                string mssvStr = MSSV.ToString();
                if (MSSV <= 0 || mssvStr.Length != 8 || !Regex.IsMatch(mssvStr, @"^\d{8}$"))
                    error += "MSSV phải là số nguyên dương có đúng 8 chữ số." + Environment.NewLine;

                if (string.IsNullOrWhiteSpace(DienThoai) || !Regex.IsMatch(DienThoai, @"^0\d{9}$"))
                    error += "Số điện thoại phải bắt đầu bằng 0 và có đúng 10 chữ số." + Environment.NewLine;

                if (DiemMon1 < 0 || DiemMon1 > 10)
                    error += "Điểm môn 1 phải từ 0 đến 10." + Environment.NewLine;
                if (DiemMon2 < 0 || DiemMon2 > 10)
                    error += "Điểm môn 2 phải từ 0 đến 10." + Environment.NewLine;
                if (DiemMon3 < 0 || DiemMon3 > 10)
                    error += "Điểm môn 3 phải từ 0 đến 10." + Environment.NewLine;

                return string.IsNullOrEmpty(error);
            }

            public override string ToString()
            {
                return $"Họ tên: {HoTen}" + Environment.NewLine +
                    $"MSSV: {MSSV}" + Environment.NewLine +
                    $"ĐT: {DienThoai}" + Environment.NewLine +
                    $"ĐM1: {DiemMon1}" + Environment.NewLine +
                    $"ĐM2: {DiemMon2}" + Environment.NewLine +
                    $"ĐM3: {DiemMon3}" + Environment.NewLine +
                    $"DTB: {DiemTB:F2}";
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            SinhVien sv = new SinhVien
            {
                HoTen = tb_name_write.Text,
                MSSV = int.TryParse(tb_id_write.Text, out int mssv) ? mssv : -1,
                DienThoai = tb_phone_write.Text,
                DiemMon1 = float.TryParse(tb_score1_write.Text, out float d1) ? d1 : -1,
                DiemMon2 = float.TryParse(tb_score2_write.Text, out float d2) ? d2 : -1,
                DiemMon3 = float.TryParse(tb_score3_write.Text, out float d3) ? d3 : -1
            };

            if (sv.KiemTraDuLieu(out string error))
            {
                danhSachSV.Add(sv);
                MessageBox.Show("Thêm sinh viên thành công!");
                ClearInputs();
                DisplayIndex();
            }
            else
            {
                MessageBox.Show("Lỗi nhập liệu:\n" + error);
            }
        }

        private void btn_Write_Click(object sender, EventArgs e)
        {
            if (danhSachSV.Count == 0)
            {
                MessageBox.Show("Chưa có sinh viên để ghi!");
                return;
            }

            try
            {
                using (FileStream fs = new FileStream(InputFile, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, danhSachSV);
                }
                MessageBox.Show("Ghi file input4.txt thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi file: " + ex.Message);
            }
        }

        private void btn_Read_Click(object sender, EventArgs e)
        {
            try
            {
                List<SinhVien> svList;
                using (FileStream fs = new FileStream(InputFile, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    svList = (List<SinhVien>)formatter.Deserialize(fs);
                }

                foreach (var sv in svList)
                {
                    sv.TinhDiemTB();
                }

                using (FileStream fs = new FileStream(OutputFile, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, svList);
                }

                danhSachSV = svList;
                currentPage = 0; 
                DisplayIndex();
                MessageBox.Show("Đọc, tính DTB và ghi output4.txt thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc/xử lý file: " + ex.Message);
            }
        }

        private void btn_prev_Click(object sender, EventArgs e)
        {
            if (currentPage > 0)
            {
                currentPage--;
                DisplayIndex();
            }
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (currentPage < danhSachSV.Count - 1)
            {
                currentPage++;
                DisplayIndex();
            }
        }

        private void DisplayIndex()
        {

            tb_name_read.Clear();
            tb_id_read.Clear();
            tb_phone_read.Clear();
            tb_score1_read.Clear();
            tb_score2_read.Clear();
            tb_score3_read.Clear();
            tb_avg_read.Clear();

            tb_list.Clear();
            foreach (var sv in danhSachSV)
            {
                tb_list.AppendText(sv.ToString() + Environment.NewLine + Environment.NewLine);
            }

            if (danhSachSV.Count > 0 && currentPage >= 0 && currentPage < danhSachSV.Count)
            {
                var sv = danhSachSV[currentPage];
                tb_name_read.Text = sv.HoTen;
                tb_id_read.Text = sv.MSSV.ToString();
                tb_phone_read.Text = sv.DienThoai;
                tb_score1_read.Text = sv.DiemMon1.ToString();
                tb_score2_read.Text = sv.DiemMon2.ToString();
                tb_score3_read.Text = sv.DiemMon3.ToString();
                tb_avg_read.Text = sv.DiemTB.ToString("F2");
            }

            UpdatePageLabel();
        }

        private void UpdatePageLabel()
        {
            int totalItems = danhSachSV.Count;
            lbl_page.Text = $"{(currentPage + 1)}/{totalItems}";
        }

        private void ClearInputs()
        {
            tb_name_write.Clear();
            tb_id_write.Clear();
            tb_phone_write.Clear();
            tb_score1_write.Clear();
            tb_score2_write.Clear();
            tb_score3_write.Clear();
        }
    }
}