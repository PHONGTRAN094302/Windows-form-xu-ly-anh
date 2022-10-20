using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
namespace WindowsFormsApp_XULYANH
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Modify Modify = new Modify();
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Modify.DataTable("Select * from NhanVien");
            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)dataGridView1.Columns[1];
            pic.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }
        private void bt_anh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = ("Chọn Ảnh");
            openFileDialog.Filter = "Image Files(*.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png;*.jfif)|*.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png;*.jfif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog.FileName;
            }
        }
        NhanVien nhanVien;
        private void Getvalues()
        {
            string manv = textBox1.Text;
            byte[] anh = ImageToByteArray(pictureBox1);
            nhanVien = new NhanVien(manv, anh);
        }
        private byte[] ImageToByteArray(PictureBox pictureBox)
        {
            MemoryStream memoryStream = new MemoryStream();
            pictureBox.Image.Save(memoryStream, pictureBox.Image.RawFormat);
            return memoryStream.ToArray();
        }
        private void bt_them_Click(object sender, EventArgs e)
        {
            string query = "Insert into NhanVien values (@MaNV,@Anh)";
            try
            {
                Getvalues();
                Modify.command(nhanVien, query);
                MessageBox.Show("Thêm thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm:" + ex.Message);
            }
        }
        private void bt_sua_Click(object sender, EventArgs e)
        {
            string query = "Update NhanVien set Anh = @Anh where MaNV = @MaNV";
            try
            {
                Getvalues();
                Modify.command(nhanVien, query);
                MessageBox.Show("Sửa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm:" + ex.Message);
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            if(dataGridView1.SelectedRows[0].Cells[1].Value.ToString()!="")
            {
                MemoryStream memoryStream = new MemoryStream((byte[])dataGridView1.SelectedRows[0].Cells[1].Value);
                pictureBox1.Image = Image.FromStream(memoryStream);
            }
            else
            {
                pictureBox1.Image = null;
            }
        }
        private void bt_xoa_Click(object sender, EventArgs e)
        {
            string query = "Delete from NhanVien where @MaNV = @Anh";
            try
            {
                Getvalues();
                Modify.command(nhanVien, query);
                MessageBox.Show("Xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm:" + ex.Message);
            }
        }
    }
}
