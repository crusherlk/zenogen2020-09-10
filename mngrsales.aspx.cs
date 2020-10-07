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
    public partial class WebForm4 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        //go
        protected void Button4_Click(object sender, EventArgs e)
        {
            getOrderByID();
        }

        //insert
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkOrderExist())
            {
                Response.Write("<script>alert('Order ID is already excisting. Try a different Product ID');</script>");
            }
            else
            {
                validatingInsert();
            }
        }

        //update
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkOrderExist())
            {
                validatingUpdate();
            }
            else
            {
                Response.Write("<script>alert('Order ID is not excisting. Try a different Product ID');</script>");
            }
        }

        //delete
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkOrderExist())
            {
                deleteOrder();
            }
            else
            {
                Response.Write("<script>alert('Order ID is not excisting. Try a different Product ID');</script>");
            }
        }

        void inserOrder()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO orders" +
                    "(orderNo,customerID,productID,orderedQty,soldEmpId,orderDate) VALUES" +
                    "(@orderNo,@customerID,@productID,@orderedQty,@soldEmpId,@orderDate)", con);

                cmd.Parameters.AddWithValue("@orderNo", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@customerID", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@productID", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@orderedQty", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@soldEmpId", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@orderDate", TextBox6.Text.Trim());

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

        bool checkOrderExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM orders " +
                    "WHERE orderNo='" + TextBox3.Text.Trim() + "';", con);

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

        void updateOrder()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE orders SET customerID=@customerID, productID=@productID, " +
                    "orderedQty=@orderedQty,soldEmpId=@soldEmpId,orderDate=@orderDate WHERE " +
                    "orderNo='" + TextBox3.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@orderNo", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@customerID", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@productID", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@orderedQty", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@soldEmpId", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@orderDate", TextBox6.Text.Trim());

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

        void deleteOrder()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE orders WHERE orderNo='" + TextBox3.Text.Trim() + "'", con);

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
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
        }

        void getOrderByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM orders " +
                    "WHERE orderNo='" + TextBox3.Text.Trim() + "';", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox4.Text = dt.Rows[0][1].ToString();
                    TextBox7.Text = dt.Rows[0][2].ToString();
                    TextBox8.Text = dt.Rows[0][3].ToString();
                    TextBox5.Text = dt.Rows[0][4].ToString();
                    TextBox6.Text = dt.Rows[0][5].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Order ID');</script>");

                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void validatingInsert()
        {
            String orderNo;
            String customerID;
            String productID;
            String orderedQty;
            String soldEmpId;
            String orderDate;

            if (!string.IsNullOrEmpty(TextBox3.Text))
            {
                if (TextBox3.Text.Length == 8)
                {
                    orderNo = TextBox3.Text;

                    if (!string.IsNullOrEmpty(TextBox4.Text))
                    {
                        if(TextBox4.Text.Length == 6)
                        {
                            customerID = TextBox4.Text;

                            if (!string.IsNullOrEmpty(TextBox7.Text))
                            {
                                if(TextBox7.Text.Length == 4)
                                {
                                    productID = TextBox7.Text;

                                    if (!string.IsNullOrEmpty(TextBox8.Text))
                                    {
                                        orderedQty = TextBox8.Text;

                                        if (!string.IsNullOrEmpty(TextBox5.Text))
                                        {
                                            if(TextBox5.Text.Length == 4)
                                            {
                                                soldEmpId = TextBox5.Text;

                                                if (!string.IsNullOrEmpty(TextBox6.Text))
                                                {
                                                    orderDate = TextBox6.Text;

                                                    inserOrder();
                                                }
                                                else
                                                {
                                                    Response.Write("<script>alert('Order Date is required');</script>");
                                                }
                                            }
                                            else
                                            {
                                                Response.Write("<script>alert('Employee ID should be 4 numbers');</script>");
                                            }
                                            

                                        }
                                        else
                                        {
                                            Response.Write("<script>alert('Employee ID is required');</script>");
                                        }
                                    }
                                    else
                                    {
                                        Response.Write("<script>alert('Ordered Quantity is required');</script>");
                                    }
                                }
                                else
                                {
                                    Response.Write("<script>alert('Product ID  must have 4 numbers');</script>");
                                }
                                

                                
                            }
                            else
                            {
                                Response.Write("<script>alert('Product ID is required');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Customer ID must have 6 numbers');</script>");
                        }
                        

                    }
                    else
                    {
                        Response.Write("<script>alert('Customer ID is required');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Order ID must have 8 numbers');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Order ID is required');</script>");
            }
        }

        void validatingUpdate()
        {
            String orderNo;
            String customerID;
            String productID;
            String orderedQty;
            String soldEmpId;
            String orderDate;

            if (!string.IsNullOrEmpty(TextBox3.Text))
            {
                if (TextBox3.Text.Length == 8)
                {
                    orderNo = TextBox3.Text;

                    if (!string.IsNullOrEmpty(TextBox4.Text))
                    {
                        if (TextBox4.Text.Length == 6)
                        {
                            customerID = TextBox4.Text;

                            if (!string.IsNullOrEmpty(TextBox7.Text))
                            {
                                if (TextBox7.Text.Length == 4)
                                {
                                    productID = TextBox7.Text;

                                    if (!string.IsNullOrEmpty(TextBox8.Text))
                                    {
                                        orderedQty = TextBox8.Text;

                                        if (!string.IsNullOrEmpty(TextBox5.Text))
                                        {
                                            if (TextBox5.Text.Length == 4)
                                            {
                                                soldEmpId = TextBox5.Text;

                                                if (!string.IsNullOrEmpty(TextBox6.Text))
                                                {
                                                    orderDate = TextBox6.Text;

                                                    updateOrder();
                                                }
                                                else
                                                {
                                                    Response.Write("<script>alert('Order Date is required');</script>");
                                                }
                                            }
                                            else
                                            {
                                                Response.Write("<script>alert('Employee ID should be 4 numbers');</script>");
                                            }


                                        }
                                        else
                                        {
                                            Response.Write("<script>alert('Employee ID is required');</script>");
                                        }
                                    }
                                    else
                                    {
                                        Response.Write("<script>alert('Ordered Quantity is required');</script>");
                                    }
                                }
                                else
                                {
                                    Response.Write("<script>alert('Product ID  must have 4 numbers');</script>");
                                }



                            }
                            else
                            {
                                Response.Write("<script>alert('Product ID is required');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Customer ID must have 8 numbers');</script>");
                        }


                    }
                    else
                    {
                        Response.Write("<script>alert('Customer ID is required');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Order ID must have 8 numbers');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Order ID is required');</script>");
            }
        }

    }
}