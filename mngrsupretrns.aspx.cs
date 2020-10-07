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
    public partial class WebForm17 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        //go
        protected void Button4_Click(object sender, EventArgs e)
        {
            getReturnedOrderByID();
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
                deleteReturnedOrder();
            }
            else
            {
                Response.Write("<script>alert('Order ID is not excisting. Try a different Product ID');</script>");
            }
        }

        void insertReturnedOrder()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO purchase_returns" +
                    "(supreturnInvoiceNo,purchaseId,supId,productId,returnedQty,returnDate) VALUES" +
                    "(@supreturnInvoiceNo,@purchaseId,@supId,@productId,@returnedQty,@returnDate)", con);

                cmd.Parameters.AddWithValue("@supreturnInvoiceNo", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@purchaseId", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@supId", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@productId", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@returnedQty", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@returnDate", TextBox6.Text.Trim());

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
                SqlCommand cmd = new SqlCommand("SELECT * FROM purchase_returns " +
                    "WHERE supreturnInvoiceNo='" + TextBox3.Text.Trim() + "';", con);

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

        void updateReturnedOrder()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE purchase_returns SET purchaseId=@purchaseId, supId=@supId, " +
                    "productId=@productId,returnedQty=@returnedQty,returnDate=@returnDate WHERE " +
                    "supreturnInvoiceNo='" + TextBox3.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@supreturnInvoiceNo", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@purchaseId", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@supId", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@productId", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@returnedQty", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@returnDate", TextBox6.Text.Trim());

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

        void deleteReturnedOrder()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE purchase_returns WHERE supreturnInvoiceNo='" + TextBox3.Text.Trim() + "'", con);

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

        void getReturnedOrderByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM purchase_returns " +
                    "WHERE supreturnInvoiceNo='" + TextBox3.Text.Trim() + "';", con);

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
            String supreturnInvoiceNo;
            String purchaseId;
            String supId;
            String productId;
            String returnedQty;
            String returnDate;

            if (!string.IsNullOrEmpty(TextBox3.Text))
            {
                if (TextBox3.Text.Length == 8)
                {
                    supreturnInvoiceNo = TextBox3.Text;

                    if (!string.IsNullOrEmpty(TextBox4.Text))
                    {
                        if (TextBox4.Text.Length == 8)
                        {
                            purchaseId = TextBox4.Text;

                            if (!string.IsNullOrEmpty(TextBox7.Text))
                            {
                                if (TextBox7.Text.Length == 6)
                                {
                                    supId = TextBox7.Text;

                                    if (!string.IsNullOrEmpty(TextBox8.Text))
                                    {

                                        if (TextBox8.Text.Length == 4)
                                        {
                                            productId = TextBox8.Text;

                                            if (!string.IsNullOrEmpty(TextBox5.Text))
                                            {
                                                returnedQty = TextBox5.Text;

                                                if (!string.IsNullOrEmpty(TextBox6.Text))
                                                {
                                                    returnDate = TextBox6.Text;

                                                    insertReturnedOrder();
                                                }
                                                else
                                                {
                                                    Response.Write("<script>alert('Returned Date is required');</script>");
                                                }
                                            }
                                            else
                                            {
                                                Response.Write("<script>alert('Returned Quantity is required');</script>");
                                            }
                                        }
                                        else
                                        {
                                            Response.Write("<script>alert('Product ID should be 4 numbers');</script>");
                                        }
                                    }
                                    else
                                    {
                                        Response.Write("<script>alert('Product ID is required');</script>");
                                    }
                                }
                                else
                                {
                                    Response.Write("<script>alert('Supplier ID  must have 6 numbers');</script>");
                                }



                            }
                            else
                            {
                                Response.Write("<script>alert('Supplier ID is required');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Order Number must have 8 numbers');</script>");
                        }


                    }
                    else
                    {
                        Response.Write("<script>alert('Order Number is required');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Returned Order Number must have 8 numbers');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Returned Order Number is required');</script>");
            }

        }

        void validatingUpdate()
        {
            String supreturnInvoiceNo;
            String purchaseId;
            String supId;
            String productId;
            String returnedQty;
            String returnDate;

            if (!string.IsNullOrEmpty(TextBox3.Text))
            {
                if (TextBox3.Text.Length == 8)
                {
                    supreturnInvoiceNo = TextBox3.Text;

                    if (!string.IsNullOrEmpty(TextBox4.Text))
                    {
                        if (TextBox4.Text.Length == 8)
                        {
                            purchaseId = TextBox4.Text;

                            if (!string.IsNullOrEmpty(TextBox7.Text))
                            {
                                if (TextBox7.Text.Length == 6)
                                {
                                    supId = TextBox7.Text;

                                    if (!string.IsNullOrEmpty(TextBox8.Text))
                                    {

                                        if (TextBox8.Text.Length == 4)
                                        {
                                            productId = TextBox8.Text;

                                            if (!string.IsNullOrEmpty(TextBox5.Text))
                                            {
                                                returnedQty = TextBox5.Text;

                                                if (!string.IsNullOrEmpty(TextBox6.Text))
                                                {
                                                    returnDate = TextBox6.Text;

                                                    updateReturnedOrder();
                                                }
                                                else
                                                {
                                                    Response.Write("<script>alert('Returned Date is required');</script>");
                                                }
                                            }
                                            else
                                            {
                                                Response.Write("<script>alert('Returned Quantity is required');</script>");
                                            }
                                        }
                                        else
                                        {
                                            Response.Write("<script>alert('Product ID should be 4 numbers');</script>");
                                        }
                                    }
                                    else
                                    {
                                        Response.Write("<script>alert('Product ID is required');</script>");
                                    }
                                }
                                else
                                {
                                    Response.Write("<script>alert('Supplier ID  must have 6 numbers');</script>");
                                }



                            }
                            else
                            {
                                Response.Write("<script>alert('Supplier ID is required');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Order Number must have 8 numbers');</script>");
                        }


                    }
                    else
                    {
                        Response.Write("<script>alert('Order Number is required');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Returned Order Number must have 8 numbers');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Returned Order Number is required');</script>");
            }

        }

    }
}