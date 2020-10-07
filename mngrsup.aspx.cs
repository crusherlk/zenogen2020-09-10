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
    public partial class WebForm18 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            getCustomerByID();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkCustomerExist())
            {
                Response.Write("<script>alert('Customer is already excisting. Try a different Product ID');</script>");
            }
            else
            {
                validatingInsert();
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkCustomerExist())
            {
                validatingUpdate();
            }
            else
            {
                Response.Write("<script>alert('Customer ID is not excisting. Try a different Product ID');</script>");
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkCustomerExist())
            {
                deleteCustomer();
            }
            else
            {
                Response.Write("<script>alert('Customer ID is not excisting. Try a different Product ID');</script>");
            }
        }

        void inserCustomer()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO suppliers" +
                    "(supId,supFname,supLname,supPhone,supEmail,supAddress) VALUES" +
                    "(@supId,@supFname,@supLname,@supPhone,@supEmail,@supAddress)", con);

                cmd.Parameters.AddWithValue("@supId", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@supFname", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@supLname", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@supPhone", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@supEmail", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@supAddress", TextBox7.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Data inserted Successfully!');</script>");
                clear();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        bool checkCustomerExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM suppliers " +
                    "WHERE supId='" + TextBox1.Text.Trim() + "';", con);

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

        void updateCustomer()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE suppliers SET supFname=@supFname, supLname=@supLname, " +
                    "supPhone=@supPhone,supEmail=@supEmail,supAddress=@supAddress WHERE " +
                    "supId='" + TextBox1.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@supId", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@supFname", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@supLname", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@supPhone", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@supEmail", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@supAddress", TextBox7.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Data Updated Successfully');</script>");
                clear();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void deleteCustomer()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE suppliers WHERE supId='" + TextBox1.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Data Deleted Successfully');</script>");
                clear();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void clear()
        {
            TextBox1.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
        }

        void getCustomerByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM suppliers " +
                    "WHERE supId='" + TextBox1.Text.Trim() + "';", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox3.Text = dt.Rows[0][1].ToString();
                    TextBox4.Text = dt.Rows[0][2].ToString();
                    TextBox5.Text = dt.Rows[0][3].ToString();
                    TextBox6.Text = dt.Rows[0][4].ToString();
                    TextBox7.Text = dt.Rows[0][5].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Supplier ID');</script>");

                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void validatingInsert()
        {
            String supId;
            String supFname;
            String supLname;
            String supPhone;
            String supEmail;
            String supAddress;

            if (!string.IsNullOrEmpty(TextBox1.Text))
            {

                if (TextBox1.Text.Length == 6)
                {
                    supId = TextBox1.Text;

                    if (!string.IsNullOrEmpty(TextBox3.Text))
                    {
                        supFname = TextBox3.Text;

                        if (!string.IsNullOrEmpty(TextBox4.Text))
                        {
                            supLname = TextBox4.Text;

                            if (!string.IsNullOrEmpty(TextBox5.Text))
                            {
                                if (TextBox5.Text.Length == 10)
                                {
                                    supPhone = TextBox5.Text;

                                    if (!string.IsNullOrEmpty(TextBox6.Text))
                                    {
                                        supEmail = TextBox6.Text;

                                        if (!string.IsNullOrEmpty(TextBox7.Text))
                                        {
                                            supAddress = TextBox7.Text;

                                            inserCustomer();
                                        }
                                        else
                                        {
                                            Response.Write("<script>alert('Supplier Address is required');</script>");
                                        }
                                    }
                                    else
                                    {
                                        Response.Write("<script>alert('Supplier Email is required');</script>");
                                    }
                                }
                                else
                                {
                                    Response.Write("<script>alert('Phone number should be 10 Digits');</script>");
                                }
                            }
                            else
                            {
                                Response.Write("<script>alert('Supplier Phone Number is required');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Supplier Last name is required');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Supplier First name is required');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Supplier ID should be 6 numbers');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Supplier ID is required');</script>");
            }
        }

        void validatingUpdate()
        {
            String supId;
            String supFname;
            String supLname;
            String supPhone;
            String supEmail;
            String supAddress;

            if (!string.IsNullOrEmpty(TextBox1.Text))
            {

                if (TextBox1.Text.Length == 6)
                {
                    supId = TextBox1.Text;

                    if (!string.IsNullOrEmpty(TextBox3.Text))
                    {
                        supFname = TextBox3.Text;

                        if (!string.IsNullOrEmpty(TextBox4.Text))
                        {
                            supLname = TextBox4.Text;

                            if (!string.IsNullOrEmpty(TextBox5.Text))
                            {
                                if (TextBox5.Text.Length == 10)
                                {
                                    supPhone = TextBox5.Text;

                                    if (!string.IsNullOrEmpty(TextBox6.Text))
                                    {
                                        supEmail = TextBox6.Text;

                                        if (!string.IsNullOrEmpty(TextBox7.Text))
                                        {
                                            supAddress = TextBox7.Text;

                                            updateCustomer();
                                        }
                                        else
                                        {
                                            Response.Write("<script>alert('Supplier Address is required');</script>");
                                        }
                                    }
                                    else
                                    {
                                        Response.Write("<script>alert('Supplier Email is required');</script>");
                                    }
                                }
                                else
                                {
                                    Response.Write("<script>alert('Phone number should be 10 Digits');</script>");
                                }
                            }
                            else
                            {
                                Response.Write("<script>alert('Supplier Phone Number is required');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Supplier Last name is required');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Supplier First name is required');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Supplier ID should be 6 numbers');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Supplier ID is required');</script>");
            }
        }

    }
}