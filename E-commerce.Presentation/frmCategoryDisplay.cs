using Application.Dtos;
using Application.Services;
using Applications.DTOs;
using Autofac;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_commerce.Presentation
{

    public partial class frmCategoryDisplay : Form
    {
        private readonly ICategoryService _categoryService;
        private List<CategoryDTO> _categories;
        private readonly IAdminService _adminService;
        private bool ValidateCategoryInput()
        {
            if (string.IsNullOrEmpty(txtCateName.Text))
            {
                MessageBox.Show("Enter valid name", "In valid Category name.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCateName.Select();
                return false;
            }
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show("Enter valid name", "In valid Category description.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Select();
                return false;
            }
            return true;
        }
        private void LoadCategories()
        {
            _categories = _categoryService.GetAllCategories();
            dgvCategories.DataSource = _categories;
        }


        public frmCategoryDisplay()
        {
            InitializeComponent();
            var container = AutofacConfig.Configure();
            _categoryService = container.Resolve<ICategoryService>();
            _adminService = container.Resolve<IAdminService>();
        }



        private void frmCategoryDisplay_Load(object sender, EventArgs e)
        {
            LoadCategories();

            dgvCategories.EnableHeadersVisualStyles = false;
            dgvCategories.BackgroundColor = Color.White;
            dgvCategories.ColumnHeadersDefaultCellStyle.BackColor = Color.BlueViolet;
            dgvCategories.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCategories.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dgvCategories.Dock = DockStyle.Fill;
            dgvCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategories.Columns[0].Visible = false;
            dgvCategories.DefaultCellStyle.BackColor= Color.White;
            dgvCategories.DefaultCellStyle.ForeColor= Color.Black;
        }


        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                lblID.Text = dgvCategories.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtCateName.Text = dgvCategories.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                txtDescription.Text = dgvCategories.Rows[e.RowIndex].Cells["Description"].Value.ToString();
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateCategoryInput())
                {
                    //_categoryService.CreateCategory(new Category { Name = txtCateName.Text, Description = txtDescription.Text });
                    _adminService.AddCategory(new CategoryDTO { Name = txtCateName.Text, Description = txtDescription.Text });

                    MessageBox.Show($"{txtCateName.Text} added successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCategories();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateCategoryInput())
                {
                    DialogResult confirmingUpdate = MessageBox.Show($"Are you sure you want to update {txtCateName.Text}?", "Updating Category", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirmingUpdate == DialogResult.Yes)
                    {
                        //_categoryService.UpdateCategory(new Category { CategoryID = int.Parse(lblID.Text), Name = txtCateName.Text, Description = txtDescription.Text });
                        _adminService.UpdateCategory(new CategoryDTO { CategoryID = int.Parse(lblID.Text), Name = txtCateName.Text, Description = txtDescription.Text });

                        MessageBox.Show($"{txtCateName.Text} Updated successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCategories();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(lblID.Text, out int id))
                {
                    DialogResult confirmingDeletion = MessageBox.Show($"Are you sure you want to delete {txtCateName.Text}?", "Deleting Category", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirmingDeletion == DialogResult.Yes)
                    {
                        //_categoryService.DeleteCategory(int.Parse(lblID.Text));
                        _adminService.DeleteCategory(int.Parse(lblID.Text));
                        MessageBox.Show($"{txtCateName.Text} Deleted successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCategories();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                lblID.Text = dgvCategories.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtCateName.Text = dgvCategories.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                txtDescription.Text = dgvCategories.Rows[e.RowIndex].Cells["Description"].Value.ToString();
            }
        }

        
    }
}
