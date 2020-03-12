<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="adminlogin.aspx.cs" Inherits="admin_adminlogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- bradcam_area_start -->
    <div class="bradcam_area1 breadcam_bg">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="bradcam_text text-center">
                        <h3 style="color:White; font-size:xx-large;">Admin Login!</h3>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <!-- bradcam_area_end -->
     <div class="service_area" style ="padding:0px ; margin:0px;">
        <div class="container">            
            <div class="row justify-content-center">
                <div class="col-lg-6 col-md-8  p-3 mb-5 " style="margin-top:0px;">
                    <div class="single_service active">
                            <div class="row mt-3 ">
                                <div class="col">
                                    <asp:TextBox class="form-control" placeholder="Email" ID="Email" runat="server"></asp:TextBox>
                                 </div>
                            </div>
                            <div class="row mt-3 ">
                                <div class="col">
                                    <asp:TextBox ID="Password" class="form-control" placeholder="Password"  TextMode="password" runat="server"></asp:TextBox>
                                 </div>
                            </div>
                                <div class="row justify-content-center mt-3">
                                    <asp:LinkButton Text="Login" href="contact.html" class="boxed-btn4" style="  background: #ff3500;color: #fff;border: 1px solid #ff3500;" runat="server" ID="Login"></asp:LinkButton>
                                </div>
                           </div>
                    </div>
                </div>
             </div>
        </div>

</asp:Content>

