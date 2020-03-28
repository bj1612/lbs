<%@ Page Title="Update Moderator" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="UpdateModerator.aspx.cs" Inherits="subAdmin_UpdateModerator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
<script type="text/javascript" src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
<script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>

<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous" />


    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"/>
    <div class="background_check">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="bradcam_text text-center">
                        <h3 style="color:White; font-size:xx-large;font-family: 'Poppins', sans-serif;">Update Moderator</h3>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:UpdatePanel ID="ComplaintUpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
    <div class="service_area" style ="padding:0px ; margin:0px;">
        <div class="container">            
            <div class="row justify-content-center">
                <div class="col-lg-8 col-md-10  p-3 mb-5 " style="margin-top:0px;">
                    <div class="single_service active">
                            <div class="row justify-content-center">
                                <ul class="nav nav-tabs" id="myTab" role="tablist">
                                    <li class="nav-item">
                                        <a class="nav-link active" id="removelist" data-toggle="tab" href="#remove" role="tab" aria-controls="remove" aria-selected="true">Remove Availability</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" id="addlist" data-toggle="tab" href="#add" role="tab" aria-controls="add" aria-selected="false">Add Availability</a>
                                    </li>
                                </ul>
                            </div>
                            
                            <div class="tab-content">
                                <div id="remove" class="tab-pane fade show active" role="tabpanel" aria-labelledby="remove-tab">
                                    <div class="row justify-content-center">
                                        <div class="col-lg-12 col-md-12 col-xs-12 mt-3">
                                            <div class="row">
                                                <div class="col mt-3">
                                                    <label for="AvailableModerator">Available Moderators</label>
                                                    <asp:DropDownList ID="AvailableModerator" class="form-control" runat="server" style="height:48px;font-size:18px;border:1px solid #e5e6e9;">
                                                        <asp:ListItem Value="Select Moderator" Text="Select Moderator"></asp:ListItem>
                                                    </asp:DropDownList>  
                                                </div>
                                            </div>
                                            <div class="row justify-content-center mt-5">
                                                <button type="button" class="btn boxed-btn4" style="background: #ff3500;color: #fff;border: 1px solid #ff3500;" id="UpdateModerator1" data-toggle="modal" data-target="#myModal1">
                                                    Update Moderator
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="add" class="tab-pane fade" role="tabpanel" aria-labelledby="add-tab">
                                    <div class="row justify-content-center">
                                        <div class="col-lg-12 col-md-12 col-xs-12 mt-3">
                                            <div class="row">
                                                <div class="col mt-3">
                                                    <label for="OffDutyModerator">Off Duty Moderators</label>
                                                    <asp:DropDownList ID="OffDutyModerator" class="form-control" runat="server" style="height:48px;font-size:18px;border:1px solid #e5e6e9;">
                                                        <asp:ListItem Value="Select Moderator" Text="Select Moderator"></asp:ListItem>
                                                    </asp:DropDownList>  
                                                </div>
                                            </div>
                                            <div class="row justify-content-center mt-5">
                                                <button type="button" class="btn boxed-btn4" style="background: #ff3500;color: #fff;border: 1px solid #ff3500;" id="UpdateModerator2" data-toggle="modal" data-target="#myModal2" onclick="AddContentActive();">
                                                    Update Moderator
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
            </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="RemoveButton" EventName="ServerClick" />
            <asp:AsyncPostBackTrigger ControlID="AddButton" EventName="ServerClick" />
        </Triggers>
    </asp:UpdatePanel>
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
                            <button id="RemoveButton" type="button" class="btn btn-primary" data-dismiss="modal" runat="server" onserverclick="Remove_Click">Yes</button>
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
                            <button id="AddButton" type="button" class="btn btn-primary" data-dismiss="modal" runat="server" onserverclick="Add_Click">Yes</button>
                            <button type="button" class="btn btn-default" data-dismiss="modal">No</button>
                        </div>
                    </div>
                </div>
            </div>
    
</asp:Content>

