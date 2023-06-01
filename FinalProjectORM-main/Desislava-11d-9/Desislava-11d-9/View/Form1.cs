using Desislava_11d_9.Controller;
using Desislava_11d_9.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Desislava_11d_9.View
{
    public partial class Form1 : Form
    {
        VegetableLogic vegController = new VegetableLogic();
        TypeLogic typeController = new TypeLogic();
        public Form1()
        {
            InitializeComponent();
        }
        private void LoadRecord(Vegetable veg)
        {
            txtId.Text = veg.Id.ToString();
            txtNumber.Text = veg.Number.ToString();
            txtName.Text = veg.Name;
            txtPrice.Text = veg.Price.ToString();
            cmbType.Text = typeController.GetTypeById(int.Parse(txtId.Text));
            listBoxDiscription.Items.Add( veg.Description.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<VegetableType> allTypes = typeController.GetAllTypes();
            cmbType.DataSource = allTypes;
            cmbType.DisplayMember = "Type";
            cmbType.ValueMember = "Id";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text) || txtName.Text == "")
            {
                MessageBox.Show("Въведете данни!");
                txtId.Focus();
                txtId.BackColor = Color.Red;
                return;
            }
            txtId.BackColor = Color.White;
            Vegetable newVeg = new Vegetable();
            newVeg.Id=int.Parse(txtId.Text);
            newVeg.Number = int.Parse(txtNumber.Text);
            newVeg.Price = int.Parse(txtPrice.Text);
            newVeg.Name = txtName.Text;
            newVeg.TypeId = (int)cmbType.SelectedValue;
            newVeg.Description = listBoxDiscription.Text;

            vegController.Create(newVeg);
            MessageBox.Show("Добавен!");
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            List<Vegetable> allVeg = vegController.GetAll();
            listBoxAll.Items.Clear();
            foreach (var item in allVeg)
            {
                listBoxAll.Items.Add($"{item.Id}. {item.Number}- {item.Name}- {item.Price} $");
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Въведи ид!");
                txtId.BackColor = Color.Red;
                txtId.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txtId.Text);

            }
            Vegetable findVeg = vegController.Get(findId);
            if (findVeg == null)
            {
                MessageBox.Show("Не е намерено такоша ид.");
                txtId.BackColor = Color.Red;
                txtId.Focus();
                return;
            }
            txtId.BackColor = Color.White;
            LoadRecord(findVeg);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int findId;
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Въведете ид!!!");
                return;
            }
            else
            {
                findId = int.Parse(txtId.Text);

            }
            Vegetable findVeg = vegController.Get(findId);
            if (findVeg == null)
            {
                MessageBox.Show("Не е намерено такова ид!");
                txtId.BackColor = Color.Red;
                return;
            }
            else
            {
                txtId.BackColor = Color.White;
                findVeg.Id = int.Parse(txtId.Text);
                findVeg.Name = txtName.Text;
                findVeg.Number = int.Parse(txtNumber.Text);
                findVeg.Price = int.Parse(txtPrice.Text);
                findVeg.Description = listBoxDiscription.Items.ToString();
                MessageBox.Show("Всичко е готово!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Въведи ид!");
                txtId.BackColor = Color.Red;
                txtId.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txtId.Text);
                txtId.BackColor = Color.White;
            }
            Vegetable findVeg = vegController.Get(findId);
            if (findVeg == null)
            {
                MessageBox.Show("Не е намерено такова ид!");
                txtId.BackColor = Color.Red;
                return;
            }
            else
            {
                DialogResult answear = MessageBox.Show("Искате ли да изтриете записа?", "Question", MessageBoxButtons.YesNo);
                if (answear == DialogResult.Yes)
                {
                    vegController.Delete(findId);
                    MessageBox.Show("Успешно изтрихте записа.");
                }
                else
                {
                    return;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNumber.Clear();
            txtName.Clear();
            txtPrice.Clear();
            txtId.Clear();
            cmbType.Text = "";
            listBoxDiscription.Items.Clear();   
            listBoxAll.Items.Clear();   
        }
    }
}
