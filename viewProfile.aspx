<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="viewProfile.aspx.cs" Inherits="student_viewProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                        
                               
                                    <div class="row">
                                        <div class="col">
                                            <label for="First">First Name</label>
                                            <asp:TextBox ID="First" class="form-control" runat="server" pattern="[A-Za-z]+" required="true" title="Alphabets only"></asp:TextBox>
                                         </div>
                                        <div class="col">
                                        <label for="First">Last Name</label>
                                            <asp:TextBox ID="Last" class="form-control"  runat="server" pattern="[A-Za-z]+" required="true" title="Alphabets only"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row mt-3 ">
                                        <div class="col">
                                        <label for="First">Contact Number</label>
                                            <asp:TextBox ID="Contact" class="form-control"  runat="server" pattern="[0-9]{10}" required="true" title="Enter 10 digit contact number"></asp:TextBox>
                                         </div>                                                            
                                        <div class="col">  
                                        <label for="First">Email Address</label>              
                                            <asp:TextBox ID="Email" class="form-control"  runat="server" pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$" required="true" title="Enter valid email address"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row mt-3">
                                        <div class="col">
                                        <label for="First">University Name</label>
                                            <asp:DropDownList ID="DropDownList2" class="form-control"  runat="server">
                                                <asp:ListItem Value="">Please Select</asp:ListItem>  
                                                <asp:ListItem>New Delhi </asp:ListItem>  
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col">       
                                        <label for="First">Institute Name</label>                                 
                                            <asp:DropDownList ID="DropDownList3" class="form-control" runat="server">
                                                <asp:ListItem Value="">Please Select</asp:ListItem>  
                                                <asp:ListItem>New Delhi </asp:ListItem>  
                                            </asp:DropDownList>  
                                        </div>
                                        <div class="col">
                                        <label for="First">Department Name</label>
                                            <asp:DropDownList ID="DropDownList1" class="form-control" runat="server">
                                                <asp:ListItem Value="">Please Select</asp:ListItem>  
                                                <asp:ListItem>New Delhi </asp:ListItem>  
                                            </asp:DropDownList> 
                                        </div>
                                    </div>
                                    <div class="row mt-3 ">
                                    <div class="col">
                                    <label for="First">Addmission Year</label>
                                        <asp:DropDownList ID="DropDownList4" class="form-control"  runat="server">
                                                <asp:ListItem Value="">Please Select</asp:ListItem>  
                                                <asp:ListItem>New Delhi </asp:ListItem>  
                                            </asp:DropDownList>
                                    </div>
                                    <div class="col">
                                    <label for="First">Current Year</label>
                                        <asp:DropDownList ID="DropDownList5" class="form-control"  runat="server">
                                                <asp:ListItem Value="">Please Select</asp:ListItem>  
                                                <asp:ListItem>New Delhi </asp:ListItem>  
                                            </asp:DropDownList>
                                    </div>
                                    </div>

                             <div class="row mt-3 ">
                                <div class="col">
                                <label for="First">Shift</label>
                                      <asp:DropDownList ID="Shift" class="form-control" runat="server" >  
                                        <asp:ListItem Value="Shift">Shift</asp:ListItem>  
                                        <asp:ListItem Value="First Shift">First Shift</asp:ListItem>  
                                        <asp:ListItem Value="Second Shift">Second Shift</asp:ListItem>
                                        <asp:ListItem Value="None">None</asp:ListItem>   
                                    </asp:DropDownList>
                                </div>
                                <div class="col">
                                <label for="First">Roll Number</label>
                                    <asp:TextBox ID="Roll"  class="form-control"  runat="server" pattern="[0-9]+" required="true" title="Numbers only"></asp:TextBox>
                                 </div>                                                            
                                <div class="col">
                                <label for="First">PNR Number</label>
                                    <asp:TextBox ID="PNR" class="form-control"  runat="server" pattern="[0-9]+" required="true" title="Numbers only"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row justify-content-center mt-3">
                                <asp:Button Text="Update Profile" class="boxed-btn4" 
                                    style="background: #ff3500;color: #fff;border: 1px solid #ff3500;" 
                                    runat="server" >
                                    </asp:Button>
                            </div>
                         
                     
                      </div>
                </div>
              
            </div>
        </div>
    </div>

</asp:Content>

