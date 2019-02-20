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

        protected void Page_Load(object sender, EventArgs e) {

            con = new SqlConnection(VehicleDB_Customers.ConnectionString);

            VehicleDB_Customers.DeleteCommand = "Delete from dbo.Customer where ID=@ID";

            VehicleDB_Customers.UpdateCommand = "UPDATE dbo.Customer SET ";

        }
    }
}