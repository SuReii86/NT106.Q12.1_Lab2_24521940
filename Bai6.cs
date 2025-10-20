using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NT106.Q12._1_Lab2_24521940
{
    public partial class Bai6 : Form
    {
        public Bai6()
        {
            InitializeComponent();
            ptb_MONAN.SizeMode = PictureBoxSizeMode.Zoom;
            using (var connection = new SQLiteConnection("Data Source=Lab2.db"))
            {
                try
                {
                    connection.Open();
                    using (var pragmaCommand = new SQLiteCommand("PRAGMA foreign_keys = ON;", connection))
                    {
                        pragmaCommand.ExecuteNonQuery();
                    }

                    string createNguoiDung = @"
                            CREATE TABLE IF NOT EXISTS NGUOIDUNG
                            (
                                IDNCC TEXT PRIMARY KEY,
                                HoVaTen TEXT NOT NULL,
                                QuyenHan TEXT
                            );";

                    string createMonAn = @"
                                CREATE TABLE IF NOT EXISTS MONAN
                                (
                                    IDMONAN INTEGER PRIMARY KEY,
                                    TenMonAn TEXT NOT NULL,
                                    HinhAnh TEXT,
                                    IDNCC TEXT,
                                    FOREIGN KEY(IDNCC) REFERENCES NGUOIDUNG(IDNCC)
                                );";

                    using (var cmd = new SQLiteCommand(createNguoiDung, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    using (var cmd = new SQLiteCommand(createMonAn, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    string command_ins_tb = @"
                                        INSERT INTO NGUOIDUNG (IDNCC, HoVaTen, QuyenHan)
                                        VALUES ('ND1', 'Phan Le Tuan', 'Admin'),
                                               ('ND2', 'Nguyen Van A', 'Guest'),
                                               ('ND3', 'Tran Van B', 'Guest'),
                                               ('ND4', 'Pham Thi C', 'Guest');
                                        INSERT INTO MONAN (TenMonAn, HinhAnh, IDNCC)
                                        VALUES ('Pho Ga', 'images/phoga.jpg' , 'ND1'),
                                        ('Com Chien', 'images/com.jpg' , 'ND1'),
                                        ('Bun Bo', 'images/bunbo.jpg' , 'ND2'),
                                        ('Hu Tieu', 'images/hutieu.jpg' , 'ND3'),
                                        ('Banh Canh','images/banhcanh.jpg' , 'ND4');
                                        ";
                    using (var ins_command = new SQLiteCommand(command_ins_tb, connection))
                    {
                        ins_command.ExecuteNonQuery();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi CSDL: " + ex.Message);
                }
                Add_Items_Panel(Lp_Table);
            }
        }

        private void Add_Header_Panel(TableLayoutPanel table)
        {
            var bold = new Font(table.Font, FontStyle.Bold);
            table.Controls.Add(new Label { Text = "ID Món Ăn", Font = bold, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter }, 0, 0);
            table.Controls.Add(new Label { Text = "Tên Món Ăn", Font = bold, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter }, 1, 0);
            table.Controls.Add(new Label { Text = "ID Người Cung Cấp", Font = bold, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter }, 2, 0);
            table.Controls.Add(new Label { Text = "Quyền Hạn", Font = bold, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter }, 3, 0);
        }

        private void Add_Items_Panel(TableLayoutPanel table)
        {
            table.Controls.Clear();              
            Add_Header_Panel(table);           

            using (var cn = new SQLiteConnection("Data Source=Lab2.db"))
            {
                cn.Open();
                const string sql = @"
                    SELECT MA.IDMONAN, MA.TenMonAn, ND.IDNCC, ND.QuyenHan
                    FROM MONAN MA
                    JOIN NGUOIDUNG ND ON MA.IDNCC = ND.IDNCC
                    ORDER BY MA.IDMONAN;";

                using (var cmd = new SQLiteCommand(sql, cn))
                using (var rdr = cmd.ExecuteReader())
                {
                    int row = 1;
                    while (rdr.Read())
                    {
                        table.Controls.Add(new Label { Text = rdr["IDMONAN"].ToString(), Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter }, 0, row);
                        table.Controls.Add(new Label { Text = rdr["TenMonAn"].ToString(), Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter }, 1, row);
                        table.Controls.Add(new Label { Text = rdr["IDNCC"].ToString(), Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter }, 2, row);
                        table.Controls.Add(new Label { Text = rdr["QuyenHan"].ToString(), Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter }, 3, row);
                        row++;
                    }
                    int totalRows = row; 
                    table.RowCount = totalRows;
                    table.RowStyles.Clear();
                    for (int i = 0; i < totalRows; i++)
                    {
                        table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    }
                }
            }

            
        }
        private void btn_RAND_Click(object sender, EventArgs e)
        {
            rtb_RESULT.Clear();


            if (ptb_MONAN.Image != null)
            {
                ptb_MONAN.Image.Dispose();
                ptb_MONAN.Image = null;
            }

            try
            {
                using (var connection = new SQLiteConnection("Data Source=Lab2.db"))
                {
                    connection.Open();
                    using (var command_count_row = new SQLiteCommand("SELECT COUNT(*) FROM MONAN;", connection))
                    {
                        string query = @"
                                    SELECT TenMonAn, HinhAnh, HoVaTen, QuyenHan
                                    FROM MONAN
                                    INNER JOIN NGUOIDUNG ON MONAN.IDNCC = NGUOIDUNG.IDNCC
                                    ORDER BY RANDOM()
                                    LIMIT 1;"; 

                        using (var command_get_MONAN = new SQLiteCommand(query, connection))
                        {
                            using (SQLiteDataReader reader = command_get_MONAN.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string Name_MonAn = "Tên Món Ăn: " + reader["TenMonAn"].ToString();
                                    string path_HinhAnh = reader["HinhAnh"].ToString();
                                    string Name_NCC = "Người Cung Cấp: " + reader["HoVaTen"].ToString();
                                    string Level = "Quyền Hạn: " + reader["QuyenHan"].ToString();

                                    try
                                    {                                        
                                        using (var fs = new System.IO.FileStream(path_HinhAnh, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                                        using (var ms = new System.IO.MemoryStream())
                                        {
                                            fs.CopyTo(ms);
                                            ptb_MONAN.Image = Image.FromStream(ms);
                                        }
                                    }
                                    catch (FileNotFoundException)
                                    {
                                        rtb_RESULT.AppendText("LỖI FILE: Không tìm thấy file ảnh: " + path_HinhAnh + Environment.NewLine);
                                        ptb_MONAN.Image = null;
                                    }
                                    catch (OutOfMemoryException ex)
                                    {
                                        rtb_RESULT.AppendText("LỖI BỘ NHỚ: Ảnh quá lớn hoặc bộ nhớ hệ thống đầy. Chi tiết: " + ex.Message);
                                        ptb_MONAN.Image = null;
                                    }
                                    rtb_RESULT.AppendText(Name_MonAn + Environment.NewLine);
                                    rtb_RESULT.AppendText(Name_NCC + Environment.NewLine);
                                    rtb_RESULT.AppendText(Level);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi chung: " + ex.Message);
            }
        }

        private void btn_RESET_Click(object sender, EventArgs e)
        {
            rtb_RESULT.Clear();
            if (ptb_MONAN.Image != null)
            {
                ptb_MONAN.Image.Dispose();
                ptb_MONAN.Image = null;
            }
            Add_Items_Panel(Lp_Table); 
        }

        private void btn_EXIT_Click(object sender, EventArgs e)
        {
            using (var connection = new SQLiteConnection("Data Source=Lab2.db"))
            {
                connection.Open();
                string Drop_tb_MA = "DROP TABLE IF EXISTS MONAN";
                string Drop_tb_ND = "DROP TABLE IF EXISTS NGUOIDUNG";

                using (var cmd = new SQLiteCommand(Drop_tb_MA, connection))
                {
                    cmd.ExecuteNonQuery();
                }
                using (var cmd = new SQLiteCommand(Drop_tb_ND, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            this.Close();
        }
    }
}
