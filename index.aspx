﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <!-- slider_area_start -->
    <div class="slider_area">
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
                <img src="img/banner/complaint.png" alt="">
            </div>
        </div>
    </div>
    <!-- slider_area_end -->

    <!-- service_area_start  -->
    <div class="service_area">
        <div class="container">
            <div class="row justify-content-center ">
                <div class="col-lg-7 col-md-10">
                    <div class="section_title text-center mb-95">
                        <h3>Want to complaint, yes you can</h3>
                        <p>Student will able to complaint at department level, institute level and univesity level.</p>
                    </div>
                </div>
            </div>
            <div class="row justify-content-center">
                <div class="col-lg-4 col-md-6">
                    <div class="single_service">
                         <div class="service_thumb service_icon_bg_1 d-flex align-items-center justify-content-center">
                             <div class="service_icon">
                                 <img src="img/service/department.png" alt="">
                             </div>
                         </div>
                         <div class="service_content text-center">
                            <h3>Department</h3>
                            <p>Here studuent can able to complaint at department level as well as there sub categories.</p>
                         </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6">
                    <div class="single_service active">
                         <div class="service_thumb service_icon_bg_1 d-flex align-items-center justify-content-center">
                             <div class="service_icon">
                                 <img src="img/service/institute.png" alt=""/>
                             </div>
                         </div>
                         <div class="service_content text-center">
                            <h3>Institute Level</h3>
                            <p>Here studuent can able to complaint at institute level as well as there sub categories.</p>
                         </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6">
                    <div class="single_service">
                         <div class="service_thumb service_icon_bg_1 d-flex align-items-center justify-content-center">
                             <div class="service_icon">
                                 <img src="img/service/university.png" alt="">
                             </div>
                         </div>
                         <div class="service_content text-center">
                            <h3>University Level</h3>
                            <p>Here studuent can able to complaint at university level as well as there sub categories.</p>
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
                            <h3><span>track complaint</span>
                                status</h3>
                            <p>This selection provide the checking the status of complaint which you regiser with us.</p>
                            <a href="track_complaint.aspx" class="boxed-btn3">Track Complaint</a>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="adapt_about">
                        <div class="row align-items-center">
                            <div class="col-lg-6 col-md-6">
                                <div class="single_adapt text-center">
                                    <img src="img/adapt_icon/department1.png" alt="">
                                    <div class="adapt_content">
                                        <h3 class="counter">452</h3>
                                        <p>Department Complaint</p>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-6">
                                <div class="single_adapt text-center">
                                    <img src="img/adapt_icon/institute1.png" alt="">
                                    <div class="adapt_content">
                                        <h3><span class="counter">52</span>+</h3>
                                        <p>Institute Complaint</p>
                                    </div>
                                </div>
                                <div class="single_adapt text-center">
                                    <img src="img/adapt_icon/university1.png" alt="">
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

