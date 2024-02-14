<%@ Page Title="" Language="C#" MasterPageFile="~/Makina.Master" AutoEventWireup="true" CodeBehind="Expertiz.aspx.cs" Inherits="SifirGibiMakina.Ekspertiz" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlExpertiz1" runat="server">
  <div class="sgm-ekspertiz py-5">
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <h3 class="title">Sıfır Gibi Ekspertiz</h3>
                    </div>
                </div>
                <div class="row mt-5">
                    <div class="col-lg-3 col-md-3 col-sm-6 col-6 col-12 sm-my-8">
                        <div class="card">
                            <div class="card-body">
                                <img src="/images/sgm-ekspertiz/1.png" alt="">
                                <h6 class="title">Uygun Fiyatlandırma</h6>
                                <p class="text">Her Bütçeye Uygun Ekpertiz Fırsatları</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-6 col-6 col-12 sm-my-8">
                        <div class="card">
                            <div class="card-body">
                                <img src="/images/sgm-ekspertiz/2.png" alt="">
                                <h6 class="title">Şube Kolaylığı</h6>
                                <p class="text">Size En Yakın Ekpertiz Noktasını Bulun</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-6 col-6 col-12 sm-my-8">
                        <div class="card">
                            <div class="card-body">
                                <img src="/images/sgm-ekspertiz/1.png" alt="">
                                <h6 class="title">Detaylı Rapor</h6>
                                <p class="text">İşlem Sonunda Detaylı Ekspertiz Raporunuzu Alın</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-6 col-6 col-12 sm-my-8">
                        <div class="card">
                            <div class="card-body">
                                <img src="/images/sgm-ekspertiz/2.png" alt="">
                                <h6 class="title">Güvenilir Hizmet</h6>
                                <p class="text">Güvenli ve Sorunsuz Bir Şekilde Ekspertiz Yaptırın</p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row my-5 texts">
                 
                    <div class="col-12 text-center">
                        <asp:Button ID="btnExpertiz1" runat="server" Text="Ekspertiz Hizmeti Al" CssClass="btn btn-success" OnClick="btnExpertiz1_Click"/>
                    </div>
                </div>
            </div>
        </div>
        </asp:Panel>

    <asp:Panel ID="pnlExpertiz2" runat="server" Visible="false">
         <div class="sgm-ekspertiz py-5">
        <div class="container">
            <div class="row">
                <div class="col-12 text-center">
                    <h4 class="subtitle">Sıfır Gibi Makina ile Ekspertiz Randevunuzu Hemen Alın</h4>
                </div>
            </div>
            <div class="row">
                <div class="col-12">
                    <div class="box">
                        <div class="text-center">
                            <img src="/images/sgm-ekspertiz/2.png" alt="">
                            <p class="text">Şube Seçimi</p>
                        </div>
                        <div class="dots">
                            <i class="fas fa-circle"></i>
                            <i class="fas fa-circle"></i>
                            <i class="fas fa-circle"></i>
                        </div>
                        <div class="text-center">
                            <img src="/images/sgm-ekspertiz/2.png" alt="">
                            <p class="text">Tarih Seçimi</p>
                        </div>
                        <div class="dots">
                            <i class="fas fa-circle"></i>
                            <i class="fas fa-circle"></i>
                            <i class="fas fa-circle"></i>
                        </div>
                        <div class="text-center">
                            <img src="/images/sgm-ekspertiz/2.png" alt="">
                            <p class="text">Müşteri ve Makine Bilgileri</p>
                        </div>
                        <div class="dots">
                            <i class="fas fa-circle"></i>
                            <i class="fas fa-circle"></i>
                            <i class="fas fa-circle"></i>
                        </div>
                        <div class="text-center">
                            <img src="/images/sgm-ekspertiz/2.png" alt="">
                            <p class="text">Onay</p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row my-4">
                <div class="col-4 sm-pr-8">
                    <div class="profilim my-0">
                        <div class="profil-right-box">
                            <div class="form-group">
                                                <asp:DropDownList ID="ddCountries" runat="server"  CssClass="form-control select2" Width="100%" OnSelectedIndexChanged="ddCountries_SelectedIndexChanged" AutoPostBack="true">
