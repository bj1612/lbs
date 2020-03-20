<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="~/admin/Admin_View.aspx.cs" Inherits="Admin_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/chatbox.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .custom-list-check
        {
        }
        .custom-moderator-list-check
        {
        }
        .remove-complaint-list
        {
        }
        .moderator-change
        {
        }
        . remove-active-moderator
        {
        }
    </style>
    <script type="text/javascript">
        var idd;
        var idd2;
        function removeActive(id) {
            idd = id;
            $.myjQuery();
        }
        function removeActiveModerator(id) {
            idd2 = id;
            $.myjQuery1();
            $.myjQuery2();
        }
        function childActive() {
            //modeid = id;
            $.myjQuery3();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"/>
    <asp:Timer ID="Timer1" runat="server" ontick="Timer1_Tick" Interval="600000">
     </asp:Timer>
    <div class="background_check">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="bradcam_text text-center">
                        <h3 style="color:White;font-size:xx-large;">Quick View</h3>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div style="margin-top:30px;">
        <asp:UpdatePanel ID="AdminViewUpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="container-fluid">
                    <div class = "row" style="min-height:300px;">
                        <div class ="col-sm-12 col-md-3 col-lg-2">
                            <div class="list-group" id="subadminlist" role="tablist" runat="server">
                                
                            </div>
                        </div>
                        <div class ="col-sm-12 col-md-3 col-lg-2">
                            <div class="tab-content" id="moderatortabContent" runat="server">
                  
                            </div>
                        </div>
                        <div class ="col-sm-12 col-md-6 col-lg-2">
                            <div class="tab-content" id="complainttabContent" runat="server">
                    
                            </div>
                        </div>
                        <div class ="col-sm-12 col-md-12 col-lg-6">
                            <div class="tab-content" id="complaintviewtab" runat="server">
                          
                            </div>
                        </div> 
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $.myjQuery = function () {
                $('.custom-list-check').removeClass("active");
                $(idd).addClass("active");
            };
            $.myjQuery1 = function () {
                $('.remove-complaint-list').removeClass("active");
                $('.remove-complaint-list').removeClass("show");
                $('.moderator-change').removeClass("active");
            };
            $.myjQuery3 = function () {
                $('.remove-active-moderator').removeClass("active");
                $('.remove-moderator-tab').removeClass("active");
                $('.remove-moderator-tab').removeClass("show");
                $('.remove-complaint-list').removeClass("active");
                $('.remove-complaint-list').removeClass("show");
                $('.moderator-change').removeClass("active");
            };
            $.myjQuery2 = function () {
                $('.custom-moderator-list-check').removeClass("active");
                $(idd2).addClass("active");
            };
        });
    </script>
</asp:Content>

