<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- bradcam_area_start -->
    <div class="bradcam_area1 breadcam_bg">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="bradcam_text text-center">
                        <h3 style="color:White;font-size:xx-large;">Register</h3style></h3>
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
                                    <asp:TextBox ID="Contact" class="form-control" placeholder="Contact Number " runat="server"></asp:TextBox>
                                 </div>                                                            
                                <div class="col">                
                                    <asp:TextBox ID="Email" class="form-control" placeholder="Email Adrress" runat="server"></asp:TextBox>
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
                             <div class="row mt-3 ">
                                <div class="col">
                                  <asp:DropDownList ID="DropDownList1" class="form-control" runat="server" >  
                                    <asp:ListItem Value="" InitialValue="Unselectable Item">Department Name</asp:ListItem>  
                                    <asp:ListItem>Department1</asp:ListItem>  
                                    <asp:ListItem>Department2</asp:ListItem>  
                                    <asp:ListItem>Department3</asp:ListItem>  
                                    <asp:ListItem>Department4</asp:ListItem>  
                                    <asp:ListItem>Department5</asp:ListItem>  
                                </asp:DropDownList>  
                                </div>
                                <div class="col">                                        
                                  <asp:DropDownList ID="inputState" class="form-control" runat="server" >  
                                    <asp:ListItem Value="" InitialValue="Unselectable Item">Institute Name</asp:ListItem>  
                                    <asp:ListItem>Institute1</asp:ListItem>  
                                    <asp:ListItem>Institute2</asp:ListItem>  
                                    <asp:ListItem>Institute3</asp:ListItem>  
                                    <asp:ListItem>Institute4</asp:ListItem>  
                                    <asp:ListItem>Institute5</asp:ListItem>  
                                </asp:DropDownList>  
                                </div>
                                  <div class="col">
                                      <asp:DropDownList ID="university" class="form-control" runat="server" >  
                                        <asp:ListItem Value="" InitialValue="Unselectable Item">University Name</asp:ListItem>  
                                        <asp:ListItem>University1</asp:ListItem>  
                                        <asp:ListItem>University2</asp:ListItem>  
                                        <asp:ListItem>University3</asp:ListItem>  
                                        <asp:ListItem>University4</asp:ListItem>  
                                        <asp:ListItem>University5</asp:ListItem>  
                                    </asp:DropDownList> 
                                </div>
                             </div>
                             <div class="row mt-3 ">
                                <div class="col">
                                      <asp:DropDownList ID="year" class="form-control" runat="server" >  
                                        <asp:ListItem Value="" InitialValue="Unselectable Item">Admission Year</asp:ListItem>  
                                        <asp:ListItem>2020</asp:ListItem>  
                                        <asp:ListItem>2019</asp:ListItem>  
                                        <asp:ListItem>2018</asp:ListItem>  
                                        <asp:ListItem>2017</asp:ListItem>  
                                        <asp:ListItem>2016</asp:ListItem>  
                                    </asp:DropDownList> 
                                </div>
                                <div class="col">
                                      <asp:DropDownList ID="curryear" class="form-control" runat="server" >  
                                        <asp:ListItem Value="" InitialValue="Unselectable Item">Current Year</asp:ListItem>  
                                        <asp:ListItem>2020</asp:ListItem>  
                                        <asp:ListItem>2019</asp:ListItem>  
                                        <asp:ListItem>2018</asp:ListItem>  
                                        <asp:ListItem>2017</asp:ListItem>  
                                        <asp:ListItem>2016</asp:ListItem>  
                                    </asp:DropDownList>
                                </div>
                              </div>
                             <div class="row mt-3 ">
                                <div class="col">
                                      <asp:DropDownList ID="shift" class="form-control" runat="server" >  
                                        <asp:ListItem Value="" InitialValue="Unselectable Item">Shift</asp:ListItem>  
                                        <asp:ListItem>First Shift</asp:ListItem>  
                                        <asp:ListItem>Second Shift</asp:ListItem>  
                                    </asp:DropDownList>
                                </div>
                                <div class="col">
                                    <asp:TextBox ID="Roll"  class="form-control" placeholder="Roll Number " runat="server"></asp:TextBox>
                                 </div>                                                            
                                <div class="col">
                                    <asp:TextBox ID="PNR" class="form-control" placeholder="PNR Number" runat="server"></asp:TextBox>
                                </div>
                            </div>
                             <div class="row justify-content-center mt-3">
                                   <asp:LinkButton Text="Register" href="contact.html" class="boxed-btn4" style="  background: #ff3500;color: #fff;border: 1px solid #ff3500;" runat="server" ID="Login"></asp:LinkButton>
                             </div>
                      </div>
                </div>
              
            </div>
        </div>
    </div>
</asp:Content>

