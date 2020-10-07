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
    public partial class WebForm16 : System.Web.UI.Page
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
                SqlCommand cmd = new SqlCommand("INSERT INTO sup_purchase" +
                    "(purchaseId,supId,productID,oneProductPrice,purchasedQty,purchasedDate) VALUES" +
                    "(@purchaseId,@supId,@productID,@oneProductPrice,@purchasedQty,@purchasedDate)", con);

                cmd.Parameters.AddWithValue("@purchaseId", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@supId", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@productID", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@oneProductPrice", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@purchasedQty", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@purchasedDate", TextBox6.Text.Trim());

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
                SqlCommand cmd = new SqlCommand("SELECT * FROM sup_purchase " +
                    "WHERE purchaseId='" + TextBox3.Text.Trim() + "';", con);

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
                SqlCommand cmd = new SqlCommand("UPDATE sup_purchase SET supId=@supId, productID=@productID, " +
                    "oneProductPrice=@oneProductPrice,purchasedQty=@purchasedQty,purchasedDate=@purchasedDate WHERE " +
                    "purchaseId='" + TextBox3.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@purchaseId", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@supId", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@productID", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@oneProductPrice", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@purchasedQty", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@purchasedDate", TextBox6.Text.Trim());

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
                SqlCommand cmd = new SqlCommand("DELETE sup_purchase WHERE purchaseId='" + TextBox3.Text.Trim() + "'", con);

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
                SqlCommand cmd = new SqlCommand("SELECT * FROM sup_purchase " +
                    "WHERE purchaseId='" + TextBox3.Text.Trim() + "';", con);

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
            String purchaseId;
            String supId;
            String productID;
            String oneProductPrice;
            String purchasedQty;
            String purchasedDate;

            if (!string.IsNullOrEmpty(TextBox3.Text))
            {
                if (TextBox3.Text.Length == 8)
                {
                    purchaseId = TextBox3.Text;

                    if (!string.IsNullOrEmpty(TextBox4.Text))
                    {
                        if (TextBox4.Text.Length == 6)
                        {
                            supId = TextBox4.Text;

                            if (!string.IsNullOrEmpty(TextBox7.Text))
                            {
                                if (TextBox7.Text.Length == 4)
                                {
                                    productID = TextBox7.Text;

                                    if (!string.IsNullOrEmpty(TextBox8.Text))
                                    {
                                        oneProductPrice = TextBox8.Text;

                                        if (!string.IsNullOrEmpty(TextBox5.Text))
                                        {

                                            purchasedQty = TextBox5.Text;

                                            if (!string.IsNullOrEmpty(TextBox6.Text))
                                            {
                                                purchasedDate = TextBox6.Text;

                                                inserOrder();
                                            }
                                            else
                                            {
                                                Response.Write("<script>alert('Purchased Date is required');</script>");
                                            }

                                        }
                                        else
                                        {
                                            Response.Write("<script>alert('Purchased Quantity is required');</script>");
                                        }
                                    }
                                    else
                                    {
                                        Response.Write("<script>alert('One Product Price is required');</script>");
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
                            Response.Write("<script>alert('Supplier ID must have 6 numbers');</script>");
                        }


                    }
                    else
                    {
                        Response.Write("<script>alert('Supplier ID is required');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Purchase ID must have 8 numbers');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Purchase ID is required');</script>");
            }
        }

        void validatingUpdate()
        {
            String purchaseId;
            String supId;
            String productID;
            String oneProductPrice;
            String purchasedQty;
            String purchasedDate;

            if (!string.IsNullOrEmpty(TextBox3.Text))
            {
                if (TextBox3.Text.Length == 8)
                {
                    purchaseId = TextBox3.Text;

                    if (!string.IsNullOrEmpty(TextBox4.Text))
                    {
                        if (TextBox4.Text.Length == 6)
                        {
                            supId = TextBox4.Text;

                            if (!string.IsNullOrEmpty(TextBox7.Text))
                            {
                                if (TextBox7.Text.Length == 4)
                                {
                                    productID = TextBox7.Text;

                                    if (!string.IsNullOrEmpty(TextBox8.Text))
                                    {
                                        oneProductPrice = TextBox8.Text;

                                        if (!string.IsNullOrEmpty(TextBox5.Text))
                                        {

                                            purchasedQty = TextBox5.Text;

                                            if (!string.IsNullOrEmpty(TextBox6.Text))
                                            {
                                                purchasedDate = TextBox6.Text;

                                                updateOrder();
                                            }
                                            else
                                            {
                                                Response.Write("<script>alert('Purchased Date is required');</script>");
                                            }

                                        }
                                        else
                                        {
                                            Response.Write("<script>alert('Purchased Quantity is required');</script>");
                                        }
                                    }
                                    else
                                    {
                                        Response.Write("<script>alert('One Product Price is required');</script>");
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
                            Response.Write("<script>alert('Supplier ID must have 6 numbers');</script>");
                        }


                    }
                    else
                    {
                        Response.Write("<script>alert('Supplier ID is required');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Purchase ID must have 8 numbers');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Purchase ID is required');</script>");
            }
        }

    }
}