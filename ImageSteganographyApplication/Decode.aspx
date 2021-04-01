<%@ Page Title="Decode" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Decode.aspx.cs" Inherits="ImageSteganographyApplication.Decode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <h3 class="text-center pt-3">Decode</h3>
        <div class="container">
            <div class="card m-1 bg-light">
                <img src="Content/Static/decode.png" alt="Default PNG Image" class="card-img-top mypreview d-md-none" />
                
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-6 form-group justify-content-center d-none d-md-block">
                            <%--<asp:Image ID="preview" ImageUrl="~/Content/Static/encode.png" Width="500" Height="300" runat="server" />--%>
                            <img src="Content/Static/decode.png" alt="Default PNG Image" class="img-responsive mypreview imageThumbnail" />
                        </div>
                        <div class="col d-none d-md-block">
                            <div class="ufo">
                                <div class="monster" style="color: #7cb342">
                                    <div class="body">
                                        <div class="ear"></div>
                                        <div class="ear"></div>
                                        <div class="vampi-mouth">
                                            <div class="vampi-tooth"></div>
                                        </div>
                                    </div>
                                    <div class="eye-lid">
                                        <div class="eyes">
                                            <div class="eye"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                       
                    </div>
                    <div class="form-row">
                        <div class="col-md">
                            <div class="form-group">
                                <label class="col-form-label">Upload Picture (in PNG):</label>
                                <div class="custom-file">
                                    <input type="file" name="picture" title="Upload PNG Image"
                                        runat="server" required="required"
                                        class="custom-file-input" id="image_upload" clientidmode="Static" />
                                    <label class="custom-file-label" for="image_upload">Choose file...</label>
                                </div>
                            </div>
                        </div>

                        <div class="col">
                            <div class="form-group">
                                <label class="col-form-label">Select Encrytion Type:</label>
                                <asp:DropDownList ID="encrypt" CssClass="form-control" runat="server">
                                    <asp:ListItem Text="AES"></asp:ListItem>
                                    <asp:ListItem Text="DES"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>


                    <div class="form-group">
                            <label class="col-form-label">Enter Key: </label>
                            <asp:TextBox ID="key" placeholder="Check if no one's seeing !!" class="form-control" runat="server" title="EnterKey" required=""></asp:TextBox>
                    </div>
                    <div class="row">
                        <div class="col form-group text-center">
                            <%-- Reset is done by the HTML tags --%>
                            <button type="reset" class="btn btn-dark mr-1">Reset</button>
                            <asp:Button ID="DecodeSubmitButton" runat="server" Text="Submit" CssClass="btn btn-dark" OnClick="DecodeSubmitButton_Click"></asp:Button>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <asp:Label ID="error" runat="server" ForeColor="Red" CssClass="font-weight-bold" Visible="false">Invalid Data Provided For Decoding</asp:Label>
                        </div>
                    </div>

                    <%-- Display Output here --%>
                    <div class="row">
                        <div class="col form-group">
                            <label class="font-weight-bold">Message: </label>
                            <label id="finalmessage" runat="server"></label>
                            <%-- Display the decoded message here --%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="Scripts/ufo_script.js"></script>
    <script type="text/javascript">
        $(document).ready(function(){
            function loadSelectedImage(input) {
                if (input.files && input.files[0]) {
                    var reader = new FileReader();

                    reader.onload = function (e) {
                        $('.mypreview').attr('src', e.target.result);
                    }

                    reader.readAsDataURL(input.files[0]); // convert to base64 string
                }
            }

            $("#image_upload").change(function () {
                loadSelectedImage(this);
            });
        });
        
    </script>
</asp:Content>
