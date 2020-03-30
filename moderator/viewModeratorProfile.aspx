<%@ Page Title="Moderator Profile" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="~/moderator/viewModeratorProfile.aspx.cs" Inherits="viewModeratorProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- bradcam_area_start -->
    <div class="background_check">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="bradcam_text text-center">
                        <h3 style="color:White;font-size:xx-large;">View Moderator Profile</h3>
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
                                <label for="First" style="font-weight:bold;padding-left:10px;">First Name</label>
                                <asp:TextBox ID="First" class="form-control" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col">
                                <label for="Last" style="font-weight:bold;padding-left:10px;">Last Name</label>
                                <asp:TextBox ID="Last" class="form-control"  runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mt-3 ">
                            <div class="col">  
                                <label for="Email" style="font-weight:bold;padding-left:10px;">Email Address</label>              
                                <asp:TextBox ID="Email" class="form-control"  runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mt-3 ">
                            <div class="col">  
                                <label for="CompleteNo" style="font-weight:bold;padding-left:10px;">Completed Complaints</label>              
                                <asp:TextBox ID="CompleteNo" class="form-control"  runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col">  
                                <label for="TotalNo" style="font-weight:bold;padding-left:10px;">Assigned Complaints</label>              
                                <asp:TextBox ID="TotalNo" class="form-control"  runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col">  
                                <label for="Status" style="font-weight:bold;padding-left:10px;">Status</label>              
                                <asp:TextBox ID="Status" class="form-control"  runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

