<%@ Page Title="Quick View" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="~/subAdmin/SubAdmin_View.aspx.cs" Inherits="SubAdmin_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/chatbox.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css"/>
    <style type="text/css">
        .custom-list-check
        {
        }
    </style>
    <script type="text/javascript">
        var idd;
        function removeActive(id) {
            idd = id;
            $.myjQuery();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <div class = "row">
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

    <script type="text/javascript">
        $(document).ready(function () {
            $.myjQuery = function () {
                $('.custom-list-check').removeClass("active");
                $(idd).addClass("active");
            };
        });
    </script>
</asp:Content>

