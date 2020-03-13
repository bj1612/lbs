<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="adminlogin.aspx.cs" Inherits="admin_adminlogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="bradcam_area1 breadcam_bg">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="bradcam_text text-center">
                        <h3 style="color:White;font-size:xx-large;">Registration Page For Moderator!</h3style></h3>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <!-- bradcam_area_end -->
       <div class="service_area" style ="padding:0px ; margin:0px;">
        <div class="container">            
            <div class="row justify-content-center">
                
                <div class="col-lg-8 col-md-10  p-3 mb-5 " style="margin-top:0px;">
                    <div class="single_service active">
                            <div class="row">
                                <div class="col">
                                    <asp:TextBox ID="First" class="form-control" placeholder="First name" runat="server"></asp:TextBox>
                                 </div>
                                <div class="col">
                                    <asp:TextBox ID="Last" class="form-control" placeholder="Last name" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row mt-3 ">
                                <div class="col">
                                    <asp:TextBox ID="Contact" class="form-control" placeholder="Contact Number " runat="server"></asp:TextBox>
                                 </div>                                                            
                                <div class="col">                
                                    <asp:TextBox ID="Email" class="form-control" placeholder="Email Adrress" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row mt-3 ">
                                <div class="col">
                                    <asp:TextBox ID="Password" class="form-control" placeholder="Password"  TextMode="password" runat="server"></asp:TextBox>
                                 </div>
                                <div class="col">
                                    <asp:TextBox ID="Confirm"  class="form-control" placeholder="Confirm Password" TextMode="password" runat="server"></asp:TextBox>
                                </div>
                            </div>                       
                             <div class="row justify-content-center mt-3">
                                   <asp:LinkButton Text="Register" href="contact.html" class="boxed-btn4" style="  background: #ff3500;color: #fff;border: 1px solid #ff3500;" runat="server" ID="Login"></asp:LinkButton>
                             </div>
                      </div>
                </div>
              
            </div>
        </div>
    </div>
</asp:Content>

