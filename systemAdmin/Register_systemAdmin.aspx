<%@ Page Title="Register System Admin" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="~/systemAdmin/Register_systemAdmin.aspx.cs" Inherits="Register_systemAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="updatepanel" runat="server" />
<div class="background_check">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="bradcam_text text-center">
                        <h3 style="color:White;font-size:xx-large;">Registration Page For System Admin!</h3>
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
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                            <div class="row">
                                <div class="col">
                                    <asp:TextBox ID="First" class="form-control" placeholder="First name" runat="server" pattern="[A-Za-z]+" required="true" title="Alphabets only"></asp:TextBox>
                                 </div>
                                <div class="col">
                                    <asp:TextBox ID="Last" class="form-control" placeholder="Last name" runat="server" pattern="[A-Za-z]+" required="true" title="Alphabets only"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row mt-3 ">                                                            
                                <div class="col">                
                                    <asp:TextBox ID="Email" class="form-control" placeholder="Email Address" runat="server" pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$" required="true" title="Enter valid email address"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row mt-3 ">
                                <div class="col">
                                    <asp:TextBox ID="Password" class="form-control" placeholder="Password"  TextMode="password" runat="server" pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}" required="true" title="Must contain at least one  number and one uppercase and lowercase letter, and at least 8 or more characters"></asp:TextBox>
                                 </div>
                                <div class="col">
                                    <asp:TextBox ID="Confirm"  class="form-control" placeholder="Confirm Password" TextMode="password" runat="server" pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}" required="true" title="Must contain at least one  number and one uppercase and lowercase letter, and at least 8 or more characters"></asp:TextBox>
                                </div>
                            </div>                       
                             <div class="row justify-content-center mt-3">
                                   <asp:Button Text="Register" class="btn boxed-btn4" 
                                       style="  background: #ff3500;color: #fff;border: 1px solid #ff3500;" 
                                       runat="server" ID="Register" onclick="Register_Click"></asp:Button>
                             </div>
                             
                            </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="Register" EventName="Click" />
                                </Triggers>
                           </asp:UpdatePanel>
                      </div>
                </div>
              
            </div>
        </div>
    </div>
</asp:Content>

