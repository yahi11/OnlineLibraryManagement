<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminMemberManagement.aspx.cs" Inherits="OnlineLibraryManagement.AdminMemberManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <script type="text/javascript">
     $(document).ready(function () {
         $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
     });

     </script>

</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


        <div class="container-fluid">
        <div class="row">

            <div class="col-md-5">

                <div class="card">
                    <div class="card-body">

                        

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Member Details</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img class="mb-0" width="100px" src="images/generaluser.png" />
                                </center>
                            </div>
                        </div>

                

                        <div class="row mb-3">                         
                            <div class="col-md-3">
                                <label class="mb-1">Member ID</label>
                                <div class="mb-3">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control me-1" ID="TextBox1" runat="server" placeholder="Member ID"></asp:TextBox>
                                        <asp:LinkButton class="btn btn-success rounded-1"  ID="LinkButton1" runat="server" Text="Go" OnClick="LinkButton1_Click"><i class="fa-solid fa-circle-check"></i></asp:LinkButton>
                                    </div>                                    
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label class="mb-1">Full Name</label>
                                <div class="mb-3">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Full Name" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-5">
                                <label class="mb-1">Account Status</label>
                                <div class="mb-3">  
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control me-1" ID="TextBox7" runat="server" placeholder="Account Status" ReadOnly="True"></asp:TextBox>
                                        <asp:LinkButton class="btn btn-success me-1 rounded-1"  ID="LinkButton2" runat="server" Text="A" OnClick="LinkButton2_Click"><i class="fa-solid fa-circle-check"></i></asp:LinkButton>
                                        <asp:LinkButton class="btn btn-warning me-1 rounded-1"  ID="LinkButton3" runat="server" Text="P" OnClick="LinkButton3_Click"><i class="fa-sharp fa-solid fa-circle-pause"></i></asp:LinkButton>
                                        <asp:LinkButton class="btn btn-danger me-1 rounded-1"  ID="LinkButton4" runat="server" Text="D" OnClick="LinkButton4_Click"><i class="fa-solid fa-circle-xmark"></i></asp:LinkButton>
                                    </div>
                                    
                                </div>
                            </div>
                           
                        </div>


                        <div class="row mb-3">
                            
                            <div class="col-md-3">
                                <label class="mb-1">DOB</label>
                                <div class="mb-3">
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Date Of Birth" TextMode="Date" ReadOnly="True"></asp:TextBox>
                                </div>                                  
                            </div>

                            <div class="col-md-4">
                                <label class="mb-1">Contact Number</label>
                                <div class="mb-3">
                                        <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Contact Number" ReadOnly="True" TextMode="Number"></asp:TextBox>                                   
                                </div>
                            </div>

                            <div class="col-md-5">
                                <label class="mb-1">Email ID</label>
                                <div class="mb-3">
                                        <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="Email ID" ReadOnly="True" TextMode="Email"></asp:TextBox>                                   
                                </div>
                            </div>

                        </div>


                        <div class="row mb-3">
                            
                            <div class="col-md-4">
                                <label class="mb-1">District</label>
                                <div class="mb-3">
                                    <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="District" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label class="mb-1">City</label>
                                <div class="mb-3">
                                        <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="City" ReadOnly="True"></asp:TextBox>                                   
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label class="mb-1">Pin Code</label>
                                <div class="mb-3">
                                        <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="Pin Code" TextMode="Number" ReadOnly="True"></asp:TextBox>                                   
                                </div>
                            </div>
                        </div>

                        <div class="row mb-3">
                            <div class="col-md-12">
                                <label class="mb-1">Full Postal Address</label>
                                <div class="mb-3">
                                    <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="Full Postal Address" TextMode="MultiLine" ReadOnly="True" ></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-8 mx-auto">
                                <center>
                                    <div class="mb-3 d-grid ">                                                                       
                                       <asp:Button class="btn btn-danger btn-lg"  ID="Button2" runat="server" Text="Delete User Permanently" OnClick="Button2_Click" />
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
                                    <h4>Member List</h4>                                  
                                </center>
                            </div>
                        </div>
                 

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>


                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=DESKTOP-TDRMUC6\SQLEXPRESS;Initial Catalog=elibraryDB;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [member_master_tbl]"></asp:SqlDataSource>
                            <div class="col">

                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="member_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="member_id" HeaderText="Member ID" ReadOnly="True" SortExpression="member_id" />
                                        <asp:BoundField DataField="full_name" HeaderText="Name" SortExpression="full_name" />
                                        <asp:BoundField DataField="account_status" HeaderText="Account Status" SortExpression="account_status" />
                                        <asp:BoundField DataField="contact_no" HeaderText="Contact No" SortExpression="contact_no" />
                                        <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                                        <asp:BoundField DataField="state" HeaderText="State" SortExpression="state" />
                                        <asp:BoundField DataField="city" HeaderText="City" SortExpression="city" />
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
