<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous" />

    <script type="text/javascript">
        function ClickButtonTrigger() {
            var btnTrigger = document.getElementById("ContentPlaceHolder1_btnTrigger");
            btnTrigger.click();
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="LoginScriptManager1" runat="server"/>
    <!-- bradcam_area_start -->
    <div class="background_check">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="bradcam_text text-center">
                        <h3 style="color:White; font-size:xx-large;">Login!</h3>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <!-- bradcam_area_end -->

     <div class="service_area" style ="padding:0px ; margin:0px;">
        <div class="container">
            <asp:UpdatePanel ID="LoginUpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>           
                    <div class="row justify-content-center">
                        <div class="col-lg-6 col-md-8  p-3 mb-5 " style="margin-top:0px;">
                            <div class="single_service active">
                                    <div class="row mt-3 ">
                                        <div class="col">
                                            <asp:TextBox class="form-control" placeholder="Email" ID="Email" runat="server" required="true"></asp:TextBox>
                                         </div>
                                    </div>
                                    <div class="row mt-3 ">
                                        <div class="col">
                                            <asp:TextBox ID="Password" class="form-control" placeholder="Password"  TextMode="password" runat="server" required="true"></asp:TextBox>
                                         </div>
                                    </div>
                                        <div class="row justify-content-center mt-3">
                                            <asp:Button Text="Login" class="btn boxed-btn4" CssClass="btn boxed-btn4" 
                                                style="background: #ff3500;color: #fff;border: 1px solid #ff3500;" 
                                                runat="server" ID="Login" onclick="Login_Click"></asp:Button>
                                            <button class="btn btn-primary btn-lg" id="btnTrigger" data-toggle="modal" data-target="#myModal1" style="display:none;" runat="server"/>
                                        </div>
                                   </div>
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Login" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
          </div>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="modal fade" id="myModal1" tabindex="-1" role="dialog" aria-labelledby="myModalLabel4" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="myModalLabel4">Select Your Account Type</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col">
                                    <h5>Which account would you like to login?</h5>
                                </div>
                            </div>
                            <div class="row mt-3">
                                <div class="col">
                                    <asp:DropDownList ID="userradiolist" runat="server" EnableViewState="true" CssClass="form-control">
                                        <asp:ListItem Value="Select Account Type" Text="Select Account Type"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button id="LoginButton" type="button" class="btn btn-primary" data-dismiss="modal" runat="server" onserverclick="LoginButton_Click">Login</button>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Login" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

