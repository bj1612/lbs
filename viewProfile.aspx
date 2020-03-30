<%@ Page Title="Student Profile" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="viewProfile.aspx.cs" Inherits="student_viewProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"/>
    <!-- bradcam_area_start -->
    <div class="background_check">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="bradcam_text text-center">
                        <h3 style="color:White;font-size:xx-large;">View Student Profile</h3>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <!-- bradcam_area_end -->
    <div class="service_area" style ="padding:0px ; margin:0px;">
        <div class="container">            
            <div class="row justify-content-center">
                <div class="col-lg-8 col-md-10  p-3 mb-5 " style="margin-top:0px;">
                    <div class="single_service active">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col"></div>
                                    <div class="col">
                                        <div class="row justify-content-end">
                                            <button type="button" class="btn btn-info btn-lg check-edit" id="EditButton" runat="server" onserverclick="EditButton_Click" style="display:none;">
                                                <div class="fa fa-edit"><span style="padding-left:3px;">Edit</span></div>
                                            </button>
                                        </div>
                                    </div>
                                </div>
                                <div class="row mt-3">
                                    <div class="col">
                                        <label for="First" style="font-weight:bold;padding-left:10px;">First Name</label>
                                        <asp:TextBox ID="First" class="form-control" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    <div class="col">
                                    <label for="Last" style="font-weight:bold;padding-left:10px;">Last Name</label>
                                        <asp:TextBox ID="Last" class="form-control"  runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row mt-3 ">
                                    <div class="col">  
                                    <label for="Email" style="font-weight:bold;padding-left:10px;">Email Address</label>              
                                        <asp:TextBox ID="Email" class="form-control"  runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col">
                                    <label for="Contact" style="font-weight:bold;padding-left:10px;">Contact Number</label>
                                        <asp:TextBox ID="Contact" class="form-control"  runat="server" pattern="[0-9]{10}" required="true" title="Enter 10 digit contact number" Enabled="false" CssClass="form-control"></asp:TextBox>
                                        </div>
                                </div>
                                <div class="row mt-3">
                                    <div class="col">
                                    <label for="DropDownList2" style="font-weight:bold;padding-left:10px;">University Name</label>
                                        <asp:DropDownList ID="DropDownList2" class="form-control"  runat="server" 
                                            Enabled="false" CssClass="form-control" 
                                            onselectedindexchanged="DropDownList2_SelectedIndexChanged" AutoPostBack="true">
                                            
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row mt-3">
                                    <div class="col">       
                                    <label for="DropDownList3" style="font-weight:bold;padding-left:10px;">Institute Name</label>                                 
                                        <asp:DropDownList ID="DropDownList3" class="form-control" runat="server" 
                                            Enabled="false" CssClass="form-control" 
                                            onselectedindexchanged="DropDownList3_SelectedIndexChanged" AutoPostBack="true">
                                             
                                        </asp:DropDownList>  
                                    </div>
                                </div>
                                <div class="row mt-3">
                                    <div class="col">
                                    <label for="DropDownList1" style="font-weight:bold;padding-left:10px;">Department Name</label>
                                        <asp:DropDownList ID="DropDownList1" class="form-control" runat="server" 
                                            Enabled="false" CssClass="form-control" 
                                            onselectedindexchanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
                                            
                                        </asp:DropDownList> 
                                    </div>
                                </div>
                                <div class="row mt-3 ">
                                    <div class="col">
                                    <label for="DropDownList4" style="font-weight:bold;padding-left:10px;">Admission Year</label>
                                        <asp:DropDownList ID="DropDownList4" class="form-control"  runat="server" 
                                            Enabled="false" CssClass="form-control" 
                                            onselectedindexchanged="DropDownList4_SelectedIndexChanged" AutoPostBack="true">
                                                  
                                                  
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col">
                                    <label for="DropDownList5" style="font-weight:bold;padding-left:10px;">Current Year</label>
                                        <asp:DropDownList ID="DropDownList5" class="form-control"  runat="server" 
                                            Enabled="false" CssClass="form-control" >
                                                  
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="row mt-3 ">
                                    <div class="col">
                                        <label for="Shift" style="font-weight:bold;padding-left:10px;">Shift</label>
                                        <asp:DropDownList ID="Shift" class="form-control" runat="server" 
                                            Enabled="false" CssClass="form-control">  
                                               
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col">
                                        <label for="Roll" style="font-weight:bold;padding-left:10px;">Roll Number</label>
                                        <asp:TextBox ID="Roll"  class="form-control"  runat="server" pattern="[0-9]+" required="true" title="Numbers only" Enabled="false" CssClass="form-control"></asp:TextBox>
                                    </div>                                                            
                                    <div class="col">
                                    <label for="PNR" style="font-weight:bold;padding-left:10px;">PNR Number</label>
                                        <asp:TextBox ID="PNR" class="form-control"  runat="server" pattern="[0-9]+" required="true" title="Numbers only" Enabled="false" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row justify-content-center mt-3">
                                    <asp:Button Text="Update Profile" class="btn boxed-btn4" 
                                        style="background: #ff3500;color: #fff;border: 1px solid #ff3500;display:none;" 
                                        runat="server" id="UpdateButton" onclick="UpdateButton_Click">
                                        </asp:Button>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="UpdateButton" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="EditButton" EventName="ServerClick" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

