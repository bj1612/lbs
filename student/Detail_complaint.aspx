<%@ Page Title="Detailed View Of Complaint" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Detail_complaint.aspx.cs" Inherits="Detail_complaint" MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="/lbs/css/chatbox.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"/>
    <asp:Timer ID="Timer1" runat="server" ontick="Timer1_Tick" Interval="100000">
     </asp:Timer>
    <!-- bradcam_area_start -->
    <div class="background_check" style="padding-top:0px;">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="bradcam_text text-center">
                        <h3 style="color:White; font-size:xx-large;font-family: 'Poppins', sans-serif;">Details Of Your Complaint!</h3>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:UpdatePanel ID="CommentUpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate> 
        <!-- bradcam_area_end -->
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
                                <!--<asp:Button class="fa fa-paper-plane-o msg_send_btn" ID="Comment1" runat="server" EnableTheming="True" aria-hidden="true" onclick="Comment_Click"/>-->
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
        <div class="row" style="margin-top:20px;margin-bottom:20px;text-align:center;display:none;overflow:hidden" id="reappealdiv" runat="server"> 
            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal">Reappeal</button>
        </div>               
        <!-- Reappeal Modal-->
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="overflow:hidden">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <h4 class="modal-title" id="myModalLabel">Confirm your action </h4>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
                </button>
              </div>
              <div class="modal-body">
                <h3>Are you sure you want to reappeal your request?</h3>
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-primary" data-dismiss="modal" data-toggle="modal" data-target="#getModal">Yes</button>
                <button type="button" class="btn btn-default" data-dismiss="modal">No</button>
              </div>
            </div>
          </div>
        </div>
        <div class="modal fade" id="getModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel1" aria-hidden="true" style="overflow:hidden">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <h4 class="modal-title" id="myModalLabel1">Reappeal Details </h4>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
                </button>
              </div>
              <div class="modal-body">
                <h4>Please provide us detail why you want to reappeal</h4>
                    <!-- Example single danger button -->
                      <div class="form-group">
                        <label for="reappeal_text" class="col-form-label">Description:</label>
                        <textarea class="form-control" rows="4" id="reappeal_text" runat="server"></textarea>
                      </div>
              </div>
              <div class="modal-footer">
                <button id="Button1" type="button" class="btn btn-primary" data-dismiss="modal" runat="server" onserverclick="Reappeal_Click">Reappeal</button>
              </div>
            </div>
          </div>
        </div>
    <!--<script>
        /*$('#exampleModal').on('show.bs.modal', function (event) {
            var button = $(event.relatedTarget) // Button that triggered the modal
            var recipient = button.data('whatever') // Extract info from data-* attributes
            // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
            // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
            var modal = $(this)
            modal.find('.modal-title').text('New message to ' + recipient)
            modal.find('.modal-body input').val(recipient)
        })*/
    </script>-->
    <script type="text/javascript">
        function checkcomment() {
            var commentbox = document.getElementById("ContentPlaceHolder1_CommentBox").value;
            if (commentbox == "") {
                alert('Please enter comment');
                return false;
            }
            return true;
        }
    </script>
                     
                        <!--Orange Border code End-->
    
</asp:Content>

