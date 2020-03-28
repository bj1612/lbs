<%@ Page Title="Add University" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Add_university.aspx.cs" Inherits="systemAdmin_Add_university" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="updatepanel" runat="server" />
    <div class="background_check">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="bradcam_text text-center">
                        <h3 style="color:White;font-size:xx-large;">Add University</h3>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="service_area" style ="padding:0px ; margin:0px;">
            <div class="container">            
                <div class="row justify-content-center">
                    <div class="col-lg-8 col-md-10  p-3 mb-5 " style="margin-top:0px;">
                        <div class="single_service active">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="col">
                                            <label for="University">Available Universities</label>
                                            <asp:DropDownList ID="University" class="form-control" runat="server">
                                            </asp:DropDownList>  
                                        </div>
                                    </div>
                                    <div class="row mt-3">
                                        <div class="col">
                                            <asp:TextBox ID="UniversityName" class="form-control" placeholder="University name" runat="server" pattern="[A-Za-z ]+" required="true" title="Alphabets only"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row mt-3">
                                        <div class="col">
                                            <asp:DropDownList ID="State" class="form-control" runat="server" 
                                        onselectedindexchanged="State_SelectedIndexChanged" AutoPostBack="True">  
                                                <asp:ListItem Value="Select State" Text="Select State"></asp:ListItem> 
                                            </asp:DropDownList>  
                                        </div>
                                    </div>
                                    <div class="row mt-3">
                                        <div class="col">
                                            <asp:DropDownList ID="City" class="form-control" runat="server">  
                                                <asp:ListItem Value="Select City" Text="Select City"></asp:ListItem> 
                                            </asp:DropDownList>  
                                        </div>
                                    </div>
                                    <div class="row mt-3">                                                            
                                        <div class="col">                
                                            <asp:TextBox ID="Address" class="form-control" placeholder="Address" runat="server" required="true" TextMode="MultiLine" Rows="3"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row mt-3">                                                            
                                        <div class="col">                
                                            <asp:TextBox ID="Contact" class="form-control" placeholder="Contact" runat="server" pattern="[0-9]{10}" required="true" title="Enter 10 digit contact number"></asp:TextBox>
                                        </div>
                                    </div>                          
                                
                                    <div class="row justify-content-center mt-3">
                                        <asp:Button Text="Add" class="boxed-btn4" 
                                        style="background: #ff3500;color: #fff;border: 1px solid #ff3500;"
                                               runat="server" ID="Add" onclick="Add_Click">
                                        </asp:Button>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="State" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="Add" EventName="Click"/>
                                </Triggers>
                            </asp:UpdatePanel>
                            <asp:Label ID="show" runat="server"></asp:Label>
                        </div>
                   </div>
               </div>
           </div>
       </div>
</asp:Content>

