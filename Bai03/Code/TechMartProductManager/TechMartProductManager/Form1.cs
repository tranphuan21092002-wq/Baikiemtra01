using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechMartProductManager
{
    public partial class Form1 : Form
    {
        private BindingList<ProductModel> products;
        private BindingSource bindingSource;
        private string selectedAvatarPath = "";
        private class CategoryItem
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }
        public Form1()
        {
            InitializeComponent();

            // Tao danh sach san pham
            products = new BindingList<ProductModel>();

            // Tao BindingSource lam trung gian
            bindingSource = new BindingSource();
            bindingSource.DataSource = products;

            // Tao danh muc
            var categories = new BindingList<CategoryItem>();

            categories.Add(new CategoryItem
            {
                Id = "DT",
                Name = "Dien thoai"
            });

            categories.Add(new CategoryItem
            {
                Id = "LT",
                Name = "Laptop"
            });

            categories.Add(new CategoryItem
            {
                Id = "PK",
                Name = "Phu kien"
            });

            // Gan danh muc cho ComboBox
            cboCategory.DataSource = categories;
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember = "Id";
            // Gan du lieu vao DataGridView
            dgvProducts.DataSource = bindingSource;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Kiem tra ten san pham
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                errorProvider1.SetError(txtProductName, "Ten san pham khong duoc de trong!");
                return;
            }

            // Kiem tra don gia
            decimal unitPrice;

            if (!decimal.TryParse(txtUnitPrice.Text, out unitPrice) || unitPrice <= 0)
            {
                errorProvider1.SetError(txtUnitPrice, "Don gia phai lon hon 0!");
                return;
            }

            // Kiem tra so luong
            int quantity;

            if (!int.TryParse(txtQuantity.Text, out quantity) || quantity < 0)
            {
                errorProvider1.SetError(txtQuantity, "So luong phai lon hon hoac bang 0!");
                return;
            }

            // Xoa thong bao loi
            errorProvider1.Clear();

            // Tao san pham moi
            ProductModel product = new ProductModel();

            product.ProductId = txtProductId.Text;
            product.ProductName = txtProductName.Text;
            product.CategoryId = cboCategory.SelectedValue.ToString();
            product.CategoryName = cboCategory.Text;
            product.UnitPrice = unitPrice;
            product.Quantity = quantity;

            // Them vao danh sach
            products.Add(product);

            // Cap nhat so luong san pham tren StatusStrip
            lblStatus.Text = "Tong so san pham: " + products.Count;

            // Thong bao
            MessageBox.Show(
                "Them san pham thanh cong!",
                "Thong bao",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter =
                "Image Files|*.jpg;*.jpeg;*.png;*.bmp|PNG Files|*.png|All Files|*.*";

            openFileDialog.Title = "Chon anh san pham";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedAvatarPath = openFileDialog.FileName;

                if (picAvatar.Image != null)
                {
                    picAvatar.Image.Dispose();
                    picAvatar.Image = null;
                }

                using (Bitmap temp = new Bitmap(openFileDialog.FileName))
                {
                    picAvatar.Image = new Bitmap(temp);
                }

                picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Kiem tra da chon san pham chua
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui long chon san pham can xoa!",
                    "Thong bao",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            // Lay san pham dang duoc chon
            ProductModel product = dgvProducts.CurrentRow.DataBoundItem as ProductModel;

            if (product == null)
            {
                return;
            }

            // Hien hop thoai xac nhan
            DialogResult result = MessageBox.Show(
                "Ban co chac chan muon xoa san pham nay?",
                "Xac nhan xoa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // Neu chon Yes thi xoa
            if (result == DialogResult.Yes)
            {
                products.Remove(product);

                // Cap nhat so luong san pham
                lblStatus.Text = "Tong so san pham: " + products.Count;
            }
        }
    }
}
