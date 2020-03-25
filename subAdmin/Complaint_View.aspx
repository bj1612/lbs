<%@ Page Title="Detailed View Of Complaint" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="~/subAdmin/Complaint_View.aspx.cs" Inherits="Complaint_View" MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="/lbs/css/chatbox.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     </asp:Timer>
    <div class="background_check" style="padding-top:0px;">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="bradcam_text text-center">
                        <h3 style="color:White; font-size:xx-large;font-family: 'Poppins', sans-serif;">Details Of Student Complaint!</h3>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <!-- bradcam_area_end -->
    <div style="overflow:hidden;">
            <div class="service_area" style ="padding:0px ; margin:0px;">
                <div class="container">            
                    <div class="row justify-content-center">
                        <!--complaint id and description-->
                        <div class="card" style="text-align:center; width:95%;margin-top: 20px;" >
                            <div class="card-header" style="background-color:orange;color:White; font-size:larger;">
                                <div class="row">
                                    <div class="col">
                                        <div class="row">
                                            <div class="col col-lg-6">ID:</div>
                                            <div class="col col-lg-6" style="margin-right:20px;padding-left:5px;color:Black;" runat="server" id="complaintiddiv">111111</div>
                                        </div>
                                    </div>
                                    <div class="col">
                                        <div class="col">Date:</div>
                                        <div class="col" style="margin-right:20px;padding-left:5px;color:Black;" runat="server" id="complaintdatediv">2015-10-31</div>
                                    </div>
                                    <div class="col">
                                        <div class="col">Time:</div>
                                        <div class="col" style="margin-right:20px;padding-left:5px;color:Black;" runat="server" id="complainttimediv">01:01</div>
                                    </div>
                                    <div class="col">
                                        <div class="col">Progress:</div>
                                        <div class="col" style="margin-right:20px;padding-left:5px;color:Black;" runat="server" id="progressdiv">Open</div>
                                    </div>
                                    <div class="col">
                                        <div class="col">Status:</div>
                                        <div class="col" style="margin-right:20px;padding-left:5px;color:Black;" runat="server" id="statusdiv">Pending</div>
                                    </div>
                                    <div class="col">
                                        <div class="col">Category:</div>
                                        <div class="col" style="margin-right:20px;padding-left:5px;color:Black;" runat="server" id="catdiv">Grade</div>
                                    </div>
                                </div>
                            </div>
                        </div>
                   
                        <div class="card" style="text-align:center; width:95%;margin-top: 20px;" >
                            <div class="card-header" style="background-color:orange;color:White; font-size:x-large;"><span runat="server" id="titlediv">Title of Complaint</span></div>
                            <div class="card-body">
                            <blockquote class="blockquote mb-0">
                                <!--<p>Description about complaint </p>-->
                                <p runat="server" id="descriptiondiv" class="text-info">Description about complaint</p>
                            </blockquote>
                            </div>
                        </div>
                        <!--End complaint and des-->
                        <!--Chat Message-->

                        <div class="mesgs">
                            <div class="msg_history">
                                <div class="row" id="messageboxdiv" runat="server">
                                    <!--<div class="incoming_msg col-sm-11 col-md-10 col-lg-10">
                                        <div class="incoming_msg_img"> 
                                            <div style="width:300px;">
                                                <img src="../img/user-profile.png" alt="user-image" style="float:left;width:33px;margin-right:10px;"/>
                                                <div style="padding-left:10px;padding-top:5px;">
                                                    Venkatesh Nadar
                                                </div>
                                            </div>
                                        </div>
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
                                            <div>
                                                <div style="padding-left:10px;margin-bottom:5px;">
                                                    Venkatesh Nadar
                                                </div>
                                            </div>
                                            <p>Test which is a new approach to have all
                                                solutions</p>
                                            <span class="time_date"> 11:01 AM    |    June 9</span>
                                        </div>
                                    </div>-->
                                </div>
                            </div>             
                        </div>
                        <div id="reassigndiv" class="check-reassign-report" runat="server" style="display:none;">
                            <div class="card" style="text-align:center; width:100%;margin-top: 20px;" >
                                <div class="card-header" style="background-color:orange;color:White; font-size:larger;padding-bottom:0px;">
                                    <div class="row">
                                        <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">New Category:</div>
                                        <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8" runat="server" id="reassigncatname" style="color:Black;">Category Name</div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">Moderator Name:</div>
                                        <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8" runat="server" id="reassignmodenamediv" style="color:Black;">Moderator Name</div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">Moderator Email:</div>
                                        <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8" runat="server" id="reassignmodeemaildiv" style="color:Black;">Moderator Email</div>
                                    </div>
                                    <div class="row justify-content-center" style="text-align:center; background-color:	#FF4500;margin-top:10px;padding-top:5px;padding-bottom:5px;" >
                                        Description
                                    </div>
                                </div>
                                <div class="card-body">
                                    <blockquote class="blockquote mb-0">
                                        <!--<p>Description about complaint </p>-->
                                        <p runat="server" id="reassigndesc" class="text-info">Description about complaint</p>
                                    </blockquote>
                                </div>
                            </div>
                        </div>
                        <div id="reappealdiv" class="check-reassign-report" runat="server" style="display:none;">
                            <div class="card" style="text-align:center; width:100%;margin-top: 20px;" >
                                <div class="card-header" style="background-color:orange;color:White; font-size:larger;padding-bottom:0px;">
                                    <div class="row">
                                        <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">Applied Category:</div>
                                        <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8" runat="server" id="reappealcatdiv" style="color:Black;">Category Name</div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">Moderator Name:</div>
                                        <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8" runat="server" id="reappealmodenamediv" style="color:Black;">Moderator Name</div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">Moderator Email:</div>
                                        <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8" runat="server" id="reappealmodeemaildiv" style="color:Black;">Moderator Email</div>
                                    </div>
                                    <div class="row justify-content-center" style="text-align:center; background-color:	#FF4500;margin-top:10px;padding-top:5px;padding-bottom:5px;" >
                                        Description
                                    </div>
                                </div>
                                <div class="card-body">
                                    <blockquote class="blockquote mb-0">
                                        <!--<p>Description about complaint </p>-->
                                        <p runat="server" id="reappealdesc" class="text-info">Description about complaint</p>
                                    </blockquote>
                                </div>
                            </div>
                        </div>
                        <div id="reportdiv" class="check-reassign-report" runat="server" style="display:none;">
                            <div class="card" style="text-align:center; width:100%;margin-top: 20px;" >
                                <div class="card-header" style="background-color:orange;color:White; font-size:larger;padding-bottom:0px;">
                                    <div class="row">
                                        <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">Applied Category:</div>
                                        <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8" runat="server" id="reportcatdiv" style="color:Black;">Category Name</div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">Type:</div>
                                        <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8" runat="server" id="reporttypediv" style="color:Black;">Type Name</div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">Moderator Name:</div>
                                        <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8" runat="server" id="reportmodenamediv" style="color:Black;">Moderator Name</div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">Moderator Email:</div>
                                        <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8" runat="server" id="reportmodeemaildiv" style="color:Black;">Moderator Email</div>
                                    </div>
                                    <div class="row justify-content-center" style="text-align:center; background-color:	#FF4500;margin-top:10px;padding-top:5px;padding-bottom:5px;" >
                                        Description
                                    </div>
                                </div>
                                <div class="card-body">
                                    <blockquote class="blockquote mb-0">
                                        <!--<p>Description about complaint </p>-->
                                        <p runat="server" id="reportdesc" class="text-info">Description about complaint</p>
                                    </blockquote>
                                </div>
                            </div>
                        </div> 
                        <!-- end of chat-->                     
                    </div>
                </div>
            </div> 
            <div class="row" style="margin-top:20px;"> 
            </div>
            <!-- Button trigger modal -->
            <div class="row" style="margin-top:20px;margin-bottom:20px;text-align:center;">
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6" runat="server" style="display:block;">
                    <button type="button" class="btn boxed-btn4" style="background: #ff3500;color: #fff;border: 1px solid #ff3500;" data-toggle="modal" data-target="#myModal1">Approve</button>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6" runat="server" style="display:block;">
                    <button type="button" class="btn boxed-btn4" style="background: #ff3500;color: #fff;border: 1px solid #ff3500;" data-toggle="modal" data-target="#myModal2">Reject</button>
                </div>
            </div>
            <!-- Close Modal-->
            <div class="modal fade" id="myModal1" tabindex="-1" role="dialog" aria-labelledby="myModalLabel4" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title" id="myModalLabel4">Confirm your action </h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <h3>Are you sure you want to approve the request?</h3>
                        </div>
                        <div class="modal-footer">
                            <button id="YesButton" type="button" class="btn btn-primary" data-dismiss="modal" runat="server" onserverclick="Yes_Click">Yes</button>
                            <button type="button" class="btn btn-default" data-dismiss="modal">No</button>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal fade" id="myModal2" tabindex="-1" role="dialog" aria-labelledby="myModalLabel5" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title" id="myModalLabel5">Confirm your action </h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <h3>Are you sure you want to approve the request?</h3>
                        </div>
                        <div class="modal-footer">
                            <button id="No_Button" type="button" class="btn btn-primary" data-dismiss="modal" runat="server" onserverclick="No_Click">Yes</button>
                            <button type="button" class="btn btn-default" data-dismiss="modal">No</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    <!-- Modal 
    <script>
        $('#exampleModal').on('show.bs.modal', function (event) {
            var button = $(event.relatedTarget) // Button that triggered the modal
            var recipient = button.data('whatever') // Extract info from data-* attributes
            // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
            // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
            var modal = $(this)
            modal.find('.modal-title').text('New message to ' + recipient)
            modal.find('.modal-body input').val(recipient)
        })
    </script>
    <script>
        $('#example').on('show.bs.modal', function (event) {
            var button = $(event.relatedTarget) // Button that triggered the modal
            var recipient = button.data('whatever') // Extract info from data-* attributes
            // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
            // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
            var modal = $(this)
            modal.find('.modal-title').text('New message to ' + recipient)
            modal.find('.modal-body input').val(recipient)
        })
    </script>-->
</asp:Content>

