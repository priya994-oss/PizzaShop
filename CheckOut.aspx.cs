using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace PizzaShop
{
    public partial class CheckOut : System.Web.UI.Page
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
            string str = "SELECT pd.PizzaID, PizzaName, Discription, Price, SUM(Price) as Total, SUM(Quantity) as Qty,CartID FROM PizzaDetails pd Inner Join AddToCartDetails cd on pd.PizzaID = cd.pizzaid GROUP BY pd.PizzaID,PizzaName,Quantity, Discription,Price,CartID";
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
        public void SaveToCart()
        {
            int ID = 0;
            SqlCommand cmd = new SqlCommand("InsertCheckOutDetails", obj.create_AppConn());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", ID);
            //cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
            cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
            cmd.Parameters.AddWithValue("@MobileNo", txtPhoneNo.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
            cmd.Parameters.AddWithValue("@City", txtCity.Text);
            cmd.Parameters.AddWithValue("@ZipCode", txtZipcode.Text);
            cmd.Parameters.AddWithValue("@NameOnCard", txtNameOnCard.Text);
            cmd.Parameters.AddWithValue("@CardNo", txtCardNo.Text);
            cmd.Parameters.AddWithValue("@CCV", txtCCV.Text);
            cmd.Parameters.AddWithValue("@ExpiryDate", txtExpiryDate.Text);
            cmd.Parameters.AddWithValue("@TotalAmount", Convert.ToDouble(lblTotalAmt.Text));

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            BindGrid();
            for (int i = 0; i < gvPizza.Rows.Count; i++)
            {
                int ID1 = 0;
                SqlCommand cmd1 = new SqlCommand("InsertCheckOutProuductDetails", obj.create_AppConn());
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@ID", ID1);
                cmd1.Parameters.AddWithValue("@PizzaID", Convert.ToInt32(gvPizza.Rows[i].Cells[0].Text));
                cmd1.Parameters.AddWithValue("@TotalAmount", Convert.ToDouble(gvPizza.Rows[i].Cells[2].Text));
                cmd1.Parameters.AddWithValue("@Quantity", Convert.ToDouble(gvPizza.Rows[i].Cells[3].Text));
                cmd1.Parameters.AddWithValue("@checkoutID", Convert.ToInt32(gvPizza.Rows[i].Cells[5].Text));

                cmd1.ExecuteNonQuery();
                cmd1.Dispose();

                string str = "UPDATE AddToCartDetails SET IsActive = 'False' WHERE CartID ="+ Convert.ToInt32(gvPizza.Rows[i].Cells[5].Text);
                SqlCommand cmd2 = new SqlCommand(str, obj.create_AppConn());
                cmd2.CommandType = CommandType.Text;
                cmd2.ExecuteNonQuery();
                cmd2.Dispose();
            }

            string message = "Your Order Placed Successfully...";
            string url = "Home.aspx";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "');";
            script += "window.location = '";
            script += url;
            script += "'; }";
            ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            SaveToCart();
        }
    }
}