using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace testzeno
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            validateRedirecting();
        }

        bool checkEmpExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM employees WHERE empUname='" + txtusername.Text + "' " +
                "and empPass='" + txtpassword.Text + "' and empType='" + DropDownList1.SelectedItem.Value.Trim() + "'", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        void redirecting()
        {
            if (DropDownList1.SelectedIndex == 1)
            {
                Server.Transfer("empdash.aspx");
            }
            else if (DropDownList1.SelectedIndex == 2)
            {
                Server.Transfer("mngrdash.aspx");
            }
            else if (DropDownList1.SelectedIndex == 3)
            {
                Server.Transfer("mngrdash.aspx");
            }
        }

        void validateRedirecting()
        {
            String empType;
            String empUname;
            String empPass;

            if (DropDownList1.SelectedValue != "Select")
            {
                empType = DropDownList1.SelectedValue;

                if (!string.IsNullOrEmpty(txtusername.Text))
                {
                    empUname = txtusername.Text;

                    if (!string.IsNullOrEmpty(txtpassword.Text))
                    {
                        empPass = txtpassword.Text;

                        if (checkEmpExist())
                        {
                            redirecting();
                        }
                        else
                        {
                            Response.Write("<script>alert('Chech your Employee Role, Username and Password and Try Again');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Enter Employee Password');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Enter Employee Username');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Select the Employee Role Before Sign In');</script>");
            }
        }
    }
}