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
    public partial class WebForm3 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView2.DataBind();
        }

        //go button
        protected void Button4_Click(object sender, EventArgs e)
        {
            getEmpByID();
        }

        //insert button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkEmpExist())
            {
                Response.Write("<script>alert('Employee ID is already excisting. Try a different Employee ID');</script>");
            }
            else
            {
                validatingInsert();
            }
        }

        //Update button
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkEmpExist())
            {
                validatingUpdate();
            }
            else
            {
                Response.Write("<script>alert('Employee ID is not excisting. Try a different Employee ID');</script>");
            }
        }

        //delete button
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkEmpExist())
            {
                deleteEmp();
            }
            else
            {
                Response.Write("<script>alert('Employee ID is not excisting. Try a different Employee ID');</script>");
            }
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM employees " +
                    "WHERE empID='" + TextBox1.Text.Trim() + "';", con);

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

        bool checkUsernameExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM employees " +
                    "WHERE empUname='" + TextBox10.Text.Trim() + "';", con);

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

        bool checkUsernameWithId()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM employees " +
                    "WHERE empID='" + TextBox1.Text.Trim() + "' AND empUname='" + TextBox10.Text.Trim() + "';", con);

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

        void insertEmp()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO employees" +
                    "(empID,empFname,empLname,empPhone,empRegdate,empType,empAreacode,empCity,empAddress,empUname,empPass) VALUES" +
                    "(@empID,@empFname,@empLname,@empPhone,@empRegdate,@empType,@empAreacode,@empCity,@empAddress,@empUname,@empPass)", con);

                //SqlCommand cmd2 = new SqlCommand("INSERT INTO logging_data (empUname,empPass,empID,empType) VALUES" +
                //    "(@empUname,@empPass,@empID,@empType)", con);

                cmd.Parameters.AddWithValue("@empID", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@empFname", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@empLname", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@empPhone", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@empRegdate", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@empType", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@empAreacode", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@empCity", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@empAddress", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@empUname", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@empPass", TextBox11.Text.Trim());

                cmd.ExecuteNonQuery();

                con.Close();
                Response.Write("<script>alert('Data inserted Successfully!');</script>");
                clear();
                GridView2.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void updateEmp() 
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE employees SET " +
                    "empFname=@empFname,empLname=@empLname,empPhone=@empPhone,empRegdate=@empRegdate,empType=@empType," +
                    "empAreacode=@empAreacode,empCity=@empCity,empAddress=@empAddress,empUname=@empUname," +
                    "empPass=@empPass WHERE empID='" + TextBox1.Text.Trim() + "'", con);

                
                cmd.Parameters.AddWithValue("@empFname", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@empLname", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@empPhone", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@empRegdate", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@empType", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@empAreacode", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@empCity", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@empAddress", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@empUname", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@empPass", TextBox11.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Data Updated Successfully!');</script>");
                clear();
                GridView2.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void deleteEmp()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE employees WHERE empID='" + TextBox1.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Data Deleted Successfully');</script>");
                clear();
                GridView2.DataBind();
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
            DropDownList1.SelectedValue = "Select";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
        }

        void getEmpByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM employees " +
                    "WHERE empID='" + TextBox1.Text.Trim() + "';", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox3.Text = dt.Rows[0][1].ToString();
                    TextBox4.Text = dt.Rows[0][2].ToString();
                    TextBox5.Text = dt.Rows[0][3].ToString();
                    TextBox6.Text = dt.Rows[0][4].ToString();
                    DropDownList1.SelectedValue = dt.Rows[0][5].ToString();
                    TextBox7.Text = dt.Rows[0][6].ToString();
                    TextBox8.Text = dt.Rows[0][7].ToString();
                    TextBox9.Text = dt.Rows[0][8].ToString();
                    TextBox10.Text = dt.Rows[0][9].ToString();
                    TextBox11.Text = dt.Rows[0][10].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Employee ID');</script>");
                    
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void validatingInsert()
        {
            String empID;
            String empFname;
            String empLname;
            String phone;
            String recDate;
            String empType;
            String areaCode;
            String city;
            String empAdd;
            String empUname;
            String empPass;

            if (!string.IsNullOrEmpty(TextBox1.Text))
            {
                if(TextBox1.Text.Length == 4)
                {
                    empID = TextBox1.Text;

                    if (!string.IsNullOrEmpty(TextBox3.Text))
                    {
                        empFname = TextBox3.Text;

                        if (!string.IsNullOrEmpty(TextBox4.Text))
                        {
                            empLname = TextBox4.Text;

                            if (!string.IsNullOrEmpty(TextBox5.Text))
                            {

                                if (TextBox5.Text.Length == 10)
                                {
                                    phone = TextBox5.Text;

                                    if (!string.IsNullOrEmpty(TextBox6.Text))
                                    {
                                        recDate = TextBox6.Text;

                                        if (DropDownList1.SelectedValue != "Select")
                                        {
                                            empType = DropDownList1.SelectedValue;

                                            if (!string.IsNullOrEmpty(TextBox7.Text))
                                            {

                                                if (TextBox7.Text.Length == 5)
                                                {
                                                    areaCode = TextBox7.Text;

                                                    if (!string.IsNullOrEmpty(TextBox8.Text))
                                                    {
                                                        city = TextBox8.Text;

                                                        if (!string.IsNullOrEmpty(TextBox9.Text))
                                                        {
                                                            empAdd = TextBox9.Text;

                                                            {
                                                                if (!string.IsNullOrEmpty(TextBox10.Text))
                                                                {

                                                                    if (TextBox10.Text.Length >= 7)
                                                                    {
                                                                        empUname = TextBox10.Text;

                                                                        if (!string.IsNullOrEmpty(TextBox11.Text))
                                                                        {

                                                                            if (TextBox11.Text.Length >= 6)
                                                                            {
                                                                                empPass = TextBox11.Text;

                                                                                if (checkUsernameExist())
                                                                                {
                                                                                    Response.Write("<script>alert('Employee Username is already excisting. Try a different Username');</script>");
                                                                                }
                                                                                else
                                                                                {
                                                                                    insertEmp();
                                                                                }

                                                                            }
                                                                            else
                                                                            {
                                                                                Response.Write("<script>alert('Password should have 6 or more characters');</script>");
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            Response.Write("<script>alert('Password is required');</script>");
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        Response.Write("<script>alert('Username should have 7 or more characters');</script>");
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    Response.Write("<script>alert('Username is required');</script>");
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            Response.Write("<script>alert('Address is required');</script>");
                                                        }

                                                    }
                                                    else
                                                    {
                                                        Response.Write("<script>alert('City is required');</script>");
                                                    }
                                                }
                                                else
                                                {
                                                    Response.Write("<script>alert('Should indicate area code in 5 numbers');</script>");
                                                }
                                            }
                                            else
                                            {
                                                Response.Write("<script>alert('Area code is required');</script>");
                                            }
                                        }
                                        else
                                        {
                                            Response.Write("<script>alert('Employee Type is required');</script>");
                                        }
                                    }
                                    else
                                    {
                                        Response.Write("<script>alert('Recruited Date is required');</script>");
                                    }
                                }
                                else
                                {
                                    Response.Write("<script>alert('Phone number must be 10 numbers');</script>");
                                }
                            }
                            else
                            {
                                Response.Write("<script>alert('Employee Phone number is required');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Employee Last Name is required');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Employee First Name is required');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Employee ID must have 4 numbers');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Employee ID is required');</script>");
            }
        }

        void validatingUpdate()
        {
            String empID;
            String empFname;
            String empLname;
            String phone;
            String recDate;
            String empType;
            String areaCode;
            String city;
            String empAdd;
            String empUname;
            String empPass;

            if (!string.IsNullOrEmpty(TextBox1.Text))
            {
                if (TextBox1.Text.Length == 4)
                {
                    empID = TextBox1.Text;

                    if (!string.IsNullOrEmpty(TextBox3.Text))
                    {
                        empFname = TextBox3.Text;

                        if (!string.IsNullOrEmpty(TextBox4.Text))
                        {
                            empLname = TextBox4.Text;

                            if (!string.IsNullOrEmpty(TextBox5.Text))
                            {

                                if (TextBox5.Text.Length == 10)
                                {
                                    phone = TextBox5.Text;

                                    if (!string.IsNullOrEmpty(TextBox6.Text))
                                    {
                                        recDate = TextBox6.Text;

                                        if (DropDownList1.SelectedValue != "Select")
                                        {
                                            empType = DropDownList1.SelectedValue;

                                            if (!string.IsNullOrEmpty(TextBox7.Text))
                                            {

                                                if (TextBox7.Text.Length == 5)
                                                {
                                                    areaCode = TextBox7.Text;

                                                    if (!string.IsNullOrEmpty(TextBox8.Text))
                                                    {
                                                        city = TextBox8.Text;

                                                        if (!string.IsNullOrEmpty(TextBox9.Text))
                                                        {
                                                            empAdd = TextBox9.Text;

                                                            {
                                                                if (!string.IsNullOrEmpty(TextBox10.Text))
                                                                {

                                                                    if (TextBox10.Text.Length >= 7)
                                                                    {
                                                                        empUname = TextBox10.Text;

                                                                        if (!string.IsNullOrEmpty(TextBox11.Text))
                                                                        {

                                                                            if (TextBox11.Text.Length >= 6)
                                                                            {
                                                                                empPass = TextBox11.Text;

                                                                                if (checkUsernameExist())
                                                                                {
                                                                                    if (checkUsernameWithId())
                                                                                    {
                                                                                        updateEmp();
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        Response.Write("<script>alert('Employee Username is already excisting. Try a different Username');</script>");
                                                                                    }
                                                                                    
                                                                                }
                                                                                else
                                                                                {
                                                                                    updateEmp();
                                                                                }

                                                                            }
                                                                            else
                                                                            {
                                                                                Response.Write("<script>alert('Password should have 6 or more characters');</script>");
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            Response.Write("<script>alert('Password is required');</script>");
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        Response.Write("<script>alert('Username should have 7 or more characters');</script>");
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    Response.Write("<script>alert('Username is required');</script>");
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            Response.Write("<script>alert('Address is required');</script>");
                                                        }

                                                    }
                                                    else
                                                    {
                                                        Response.Write("<script>alert('City is required');</script>");
                                                    }
                                                }
                                                else
                                                {
                                                    Response.Write("<script>alert('Should indicate area code in 5 numbers');</script>");
                                                }
                                            }
                                            else
                                            {
                                                Response.Write("<script>alert('Area code is required');</script>");
                                            }
                                        }
                                        else
                                        {
                                            Response.Write("<script>alert('Employee Type is required');</script>");
                                        }
                                    }
                                    else
                                    {
                                        Response.Write("<script>alert('Recruited Date is required');</script>");
                                    }
                                }
                                else
                                {
                                    Response.Write("<script>alert('Phone number must be 10 numbers');</script>");
                                }
                            }
                            else
                            {
                                Response.Write("<script>alert('Employee Phone number is required');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Employee Last Name is required');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Employee First Name is required');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Employee ID must have 4 numbers');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Employee ID is required');</script>");
            }
        }

    }
}