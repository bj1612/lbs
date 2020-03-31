<%@ Page Title="Add Category" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AddCategory.aspx.cs" Inherits="admin_AddCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="background_check">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="bradcam_text text-center">
                        <h3 style="color:White;font-size:xx-large;">Add Category</h3>
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
                            <div class="row">
                                <div class="col">
                                    <label for="Category" style="font-weight:bold;padding-left:10px;">Available Category</label>
                                    <asp:DropDownList ID="Category" class="form-control" runat="server">
                                        <asp:ListItem Value="Available Category" Text="Available Category"></asp:ListItem>
                                    </asp:DropDownList>  
                                </div>
                            </div>
                            <div class="row mt-3">
                                <div class="col">
                                    <asp:TextBox ID="CategoryName" class="form-control" placeholder="Category name" runat="server" pattern="[A-Za-z ]+" required="true" title="Alphabets only"></asp:TextBox>
                                </div>
                            </div>                          
                                
                            <div class="row justify-content-center mt-3">
                                <asp:Button Text="Add" class="boxed-btn4" 
                                style="background: #ff3500;color: #fff;border: 1px solid #ff3500;"
                                        runat="server" ID="Add" onclick="Add_Click">
                                </asp:Button>
                            </div>
                        </div>
                   </div>
               </div>
           </div>
       </div>
</asp:Content>

