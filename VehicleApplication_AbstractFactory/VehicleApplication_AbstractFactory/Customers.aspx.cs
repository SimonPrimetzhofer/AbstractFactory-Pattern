using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VehicleApplication_AbstractFactory.AbstractFactory;
using System.Data.SqlClient;
using System.Data;

namespace VehicleApplication_AbstractFactory {
    public partial class Customers : System.Web.UI.Page {

        AbstractCustomerFactory acf = FactoryProducer.GetCustomerFactory();

        SqlConnection con;

        protected void Page_Init(object sender, EventArgs e) {

            con = new SqlConnection(VehicleDB_Customers.ConnectionString);

            VehicleDB_Customers.DeleteCommand = "Delete from dbo.Customer where ID=@ID";

            //Replace ',' by '.' in conversion to fit decimal
            VehicleDB_Customers.UpdateCommand = "UPDATE dbo.Customer SET FirstName=@FirstName, LastName=@LastName, " +
                "Income=CONVERT(DECIMAL(10,2),replace(@Income,',','.')) WHERE ID=@ID";

        }

        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void customerSubmitButton_Click(object sender, EventArgs e) {
            Customer c = acf.GetCustomer(customerType.SelectedValue);

            c.CustomerType = customerType.SelectedValue;
            c.FirstName = customerFirstname.Text;
            c.LastName = customerLastname.Text;

            try {
                c.Income = double.Parse(customerIncome.Text);
            }catch(Exception) {
                CustomerMessageLabel.Text = "Income must be a number with 2 decimal digits!";
                return;
            }

            if(c.Income < 0) {
                CustomerMessageLabel.Text = "Income must be greater or equal to zero!";
                return;
            }

            InsertCustomer(c);

        }

        private void InsertCustomer(Customer toInsert) {
            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM dbo.Customer where 0 = 1", con);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            DataRow dr = dt.NewRow();

            dr["CustomerType"] = toInsert.CustomerType;
            dr["FirstName"] = toInsert.FirstName;
            dr["LastName"] = toInsert.LastName;
            dr["Income"] = toInsert.Income;

            dt.Rows.Add(dr);

            new SqlCommandBuilder(adapter);

            adapter.Update(dt);

            con.Close();

            customersGrid.DataBind();

            ClearForm();

            SetCustomerMessageLabel(toInsert);
        }

        private void SetCustomerMessageLabel(Customer c) {
            CustomerMessageLabel.Text = string.Format("Kunde: {0} {1} {2} - Einkommen: {3}", c.CustomerType, c.FirstName, c.LastName, c.Income);
        }

        private void ClearForm() {
            customerFirstname.Enabled = true;
            customerType.SelectedIndex = 0;
            customerFirstname.Text = "";
            customerLastname.Text = "";
            customerIncome.Text = "";
        }

        protected void customerClearButton_Click(object sender, EventArgs e) => ClearForm();

        protected void customerType_SelectedIndexChanged(object sender, EventArgs e) {
            if (customerType.SelectedIndex == 1) {
                customerFirstname.Enabled = false;
            }
            else if (customerType.SelectedIndex == 0)
                customerFirstname.Enabled = true;
        }
    }
}