<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="subadmin_index.aspx.cs" Inherits="subAdmin_subadmin_index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="background_check">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="bradcam_text text-center">
                        <h3 style="color:White;font-size:xx-large;">Work Portal</h3>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="service_area"  style ="padding:0px ; margin-top:20px;">
        <div class="container">
            <!--<div class="row justify-content-center ">
                <div class="col-xs-12 col-sm-12 col-lg-6 col-md-10">
                    <div class="section_title text-center mb-95">
                    </div>
                </div>
            </div>-->
            <div class="row justify-content-center">
                <div class="col-xs-12 col-sm-12 col-lg-4 col-md-6">
                    <div class="single_service">
                        <h5 class="text-center">Reassign Approval</h5>
                        <div id="resigndiv" runat="server" class="text-center" style="padding-top:10px;">
                            <!--<table class="table table-responsive table-hover" style="color:#FF5500">
                                <thead>
                                <tr>
                                    <th scope="col">Complaint No.</th>
                                    <th scope="col">Type</th>
                                    <th scope="col">Subject</th>
                                </tr>
                                </thead>
                                <tbody>
                                <tr>
                                    <th scope="row">1</th>
                                    <td>university</td>
                                    <td>Less Hygenic Wash Rooms</td>
                                </tr>
                                </tbody>
                            </table>-->
                        </div>
                    </div>
                </div>
                <div class="col-xs-12 col-sm-12 col-lg-4 col-md-6">
                    <div class="single_service">
                        <h5 class="text-center">Reappeal Approval</h5>
                        <div id="reappealdiv" runat="server" class="text-center" style="padding-top:10px;">
                            <!--<table class="table table-responsive table-hover" style="color:#FF5500">
                                <thead>
                                <tr>
                                    <th scope="col">Complaint No.</th>
                                    <th scope="col">Type</th>
                                    <th scope="col">Subject</th>
                                </tr>
                                </thead>
                                <tbody>
                                <tr>
                                    <th scope="row">1</th>
                                    <td>university</td>
                                    <td>Less Hygenic Wash Rooms</td>
                                </tr>
                                </tbody>
                            </table>-->
                        </div>                        
                    </div>
                </div>
                <div class="col-xs-12 col-sm-12 col-lg-4 col-md-6">
                    <div class="single_service">
                        <h5 class="text-center">Report Approval</h5>
                        <div id="reportdiv" runat="server" class="text-center" style="padding-top:10px;">
                            <!--<table class="table table-responsive table-hover" style="color:#FF5500">
                                <thead>
                                <tr>
                                    <th scope="col">Complaint No.</th>
                                    <th scope="col">Type</th>
                                    <th scope="col">Subject</th>
                                </tr>
                                </thead>
                                <tbody>
                                <tr>
                                    <th scope="row">1</th>
                                    <td>university</td>
                                    <td>Less Hygenic Wash Rooms</td>
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

