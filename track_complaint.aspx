<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="track_complaint.aspx.cs" Inherits="track_complaint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- bradcam_area_start -->
    <div class="bradcam_area1 breadcam_bg">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="bradcam_text text-center">
                        <h3 style="color:White;font-size:xx-large;">Track your complaint status</h3>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <!-- bradcam_area_end -->
    <div class="service_area"  style ="padding:0px ; margin:0px;">
        <div class="container">
            <div class="row justify-content-center ">
                <div class="col-lg-7 col-md-10">
                    <div class="section_title text-center mb-95">
                    </div>
                </div>
            </div>
            <div class="row justify-content-center">
                <div class="col-lg-6 col-md-8">
                    <div class="single_service">
                         <div class="service_thumb service_icon_bg_1 d-flex align-items-center justify-content-center">
                         </div>
                         <div class="service_content text-center">  
                         </div>
                    </div>
                </div>
                <div class="col-lg-6 col-md-8">
                    <div class="single_service active">
                         <div class="service_content text-center" id="tableDiv" runat="server" >
                            <div class="row justify-content-center mt-3" runat="server">
                                <asp:Button ID="Button1" runat="server" Text="Login" onclick="Button1_Click" />
                            </div>
                            <!--<asp:Table ID="Table1" runat="server" Height="123px" Width="567px" class="table table-hover mt-0">
                                <asp:TableRow ID="TableRow1" runat="server" style="background-color: #f88017; color: white;">
                                    <asp:TableCell ID="TableCell1" runat="server">Complaint</asp:TableCell>
                                    <asp:TableCell ID="TableCell2" runat="server">Subject</asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow ID="TableRow2" runat="server">
                                    <asp:TableCell ID="TableCell4" runat="server">1</asp:TableCell>
                                    <asp:TableCell ID="TableCell5" runat="server">Mark</asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>-->
                            <!--<label style="font-size:x-large;">Unsolved Complaint</label>
                            <table class="table table-hover mt-0">
                                <thead style="background-color: #f88017; color: white;">
                                <tr>
                                    <th scope="col">Complaint Id</th>
                                    <th scope="col">Subject</th>
                                </tr>
                                </thead>
                                <tbody>
                                <tr>
                                    <th scope="row">1</th>
                                    <td>Mark</td>

                                </tr>
                                </tbody>
                            </table>-->
                         </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>

