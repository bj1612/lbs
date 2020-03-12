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
                        <h5 class="text-center">Pending Complaint</h5>
                        <table class="table table-hover" style="color:#FF5500">
                            <thead>
                            <tr>
                                <th scope="col">Complaint No.</th>
                                <th scope="col">Subject</th>
                            </tr>
                            </thead>
                            <tbody>
                            <tr>
                                <th scope="row">1</th>
                                <td></td>
                            </tr>
                            </tbody>
                        </table>
                    </div>
                   
                </div>
                <div class="col-lg-6 col-md-8">
                    <div class="single_service">
                    <h5 class="text-center">Completed Complaint</h5>
                        <table class="table table-hover" style="color:#FF5500">
                            <thead>
                            <tr>
                                <th scope="col">Complaint No.</th>
                                <th scope="col">Subject</th>
                            </tr>
                            </thead>
                            <tbody>
                            <tr>
                                <th scope="row">1</th>
                                <td>Unable to fill KT form, since delay in revaluation results</td>
                            </tr>
                            </tbody>
                        </table>
                    </div>
                </div>

            </div>
        </div>
    </div>

</asp:Content>

