using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VehicleApplication_AbstractFactory.AbstractFactory;
using VehicleApplication_AbstractFactory.Model;

namespace VehicleApplication_AbstractFactory {
    public partial class _Default : Page {

        AbstractVehicleFactory avf = FactoryProducer.GetVehicleFactory();
        AbstractCustomerFactory acf = FactoryProducer.GetCustomerFactory();
        SqlConnection con;

        protected void Page_Load(object sender, EventArgs e) {

            con = new SqlConnection(VehicleDB.ConnectionString);

            VehicleDB.DeleteCommand = "DELETE FROM dbo.Vehicle where ID = @ID";

            //VehicleDB.UpdateCommand = "UPDATE dbo.Vehicle SET Type=@Type,B=@LastName,Title=@Title WHERE EmployeeID=@EmployeeID";

            con.Open();

            DataTable dt = new DataTable();

            try {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Customer", con);                

                adapter.Fill(dt);

                ownerDropdown.DataSource = dt;
                ownerDropdown.DataTextField = "LastName";
                ownerDropdown.DataValueField = "ID";
                ownerDropdown.DataBind();

                con.Close();

            }
            catch (Exception) {

            }

        }

        protected void vehicleGrid_RowDataBound(object sender, GridViewRowEventArgs e) {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            if (e.Row.RowType == DataControlRowType.DataRow) {
                bool val = Convert.ToBoolean(drv["Preowned"]);

                e.Row.Cells[6].Text = (val ? "Yes" : "No");
            }

        }

        protected void submitButton_Click(object sender, EventArgs e) {
            Vehicle v = avf.GetVehicle(vehicleType.SelectedValue);

            v.Type = vehicleType.Text;
            v.Brand = vehicleBrand.Text;
            v.Model = vehicleModel.Text;

            v.Kilowatt = int.Parse(vehicleKw.Text);
            v.Seats = int.Parse(vehicleSeats.Text);
            v.Preowned = vehiclePreowned.Checked;

            //Get Owner from database
            DataTable dt = new DataTable();

            Customer c = null;

            try {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM dbo.Customer where ID = @customerID", con);
                adapter.SelectCommand.Parameters.AddWithValue("@customerID", ownerDropdown.SelectedValue);

                adapter.Fill(dt);

                DataRow dr = dt.Rows[0];

                //Entry found
                if (dr != null) {
                    //Company --> has no firstname
                    if (dr["LastName"].ToString().Length > 0 && dr["FirstName"].ToString().Length == 0) {
                        c = (Company)acf.GetCustomer("Firma");
                    }
                    else if (dr["LastName"].ToString().Length > 0 && dr["FirstName"].ToString().Length > 0) {
                        c = (PrivateCustomer)acf.GetCustomer("Privatperson");
                    }

                    //set values of customer
                    c.ID = int.Parse(dr["ID"].ToString());
                    c.CustomerType = dr["CustomerType"].ToString();
                    c.FirstName = dr["FirstName"].ToString();
                    c.LastName = dr["LastName"].ToString();
                    c.Income = double.Parse(dr["Income"].ToString());
                }

            }
            catch (Exception) {

            }
            //Set owner
            v.Owner = c;

            con.Close();


            InsertVehicle(v);

        }

        private void setMessageLabel(Vehicle v) {
            MessageLabel.Text = string.Format("{0} - Besitzer: {1} {2} {3}", v.Drive(), v.Owner.CustomerType,
                v.Owner.FirstName, v.Owner.LastName);
        }

        private void InsertVehicle(Vehicle toInsert) {

            con.Open();

            //Select 0 lines but open connection to database
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM dbo.Vehicle where 0 = 1", con);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            //Create new row in datatable
            DataRow newRow = dt.NewRow();

            //Set values of new row
            newRow["Type"] = toInsert.Type;
            newRow["Brand"] = toInsert.Brand;
            newRow["Model"] = toInsert.Model;
            newRow["Kilowatt"] = toInsert.Kilowatt;
            newRow["Seats"] = toInsert.Seats;
            newRow["Preowned"] = toInsert.Preowned;
            newRow["Owner"] = toInsert.Owner.ID;

            dt.Rows.Add(newRow);

            //Build new sql command for adapter to insert
            new SqlCommandBuilder(adapter);

            //Update Table
            adapter.Update(dt);

            con.Close();

            //refresh datagrid
            vehicleGrid.DataBind();

        }
    }
}