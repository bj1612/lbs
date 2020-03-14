<%@ Page Title="Detailed View Of Complaint" Language="C#" MasterPageFile="~/moderator/moderator.master" AutoEventWireup="true" CodeFile="~/moderator/Complaint_View.aspx.cs" Inherits="Complaint_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <link href="../css/chatbox.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                <!--Chat Message-->

                <div class="mesgs p-5" style="">
                   <div class="msg_history">
                    <div class="incoming_msg">
                        <div class="incoming_msg_img"> <img src="https://ptetutorials.com/images/user-profile.png" alt="sunil"> </div>
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
                        <div class="incoming_msg_img"> <img src="https://ptetutorials.com/images/user-profile.png" alt="sunil"> </div>
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
<!-- Button trigger modal -->
<div class="row p-lg-3" style="margin-left:550px;"> 
<button type="button" class="btn btn-primary m-3" data-toggle="modal" data-target="#exampleModal" data-whatever="@getbootstrap">Reassign</button>
<button type="button" class="btn btn-primary m-3" data-toggle="modal" data-target="#example" data-whatever="@fat">Report</button>
</button>
 </div>  
<!-- Modal -->
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
</script>



            <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
              <div class="modal-dialog" role="document">
                <div class="modal-content">
                  <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">New message</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                      <span aria-hidden="true">&times;</span>
                    </button>
                  </div>
                  <div class="modal-body">
                    <form>
<!-- Example single danger button -->
                    <div class="btn-group">
                      <button type="button" class="btn btn-danger dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                       Type
                      </button>
                      <div class="dropdown-menu">
                        <a class="dropdown-item" href="#">1</a>
                        <a class="dropdown-item" href="#">2</a>
                        <a class="dropdown-item" href="#">3</a>
                      </div>
                    </div>
                      <div class="form-group">
                        <label for="message-text" class="col-form-label">Description:</label>
                        <textarea class="form-control" id="message-text"></textarea>
                      </div>
                    </form>
                  </div>
                  <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary">Send message</button>
                  </div>
                </div>
              </div>
            </div>















               <div class="modal fade" id="example" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
              <div class="modal-dialog" role="document">
                <div class="modal-content">
                  <div class="modal-header">
                    <h5 class="modal-title" id="H1">New message</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                      <span aria-hidden="true">&times;</span>
                    </button>
                  </div>
                  <div class="modal-body">
                    <form>
<!-- Example single danger button -->
                    <div class="btn-group">
                      <button type="button" class="btn btn-danger dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                       Type
                      </button>
                      <div class="dropdown-menu">
                        <a class="dropdown-item" href="#">a</a>
                        <a class="dropdown-item" href="#">b</a>
                        <a class="dropdown-item" href="#">c</a>
                      </div>
                    </div>
                      <div class="form-group">
                        <label for="message-text" class="col-form-label">Description:</label>
                        <textarea class="form-control" id="Textarea1"></textarea>
                      </div>
                    </form>
                  </div>
                  <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary">Send message</button>
                  </div>
                </div>
              </div>
            </div>



</asp:Content>

