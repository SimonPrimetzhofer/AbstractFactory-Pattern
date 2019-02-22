using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VehicleApplication_AbstractFactory {
    public partial class Sell : System.Web.UI.Page {

        SqlConnection con;

        protected void Page_Init(object sender, EventArgs e) {
            con = new SqlConnection(VehicleDataSource.ConnectionString);
        }

        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void CompleteButton_Click(object sender, EventArgs e) {
            con.Open();

            //Seller and Buyer are different persons
            if(BuyerDropdown.SelectedValue != SellerDropdown.SelectedValue) {

                //Vehicle was selected and is not the default vehicle
                if (VehicleDropdown.SelectedValue.Length > 0 && VehicleDropdown.SelectedValue != "DefaultVehicle") {



                }
            }

            con.Close();
        }

        protected void SellerDropdown_SelectedIndexChanged(object sender, EventArgs e) {
            con.Open();

            if (SellerDropdown.SelectedValue == "DefaultSeller") {
                VehicleDropdown.DataSource = new DataTable();
                VehicleDropdown.DataBind();
                return;
            }

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * from dbo.Vehicle WHERE Owner = @customerID", con);
            adapter.SelectCommand.Parameters.AddWithValue("@customerID", SellerDropdown.SelectedValue);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            VehicleDropdown.DataSource = dt;
            VehicleDropdown.DataValueField = "ID";
            VehicleDropdown.DataTextField = "Model";

            VehicleDropdown.DataBind();

            con.Close();
        }
    }
}