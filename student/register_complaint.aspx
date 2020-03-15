<%@ Page Title="Register Complaint" Language="C#" MasterPageFile="/lbs/Site.master" AutoEventWireup="true" CodeFile="~/student/register_complaint.aspx.cs" Inherits="register_complaint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ComplaintScriptManager1" runat="server"/>
    <div class="bradcam_area1 breadcam_bg">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="bradcam_text text-center">
                        <h3 style="color:White; height:10px;">Register Your Complaint!</h3>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <!-- bradcam_area_end -->

     <div class="service_area" style ="padding:0px ; margin:0px;">
        <div class="container">            
            <div class="row justify-content-center">
                <div class="col-lg-6 col-md-8  p-3 mb-5 " style="margin-top:0px;">
                    <div class="single_service active">
                    <asp:UpdatePanel ID="ComplaintUpdatePanel1" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                            <div class="row mt-3 ">
                                <div class="col">
                                    <asp:DropDownList ID="ComplaintType" runat="server" AutoPostBack="True" 
                                        class="form-control" 
                                        onselectedindexchanged="ComplaintType_SelectedIndexChanged">
                                        <asp:ListItem Value="Complaint Type" Text="Type"></asp:ListItem>
                                        <asp:ListItem Value="university" Text="University"></asp:ListItem>
                                        <asp:ListItem Value="institute" Text="Institute"></asp:ListItem>
                                        <asp:ListItem Value="department" Text="Department"></asp:ListItem>
                                    </asp:DropDownList> 
                                 </div>
                            </div>
                            <div class="row mt-3 ">
                                <div class="col">
                                    <asp:DropDownList ID="ComplaintCategory" runat="server" AutoPostBack="True" 
                                        class="form-control" 
                                        onselectedindexchanged="ComplaintCategory_SelectedIndexChanged">
                                        <asp:ListItem Value="Complaint Category" Text="Category"></asp:ListItem>
                                    </asp:DropDownList>
                                 </div>
                            </div>
                            <div class="row mt-3 ">
                                <div class="col">
                                    <asp:TextBox ID="Subject" runat="server" placeholder="Subject" class="form-control" required="true"></asp:TextBox>
                                 </div>
                            </div>
                             <div class="row mt-3 ">
                                <div class="col">
                                    <div class="form-group purple-border">
                                        <asp:TextBox ID="Description" runat="server" 
                                            placeholder="Write Your Review Here  !!" class="form-control" Rows="5" 
                                            TextMode="MultiLine" required="true"></asp:TextBox>
                                    </div>
                                 </div>
                            </div>

                            <div class="row justify-content-center mt-3">
                                <asp:Button ID="RegisterComplaint" runat="server" Text="Share" 
                                    class="boxed-btn4" 
                                    style="background: #ff3500;color: #fff;border: 1px solid #ff3500;" 
                                    onclick="RegisterComplaint_Click"/>
                            </div>
                            </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ComplaintType" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="ComplaintCategory" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="RegisterComplaint" EventName="Click" />
                                </Triggers>
                             </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
              
            </div>
        </div>
    </div>
</asp:Content>
