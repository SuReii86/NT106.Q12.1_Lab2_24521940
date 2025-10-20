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
    public partial class Bai7 : Form
    {
        public Bai7()
        {
            InitializeComponent();
        }

        private void Bai7_Load(object sender, EventArgs e)
        {
            string[] drives = Directory.GetLogicalDrives();

            foreach (string drive in drives)
            {
                TreeNode driveNode = new TreeNode(drive);
                treeView1.Nodes.Add(driveNode);

                driveNode.Nodes.Add("dummy");
            }
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode selectedNode = e.Node;

            if (selectedNode.Nodes.Count == 1 && selectedNode.Nodes[0].Text == "dummy")
            {
                selectedNode.Nodes.Clear();

                try
                {
                    string[] dirs = Directory.GetDirectories(selectedNode.FullPath);
                    foreach (string dir in dirs)
                    {
                        TreeNode dirNode = new TreeNode(Path.GetFileName(dir));
                        selectedNode.Nodes.Add(dirNode);
                        dirNode.Nodes.Add("dummy");
                    }

                    string[] files = Directory.GetFiles(selectedNode.FullPath);
                    foreach (string file in files)
                    {
                        TreeNode fileNode = new TreeNode(Path.GetFileName(file));
                        selectedNode.Nodes.Add(fileNode);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể truy cập thư mục: " + ex.Message);
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            string fullPath = selectedNode.FullPath;

            pictureBox1.Visible = false;
            richTextBox1.Visible = false;

            if (File.Exists(fullPath))
            {
                string extension = Path.GetExtension(fullPath).ToLower();
                try
                {
                    if (extension == ".jpg" || extension == ".png" || extension == ".bmp" || extension == ".gif")
                    {

                        pictureBox1.Image = Image.FromFile(fullPath);
                        pictureBox1.Visible = true;
                        richTextBox1.Visible = false;
                    }
                    else if (extension == ".txt" || extension == ".rtf")
                    {
                        richTextBox1.Text = File.ReadAllText(fullPath);
                        richTextBox1.Visible = true;
                    }
                    else
                    {
                        richTextBox1.Text = "Không hỗ trợ xem trước cho loại file này.";
                        richTextBox1.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi mở file: " + ex.Message);
                }
            }
        }
    }
}
