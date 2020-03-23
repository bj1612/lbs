<%@ Page Title="Register Admin" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="~/systemAdmin/Register_admin.aspx.cs" Inherits="Register_admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server"/>
    
<div class="background_check">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="bradcam_text text-center">
                        <h3 style="color:White;font-size:xx-large;">Registration Page For Admin!</h3>
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
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        
                            <div class="row">
                                <div class="col">
                                    <asp:TextBox ID="First" class="form-control" placeholder="First name" runat="server"></asp:TextBox>
                                </div>
                                <div class="col">
                                    <asp:TextBox ID="Last" class="form-control" placeholder="Last name" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row mt-3 ">
                                <div class="col">
                                    <asp:TextBox ID="Contact" class="form-control" placeholder="Contact Number" runat="server"></asp:TextBox>
                                 </div>                                                            
                                <div class="col">                
                                    <asp:TextBox ID="Email" class="form-control" placeholder="Email Adrress" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            
                             <div class="row mt-3 ">
                                <div class="col">
                                  <asp:DropDownList ID="choose_level" class="form-control" runat="server" 
                                        onselectedindexchanged="choose_level_SelectedIndexChanged" AutoPostBack="True">  
                                    <asp:ListItem Value="" InitialValue="Unselectable Item">Type</asp:ListItem>  
                                    <asp:ListItem>Department</asp:ListItem>  
                                    <asp:ListItem>Institute</asp:ListItem>  
                                    <asp:ListItem>University</asp:ListItem>   
                                  </asp:DropDownList>  
                                </div>
                              </div>
                              
                              <div class="row mt-3">
                                        <div class="col">
                                            <asp:DropDownList ID="university_choose" class="form-control" runat="server" 
                                                onselectedindexchanged="university_choose_SelectedIndexChanged" AutoPostBack="True">  
                                                <asp:ListItem Value="University Name" Text="University Name"></asp:ListItem>  
                                            </asp:DropDownList> 
                                        </div>
                                        <div class="col">                                        
                                            <asp:DropDownList ID="institute_choose" class="form-control" runat="server"  
                                                onselectedindexchanged="institute_choose_SelectedIndexChanged1" AutoPostBack="True">  
                                            <asp:ListItem Value="Institute Name" Text="Institute Name"></asp:ListItem>  
                                        </asp:DropDownList>  
                                        </div>
                                        <div class="col">
                                            <asp:DropDownList ID="department_choose" class="form-control" runat="server" AutoPostBack="True">  
                                                <asp:ListItem Value="Department Name" Text="Department Name"></asp:ListItem>  
                                            </asp:DropDownList>  
                                        </div>
                                    </div>                         
                              <div class="row mt-3 ">
                                <div class="col">
                                    <asp:TextBox ID="Password" class="form-control" placeholder="Password"  TextMode="password" runat="server"></asp:TextBox>
                                 </div>
                                <div class="col">
                                    <asp:TextBox ID="Confirm"  class="form-control" placeholder="Confirm Password" TextMode="password" runat="server"></asp:TextBox>
                                </div>
                            </div>

                             <div class="row justify-content-center mt-3">
                                   <asp:Button Text="Register" OnClick="register_admin" href="contact.html" class="boxed-btn4" style="  background: #ff3500;color: #fff;border: 1px solid #ff3500;" runat="server" ID="Login"></asp:Button>
                             </div>
                             </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="university_choose" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="institute_choose" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="department_choose" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="choose_level" EventName="SelectedIndexChanged" />
                                </Triggers>
                             </asp:UpdatePanel>
                      </div>
                      <asp:Literal ID="show" runat="server"></asp:Literal>
                </div>
              
            </div>
        </div>
    </div>
</asp:Content>

