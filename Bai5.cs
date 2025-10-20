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
    public partial class Bai5 : Form
    {
        private List<Movie> movieList = new List<Movie>();
        private List<Order> orders = new List<Order>();
        private Dictionary<string, List<string>> soldTickets = new Dictionary<string, List<string>>();
        private int currentOrderIndex = -1;
        private string file_in = "input5.txt";
        private string file_out = "output5.txt";

        public Bai5()
        {
            InitializeComponent();
        }

        public class Movie
        {
            public string Name { get; set; }
            public int Price { get; set; }
            public List<int> Rooms { get; set; } = new List<int>();
            public int RequestedTickets { get; set; }
            public int SoldTickets { get; set; } = 0;
            public int TotalSeats => Rooms.Count * 15; 
        }

        public class Order
        {
            public string CustomerName { get; set; }
            public string MovieName { get; set; }
            public string RoomNumber { get; set; }
            public int TicketCount { get; set; }
            public List<string> Seats { get; set; } = new List<string>();
            public int TotalPrice { get; set; }
        }


        private void btn_Read_Click(object sender, EventArgs e)
        {
            if (!File.Exists(file_in))
            {
                MessageBox.Show($"File {file_in} không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string[] lines = File.ReadAllLines(file_in);
                if (lines.Length % 5 != 0)
                {
                    MessageBox.Show("File input5.txt có định dạng không đúng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                movieList.Clear();
                orders.Clear();
                soldTickets.Clear();
                currentOrderIndex = -1;

                for (int i = 0; i < lines.Length; i += 5)
                {
                    if (i + 4 < lines.Length)
                    {
                        string customerName = lines[i].Trim();
                        string movieName = lines[i + 1].Trim();
                        if (!int.TryParse(lines[i + 2], out int roomNumber))
                        {
                            MessageBox.Show($"Phòng chiếu cho phim '{movieName}' không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }
                        if (!int.TryParse(lines[i + 3], out int ticketCount) || ticketCount > 2 || ticketCount < 1)
                        {
                            MessageBox.Show($"Số vé yêu cầu cho phim '{movieName}' không hợp lệ (phải từ 1 đến 2).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }
                        string[] seats = lines[i + 4].Split(',').Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s)).ToArray();
                        if (seats.Length != ticketCount)
                        {
                            MessageBox.Show($"Số ghế cho phim '{movieName}' không khớp với số vé yêu cầu ({ticketCount}).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }
                        List<string> seatList = seats.Where(s => IsValidSeat(s)).ToList();
                        if (seatList.Count != ticketCount)
                        {
                            MessageBox.Show($"Ghế cho phim '{movieName}' không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }

                        Movie movie = movieList.FirstOrDefault(m => m.Name == movieName);
                        if (movie == null)
                        {
                            movie = new Movie
                            {
                                Name = movieName,
                                Price = GetDefaultPrice(movieName),
                                Rooms = new List<int> { roomNumber },
                                RequestedTickets = ticketCount
                            };
                            movieList.Add(movie);
                        }
                        else
                        {
                            if (!movie.Rooms.Contains(roomNumber))
                                movie.Rooms.Add(roomNumber);
                        }

                        Order order = new Order
                        {
                            CustomerName = customerName,
                            MovieName = movieName,
                            RoomNumber = roomNumber.ToString(),
                            TicketCount = ticketCount,
                            Seats = seatList,
                            TotalPrice = CalculateTotalPrice(movie, seatList)
                        };
                        orders.Add(order);

                        movie.SoldTickets += ticketCount;
                        if (!soldTickets.ContainsKey(movieName))
                            soldTickets[movieName] = new List<string>();
                        soldTickets[movieName].AddRange(seatList);
                    }
                }

                if (orders.Count > 0)
                {
                    currentOrderIndex = 0;
                    DisplayOrder(currentOrderIndex);
                    btn_Prev.Enabled = currentOrderIndex > 0;
                    btn_Aft.Enabled = currentOrderIndex < orders.Count - 1;
                }
                else
                {
                    MessageBox.Show("Không có đơn hàng hợp lệ nào trong file!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đọc file input5.txt: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidSeat(string seat)
        {
            string[] validSeats = { "A1", "A2", "A3", "A4", "A5", "B1", "B2", "B3", "B4", "B5", "C1", "C2", "C3", "C4", "C5" };
            return validSeats.Contains(seat);
        }

        private int GetDefaultPrice(string movieName)
        {

            Dictionary<string, int> defaultPrices = new Dictionary<string, int>
            {
                { "Đào, phở và piano", 45000 },
                { "Mai", 100000 },
                { "Gặp lại chị bầu", 70000 },
                { "Tarot", 90000 }
            };
            return defaultPrices[movieName];
        }

        private int CalculateTotalPrice(Movie movie, List<string> seats)
        {
            int totalPrice = 0;
            foreach (string seat in seats)
            {
                int seatPrice = movie.Price;
                switch (seat)
                {
                    case "B2":
                    case "B3":
                    case "B4":
                        seatPrice *= 2;
                        break;
                    case "A1":
                    case "A5":
                    case "C1":
                    case "C5":
                        seatPrice /= 4;
                        break;
                }
                totalPrice += seatPrice;
            }
            return totalPrice;
        }

        private void DisplayOrder(int index)
        {
            if (index < 0 || index >= orders.Count) return;

            Order order = orders[index];
            tb_Name.Text = order.CustomerName;
            tb_Movie.Text = order.MovieName;
            tb_Rooms.Text = order.RoomNumber;
            tb_Ticket_num.Text = order.TicketCount.ToString();

            foreach (Control control in this.Controls)
            {
                if (control is CheckBox cb && cb.Name.StartsWith("cb_seat_"))
                {
                    cb.Checked = false;
                }
            }

            foreach (string seat in order.Seats)
            {
                string cbName = "cb_seat_" + seat;
                Control[] controls = this.Controls.Find(cbName, true);
                if (controls.Length > 0 && controls[0] is CheckBox cb)
                {
                    cb.Checked = true;
                }
            }

            btn_Prev.Enabled = index > 0;
            btn_Aft.Enabled = index < orders.Count - 1;
        }

        private void btn_Prev_Click(object sender, EventArgs e)
        {
            if (currentOrderIndex > 0)
            {
                currentOrderIndex--;
                DisplayOrder(currentOrderIndex);
            }
        }

        private void btn_Aft_Click(object sender, EventArgs e)
        {
            if (currentOrderIndex < orders.Count - 1)
            {
                currentOrderIndex++;
                DisplayOrder(currentOrderIndex);
            }
        }

        private void btn_Write_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Value = 0;

            try
            {
                StringBuilder output = new StringBuilder();
                var sortedMovies = movieList.OrderByDescending(m =>
                    soldTickets.ContainsKey(m.Name) ? soldTickets[m.Name].Sum(seat => CalculateSeatPrice(m, seat)) : 0).ToList();
                int totalSteps = sortedMovies.Count + 1;
                int step = 0;

                output.AppendLine("Thống Kê Phòng Vé:");
                output.AppendLine("--------------------------------------------------");
                foreach (var movie in sortedMovies)
                {
                    int sold = movie.SoldTickets;
                    int totalSeats = movie.TotalSeats;
                    int remaining = totalSeats - sold;
                    double sellRatio = totalSeats > 0 ? (double)sold / totalSeats * 100 : 0;
                    int revenue = 0;

                    if (soldTickets.ContainsKey(movie.Name))
                    {
                        revenue = soldTickets[movie.Name].Sum(seat => CalculateSeatPrice(movie, seat));
                    }

                    int rank = sortedMovies.IndexOf(movie) + 1;
                    output.AppendLine($"Phim: {movie.Name}");
                    output.AppendLine($"Số vé bán ra: {sold}");
                    output.AppendLine($"Số vé tồn: {remaining}");
                    output.AppendLine($"Tỉ lệ vé bán ra: {sellRatio:F2}%");
                    output.AppendLine($"Doanh thu: {revenue}");
                    output.AppendLine($"Xếp hạng doanh thu: {rank}");
                    output.AppendLine("--------------------------------------------------");

                    step++;
                    progressBar1.Value = (step * 100) / totalSteps;
                    Application.DoEvents();
                }

                File.WriteAllText(file_out, output.ToString());
                step++;
                progressBar1.Value = (step * 100) / totalSteps;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi ghi file output5.txt: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                progressBar1.Visible = true;
            }
                using (StreamReader sr = new StreamReader(file_out))
            {
                tb_output.Text = sr.ReadToEnd();
            }    
        }

        private int CalculateSeatPrice(Movie movie, string seat)
        {
            int seatPrice = movie.Price;
            switch (seat)
            {
                case "B2":
                case "B3":
                case "B4":
                    seatPrice *= 2;
                    break;
                case "A1":
                case "A5":
                case "C1":
                case "C5":
                    seatPrice /= 4;
                    break;
            }
            return seatPrice;
        }
    }
}