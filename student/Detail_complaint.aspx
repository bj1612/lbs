<%@ Page Title="Detailed View Of Complaint" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Detail_complaint.aspx.cs" Inherits="Detail_complaint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/chatbox.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <!-- bradcam_area_start -->
    <div class="bradcam_area1 breadcam_bg">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="bradcam_text text-center">
                        <h3 style="color:White; font-size:xx-large;">Details Of Your Complaint!</h3>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <!-- bradcam_area_end -->
    <div class="service_area" style ="padding:0px ; margin:0px;">
        <div class="container">            
            <div class="row justify-content-center">
                <!--complaint id and description-->
                <div class="card" style="text-align:center; width:2000px;margin-top: 20px;" >
                  <div class="card-header" style="background-color:orange;color:White; font-size:x-large;">Complaint ID<space>                         </space><date>20-05-2018</date><time>10:05 Am</time></div>
                </div>
                   
                <div class="card" style="text-align:center; width:2000px;margin-top: 20px;" >
                  <div class="card-header" style="background-color:orange;color:White; font-size:x-large;">Title Of Your Complaint</div>
                  <div class="card-body">
                    <blockquote class="blockquote mb-0">
                      <p>Description about complaint </p>
                    </blockquote>
                  </div>
                </div>
                <!--End complaint and des-->

                <!--Chat Message-->
                <div class="mesgs">
                    <div class="msg_history">
                        <div class="row">
                            <div class="incoming_msg col-sm-11 col-md-10 col-lg-10">
                                <div class="incoming_msg_img"> <img src="../img/user-profile.png" alt="user-image"/> </div>
                                <div class="received_msg">
                                    <div class="received_withd_msg">
                                        <p>Test which is a new approach to have all
                                        solutions</p>
                                        <span class="time_date"> 11:01 AM    |    June 9</span>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-1 col-md-2 col-lg-2">
                            </div>
                            <div class="col-sm-1 col-md-2 col-lg-2">
                            </div>
                            <div class="outgoing_msg col-sm-11 col-md-10 col-lg-10">
                                <div class="sent_msg">
                                <p>Test which is a new approach to have all
                                    solutions</p>
                                <span class="time_date"> 11:01 AM    |    June 9</span>
                                </div>
                            </div>
                            <div class="incoming_msg col-sm-11 col-md-10 col-lg-10">
                                <div class="incoming_msg_img"> <img src="../img/user-profile.png" alt="user-image"/> </div>
                                <div class="received_msg">
                                    <div class="received_withd_msg">
                                    <p>Test, which is a new approach to have</p>
                                    <span class="time_date"> 11:01 AM    |    Yesterday</span>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-1 col-md-2 col-lg-2">
                            </div>
                            <div class="col-sm-1 col-md-2 col-lg-2">
                            </div>
                            <div class="outgoing_msg col-sm-11 col-md-10 col-lg-10">
                                <div class="sent_msg">
                                <p>Apollo University, Delhi, India Test</p>
                                <span class="time_date"> 11:01 AM    |    Today</span> 
                                </div>
                            </div>
                        </div>
                    </div>
                        <div class="type_msg">
                            <div class="input_msg_write">
                                <asp:TextBox id="tb4" rows="3" class="form-control" placeholder="Type a message" TextMode="multiline" runat="server" />
                                <button class="msg_send_btn" type="button"><i class="fa fa-paper-plane-o" aria-hidden="true"></i></button>
                            </div>
                        </div>
                    </div>
              </div>      
          </div>
    </div>
                     
                        <!--Orange Border code End-->
    
</asp:Content>

