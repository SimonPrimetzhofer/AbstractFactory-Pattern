using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VehicleApplication_AbstractFactory {
    public partial class _Default : Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void vehicleGrid_RowDataBound(object sender, GridViewRowEventArgs e) {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            if (e.Row.RowType == DataControlRowType.DataRow) {
                bool val = Convert.ToBoolean(drv["Preowned"]);

                e.Row.Cells[5].Text = (val ? "Yes" : "No");
            }
        }
    }
}