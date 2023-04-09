using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PizzaShop
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        Connection obj = new Connection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGrid();
                Cal();
            }
        }
        public void BindGrid()
        {
            string str = "SELECT pd.PizzaID, PizzaName, Discription, Price, SUM(Price) as Total, SUM(Quantity) as Qty FROM PizzaDetails pd Inner Join AddToCartDetails cd on pd.PizzaID = cd.pizzaid  Where IsActive <> '0' GROUP BY pd.PizzaID,PizzaName,Quantity, Discription,Price";
            SqlCommand cmd = new SqlCommand(str, obj.create_AppConn());
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                gvPizza.DataSource = dt;
                gvPizza.DataBind();
            }
            else
            {
                gvPizza.DataSource = dt;
                gvPizza.DataBind();
            }

        }
        public void Cal()
        {
            double totalSalary = 0;

            for (int i = 0; i < gvPizza.Rows.Count; i++)
            {
                totalSalary += Convert.ToDouble(gvPizza.Rows[i].Cells[4].Text);
            }
            lblSubtotal.Text = totalSalary.ToString();
            lblTotalAmt.Text = totalSalary.ToString();
        }       
        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            Response.Redirect("CheckOut.aspx");
        }
    }
}