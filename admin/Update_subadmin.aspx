<%@ Page Title="Update Subadmin" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Update_subadmin.aspx.cs" Inherits="admin_Update_subadmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"/>
    <div class="background_check">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="bradcam_text text-center">
                        <h3 style="color:White; font-size:xx-large;font-family: 'Poppins', sans-serif;">Update SubAdmin</h3>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="service_area" style ="padding:0px ; margin:0px;">
                <div class="container">            
                    <div class="row justify-content-center">
                        <div class="col-lg-8 col-md-10  p-3 mb-5 " style="margin-top:0px;">
                            <div class="single_service active">
                                <div class="row justify-content-center">
                                    <div class="col-lg-12 col-md-12 col-xs-12 mt-3">
                                        <div class="row">
                                            <div class="col mt-3">
                                                <label for="AvailableSubadmin" style="font-weight:bold;padding-left:10px;">Available Subadmin</label>
                                                <asp:DropDownList ID="AvailableSubadmin" class="form-control" runat="server" 
                                                    onselectedindexchanged="AvailableSubadmin_SelectedIndexChanged" AutoPostBack="true">
                                                    <asp:ListItem Value="Select Subadmin" Text="Select Subadmin"></asp:ListItem>
                                                </asp:DropDownList>  
                                            </div>
                                        </div>
                                        <div class="row mt-3">
                                            <div class="col">
                                                <asp:TextBox ID="First" class="form-control" placeholder="First name" CssClass="form-control" runat="server" pattern="[A-Za-z ]+" required="true" title="Alphabets only" Enabled="false"></asp:TextBox>
                                             </div>
                                            <div class="col">
                                                <asp:TextBox ID="Last" class="form-control" placeholder="Last name" CssClass="form-control" runat="server" pattern="[A-Za-z ]+" required="true" title="Alphabets only" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row mt-3">
                                            <div class="col">
                                                <asp:TextBox ID="CategoryText" class="form-control" placeholder="Category" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                             </div>                                                            
                                            <div class="col">                
                                                <asp:TextBox ID="Email" class="form-control" placeholder="Email Address" CssClass="form-control" runat="server" pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$" required="true" title="Enter valid email address" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row mt-3 ">
                                            <div class="col">
                                                <asp:TextBox ID="Password" class="form-control" name="pass" placeholder="Password" CssClass="form-control" TextMode="password" runat="server" pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}" required="true" title="Must contain at least one  number and one uppercase and lowercase letter, and at least 8 or more characters" Enabled="false"></asp:TextBox>
                                             </div>
                                            <div class="col">
                                                <asp:TextBox ID="Confirm"  class="form-control" name="conf" placeholder="Confirm Password" CssClass="form-control" TextMode="password" runat="server" pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}" required="true" title="Must contain at least one  number and one uppercase and lowercase letter, and at least 8 or more characters" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row justify-content-center mt-5">
                                            <asp:Button class="btn boxed-btn4" CssClass="btn boxed-btn4" style="background: #ff3500;color: #fff;border: 1px solid #ff3500;" runat="server" id="UpdateButton" Enabled="false" Text="Update SubAdmin">
                                            </asp:Button>
                                            <button class="btn btn-primary btn-lg" id="btnTrigger" data-toggle="modal" data-target="#myModal1" style="display:none;">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ChangeButton" EventName="ServerClick" />
        </Triggers>
    </asp:UpdatePanel>
    <div class="modal fade" id="myModal1" tabindex="-1" role="dialog" aria-labelledby="myModalLabel4" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="myModalLabel4">Confirm your action </h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <h3>Are you sure you want to approve the request?</h3>
                </div>
                <div class="modal-footer">
                    <button id="ChangeButton" type="button" class="btn btn-primary" data-dismiss="modal" runat="server" onserverclick="Change_Click">Yes</button>
                    <button type="button" class="btn btn-default" data-dismiss="modal">No</button>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('form').on("submit", function () {
                var pass = $("#ContentPlaceHolder1_Password").val();
                var confirm = $("#ContentPlaceHolder1_Confirm").val();
                var n = pass.localeCompare(confirm);
                if (n == 0) {
                    $('#btnTrigger').click();
                }
                else {
                    $('#Password').val = "";
                    $('#Confirm').val = "";
                    alert("Password doesn't match confirm password");
                }
            });
        });
    </script>
</asp:Content>

