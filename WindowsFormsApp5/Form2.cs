using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form2 : Form 
    {
        public Form2()
        {
            InitializeComponent();
        }
        Connect co = new Connect();
        private void Form2_Load(object sender, EventArgs e)
        {
            co.dbconnect();
            SqlDataAdapter ada = new SqlDataAdapter("Select id from employee",co.con);
            DataSet ds = new DataSet();
            ada.Fill(ds);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.ValueMember = "id";
            bind();
        }
        public void bind()
        {
            dataGridView1.DataSource = co.showdata();
        }      

        private void btninsert_Click(object sender, EventArgs e)
        {
            co._name = txtname.Text;
            co._salary =Convert.ToInt32( txtsalary.Text);
            co._desg = txtdsg.Text;
            int s=co.dbinsert();
            if(s>0)
            {
                MessageBox.Show("Insertion Successful");
                bind();
            }
            else 
            {
                MessageBox.Show("Insertion Failed");
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            co._id = Convert.ToInt32(comboBox1.SelectedValue);
            co._name = txtname.Text;
            co._salary = Convert.ToInt32(txtsalary.Text);
            co._desg = txtdsg.Text;
            int i= co.updatedata();
            if(i>0)
            {
                MessageBox.Show("Update successful");
                bind();
            }
            else
            {
                MessageBox.Show("Update unsuccessful");
            }
            
            
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            co._id = Convert.ToInt32(comboBox1.SelectedValue);
            int y = co.deletedata();
            if (y > 0)
            {
                MessageBox.Show("Deletion successful");
                bind();
            }
            else
            {
                MessageBox.Show(" Deletion unsuccessful");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnretrieve_Click(object sender, EventArgs e)
        {
            SqlDataReader dr;
            co._id = Convert.ToInt32(comboBox1.SelectedValue);
            dr = co.retrievedata();
            while (dr.Read())
            {
                txtname.Text = dr.GetValue(1).ToString();
                txtsalary.Text = dr.GetValue(2).ToString();
                txtdsg.Text = dr.GetValue(3).ToString();

            }
            dr.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnexport_Click(object sender, EventArgs e)
        {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                app.Visible = true;
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Exported from gridview";                                                                
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)   
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++) 
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                workbook.SaveAs("C:\\Users\\91701\\source\\repos\\WindowsFormsApp5\\CSV", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
