using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeAppliance
{
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();
        }

        Operation Op = new Operation();
        string query;
        int ProdId;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ProdId = Op.count();
                query = "insert into ProductTbl values("+ProdId+",'" + ProdNameTb.Text + "','" + BrandCb.SelectedItem.ToString() +
                    "' , '" + CategoryCb.SelectedItem.ToString() + "' , " + ProdQty.Text + "," + PriceTb.Text + ")";
                Op.insertData(query);   
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}