</asp:DropDownList>
                                <i class="fa fa-chevron-down select-icon"></i>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-4 sm-px-8">
                    <div class="profilim my-0">
                        <div class="profil-right-box">
                            <div class="form-group">
                      <asp:DropDownList ID="ddCategory" runat="server"  CssClass="form-control select2" Width="100%" OnSelectedIndexChanged="ddCategory_SelectedIndexChanged" AutoPostBack="true">
   </asp:DropDownList>
                                <i class="fa fa-chevron-down select-icon"></i>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-4 sm-pl-8">
                    <div class="profilim my-0">
                        <div class="profil-right-box">
                            <div class="form-group">
                                                  <asp:DropDownList ID="ddSubCateory" runat="server"  OnSelectedIndexChanged="ddSubCategory_SelectedIndexChanged" CssClass="form-control select2" Width="100%"  AutoPostBack="true">
</asp:DropDownList>
                                <i class="fa fa-chevron-down select-icon"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

<%--            firma bilgileri--%>

              <div class="row">
                              <asp:Repeater ID="rptServiceFirm" runat="server" >
<ItemTemplate>
      
               
                        <div class="col-xl-4 col-lg-7 col-md-12 my-1">
     <div class="card profile-header">
         <div class="body">
             <div class="row">
               
                 <div class="col-lg-12 col-md-8 col-12">

                     <a href='<%# "/servis-" + Eval("ServiceUserID") %>'  style="text-decoration: none; color: black;">
    <h4 class="m-t-0 m-b-0"><strong><%# Eval("FirmName") %></strong></h4>
</a>

           

                     <span class="job_post"> <i class="fas fa-mail-alt"></i>
<%# Eval("Email") %></span>
                     <p>   
                               <i class="fas fa-map-marker-alt"></i>    
                         <%# Eval("Address") %></p>
                     <div>
                        
                    
                        <asp:Button runat="server" ID="btnOpenAppointment" class="btn btn-primary btn-round btn-simple" Text="Randevu Al" 
    CommandArgument='<%# Eval("ServiceUserID") %>' data-uye-id='<%# Eval("ServiceUserID") %>' 
    OnClick="btnOpenAppointment_Click" style="background-color: #44b276;" />

                     </div>
              
                 </div>                
             </div>
         </div>                    
     </div>
 </div>
        
             





 
                        </ItemTemplate>
</asp:Repeater>
      








     
      
        
        
       




     </div>
        </div>
 
    </asp:Panel>


    <asp:Panel ID="pnlExpertiz3" runat="server" Visible="false">
