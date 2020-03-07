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
                         <div class="service_content text-center" id="tableDiv" >
                         <label style="font-size:x-large;">Unsolved Complaint</label>
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
                                    </table>
                                 <div class="row justify-content-center mt-3">
                                 <a href="contact.html" class="boxed-btn4" style="  background: #ff3500;color: #fff;border: 1px solid #ff3500;">Login</a>
                               </div>
                         </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>

