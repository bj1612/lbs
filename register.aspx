<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"/>
    <!-- bradcam_area_start -->
    <div class="bradcam_area1 breadcam_bg">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="bradcam_text text-center">
                        <h3 style="color:White;font-size:xx-large;">Register</h3>
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
                                        <div class="col">
                                            <asp:TextBox ID="First" class="form-control" placeholder="First name" runat="server" pattern="[A-Za-z]+" required="true" title="Alphabets only"></asp:TextBox>
                                         </div>
                                        <div class="col">
                                            <asp:TextBox ID="Last" class="form-control" placeholder="Last name" runat="server" pattern="[A-Za-z]+" required="true" title="Alphabets only"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row mt-3 ">
                                        <div class="col">
                                            <asp:TextBox ID="Contact" class="form-control" placeholder="Contact Number " runat="server" pattern="[0-9]{10}" required="true" title="Enter 10 digit contact number"></asp:TextBox>
                                         </div>                                                            
                                        <div class="col">                
                                            <asp:TextBox ID="Email" class="form-control" placeholder="Email Address" runat="server" pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$" required="true" title="Enter valid email address"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row mt-3 ">
                                        <div class="col">
                                            <asp:TextBox ID="Password" class="form-control" placeholder="Password"  TextMode="password" runat="server" pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}" required="true" title="Must contain at least one  number and one uppercase and lowercase letter, and at least 8 or more characters"></asp:TextBox>
                                         </div>
                                        <div class="col">
                                            <asp:TextBox ID="Confirm"  class="form-control" placeholder="Confirm Password" TextMode="password" runat="server" pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}" required="true" title="Must contain at least one  number and one uppercase and lowercase letter, and at least 8 or more characters"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row mt-3">
                                        <div class="col">
                                            <asp:DropDownList ID="university" class="form-control" runat="server" 
                                                    onselectedindexchanged="university_SelectedIndexChanged" AutoPostBack="True">  
                                                <asp:ListItem Value="University Name" Text="University Name"></asp:ListItem>  
                                            </asp:DropDownList> 
                                        </div>
                                        <div class="col">                                        
                                            <asp:DropDownList ID="inputState" class="form-control" runat="server" 
                                                onselectedindexchanged="inputState_SelectedIndexChanged" AutoPostBack="True">  
                                            <asp:ListItem Value="Institute Name" Text="Institute Name"></asp:ListItem>  
                                        </asp:DropDownList>  
                                        </div>
                                        <div class="col">
                                            <asp:DropDownList ID="DropDownList1" class="form-control" runat="server" 
                                                onselectedindexchanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">  
                                                <asp:ListItem Value="Department Name" Text="Department Name"></asp:ListItem>  
                                            </asp:DropDownList>  
                                        </div>
                                    </div>
                                    <div class="row mt-3 ">
                                    <div class="col">
                                        <asp:DropDownList ID="admission_year" class="form-control" runat="server" 
                                                onselectedindexchanged="admission_year_SelectedIndexChanged" AutoPostBack="True">  
                                                <asp:ListItem Value="Admission Year">Admission Year</asp:ListItem>  
                                        </asp:DropDownList> 
                                    </div>
                                    <div class="col">
                                        <asp:DropDownList ID="current_year" class="form-control" runat="server" >  
                                            <asp:ListItem Value="Current Year">Current Year</asp:ListItem> 
                                        </asp:DropDownList>
                                    </div>
                                    </div>

                             <div class="row mt-3 ">
                                <div class="col">
                                      <asp:DropDownList ID="Shift" class="form-control" runat="server" >  
                                        <asp:ListItem Value="Shift">Shift</asp:ListItem>  
                                        <asp:ListItem Value="First Shift">First Shift</asp:ListItem>  
                                        <asp:ListItem Value="Second Shift">Second Shift</asp:ListItem>
                                        <asp:ListItem Value="None">None</asp:ListItem>   
                                    </asp:DropDownList>
                                </div>
                                <div class="col">
                                    <asp:TextBox ID="Roll"  class="form-control" placeholder="Roll Number " runat="server" pattern="[0-9]+" required="true" title="Numbers only"></asp:TextBox>
                                 </div>                                                            
                                <div class="col">
                                    <asp:TextBox ID="PNR" class="form-control" placeholder="PNR Number" runat="server" pattern="[0-9]+" required="true" title="Numbers only"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row justify-content-center mt-3">
                                <asp:Button Text="Register" class="boxed-btn4" 
                                    style="background: #ff3500;color: #fff;border: 1px solid #ff3500;" 
                                    runat="server" ID="RegisterButton" onclick="RegisterButton_Click"></asp:Button>
                            </div>
                            </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="university" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="dropDownList1" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="inputState" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="admission_year" EventName="SelectedIndexChanged" />
                                </Triggers>
                             </asp:UpdatePanel>
                      </div>
                </div>
              
            </div>
        </div>
    </div>
</asp:Content>

