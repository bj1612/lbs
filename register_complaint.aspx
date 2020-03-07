<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="register_complaint.aspx.cs" Inherits="register_complaint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="bradcam_area1 breadcam_bg">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="bradcam_text text-center">
                        <h3 style="color:White; height:10px;">Register Your Complaint!</h3>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <!-- bradcam_area_end -->

     <div class="service_area" style ="padding:0px ; margin:0px;">
        <div class="container">            
            <div class="row justify-content-center">
                
                <div class="col-lg-6 col-md-8  p-3 mb-5 " style="margin-top:0px;">
                    <div class="single_service active">
                       
                          
                            <div class="row mt-3 ">
                                <div class="col">
                                   <select id="Select5" class="form-control">
                                        <option disabled selected>Complaint Level</option>
                                        <option>Department Level</option>
                                        <option>Institute Level</option>
                                        <option>University Level</option>
                                    </select>
                                 </div>
                            </div>
                            <div class="row mt-3 ">
                                <div class="col">
                                   <select id="Select1" class="form-control">
                                        <option disabled selected>Category</option>
                                        <option>Finance</option>
                                        <option>..</option>
                                        <option>...</option>
                                    </select>
                                 </div>
                            </div>
                            <div class="row mt-3 ">
                                <div class="col">
                                    <input type="text" class="form-control" placeholder="Subject">
                                 </div>
                            </div>
                             <div class="row mt-3 ">
                                <div class="col">
                                    <div class="form-group purple-border">
                                      <textarea class="form-control" placeholder="Write Your Complaint Here  !!" id="exampleFormControlTextarea4" rows="5" ></textarea>
                                    </div>
                                 </div>
                            </div>

                            <div class="row justify-content-center mt-3">
                                   <a href="contact.html" class="boxed-btn4" style="  background: #ff3500;color: #fff;border: 1px solid #ff3500;">Register Complaint</a>
                                </div>
                               </div>
                               

                    </div>
                </div>
              
            </div>
        </div>
    </div>
</asp:Content>
