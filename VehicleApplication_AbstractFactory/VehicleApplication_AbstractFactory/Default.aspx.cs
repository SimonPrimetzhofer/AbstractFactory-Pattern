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

            DataTable dt = new DataTable();

            try {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Customer", con);

                adapter.Fill(dt);

                ownerDropdown.DataSource = dt;
                ownerDropdown.DataTextField = "LastName";
                ownerDropdown.DataValueField = "ID";
                ownerDropdown.DataBind();

            }
            catch (Exception) {

            }

        }

        protected void vehicleGrid_RowDataBound(object sender, GridViewRowEventArgs e) {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            if (e.Row.RowType == DataControlRowType.DataRow) {
                bool val = Convert.ToBoolean(drv["Preowned"]);

                e.Row.Cells[5].Text = (val ? "Yes" : "No");
            }

        }

        protected void submitButton_Click(object sender, EventArgs e) {
            Vehicle v = avf.GetVehicle(vehicleType.SelectedValue);

            if (v is Car) {
                v = (Car)v;
            }
            else if (v is Truck) {
                v = (Truck)v;
            }
            else if (v is Motorcycle) {
                v = (Motorcycle)v;
            }
            else if (v is Tractor) {
                v = (Tractor)v;
            }

            v.Type = vehicleType.Text;
            v.Brand = vehicleBrand.Text;
            v.Model = vehicleModel.Text;
            //Format passt nu ned
            //v.Kilowatt = Convert.ToInt32(vehicleKw.Text);
            //v.Seats = Convert.ToInt32(vehicleSeats.Text);
            v.Preowned = vehiclePreowned.Checked;

            TextBox1.Text = v.Drive();

            Console.WriteLine(v);

            //Get Owner from database
            DataTable dt = new DataTable();

            Customer c = null;

            try {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM dbo.Customer where ID = @customerID", con);
                adapter.SelectCommand.Parameters.AddWithValue("@customerID", ownerDropdown.SelectedValue);

                adapter.Fill(dt);

                DataRow dr = dt.Rows[0];
                TextBox2.Text = dr["LastName"].ToString();

                //Entry found
                if(dr != null) {
                    //Company --> has no firstname
                    if(dr["LastName"].ToString().Length > 0 && dr["FirstName"].ToString().Length == 0) {
                        c = (Company) acf.GetCustomer("Firma");
                    }else if(dr["LastName"].ToString().Length > 0 && dr["FirstName"].ToString().Length > 0) {
                        c = (PrivateCustomer)acf.GetCustomer("Privatperson");
                    }
                }

            }
            catch (Exception) {

            }

            //Set owner
            v.Owner = c;

            TextBox2.Text = v.Owner.LastName;

        }
    }
}