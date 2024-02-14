<%@ Page Title="" Language="C#" MasterPageFile="~/Makina.Master" AutoEventWireup="true" CodeBehind="Iletisim.aspx.cs" Inherits="SifirGibiMakina.Iletisim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
 <asp:Panel ID="pnlError" runat="server" Visible="false" Width="450px">
     <div class="alert alert-danger alert-dismissable">
      <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
       <h4>	<i class="icon fa fa-ban"></i> <asp:Label ID="lblHata" runat="server"></asp:Label></h4>
       <asp:Label ID="lblHataMesaji" runat="server"></asp:Label>
     </div>
   </asp:Panel>


      <div class="iletisim">
            <div class="iletisim-form py-5 bg-green">
                <div class="container">
                    <div class="row align-items-center">
                        <div class="col-md-5">
                            <h2>Bizimle iletişime geçin</h2>
                            <p>
                                İletişim formumuzu doldurarak bizlere her konuyla ilgili ulaşabilirsiniz. Dilek, öneri ve talepleriniz uzman personellerimiz tarafından dikkatlice değerlendirilecek ve en kısa zamanda size geri dönüş sağlanacaktır.
                            </p>
                        </div>
                        <div class="col-md-7">
  <asp:Panel ID="pnlIletisim" runat="server">
                                <div class="row">
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12 col-12 px-2">
                                        <asp:TextBox ID="txtAdSoyad" runat="server" class="form-control" placeholder="Ad, Soyad" ValidationGroup="iletisim"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                              ControlToValidate="txtAdSoyad" ErrorMessage="*" ForeColor=Red ValidationGroup="iletisim"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12 col-12 px-2">
                                       <asp:TextBox ID="txtKonu" runat="server" class="form-control" placeholder="Konu"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12 col-12 px-2">
                                      <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="E-Posta" ValidationGroup="iletisim"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                              ControlToValidate="txtEmail" ErrorMessage="*" ForeColor=Red></asp:RequiredFieldValidator>
                          <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                              ErrorMessage="*" 
                              ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                              ControlToValidate="txtEmail" ForeColor=Red ValidationGroup="iletisim"></asp:RegularExpressionValidator>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12 col-12  px-2">
                                         <asp:TextBox ID="txtTelefon" runat="server" class="form-control" placeholder="Telefon" ValidationGroup="iletisim"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                              ControlToValidate="txtTelefon" ErrorMessage="*" ForeColor=Red ValidationGroup="iletisim"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col px-2">
                                         <asp:TextBox ID="txtMesaj" runat="server"  
                              TextMode="MultiLine" Width="100%" class="form-control" Rows="4"></asp:TextBox>
                                        
                                    </div>
                                   
                                </div>

                                <div class="row iletisim-checkboxes">
                                    <div class="col-md-12 px-2">
                                        <div class="form-group form-check mb-0 register-checboxs">
                                            <input class="form-check-input" type="checkbox" id="gridCheck" required="" runat="server">
                                            <label class="form-check-label kabul-et" for="gridCheck">
                                                <a href="/sayfalar/9/site-kullanim-sartlari" target="_blank">Kişisel verilerin işlenmesine ilişkin aydınlatma metnini</a> okudum, kabul ediyorum.
                                            </label>
                                        </div>
                                    </div>

                                </div>
                                <div class="row">
                                    <div class="col-md-12 px-2">
                                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-block submit-button" Width="150px" OnClick="btnSave_Click" Text="Gönder" ValidationGroup="iletisim"/>

                                    </div>
                                </div>

      </asp:Panel>

<asp:Panel ID="pnlBitti" runat="server" Visible="false">
    <div class="row">
                                    <div class="col-md-12 px-2">
                                       
                                                  <h3>Tebrikler</h3>
                                                  <p>Mesajınız tarafımıza ulaşmıştır. Size en yakın sürede dönüş sağlayacağız.</p>
                                                </div>
                                </div>
    </asp:Panel>
                           
                        </div>
                    </div>
                </div>
            </div>
            <div class="bize-ulasin py-6 pb-5 sm-py-40px">
                <div class="container">
                    <div class="row">
                        <div class="col-md-4">
                            <h4 class="title">Bize Ulaşın</h4>
                            <div class="text">
                                <i class="fas fa-map-marker-alt"></i>
                                <p>
                                    <asp:Literal ID="ltAdres" runat="server"></asp:Literal> <br><asp:Literal ID="ltIlce" runat="server"></asp:Literal> – <asp:Literal ID="ltSehir" runat="server"></asp:Literal>
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
                        </div>
                        <div class="col-md-8">
                            <div class="map">
                                <asp:Literal ID="ltMaps" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
