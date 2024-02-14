<%@ Page Title="" Language="C#" MasterPageFile="~/Makina.Master" AutoEventWireup="true" CodeBehind="BeniHaberdarEt.aspx.cs" Inherits="SifirGibiMakina.BeniHaberdarEt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <script src="https://cdnjs.cloudflare.com/ajax/libs/gsap/1.18.5/TweenMax.min.js"></script>
    <script>
        const slides = document.querySelectorAll(".slide");
        for (const slide of slides) {
            slide.addEventListener("click", () => {
                removeActiveClass();
                slide.classList.add("active");
            });
        }
        function removeActiveClass() {
            slides.forEach((slide) => {
                slide.classList.remove("active");
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
 <asp:Panel ID="pnlError" runat="server" Visible="false" Width="450px">
     <div class="alert alert-danger alert-dismissable">
      <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
       <h4>	<i class="icon fa fa-ban"></i> <asp:Label ID="lblHata" runat="server"></asp:Label></h4>
       <asp:Label ID="lblHataMesaji" runat="server"></asp:Label>
     </div>
   </asp:Panel>

       
                <div class="iletisim haberdar-et">
            <div class="bize-ulasin py-5 pb-5 sm-py-40px">
                <div class="container">
                    <div class="row iletisim-form">
                        <div class="col-md-12">
                            <h4 class="title">Beni Haberdar Et</h4>
                        </div>
						

                        <div class="col-md-6">
                            <asp:Label ID="lblAciklama" runat="server" CssClass="alert-success"></asp:Label>
                            <asp:Panel ID="pnlIletisim" runat="server">
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:TextBox ID="txtAdSoyad" runat="server" class="form-control" placeholder="Ad, Soyad"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                              ControlToValidate="txtAdSoyad" ErrorMessage="*" ForeColor=Red ValidationGroup="benihaberdaret"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-12">
                                   <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="E-Mail"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                              ControlToValidate="txtEmail" ErrorMessage="*" ForeColor=Red></asp:RequiredFieldValidator>
                          <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                              ErrorMessage="*" 
                              ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                              ControlToValidate="txtEmail" ForeColor=Red ValidationGroup="benihaberdaret"></asp:RegularExpressionValidator>
                                </div>
                                <div class="col-md-12">
                                     <asp:TextBox ID="txtTelefon" runat="server" class="form-control" placeholder="Telefon"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                              ControlToValidate="txtTelefon" ErrorMessage="*" ForeColor=Red ValidationGroup="benihaberdaret"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-12">
                                   <asp:DropDownList ID="ddTurler" runat="server" CssClass="form-control select2" Width="100%" OnSelectedIndexChanged="ddTurler_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList> <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddTurler" InitialValue=0 Text="*" ForeColor=Red ValidationGroup="benihaberdaret"></asp:RequiredFieldValidator>
                            </div>
                                <div class="col-md-12">
                                    <asp:DropDownList ID="ddTurlerAlt" runat="server" CssClass="form-control select2" Width="100%" ValidationGroup="makina">
                        </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Makina Türü boş geçilemez." ControlToValidate="ddTurlerAlt" ForeColor="#CC3300" InitialValue="0" ValidationGroup="benihaberdaret" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                                <div class="col-md-12">
                                   <asp:DropDownList ID="ddMarkalar" runat="server" CssClass="form-control select2" Width="100%"></asp:DropDownList> <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddMarkalar" InitialValue=0 Text="*" ForeColor=Red ValidationGroup="benihaberdaret"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-12">
                                <asp:DropDownList ID="ddYillar" runat="server" CssClass="form-control select2" Width="100%"></asp:DropDownList> <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddYillar" InitialValue=0 Text="*" ForeColor=Red ValidationGroup="benihaberdaret"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-12">
								<asp:TextBox ID="txtModel" runat="server" class="form-control"  placeholder="Model"></asp:TextBox>
                                </div>
                                <div class="col-4 pr-1">
                                    <asp:TextBox ID="txtFiyat1" runat="server" class="form-control" placeholder="Min Fiyat"></asp:TextBox> 
                                </div>
                                <div class="col-4 px-1">
                                     <asp:TextBox ID="txtFiyat2" runat="server" class="form-control" placeholder="Max Fiyat"></asp:TextBox>
                                </div>
                                <div class="col-4 pl-1">
                                    <asp:DropDownList ID="ddParaBirimi" runat="server" CssClass="form-control" ValidationGroup="benihaberdaret"><asp:ListItem Text="TL" Value="1"></asp:ListItem><asp:ListItem Text="Euro" Value="2"></asp:ListItem><asp:ListItem Text="Dolar" Value="3"></asp:ListItem></asp:DropDownList>
                                </div>
                                <div class="col-md-12">
                                     <asp:TextBox ID="txtMesaj" runat="server" Height="83px" 
                              TextMode="MultiLine" Width="100%" class="form-control" placeholder="Makina Özellikleri ve Diğer Açıklamalar"></asp:TextBox>
									<div class="g-recaptcha" data-sitekey="6Ley8KoZAAAAAMSQalyhvbK4ur_RmqVnhxY5CVsP"></div>
                                </div>
                                <div class="col-md-12">
								<asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-block mt-3" Width="150px" OnClick="btnSave_Click" Text="Formu Gönder" ValidationGroup="benihaberdaret" ForeColor="White" UseSubmitBehavior="false" CausesValidation="false"/>
                                </div>
                            </div>
                                </asp:Panel>
                        </div>
                        
                        <div class="col-md-6 sm-mt-2">
                            <h3 class="title">İletişim Bilgileri</h3>
                            <div class="text">
                                <i class="fas fa-map-marker-alt"></i>
                                <p>
                                   <asp:Literal ID="ltAdres" runat="server"></asp:Literal><br><asp:Literal ID="ltIlce" runat="server"></asp:Literal> – <asp:Literal ID="ltSehir" runat="server"></asp:Literal>
                                </p>
                            </div>
                            <div class="text">
                                <i class="fas fa-phone-alt"></i>
                                <p>
                                    <asp:Literal ID="ltPhone" runat="server"></asp:Literal>	
                                </p>
                            </div>
                            <div class="text">
                                <i class="fas fa-envelope"></i>
                                <p>
                                    <asp:Literal ID="ltMail" runat="server"></asp:Literal>	
                                </p>
                            </div>
                            <div class="map">
                                 <asp:Literal ID="ltMaps" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    

</asp:Content>
