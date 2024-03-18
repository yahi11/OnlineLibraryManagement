<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserSignUp.aspx.cs" Inherits="OnlineLibraryManagement.UserSignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
    <div class="row">
        <div class="col-md-8 mx-auto">

            <div class="card">
                <div class="card-body">

                    <div class="row">
                        <div class="col">
                            <center>
                                <img class="mb-2" width="100px" src="images/generaluser.png" />
                            </center>
                        </div>
                    </div>


                    <div class="row">
                        <div class="col">
                            <center>
                                <h4>User Registration</h4>
                            </center>
                        </div>
                    </div>


                    <div class="row">
                        <div class="col">
                            <hr>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6">
                            <label class="mb-1">Full Name</label>
                            <div class="mb-3">
                                <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Full Name"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <label class="mb-1">Date Of Birth</label>
                            <div class="mb-3">
                                <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Date Of Birth" TextMode="Date"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6">
                            <label class="mb-1">Contact Number</label>
                            <div class="mb-3">
                                <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Contact Number" TextMode="Number" ></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <label class="mb-1">Email ID</label>
                            <div class="mb-3">
                                <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Email ID" TextMode="Email"></asp:TextBox>
                            </div>
                        </div>
                    </div>


                    <div class="row">
                        <div class="col-md-4">
                            <label class="mb-1">District</label>
                            <div class="mb-3">
                                <asp:DropDownList Class="form-control" ID="DropDownList1" runat="server" >

                                    <asp:ListItem Text="Select" Value="Select" />
                                    <asp:ListItem Text="Colombo" Value="Colombo" />
                                    <asp:ListItem Text="Kaluthara" Value="Kaluthara" />
                                    <asp:ListItem Text="Gampaha" Value="Gampaha" />
                                    <asp:ListItem Text="Kandy" Value="Kandy" />
                                    <asp:ListItem Text="Matale" Value="Matale" />
                                    <asp:ListItem Text="Nuwara Eliye" Value="Nuwara Eliye" />
                                    <asp:ListItem Text="Galle" Value="Galle" />
                                    <asp:ListItem Text="Matara" Value="Matara" />
                                    <asp:ListItem Text="Hambanthota" Value="Hambanthota" />
                                    <asp:ListItem Text="Jaffna" Value="Jaffna" />
                                    <asp:ListItem Text="Kilinochchi" Value="Kilinochchi" />
                                    <asp:ListItem Text="Mannar" Value="Mannar" />
                                    <asp:ListItem Text="Vavuniya" Value="Vavuniya" />
                                    <asp:ListItem Text="Mullaitivu" Value="Mullaitivu" />
                                    <asp:ListItem Text="Batticaloa" Value="Batticaloa" />
                                    <asp:ListItem Text="Ampara" Value="Ampara" />
                                    <asp:ListItem Text="Trincomalee" Value="Trincomalee" />
                                    <asp:ListItem Text="Kurunegala" Value="Kurunegala" />
                                    <asp:ListItem Text="Puttalam" Value="Puttalam" />
                                    <asp:ListItem Text="Anuradhapura" Value="Anuradhapura" />
                                    <asp:ListItem Text="Polonnaruwa" Value="Polonnaruwa" />
                                    <asp:ListItem Text="Badulla" Value="Badulla" />
                                    <asp:ListItem Text="Moneragala" Value="Moneragala" />
                                    <asp:ListItem Text="Rathnapura" Value="Rathnapura" />
                                    <asp:ListItem Text="Kegalle" Value="Kegalle" />

                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-md-4">
                            <label class="mb-1">City</label>
                            <div class="mb-3">
                                <asp:TextBox Class="form-control" ID="TextBox6" runat="server" placeholder="City" ></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-4">
                            <label class="mb-1">Pincode</label>
                            <div class="mb-3">
                                <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="Pincode" TextMode="Number"></asp:TextBox>
                            </div>
                        </div>
                    </div>



                    <div class="row">
                        <div class="col-md-12">
                            <label class="mb-1">Full Address</label>
                            <div class="mb-4">
                                <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Full Address" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col mb-3">   
                            <center>
                                <span class="badge rounded-pill text-bg-info">Login Credentials</span>
                            </center>                               
                        </div>
                    </div>


                    <div class="row">
                        <div class="col-md-6">
                            <label class="mb-1">Member ID</label>
                            <div class="mb-3">
                                <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="User ID"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <label class="mb-1">Password</label>
                            <div class="mb-3">
                                <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                    </div>



                    <div class="row">
                        <div class="col">                                                                                         
                            <div class="mb-2 d-grid gap-2 ">                                                                       
                                   <asp:Button class="btn btn-success btn-lg"  ID="Button2" runat="server" Text="Sign Up" OnClick="Button2_Click"  />
                            </div>
                        </div>
                    </div>




                </div>
            </div>

            <a href="Homepage.aspx"><< Back To Home</a><br /><br />

        </div>
    </div>
</div>





</asp:Content>
