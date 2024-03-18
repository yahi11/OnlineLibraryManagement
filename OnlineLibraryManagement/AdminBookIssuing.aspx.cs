using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineLibraryManagement
{
    public partial class AdminBookIssuing : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        //private object a;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();

        }

        // go button
        protected void Button4_Click(object sender, EventArgs e)
        {
            getNames();
        }
        
        // issue button
        protected void Button2_Click(object sender, EventArgs e)
        {
            if(checkIfBookExists() && checkIfMemberExists())
            {
                if (checkIfIssueEntryExists())
                {
                    Response.Write("<script>alert('This Member already has this Book');</script>");
                }
                else
                {
                    issueBook();
                }
                
            }
            else
            {
                Response.Write("<script>alert('Invalid Book ID or Member ID');</script>");
            }
        }

        // return button
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfBookExists() && checkIfMemberExists())
            {
                if (checkIfIssueEntryExists())
                {
                    returnBook();
                }
                else
                {
                    Response.Write("<script>alert('Book not issued to this member');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Invalid Book ID or Member ID');</script>");
            }
        }

        // user define function

        void returnBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE FROM book_issue_tbl WHERE book_id='" + TextBox1.Text.Trim() + "' AND member_id='" + TextBox2.Text.Trim() + "' ", con);
                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmd = new SqlCommand("UPDATE book_master_tbl SET current_stock = current_stock + 1 WHERE book_id= '"+TextBox1.Text.Trim()+"'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    Response.Write("<script>alert('Book Returned Succcessfully');</script>");
                    //clearForm();
                    GridView1.DataBind();

                }
                else
                {
                    Response.Write("<script>alert('Error - Invalid Details');</script>");
                }
                //cmd.Parameters.AddWithValue("@author_id", TextBox1.Text.Trim());
                //cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim()); 

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }



        }




        void issueBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO book_issue_tbl(member_id,member_name,book_id,book_name,issue_date,due_date) values " +
                    "(@member_id,@member_name,@book_id,@book_name,@issue_date,@due_date) ", con);

                cmd.Parameters.AddWithValue("@member_id", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@member_name", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@issue_date", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@due_date", TextBox6.Text.Trim());

                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("UPDATE book_master_tbl SET current_stock = current_stock - 1 WHERE book_id = '"+TextBox1.Text.Trim()+"'", con);
                cmd.ExecuteNonQuery();


                con.Close();
                Response.Write("<script>alert('Book Issued succcessful');</script>");
                //clearform();

                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        bool checkIfBookExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl WHERE book_id='" + TextBox1.Text.Trim() + "' AND current_stock >0 ", con);
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
            catch(Exception ex)
            {

            }

            return false;
        }

        bool checkIfMemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT full_name FROM member_master_tbl WHERE member_id='" + TextBox2.Text.Trim() + "' ", con);
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

            }

            return false;
        }

        bool checkIfIssueEntryExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM book_issue_tbl WHERE member_id='" + TextBox2.Text.Trim() + "' AND book_id ='"+TextBox1.Text.Trim()+"' ", con);
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

            }

            return false;
        }





        void getNames()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed) 
                { 
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT book_name FROM book_master_tbl WHERE book_id='" + TextBox1.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1) 
                {
                    TextBox4.Text = dt.Rows[0]["book_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Wrong Book ID');</script>");
                }

                cmd = new SqlCommand("SELECT full_name FROM member_master_tbl WHERE member_id='" + TextBox2.Text.Trim() + "'", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox3.Text = dt.Rows[0]["full_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Wrong Member ID');</script>");
                }




            }
            catch(Exception ex) 
            {

            } 

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                //if (e.Row.RowType == DataControlRowType.DataRow)
                //{
                //    // Assuming the condition is based on a specific column value (e.g., column at index 5)
                //    int columnIndex = 5; // Replace with the actual column index

                //    // Retrieve the value from the specified column
                //    string columnValue = e.Row.Cells[columnIndex].Text;

                //    // Check your condition based on the column value
                //    if (!string.IsNullOrEmpty(columnValue) && DateTime.TryParse(columnValue, out DateTime dateValue))
                //    {
                //        DateTime today = DateTime.Today;
                //        // Example: Set the row background color if the date is in the past
                //        if (dateValue < today)
                //        {
                //            e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                //        }
                //    }
                //}


                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //Check your condition here
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today > dt)
                    {
                        //Response.Write("<script>alert('Condition met');</script>");
                        //e.Row.Attributes["style"] = "background-color: #28b779";
                        //e.Row.Cells[0].BackColor = System.Drawing.Color.PaleVioletRed;
                        //e.Row.Cells[1].BackColor = System.Drawing.Color.PaleVioletRed;
                        //e.Row.Cells[2].BackColor = System.Drawing.Color.PaleVioletRed;
                        //e.Row.Cells[3].BackColor = System.Drawing.Color.PaleVioletRed;
                        //e.Row.Cells[4].BackColor = System.Drawing.Color.PaleVioletRed;
                        //e.Row.Cells[5].BackColor = System.Drawing.Color.PaleVioletRed;
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}