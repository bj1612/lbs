<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="LoginScriptManager1" runat="server"/>
    <div class="background_check">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="bradcam_text text-center">
                        <h3 style="color:White; font-size:xx-large;">Change Password</h3>
                    </div>
                </div>
            </div>

        </div>
    </div>

    <div class="service_area" style ="padding:0px ; margin:0px;">
        <div class="container">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>           
                    <div class="row justify-content-center">
                        <div class="col-lg-6 col-md-8  p-3 mb-5 " style="margin-top:0px;">
                            <div class="single_service active">
                                <div class="row mt-3 ">
                                    <div class="col">
                                        <asp:TextBox class="form-control" placeholder="Current Password" ID="CurrentPassword" TextMode="password" runat="server" required="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row mt-3 ">
                                    <div class="col">
                                        <asp:TextBox ID="NewPassword" class="form-control" placeholder="New Password" TextMode="password" runat="server" required="true" pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}" title="Must contain at least one  number and one uppercase and lowercase letter, and at least 8 or more characters"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row mt-3 ">
                                    <div class="col">
                                        <asp:TextBox ID="ConfirmNewPassword" class="form-control" placeholder="Confirm New Password" TextMode="password" runat="server" required="true" pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}" title="Must contain at least one  number and one uppercase and lowercase letter, and at least 8 or more characters"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row justify-content-center mt-3">
                                    <asp:Button Text="Login" class="btn boxed-btn4" 
                                        style="background: #ff3500;color: #fff;border: 1px solid #ff3500;" 
                                        runat="server" ID="Change" onclick="Change_Click"></asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Change" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>

