<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="track_complaint.aspx.cs" Inherits="track_complaint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script>
    $(document).ready(function () {
        var firstshow = true;
        var checkshow = false;
        $("#div1").click(function () {
            if (firstshow == true) {
                $("#div1").animate({ left: '-500px' });
                firstshow = false;
            }
            if (checkshow == true) {
                $("#div1").animate({ left: '-500px' });
                $("#div2").animate({ left: '0px' });
                checkshow = false;
            }
        });
        $("#div2").click(function () {
            if (firstshow == true) {
                $("#div2").animate({ left: '500px' });
                firstshow = false;
                checkshow = true;
            }
            if (checkshow == false) {
                $("#div1").animate({ left: '0px' });
                $("#div2").animate({ left: '500px' });
                checkshow = true;
            }
        });
    });
</script> 
    <!-- bradcam_area_start -->
    <div class="bradcam_area1 breadcam_bg">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="bradcam_text text-center">
                        <h3 style="color:White;font-size:xx-large;">Track your complaint status</h3>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <!-- bradcam_area_end -->
    <div class="service_area"  style ="padding:0px ; margin:0px;">
        <div class="container">
            <div class="row justify-content-center ">
                <div class="col-lg-7 col-md-10">
                    <div class="section_title text-center mb-95">
                    </div>
                </div>
            </div>
            <div class="row justify-content-center">
                <div class="col-lg-6 col-md-8">
                    <div class="single_service" style="overflow: hidden;">
		                <div id="div1" style="background:#98bf21;position: relative;z-index: 1000;">
			                Solved
		                </div>
		                <div style="background:#999999;position: absolute;z-index: 10;">
			                ID&nbsp;&nbsp;&nbsp;Subject
		                </div>
                    </div>
                   
                </div>
                <div class="col-lg-6 col-md-8">
                    <div class="single_service" style="overflow: hidden;">
		                <div id="div2" style="background:#98bf21;position: relative;z-index: 1000;">
			                Unsolved
		                </div>
		                <div style="background:#999999;position: absolute;z-index: 10;">
			                ID&nbsp;&nbsp;&nbsp;Subject
		                </div>
                    </div>
                </div>

            </div>
        </div>
    </div>

</asp:Content>