<div class="sgm-ekspertiz py-5">
        <div class="container">
            <div class="row">
                <div class="col-12 text-center">
                    <h4 class="subtitle">Sıfır Gibi Makina ile Ekspertiz Randevunuzu Hemen Alın</h4>
                </div>
            </div>
            <div class="row">
                <div class="col-12">
                    <div class="box">
                        <div class="text-center">
                            <img src="/images/sgm-ekspertiz/2.png" alt="">
                            <p class="text">Şube Seçimi</p>
                        </div>
                        <div class="dots">
                            <i class="fas fa-circle"></i>
                            <i class="fas fa-circle"></i>
                            <i class="fas fa-circle"></i>
                        </div>
                        <div class="text-center">
                            <img src="/images/sgm-ekspertiz/2.png" alt="">
                            <p class="text">Tarih Seçimi</p>
                        </div>
                        <div class="dots">
                            <i class="fas fa-circle"></i>
                            <i class="fas fa-circle"></i>
                            <i class="fas fa-circle"></i>
                        </div>
                        <div class="text-center">
                            <img src="/images/sgm-ekspertiz/2.png" alt="">
                            <p class="text">Müşteri ve Makine Bilgileri</p>
                        </div>
                        <div class="dots">
                            <i class="fas fa-circle"></i>
                            <i class="fas fa-circle"></i>
                            <i class="fas fa-circle"></i>
                        </div>
                        <div class="text-center">
                            <img src="/images/sgm-ekspertiz/2.png" alt="">
                            <p class="text">Onay</p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row mt-4">
                <div class="col-md-12">
                    <div class="select-date">
                        <div class="card">
                            <div class="card-header">
                                <h5 class="title" id="hName" runat="server"></h5>
                               
                            </div>
                            <div class="card-body">
                                <p id="adress" runat="server">
                                    <i class="fas fa-map-marker-alt"></i>
                                    
                                </p>
                                <p id="prfEmail" runat="server">
                                    <i class="fas fa-phone-alt"></i>
                                   
                                </p>
                             
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-3 mx-auto mt-5 mb-4">
                    <div class="profilim my-0">
                        <div class="profil-right-box">
                            <div class="form-group">
                                Randevu Tarihi
                                <input type="date" class="form-control" id="txtRandevuTarihi" runat="server">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                
                <div class="col-md-12 text-center mt-4">
                   <asp:Button ID="btnExpertiz3" runat="server" Text="Devam Et" CssClass="btn btn-success" OnClick="btnExpertiz3_Click"/>
                </div>
            </div>
        </div>
    </div>
    </asp:Panel>

    <asp:Panel ID="pnlExpertiz4" runat="server" Visible="false">
        <div class="sgm-ekspertiz py-5">
        <div class="container">
            <div class="row">
                <div class="col-12 text-center">
                    <h4 class="subtitle">Sıfır Gibi Makina ile Ekspertiz Randevunuzu Hemen Alın</h4>
                </div>
            </div>
            <div class="row">
                <div class="col-12">
                    <div class="box">
                        <div class="text-center">
                            <img src="/images/sgm-ekspertiz/2.png" alt="">
                            <p class="text">Şube Seçimi</p>
                        </div>
                        <div class="dots">
                            <i class="fas fa-circle"></i>
                            <i class="fas fa-circle"></i>
                            <i class="fas fa-circle"></i>
                        </div>
                        <div class="text-center">
                            <img src="/images/sgm-ekspertiz/2.png" alt="">
                            <p class="text">Tarih Seçimi</p>
                        </div>
                        <div class="dots">
                            <i class="fas fa-circle"></i>
                            <i class="fas fa-circle"></i>
                            <i class="fas fa-circle"></i>
                        </div>
                        <div class="text-center">
                            <img src="/images/sgm-ekspertiz/2.png" alt="">
                            <p class="text">Müşteri ve Makine Bilgileri</p>
                        </div>
                        <div class="dots">
                            <i class="fas fa-circle"></i>
                            <i class="fas fa-circle"></i>
                            <i class="fas fa-circle"></i>
                        </div>
                        <div class="text-center">
                            <img src="/images/sgm-ekspertiz/2.png" alt="">
                            <p class="text">Onay</p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row mt-4">
                <div class="col-md-12">
                    <div class="select-date">
                        <div class="card">
                            <div class="card-header">
                                <h5 class="title" id="pnl4Name" runat="server"></h5>
                                <asp:LinkButton ID="MyLnkButton" runat="server" onClick="MyLnkButton_Click"> <i class="fas fa-undo"></i> Değiştir</asp:LinkButton>
                               
                               
                            </div>
                            <div class="card-body">
                                 <p id="pnl4Adress" runat="server">
                                    <i class="fas fa-map-marker-alt"></i>
                                    
                                </p>
                                <p id="pnl4Email" runat="server">
                                    <i class="fas fa-phone-alt"></i>
                                
                                </p>
                               
                                <p>
                                    <i class="far fa-calendar"></i>
                                    <asp:Label ID="lblSecilenTarih" runat="server" Text="Label"></asp:Label>
                                </p>
                               
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="profilim mb-0 mt-5">
                <div class="profil-right-box">
                    <div class="row">
                        <div class="col-md-12">
                            <h5 class="form-title">
                                Kişisel Bilgiler
                            </h5>
                        </div>
                        <div class="col-md-6 pr-025rem sm-px-8">
                            <div class="form-group">
                                <input type="text" class="form-control" id="ad" runat="server"  disabled="disabled">
                            </div>
                        </div>
                        <div class="col-md-6 pl-025rem sm-px-8">
                            <div class="form-group">
                                <input type="text" class="form-control" id="soyad"  runat="server"  disabled="disabled">
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        
                        <div class="col-md-6 pr-025rem sm-px-8">
                            <div class="form-group">
                                <input type="tel" class="form-control" id="telefonno"   runat="server"  disabled="disabled">
                            </div>
                        </div>
                        <div class="col-md-6 pl-025rem sm-px-8">
                            <div class="form-group">
                             <input type="text" class="form-control" id="eposta"  runat="server" disabled="disabled">

                            </div>
                        </div>
                    </div>

                    <div class="row mt-5">
                        <div class="col-md-12">
                            <h5 class="form-title">
                                Makine Bilgileri
                            </h5>
                        </div>
                        <div class="col-md-6">
                            <p class="label">Makine Başlığı</p>
                            <div class="form-group position-relative">
                        <asp:TextBox ID="txtMakinaBaslik" runat="server" class="form-control" placeholder="Makine Başlığı"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Zorunlu alan" ControlToValidate="txtMakinaBaslik" ForeColor="#CC3300" ValidationGroup="makinamneeder"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <p class="label">Makine Modeli</p>
                            <div class="form-group position-relative">
                         <asp:TextBox ID="txtModel" runat="server" class="form-control" placeholder="Makine Modeli"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <p class="label">Makine Türü</p>
                            <div class="form-group position-relative">
                        <asp:DropDownList ID="ddTurler" runat="server" CssClass="form-control select2" Width="100%" ValidationGroup="makinamneeder" OnSelectedIndexChanged="ddTurler_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="* Zorunlu alan" ControlToValidate="ddTurler" ForeColor="#CC3300" InitialValue="0" ValidationGroup="makinamneeder"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <p class="label">Makine Alt Türü</p>
                            <div class="form-group position-relative">
                                <asp:DropDownList ID="ddTurlerAlt" runat="server" CssClass="form-control select2" Width="100%" ValidationGroup="makinamneeder">
                        </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Makina Türü boş geçilemez." ControlToValidate="ddTurlerAlt" ForeColor="#CC3300" InitialValue="0" ValidationGroup="makina" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <p class="label">Makine Üretim Yılı</p>
                            <div class="form-group position-relative">
                               <asp:DropDownList ID="ddYillar" runat="server" CssClass="form-control select2" Width="100%" ValidationGroup="makinamneeder">
                        </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="* Zorunlu alan" ControlToValidate="ddYillar" ForeColor="#CC3300" InitialValue="0" ValidationGroup="makinamneeder"></asp:RequiredFieldValidator>
                                <i class="fa fa-chevron-down select-icon"></i>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <p class="label">Makine Markası</p>
                            <div class="form-group position-relative">
                            <asp:DropDownList ID="ddMarkalar" runat="server" CssClass="form-control select2" Width="100%" ValidationGroup="makinamneeder">
                        </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="* Zorunlu alan" ControlToValidate="ddMarkalar" ForeColor="#CC3300" InitialValue="0" ValidationGroup="makinamneeder"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        
                        <div class="col-12 mt-4 text-center">
                            <asp:Button ID="btnExpertiz4" runat="server" Text="Randevu Talebini Gönder" CssClass="btn btn-success" OnClick="btnExpertiz4_Click"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    </asp:Panel>

    <asp:Panel ID="pnlExpertiz5" runat="server" Visible="false">

         <div class="sgm-ekspertiz py-5">
        <div class="success">
            <div class="container">
                <div class="row">
                    <div class="col-md-8 mx-auto text-center">
                        <i class="fas fa-check success-icon"></i>
                        <h4 class="success-title">Tebrikler!</h4>
                        <p class="success-text">
                            <asp:Label ID="lblRandevuTarihiBilgi" runat="server"></asp:Label> </p>
                    </div>
                </div>
               
            </div>
        </div>
    </div>
    </asp:Panel>

</asp:Content>
