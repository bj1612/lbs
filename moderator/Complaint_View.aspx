<%@ Page Title="Detailed View Of Complaint" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="~/moderator/Complaint_View.aspx.cs" Inherits="Complaint_View" MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="/lbs/css/chatbox.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"/>
    <asp:Timer ID="Timer1" runat="server" ontick="Timer1_Tick" Interval="100000">
     </asp:Timer>
    <div class="bradcam_area1 breadcam_bg">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="bradcam_text text-center">
                        <h3 style="color:White; font-size:xx-large;">Details Of Student Complaint!</h3>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <!-- bradcam_area_end -->
    <asp:UpdatePanel ID="ComplaintUpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="service_area" style ="padding:0px ; margin:0px;">
                <div class="container">            
                    <div class="row justify-content-center">
                        <!--complaint id and description-->
                        <div class="card" style="text-align:center; width:2000px;margin-top: 20px;" >
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
                                </div>
                            </div>
                        </div>
                   
                        <div class="card" style="text-align:center; width:2000px;margin-top: 20px;" >
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
                                <div class="row" runat="server" id="messageboxdiv">
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
                            <div class="type_msg">
                                <div class="input_msg_write" runat="server" id="commenttextboxdiv" style="display:block;">
                                    <asp:TextBox id="CommentBox" rows="3" class="form-control" placeholder="Type a message" TextMode="multiline" runat="server" Text=""/>
                                    <button class="msg_send_btn" type="button" runat="server" ID="Comment" onserverclick="Comment_Click"><i class="fa fa-paper-plane-o" aria-hidden="true"></i></button>
                                </div>
                           </div>             
                        </div>                       
                    </div>
                </div>
            </div>
            
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Comment" EventName="ServerClick" />
            <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
        </Triggers>
    </asp:UpdatePanel>  
            <div class="row" style="margin-top:20px;"> 
            </div>
            <!-- Button trigger modal -->
            <div class="row" style="margin-top:20px;margin-bottom:20px;text-align:center;">
                <div id="reassigndiv" class="col-lg-4 col-md-4 col-sm-12" runat="server" style="display:block;">
                    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal1">Ressign</button>
                </div>
                <div id="reportdiv" class="col-lg-4 col-md-4 col-sm-12" runat="server" style="display:block;">
                    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal2">Report</button>
                </div>
                <div id="closediv" class="col-lg-4 col-md-4 col-sm-12" runat="server" style="display:block;">
                    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal3">Close</button>
                </div>
            </div>
            <!-- Reassign Modal-->
            <div class="modal fade" id="myModal1" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title" id="myModalLabel">Confirm your action </h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <h3>Are you sure you want to reassign your task?</h3>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-primary" data-dismiss="modal" data-toggle="modal" data-target="#getModal1">Yes</button>
                            <button type="button" class="btn btn-default" data-dismiss="modal">No</button>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal fade" id="getModal1" tabindex="-1" role="dialog" aria-labelledby="myModalLabel1" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title" id="myModalLabel1">Reassign Details </h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <h4>Please provide us detail why you want to reassign</h4>
                            <!--<form>-->
                                <!-- Example single danger button -->
                                <h6>(Note:If you want the category to be same select the current category)</h6>
                                <div class="form-group">
                                    <label for="category" class="col-form-label">Category:</label>
                                    <!--<select></select>-->
                                    <asp:DropDownList class="form-control" ID="ReassignCategory" runat="server" style="height:40px;">
                                        <asp:ListItem Value="0" Text="Category"></asp:ListItem> 
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="reassign_text" class="col-form-label">Description:</label>
                                    <textarea class="form-control" rows="4" id="reassign_text" runat="server"></textarea>
                                </div>
                            <!--</form>-->
                        </div>
                        <div class="modal-footer">
                            <button id="Button1" type="button" class="btn btn-primary" data-dismiss="modal" runat="server" onserverclick="Reassign_Click">Reappeal</button>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Report Modal-->
            <div class="modal fade" id="myModal2" tabindex="-1" role="dialog" aria-labelledby="myModalLabel2" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title" id="myModalLabel2">Confirm your action </h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <h3>Are you sure you want to report your task?</h3>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-primary" data-dismiss="modal" data-toggle="modal" data-target="#getModal2">Yes</button>
                            <button type="button" class="btn btn-default" data-dismiss="modal">No</button>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal fade" id="getModal2" tabindex="-1" role="dialog" aria-labelledby="myModalLabel3" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title" id="myModalLabel3">Report Details </h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <h4>Please provide us detail why you want to report</h4>
                            <!--<form>-->
                                <!-- Example single danger button -->
                                <div class="form-group">
                                    <label for="ReportType" class="col-form-label">Type:</label>
                                    <!--<select></select>-->
                                    <asp:DropDownList class="form-control" ID="ReportType" runat="server" style="height:40px;">
                                        <asp:ListItem Value="Type" Text="Type"></asp:ListItem>
                                        <asp:ListItem Value="Abusive and Offensive" Text="Abusive and Offensive"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="rep_desc" class="col-form-label">Description:</label>
                                    <textarea class="form-control" rows="4" id="rep_desc" runat="server"></textarea>
                                </div>
                            <!--</form>-->
                        </div>
                        <div class="modal-footer">
                            <button id="Button2" type="button" class="btn btn-primary" data-dismiss="modal" runat="server" onserverclick="Report_Click">Report</button>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Close Modal-->
            <div class="modal fade" id="myModal3" tabindex="-1" role="dialog" aria-labelledby="myModalLabel4" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title" id="myModalLabel4">Confirm your action </h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <h3>Are you sure you want to close your task?</h3>
                        </div>
                        <div class="modal-footer">
                            <button id="CloseButton" type="button" class="btn btn-primary" data-dismiss="modal" runat="server" onserverclick="Close_Click">Yes</button>
                            <button type="button" class="btn btn-default" data-dismiss="modal">No</button>
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

