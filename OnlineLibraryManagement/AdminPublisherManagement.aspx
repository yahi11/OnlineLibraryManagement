<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminPublisherManagement.aspx.cs" Inherits="OnlineLibraryManagement.AdminPublisherManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
    $(document).ready(function () {
        $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
    });

    </script>

</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="container">
        <div class="row">

            <div class="col-md-5">

                <div class="card">
                    <div class="card-body">

                        

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Publisher Details</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img class="mb-0" width="100px" src="images/publisher.png" />
                                </center>
                            </div>
                        </div>

                

                        <div class="row mb-3">
                            <div class="col-md-4">
                                <label class="mb-1">Publisher ID</label>
                                <div class="mb-3">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="ID"></asp:TextBox>
                                        <asp:Button class="btn btn-success"  ID="Button4" runat="server" Text="Go" OnClick="Button4_Click" />
                                    </div>
                                    
                                </div>
                            </div>

                            <div class="col-md-8">
                                <label class="mb-1">Publisher Name</label>
                                <div class="mb-3">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Publisher Name"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">

                            <div class="col-4">
                                <center>
                                    <div class="mb-3 d-grid ">                                                                       
                                       <asp:Button class="btn btn-success btn-lg"  ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" />
                                    </div>
                                </center>                                
                            </div>


                            <div class="col-4">
                                <center>
                                    <div class="mb-3 d-grid ">                                                                       
                                       <asp:Button class="btn btn-primary btn-lg"  ID="Button2" runat="server" Text="Update" OnClick="Button2_Click" />
                                    </div>
                                </center>                                
                            </div>


                            <div class="col-4">
                                <center>
                                    <div class="mb-3 d-grid ">                                                                       
                                       <asp:Button class="btn btn-danger btn-lg"  ID="Button3" runat="server" Text="Delete" OnClick="Button3_Click" />
                                    </div>
                                </center>                                
                            </div>
                        </div>




                    </div>
                </div>

                <a href="Homepage.aspx"><< Back To Home</a><br /><br />
            </div>


            <div class="col-md-7">

                <div class="card">
                    <div class="card-body">


                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Publisher List</h4>                                  
                                </center>
                            </div>
                        </div>
                 

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>


                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=DESKTOP-TDRMUC6\SQLEXPRESS;Initial Catalog=elibraryDB;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [publisher_master_tbl]"></asp:SqlDataSource>
                            <div class="col">

                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="publisher_id">
                                    <Columns>
                                        <asp:BoundField DataField="publisher_id" HeaderText="publisher_id" ReadOnly="True" SortExpression="publisher_id" />
                                        <asp:BoundField DataField="publisher_name" HeaderText="publisher_name" SortExpression="publisher_name" />
                                    </Columns>
                                </asp:GridView>

                            </div>
                        </div>




                    </div>
                </div>

            </div>




        </div>
    </div>





</asp:Content>
