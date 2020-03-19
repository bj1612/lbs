<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="~/admin/Admin_View.aspx.cs" Inherits="Admin_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/chatbox.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <div class = "row">
            <div class ="col-sm-12 col-md-3 col-lg-2">
                <div class="list-group" id="subadminlist" role="tablist">
                  <a class="list-group-item list-group-item-action" disabled style=" background-color: #000066;color: white;">Sub Admin</a>
                  <a class="list-group-item list-group-item-action active" id="subadmin1" data-toggle="list" href="#subadmin1-tab" role="tab" aria-controls="subadmin1-tab">Sub Admin1</a>
                  <a class="list-group-item list-group-item-action" id="subadmin2" data-toggle="list" href="#subadmin2-tab" role="tab" aria-controls="subadmin2-tab">Sub Admin2</a>
                </div>
            </div>
            <div class ="col-sm-12 col-md-3 col-lg-2">
                <div class="tab-content" id="moderatortabContent">
                  <div class="tab-pane fade show active" id="subadmin1-tab" role="tabpanel" aria-labelledby="subadmin1">
                        <div class="list-group" id="subadmin1-moderator-list" role="tablist">
                            <a class="list-group-item list-group-item-action" disabled style=" background-color: #000066;color: white;">Moderator</a>
                            <a class="list-group-item list-group-item-action active" id="moderator1" data-toggle="list" href="#moderator1-tab" role="tab" aria-controls="moderator1-tab">Moderator1</a>
                            <a class="list-group-item list-group-item-action" id="moderator2" data-toggle="list" href="#moderator2-tab" role="tab" aria-controls="moderator2-tab">Moderator2</a>
                        </div>
                  </div>
                  <div class="tab-pane fade" id="subadmin2-tab" role="tabpanel" aria-labelledby="subadmin2">list of Moderator for subadmin 2</div>
                </div>
            </div>
            <div class ="col-sm-12 col-md-6 col-lg-2">
                <div class="tab-content" id="complainttabContent">
                    <div class="tab-pane fade show active" id="moderator1-tab" role="tabpanel" aria-labelledby="moderator1">
                        List of first moderator complaint list
                    </div>
                    <div class="tab-pane fade" id="moderator2-tab" role="tabpanel" aria-labelledby="moderator2">
                        <div class="row">
                            <div class="col-sm-12 col-md-6 col-lg-12">
                                <div class="list-group" id="moderator2-pending-list" role="tablist">
                                    <a class="list-group-item list-group-item-action" disabled style=" background-color: #000066;color: white;">Pending Complaints</a>
                                    <a class="list-group-item list-group-item-action active" id="moderator2-complaint1" data-toggle="list" href="#complaint1-tab" role="tab" aria-controls="complaint1-tab">Pending Complaints 1</a>
                                    <a class="list-group-item list-group-item-action" id="moderator2-complaint2" data-toggle="list" href="#complaint2-tab" role="tab" aria-controls="complaint2-tab">Pending Complaints 2</a>
                                </div>
                            </div>
                            <div class="col-sm-12 col-md-6 col-lg-12">
                                <div class="list-group" id="moderator2-complete-list" role="tablist">
                                    <a class="list-group-item list-group-item-action" disabled style=" background-color: #000066;color: white;">Solved Complaints</a>
                                    <a class="list-group-item list-group-item-action active" id="moderator2-complaint3" data-toggle="list" href="#complaint3-tab" role="tab" aria-controls="complaint3-tab">Solved Complaints 1</a>
                                    <a class="list-group-item list-group-item-action" id="moderator2-complaint4" data-toggle="list" href="#complaint4-tab" role="tab" aria-controls="complaint4-tab">Solved Complaints 2</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class ="col-sm-12 col-md-12 col-lg-6">
                <div class="tab-content" id="complaintviewtab" runat="server">
                          
                </div>
            </div> 
        </div>
    </div>     
</asp:Content>

