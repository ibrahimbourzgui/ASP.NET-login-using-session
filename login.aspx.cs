using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace sitewebPFF
{
    public partial class login : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSeconnecter_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();                
                }
                SqlCommand cmd = new SqlCommand("select * from client where email='" + txtUsername.Text.Trim() + "'and motdepasse ='" + txtMdp.Text.Trim() + "'", con);
                SqlDataReader dr= cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while(dr.Read())
                    {
                        Response.Write("<script>alert('Hi " + dr.GetValue(2).ToString() + "')</script>");
                        Session["name"] = dr.GetValue(2).ToString();
                        Session["email"] = dr.GetValue(5).ToString();
                        Session["role"] = "user";
                    }
                    Response.Redirect("HomePage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Utilisateur introuvable')</script>");
                }
            }
            catch(Exception ex)
            {
               

            }

        }
    }
}