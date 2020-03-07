<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- bradcam_area_start -->
    <div class="bradcam_area breadcam_bg">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="bradcam_text text-center">
                        <h3>New Here? Sign up!</h3>
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
                                    <input type="text" class="form-control" placeholder="First name">
                                 </div>
                                <div class="col">
                                    <input type="text" class="form-control" placeholder="Last name">
                                </div>
                            </div>
                            <div class="row mt-3 ">
                                <div class="col">
                                    <input type="text" class="form-control" placeholder="Contact Number ">
                                 </div>                                                            
                                <div class="col">
                                    <input type="text" class="form-control" placeholder="Email Adrress">
                                </div>
                            </div>
                            <div class="row mt-3 ">
                                <div class="col">
                                    <input type="text" class="form-control" placeholder="User Name">
                                 </div>
                                <div class="col">
                                    <input type="text" class="form-control" placeholder="Password">
                                 </div>
                                <div class="col">
                                    <input type="text" class="form-control" placeholder="Confirm Password">
                                </div>
                            </div>
                             <div class="row mt-3 ">
                                <div class="col">
                                   <select id="inputState" class="form-control">
                                        <option disabled selected>College Name</option>
                                        <option>college1</option>
                                        <option>college2</option>
                                        <option>college3</option>
                                        <option>college4</option>
                                  </select>
                                </div>
                                <div class="col">
                                   <select id="Select1" class="form-control">
                                        <option disabled selected>Department Name</option>
                                        <option>Department1</option>
                                        <option>Department2</option>
                                        <option>Department3</option>
                                        <option>Department4</option>
                                  </select>
                                </div>
                                <div class="col">
                                   <select id="Select2" class="form-control">
                                        <option disabled selected>University Name</option>
                                        <option>University1</option>
                                        <option>University2</option>
                                        <option>University3</option>
                                        <option>University4</option>
                                  </select>
                                </div>
                             </div>
                             <div class="row mt-3 ">
                                <div class="col">
                                   <select id="Select3" class="form-control">
                                        <option disabled selected>Addmition Year</option>
                                        <option>2020</option>
                                        <option>2019</option>
                                        <option>2018</option>
                                        <option>2017</option>
                                        <option>2016</option>
                                  </select>
                                </div>
                                <div class="col">
                                   <select id="Select4" class="form-control">
                                        <option disabled selected>Current Year</option>
                                        <option>2020</option>
                                        <option>2019</option>
                                        <option>2018</option>
                                        <option>2017</option>
                                        <option>2016</option>
                                  </select>
                                </div>
                              </div>
                             <div class="row mt-3 ">
                                <div class="col">
                                   <select id="Select5" class="form-control">
                                        <option disabled selected>Shift</option>
                                        <option>First Shift</option>
                                        <option>Second Shift</option>
                                    </select>
                                </div>
                                <div class="col">
                                    <input type="text" class="form-control" placeholder="Roll Number ">
                                 </div>                                                            
                                <div class="col">
                                    <input type="text" class="form-control" placeholder="PNR Number">
                                </div>
                            </div>
                             <div class="row justify-content-center mt-3">
                            <a href="contact.html" class="boxed-btn4" style="  background: #ff3500;color: #fff;border: 1px solid #ff3500;">Register</a>
                           </div>

                    </div>
                </div>
              
            </div>
        </div>
    </div>
</asp:Content>

