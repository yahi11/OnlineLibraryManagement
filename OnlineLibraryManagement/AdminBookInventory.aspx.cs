﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineLibraryManagement
{
    public partial class AdminBookInventory : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string global_filepath;
        static int global_actual_stock, global_current_stock, global_issued_books;
        private object da;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillAuthorPublisherValues();
            }
            GridView1.DataBind();
        }

        // go button
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfBookExists())
            {
                getBookByID();
            }
            else
            {
                Response.Write("<script>alert('Book does not exists');</script>");

            }
        }

        // add button
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkIfBookExists())
            {
                Response.Write("<script>alert('Book with this id already exists. We cannot add an book with same id');</script>");
            }
            else
            {
                addNewBook();

            }

            
        }

        // update button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkIfBookExists())
            {
                updateBook();          
            }
            else
            {
                Response.Write("<script>alert('Book does not exists');</script>");

            }
        }

        // delete button
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfBookExists())
            {
                deleteBook();
            }
            else
            {                
                Response.Write("<script>alert('Book does not exists');</script>");

            }
        }


        // user define functions

        void updateBook()
        {
            if (checkIfBookExists())
            {
                try
                {
                    int actual_stock = Convert.ToInt32(TextBox5.Text.Trim());
                    int current_stock = Convert.ToInt32(TextBox6.Text.Trim());

                    if (global_actual_stock == actual_stock)
                    {

                    }
                    else
                    {
                        if (actual_stock < global_issued_books)
                        {
                            Response.Write("<script>alert('Actual Stock value cannot be less than the Issued books');</script>");
                            return;
                        }
                        else
                        {
                            current_stock = actual_stock - global_issued_books;
                            TextBox6.Text = "" + current_stock;
                        }
                    }





                    string genres = "";
                    foreach (int i in ListBox1.GetSelectedIndices())
                    {
                        genres = genres + ListBox1.Items[i] + ",";

                    }
                    genres = genres.Remove(genres.Length - 1);

                    string filepath = "~/book_inventory/books1";
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    if (filename == "" || filename == null)
                    {
                        filepath = global_filepath;
                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                        filepath = "~/book_inventory/" + filename;
                    }


                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE book_master_tbl SET book_name=@book_name, genre=@genre, author_name=@author_name, publisher_name=@publisher_name, publish_date=@publish_date, language=@language, edition=@edition, book_cost=@book_cost, no_of_pages=@no_of_pages, book_description=@book_description, actual_stock=@actual_stock, current_stock=@current_stock, book_img_link=@book_img_link  WHERE book_id='" + TextBox1.Text.Trim() + "' ", con);

                    cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());

                    cmd.Parameters.AddWithValue("@genre", genres);
                    cmd.Parameters.AddWithValue("@author_name", DropDownList4.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publisher_name", DropDownList3.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publish_date", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@edition", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_cost", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@no_of_pages", TextBox8.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_description", TextBox10.Text.Trim());
                    cmd.Parameters.AddWithValue("@actual_stock", actual_stock.ToString());
                    cmd.Parameters.AddWithValue("@current_stock", current_stock.ToString());
                    cmd.Parameters.AddWithValue("@book_img_link", filepath);





                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('Book Updated Successfully');</script>");


                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Book ID');</script>");
                //clearForm();
            }
        }



        void getBookByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl WHERE book_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if(dt.Rows.Count>=1)
                {
                    TextBox2.Text = dt.Rows[0]["book_name"].ToString();
                    DropDownList1.SelectedValue = dt.Rows[0]["language"].ToString();
                    DropDownList3.SelectedValue = dt.Rows[0]["publisher_name"].ToString();
                    DropDownList4.SelectedValue = dt.Rows[0]["author_name"].ToString();
                    TextBox14.Text = dt.Rows[0]["publish_date"].ToString();
                    TextBox3.Text = dt.Rows[0]["edition"].ToString();
                    TextBox4.Text = dt.Rows[0]["book_cost"].ToString().Trim();
                    TextBox8.Text = dt.Rows[0]["no_of_pages"].ToString().Trim();
                    TextBox5.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
                    TextBox6.Text = dt.Rows[0]["current_stock"].ToString().Trim();
                    TextBox10.Text = dt.Rows[0]["book_description"].ToString();
                    TextBox9.Text = "" + (Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString()) - Convert.ToInt32(dt.Rows[0]["current_stock"].ToString()));

                    ListBox1.ClearSelection();

                    string[] genre = dt.Rows[0]["genre"].ToString().Split(',');
                    for (int i = 0; i < genre.Length; i++)
                    {
                        for (int j = 0; j < ListBox1.Items.Count; j++)
                        {
                            if (ListBox1.Items[j].ToString() == genre[i])
                            {
                                ListBox1.Items[j].Selected = true;
                            }
                            
                        }
                    }

                    global_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
                    global_actual_stock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());
                    global_issued_books = global_actual_stock - global_current_stock;
                    global_filepath = dt.Rows[0]["book_img_link"].ToString();


                }
                else
                {
                    Response.Write("<script>alert('Invalid Book ID');</script>");
                }
            }
            catch (Exception ex)
            {

            }
        }







        void fillAuthorPublisherValues()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT author_name FROM author_master_tbl;", con);
                SqlDataAdapter da= new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList4.DataSource = dt;
                DropDownList4.DataValueField = "author_name";
                DropDownList4.DataBind();

                cmd = new SqlCommand("SELECT publisher_name FROM publisher_master_tbl;",con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                DropDownList3.DataSource = dt;
                DropDownList3.DataValueField = "publisher_name";
                DropDownList3.DataBind();

            }
            catch (Exception ex)
            {

            }
        }

        bool checkIfBookExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl WHERE book_id = '" + TextBox1.Text.Trim() + "' OR book_name ='"+TextBox2.Text.Trim()+"'; ", con);
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

                //con.Close();
                // Response.Write("<script>alert('Sign up succcessful. Go to User Login to Login');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }

        }



        void addNewBook()
        {
            try
            {
                string genres = "";
                foreach (int i in ListBox1.GetSelectedIndices())
                {
                    genres = genres + ListBox1.Items[i] + ",";
                }
                // genres = Adventure,Self Help,
                genres = genres.Remove(genres.Length - 1);

                string filepath = "~/bookinventory/books1.png";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("bookinventory/" + filename));
                filepath = "~/bookinventory/" + filename;


                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO book_master_tbl(book_id,book_name,genre,author_name,publisher_name,publish_date,language,edition,book_cost,no_of_pages,book_description,actual_stock,current_stock,book_img_link) values " +
                    "(@book_id,@book_name,@genre,@author_name,@publisher_name,@publish_date,@language,@edition,@book_cost,@no_of_pages,@book_description,@actual_stock,@current_stock,@book_img_link) ", con);

                cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());

                cmd.Parameters.AddWithValue("@genre", genres);
                cmd.Parameters.AddWithValue("@author_name", DropDownList4.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_name", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publish_date", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@no_of_pages", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@current_stock", TextBox5.Text.Trim());
               cmd.Parameters.AddWithValue("@book_img_link", filepath);


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Book added succcessful');</script>");
                //clearform();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void deleteBook()
        {
            if (checkIfBookExists())
            {

                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE FROM book_master_tbl WHERE book_id='" + TextBox1.Text.Trim() + "'", con);

                    //cmd.Parameters.AddWithValue("@author_id", TextBox1.Text.Trim());
                    //cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Book deleted Succcessfully');</script>");
                    //clearForm();
                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Invalid Book ID');</script>");
                //clearForm();
            }
        }

       

        //clearForm()
        //{

        //}

    }
}