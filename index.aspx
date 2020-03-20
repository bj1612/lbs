<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="~/index.aspx.cs" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="background_check">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="bradcam_text text-center">
                        <h3 style="color:White;font-size:xx-large;">Welcome to Student Review System</h3>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <!-- slider_area_start -->
    <div class="slider_area" style="display:none;">
        <div class="single_slider slider_bg_1 d-flex align-items-center">
            <div class="container">
                <div class="row">
                    <div class="col-lg-5 col-md-6">
                        <div class="slider_text">
                            <h3>We Care <br> <span>Your Pets</span></h3>
                            <p>Lorem ipsum dolor sit amet, consectetur <br> adipiscing elit, sed do eiusmod.</p>
                            <a href="contact.html" class="boxed-btn4">Contact Us</a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="dog_thumb d-none d-lg-block">
                <img src="/lbs/img/banner/complaint.png" alt="" />
            </div>
        </div>
    </div>
    <!-- slider_area_end -->

    <!-- service_area_start  -->
    <div class="service_area">
        <div class="container">
            <div class="row justify-content-center ">
                <div class="col-lg-7 col-md-12">
                    <div class="section_title text-center mb-95">
                        <h3>Want to share your review, yes you can</h3>
                        <p>Student will able to share review at department level, institute level and univesity level.</p>
                    </div>
                </div>
            </div>
            <div class="row justify-content-center">
                <div class="col-lg-4 col-md-6">
                    <div class="single_service">
                         <div class="service_thumb service_icon_bg_1 d-flex align-items-center justify-content-center">
                             <div class="service_icon">
                                 <img src="/lbs/img/service/department.png" alt="" />
                             </div>
                         </div>
                         <div class="service_content text-center">
                            <h3>Department</h3>
                            <p>Here student can able to share review at department level as well as there sub categories.</p>
                         </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6">
                    <div class="single_service active">
                         <div class="service_thumb service_icon_bg_1 d-flex align-items-center justify-content-center">
                             <div class="service_icon">
                                 <img src="/lbs/img/service/institute.png" alt="" />
                             </div>
                         </div>
                         <div class="service_content text-center">
                            <h3>Institute Level</h3>
                            <p>Here student can able to review at institute level as well as there sub categories.</p>
                         </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6">
                    <div class="single_service">
                         <div class="service_thumb service_icon_bg_1 d-flex align-items-center justify-content-center">
                             <div class="service_icon">
                                 <img src="/lbs/img/service/university.png" alt="" />
                             </div>
                         </div>
                         <div class="service_content text-center">
                            <h3>University Level</h3>
                            <p>Here student can able to share review at university level as well as there sub categories.</p>
                         </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- service_area_end -->


    <!-- adapt_area_start  -->
    <div class="adapt_area">
        <div class="container">
            <div class="row justify-content-between align-items-center">
                <div class="col-lg-5">
                    <div class="adapt_help">
                        <div class="section_title">
                            <h3><span>Track complaint</span>
                                status</h3>
                            <p>This section provide the checking the status of complaint which you register with us.</p>
                            <a href="/lbs/student/track_complaint.aspx" class="boxed-btn3">Track Complaint</a>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="adapt_about">
                        <div class="row align-items-center">
                            <div class="col-lg-6 col-md-6">
                                <div class="single_adapt text-center">
                                    <img src="/lbs/img/adapt_icon/department1.png" alt="" />
                                    <div class="adapt_content">
                                        <h3 class="counter">452</h3>
                                        <p>Department Complaint</p>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-6">
                                <div class="single_adapt text-center">
                                    <img src="/lbs/img/adapt_icon/institute1.png" alt="" />
                                    <div class="adapt_content">
                                        <h3><span class="counter">52</span>+</h3>
                                        <p>Institute Complaint</p>
                                    </div>
                                </div>
                                <div class="single_adapt text-center">
                                    <img src="/lbs/img/adapt_icon/university1.png" alt="" />
                                    <div class="adapt_content">
                                        <h3><span class="counter">52</span>+</h3>
                                        <p>University Complaint</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- adapt_area_end  -->   
</asp:Content>

