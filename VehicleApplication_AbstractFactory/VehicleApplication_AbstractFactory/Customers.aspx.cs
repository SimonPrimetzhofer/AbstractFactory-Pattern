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

        //id of the default customer
        public static readonly int DefaultCustomer = 8;

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
            }
            catch (Exception) {
                CustomerMessageLabel.Text = "Income must be a number with 2 decimal digits!";
                return;
            }

            if (c.Income < 0) {
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

        protected void VehicleDB_Customers_Deleted(object sender, SqlDataSourceStatusEventArgs e) {

            //The default customer must not be deleted!
            if ((int)e.Command.Parameters["@ID"].Value == DefaultCustomer) {
                CustomerMessageLabel.Text = "Dieser User darf nicht gelöscht werden!";
                e.ExceptionHandled = true;
                return;
            }

            //Check if exception occured
            if (e.Exception != null) {

                //Get id to set all occurences of the customer to the 'No owner specified' customer
                int id = (int)e.Command.Parameters["@ID"].Value;

                //Get Owner from database
                DataTable dt = new DataTable();

                try {

                    con.Open();

                    //Get all vehicles where the customer which gets deleted is the owner
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM dbo.Vehicle where Owner = @customerID", con);
                    adapter.SelectCommand.Parameters.AddWithValue("@customerID", id);

                    adapter.Fill(dt);

                    //Set owner to default customer
                    foreach (DataRow row in dt.Rows) {
                        row["Owner"] = DefaultCustomer;
                    }

                    new SqlCommandBuilder(adapter);

                    //Update Table
                    adapter.Update(dt);

                    con.Close();

                }
                catch (Exception) {

                }

                //Refresh grid
                customersGrid.DataBind();

                //Retry command after removing vehicles from customer
                try {
                    e.Command.ExecuteNonQuery();
                }catch(Exception) {
                    CustomerMessageLabel.Text = "This customer can't be deleted since he " +
                        "owns vehicles or has sold one in the past!";
                }

                //Now the exception is handled
                e.ExceptionHandled = true;
            }

        }
    }
}