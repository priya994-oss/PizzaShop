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
    public partial class Home : System.Web.UI.Page
    {
        Connection obj = new Connection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGrid();
            }
        }

        public void BindGrid()
        {
            string str = " Select * From PizzaDetails";
            SqlCommand cmd = new SqlCommand(str, obj.create_AppConn());
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][0].ToString() == "1")
                    {
                        lblItalianPizza.Text = dt.Rows[i]["PizzaName"].ToString();
                        lblIPPrice.Text = dt.Rows[i]["Price"].ToString();
                    }
                    else if (dt.Rows[i][0].ToString() == "2")
                    {
                        lblGreekPizza.Text = dt.Rows[i]["PizzaName"].ToString();
                        lblGPPrice.Text = dt.Rows[i]["Price"].ToString();
                    }
                    else if (dt.Rows[i][0].ToString() == "3")
                    {
                        lblCaucasianPizza.Text = dt.Rows[i]["PizzaName"].ToString();
                        lblCPPrice.Text = dt.Rows[i]["Price"].ToString();
                    }
                    else if (dt.Rows[i][0].ToString() == "4")
                    {
                        lblAmericanPizza.Text = dt.Rows[i]["PizzaName"].ToString();
                        lblAPPrice.Text = dt.Rows[i]["Price"].ToString();
                    }
                    else if (dt.Rows[i][0].ToString() == "5")
                    {
                        lblTomatoePie.Text = dt.Rows[i]["PizzaName"].ToString();
                        lblTPPrice.Text = dt.Rows[i]["Price"].ToString();
                    }
                    else if (dt.Rows[i][0].ToString() == "6")
                    {
                        lblMargherita.Text = dt.Rows[i]["PizzaName"].ToString();
                        lblMPPrice.Text = dt.Rows[i]["Price"].ToString();
                    }
                }

            }

        }

        public void SaveToCart(int PizzaID)
        {
            int CartID = 0;
            SqlCommand cmd = new SqlCommand("InsertAddToCartDetails", obj.create_AppConn());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CartID", CartID);
            cmd.Parameters.AddWithValue("@PizzaID", PizzaID);
            cmd.Parameters.AddWithValue("@Quantity", 1);
            cmd.Parameters.AddWithValue("@IsActive", true);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            string message = "Pizza Added to Cart...";
            string url = "Home.aspx";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "');";
            script += "window.location = '";
            script += url;
            script += "'; }";
            ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
        }
        protected void btnAddCart_Click(object sender, EventArgs e)
        {
            int PizzaID = 1;
            SaveToCart(PizzaID);
        }
        protected void btnAddCart1_Click(object sender, EventArgs e)
        {
            int PizzaID = 2;
            SaveToCart(PizzaID);
        }
        protected void btnAddCart2_Click(object sender, EventArgs e)
        {
            int PizzaID = 3;
            SaveToCart(PizzaID);
        }
        protected void btnAddCart3_Click(object sender, EventArgs e)
        {
            int PizzaID = 4;
            SaveToCart(PizzaID);
        }
        protected void btnAddCart4_Click(object sender, EventArgs e)
        {
            int PizzaID = 5;
            SaveToCart(PizzaID);
        }
        protected void btnAddCart5_Click(object sender, EventArgs e)
        {
            int PizzaID = 6;
            SaveToCart(PizzaID);
        }
    }
}