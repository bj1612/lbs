<%@ Page Title="Home" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="~/admin/Admin_View.aspx.cs" Inherits="Admin_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/chatbox.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <div class = "row">
            <div class ="col-sm-12 col-md-3 col-lg-3">
                <ul class="list-group">
                    <li class="list-group-item active">Sub Admin</li>
                    <li class="list-group-item">Dapibus ac facilisis in</li>
                    <li class="list-group-item">Morbi leo risus</li>
                    <li class="list-group-item">Porta ac consectetur ac</li>
                    <li class="list-group-item">Vestibulum at eros</li>
                </ul>
            </div>
            <div class ="col-sm-12 col-md-3 col-lg-3">
                 <ul class="list-group">
                    <li class="list-group-item active">Moderator</li>
                    <li class="list-group-item">Dapibus ac facilisis in</li>
                    <li class="list-group-item">Morbi leo risus</li>
                    <li class="list-group-item">Porta ac consectetur ac</li>
                    <li class="list-group-item">Vestibulum at eros</li>
                </ul>
            </div>
            <div class ="col-sm-12 col-md-6 col-lg-3">
                <div class="row">
                    <ul class="list-group col-sm-12 col-md-6 col-lg-12">
                        <li class="list-group-item active">Pending Complaint</li>
                        <li class="list-group-item">Dapibus ac facilisis in</li>
                        <li class="list-group-item">Morbi leo risus</li>
                        <li class="list-group-item">Porta ac consectetur ac</li>
                        <li class="list-group-item">Vestibulum at eros</li>
                    </ul>
                    <ul class="list-group col-sm-12 col-md-6 col-lg-12">
                        <li class="list-group-item active">Solved Complaint</li>
                        <li class="list-group-item">Dapibus ac facilisis in</li>
                        <li class="list-group-item">Morbi leo risus</li>
                        <li class="list-group-item">Porta ac consectetur ac</li>
                        <li class="list-group-item">Vestibulum at eros</li>
                    </ul>
                </div>
            </div>

            <div class ="col-sm-12 col-md-12 col-lg-3">            
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
                    <div class="mesgs" style="width:2000px;">
                        <div class="msg_history">
                            <div class="incoming_msg">
                                <div class="incoming_msg_img"> <img src="../img/user-profile.png" alt="user-image"/> </div>
                                <div class="received_msg">
                                    <div class="received_withd_msg">
                                        <p>Test which is a new approach to have all
                                        solutions</p>
                                        <span class="time_date"> 11:01 AM    |    June 9</span>
                                    </div>
                                </div>
                            </div>
                            <div class="outgoing_msg">
                                <div class="sent_msg">
                                    <p>Test which is a new approach to have all
                                        solutions</p>
                                    <span class="time_date"> 11:01 AM    |    June 9</span>
                                </div>
                            </div>
                            <div class="incoming_msg">
                                <div class="incoming_msg_img"> <img src="../img/user-profile.png" alt="user-image"/> </div>
                                <div class="received_msg">
                                    <div class="received_withd_msg">
                                        <p>Test, which is a new approach to have</p>
                                        <span class="time_date"> 11:01 AM    |    Yesterday</span>
                                    </div>
                                </div>
                            </div>
                            <div class="outgoing_msg">
                                <div class="sent_msg">
                                    <p>Apollo University, Delhi, India Test</p>
                                    <span class="time_date"> 11:01 AM    |    Today</span> 
                                </div>
                            </div>
                        </div>
                    </div>
                </div>  
            </div> 
        </div>
    </div>     
</asp:Content>

