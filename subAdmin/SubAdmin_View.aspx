<%@ Page Title="Quick View" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="~/subAdmin/SubAdmin_View.aspx.cs" Inherits="SubAdmin_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/chatbox.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
        .remove-complaint-active
        {
        }
        .remove-complaint-list
        {
        }
        .moderator-change
        {
        }
    </style>
    <script type="text/javascript">
        var idd;
        //var modeid;
        var em=[];
        function modeclick(emaill) {
            if (em.includes(emaill)==false) {
                var a = document.createElement('a');
                a.target = "_blank";
                a.href = "/lbs/moderator/viewModeratorProfile.aspx?ID=" + emaill;
                a.click();
                em.push(emaill);
            }
        }
        function removeActive(id) {
            idd = id;
            $.myjQuery();
        }
        function childActive() {
            //modeid = id;
            $.myjQuery1();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
    <asp:ScriptManager ID="ScriptManager1" runat="server"/>
    <asp:Timer ID="Timer1" runat="server" ontick="Timer1_Tick" Interval="600000">
     </asp:Timer>
    <div style="margin-top:30px;">
        <asp:UpdatePanel ID="SubAdminViewUpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="container-fluid">
                    <div class = "row" style="min-height:300px;">
                        <div class ="col-sm-12 col-md-4 col-lg-2">
                            <div class="list-group" id="moderatorlist" role="tablist" runat="server">
                                <a class="list-group-item list-group-item-action" disabled style=" background-color: #000066;color: white;">Moderator</a>
                            </div>
                        </div>
                        <div class ="col-sm-12 col-md-8 col-lg-2">
                            <div class="tab-content" id="complainttabContent" runat="server">
                    
                            </div>
                        </div>
                        <div class ="col-sm-12 col-md-12 col-lg-8">
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
                $('.remove-complaint-active').removeClass("active");
                $(idd).addClass("active");
            };
            $.myjQuery1 = function () {
                $('.remove-complaint-list').removeClass("active");
                $('.remove-complaint-list').removeClass("show");
                $('.moderator-change').removeClass("active");
            };
        });
    </script>
</asp:Content>

