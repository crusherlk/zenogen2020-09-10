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
    public partial class WebForm1 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        //go button
        protected void Button4_Click(object sender, EventArgs e)
        {
            getProductByID();
        }

        //insert button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkProductExist()) 
            {
                Response.Write("<script>alert('Product ID is already excisting. Try a different Product ID');</script>");
            }
            else
            {
                validatingInsert();
            }

        }

        //update button
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkProductExist())
            {
                validatingUpdate();
            }
            else
            {
                Response.Write("<script>alert('Product ID is not excisting. Try a different Product ID');</script>");
            }
        }

        //delete button
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkProductExist())
            {
                deleteProduct();
            }
            else
            {
                Response.Write("<script>alert('Product ID is not excisting. Try a different Product ID');</script>");
            }
        }


        void insertProduct() 
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO inventory" +
                    "(productID,productName,oneProductPrice,ProductQty) VALUES" +
                    "(@productID,@productName,@oneProductPrice,@ProductQty)", con);

                cmd.Parameters.AddWithValue("@productID", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@productName", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@oneProductPrice", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@ProductQty", TextBox4.Text.Trim());

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

        bool checkProductExist() 
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM inventory " +
                    "WHERE productID='"+TextBox1.Text.Trim()+"';", con);

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

        void updateProduct() 
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE inventory SET productName=@productName, oneProductPrice=@oneProductPrice, " +
                    "ProductQty=@ProductQty WHERE productID='" + TextBox1.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@productName", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@oneProductPrice", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@ProductQty", TextBox4.Text.Trim());

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

        void deleteProduct() 
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE inventory WHERE productID='" + TextBox1.Text.Trim() + "'", con);

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
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
        }

        void getProductByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM inventory " +
                    "WHERE productID='" + TextBox1.Text.Trim() + "';", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                    TextBox3.Text = dt.Rows[0][2].ToString();
                    TextBox4.Text = dt.Rows[0][3].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Product ID');</script>");
                    
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void validatingInsert()
        {
            String productID;
            String productName;
            String oneQtyPrice;
            String qty;

            if (!string.IsNullOrEmpty(TextBox1.Text))
            {
                if(TextBox1.Text.Length != 4)
                {
                    Response.Write("<script>alert('Product ID should be 4 characters');</script>");
                }
                else
                {
                    productID = TextBox1.Text;

                    if (!string.IsNullOrEmpty(TextBox2.Text))
                    {
                        productName = TextBox2.Text;

                        if (!string.IsNullOrEmpty(TextBox3.Text))
                        {
                            oneQtyPrice = TextBox3.Text;

                            if (!string.IsNullOrEmpty(TextBox4.Text))
                            {
                                qty = TextBox4.Text;

                                insertProduct();
                            }
                            else
                            {
                                Response.Write("<script>alert('Product Quantity is Required');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('One Quantity Price is Required');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Product Name is Required');</script>");
                    }
                }

                
            }
            else
            {
                Response.Write("<script>alert('Product ID is required');</script>");
            }
        }

        void validatingUpdate()
        {
            String productID;
            String productName;
            String oneQtyPrice;
            String qty;

            if (!string.IsNullOrEmpty(TextBox1.Text))
            {
                if (TextBox1.Text.Length != 4)
                {
                    Response.Write("<script>alert('Product ID should be 4 characters');</script>");
                }
                else
                {
                    productID = TextBox1.Text;

                    if (!string.IsNullOrEmpty(TextBox2.Text))
                    {
                        productName = TextBox2.Text;

                        if (!string.IsNullOrEmpty(TextBox3.Text))
                        {
                            oneQtyPrice = TextBox3.Text;

                            if (!string.IsNullOrEmpty(TextBox4.Text))
                            {
                                qty = TextBox4.Text;

                                updateProduct();
                            }
                            else
                            {
                                Response.Write("<script>alert('Product Quantity is Required');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('One Quantity Price is Required');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Product Name is Required');</script>");
                    }
                }


            }
            else
            {
                Response.Write("<script>alert('Product ID is required');</script>");
            }
        }

    }
}