﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdonetDemo
{
    public partial class Form1 : Form
    {
        ProductDal _productDal = new ProductDal();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            dgvProducts.DataSource = _productDal.GetAll();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product
            {
                Name= tbxName.Text,
            UnitPrice= Convert.ToDecimal(tbxUnitPrice.Text),
            StockAmount= Convert.ToInt32(tbxStockAmount.Text)

            });
            LoadProducts();
            MessageBox.Show("product added");

        }

       

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxNameUpdate.Text= dgvProducts.CurrentRow.Cells[1].Value.ToString();
            tbxUnitPriceUpdate.Text= dgvProducts.CurrentRow.Cells[2].Value.ToString();
            tbxStockAmountUpdate.Text = dgvProducts.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Product product = new Product
            {
                Id = Convert.ToInt32(dgvProducts.CurrentRow.Cells[0].Value),
                Name = tbxNameUpdate.Text,
                UnitPrice= Convert.ToDecimal( tbxUnitPriceUpdate.Text),
                StockAmount= Convert.ToInt32( tbxStockAmountUpdate.Text)
        };
            _productDal.Update(product);
            LoadProducts();
            MessageBox.Show("updated");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvProducts.CurrentRow.Cells[0].Value);
            _productDal.Delete(id);
            LoadProducts();
            MessageBox.Show("Deleted");
        }
    }
}
