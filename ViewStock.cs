using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace HomeAppliance
{
    public partial class ViewStock : Form
    {
        public ViewStock()
        {
            InitializeComponent();
        }

        Operation Op = new Operation();
        string myQuery;
        private void GetProduct()
        {
            myQuery = "select * from ProductTbl";
            var ds = Op.populate(myQuery);
            Console.WriteLine(ds.Tables);
            ProductDGV.DataSource = ds.Tables[0];
        }


        private void ViewStock_Load(object sender, EventArgs e)
        {
            GetProduct();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                myQuery = "Delete from ProductTbl where ID=" + ProdIdTb.Text + ";";
                Op.deleteProd(myQuery);
                GetProduct();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void ProductDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ProdIdTb.Text = ProductDGV.SelectedRows[0].Cells[0].Value.ToString();
            ProdNameTb.Text = ProductDGV.SelectedRows[0].Cells[1].Value.ToString();
            ProdBrandCb.SelectedItem = ProductDGV.SelectedRows[0].Cells[2].Value.ToString();
            ProdCatCb.SelectedItem = ProductDGV.SelectedRows[0].Cells[3].Value.ToString();
            ProdQtyTb.Text = ProductDGV.SelectedRows[0].Cells[4].Value.ToString();
            ProdPriceTb.Text = ProductDGV.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void clear()
        {
            ProdIdTb.Text = "";
            ProdNameTb.Text = "";
            ProdCatCb.SelectedIndex = -1;
            ProdBrandCb.SelectedIndex = -1;
            ProdQtyTb.Text = "";
            ProdPriceTb.Text = ""; 
        }


        private void button4_Click(object sender, EventArgs e)
        {
            clear();
            
        }

        private void ProdIdTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                myQuery = "Update ProductTbl set ProdName=':"+ProdNameTb.Text+"', ProdBrand= '" + ProdBrandCb.SelectedItem.ToString()+"', ProdCat='"+ProdCatCb.SelectedItem.ToString()+"', ProdQty=" + ProdQtyTb.Text+", prodPrice ="+ProdPriceTb.Text+" whare ID="+ProdIdTb.Text+";";
                Op.EditData(myQuery);
                GetProduct();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}
