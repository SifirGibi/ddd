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
                    <div class="col-12">
                        <h4 class="title">Sıfır Gibi Ekspertiz Nedir?</h4>
                        <p class="text">
                            İncelenecek yada incelenmiş olan makinelerin detaylı bir şekilde (gerekirse test cihazları kullanarak) Alıcı yada talepte bulunan firmaya mevcutta bulunan arızalarını yada oluşabilecek arızaların Uzman servis Personeli tarafıdan sunulmasıdır.
                        </p>
                    </div>
                    <div class="col-12 my-3">
                        <h4 class="title">Ekspertiz Nasıl Yapılır?</h4>
                        <p class="text">
                        Müşteri talebine göre incelenek makine için Alıcı yada Müşteri makine exper bölümünden direk olarak talepte bulunur.Sıfırgibi Servis personeli  talebi inceler ve talepte bulunan firmaya teklif gönderir.Teklifin onaylanması ile birlik uzman servis personeli Makinanın bulunduğu konumda gerekli cihazları ile birlikte bir exper raporu oluşturur ve müşteriye sunar.                        </p>
                    </div>
                    <div class="col-12 my-3">
                        <h4 class="title">Ekspertiz Bağlayıcılığı Nasıldır?</h4>
                        <p class="text">
                        Exper raporu tamamen Sıfırgibi makine Uzman servis ekibinin öngörüsü ile sunulmaktadır.Hiç bir kurum yada kişiler için bağlayacılık sağlamaz. Bunun için Talepte bulunan firma yada kişiler exper raporu ile ilgili Sıfırgibi makina'dan herhangibir hak talep edemez.                        </p>
                    </div>
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
                                <select class="form-control" id="il-secin">
                                    <option>İl Seçin</option>
                                    <option>Kocaeli</option>
                                </select>
                                <i class="fa fa-chevron-down select-icon"></i>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-4 sm-px-8">
                    <div class="profilim my-0">
                        <div class="profil-right-box">
                            <div class="form-group">
                                <select class="form-control" id="ilce-secin">
                                    <option>İlçe Seçin</option>
                                    <option>Çerkeşli</option>
                                </select>
                                <i class="fa fa-chevron-down select-icon"></i>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-4 sm-pl-8">
                    <div class="profilim my-0">
                        <div class="profil-right-box">
                            <div class="form-group">
                                <select class="form-control" id="firma-secin">
                                    <option>Firma Seçin</option>
                                    <option>Sıfır Gibi Makina</option>
                                </select>
                                <i class="fa fa-chevron-down select-icon"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <div class="accordion" id="accordionExample">
                        <div class="card">
                          <div class="card-header" id="headingOne">
                            <h2 class="mb-0">
                              <button class="btn btn-link btn-block text-left" type="button" data-toggle="collapse" data-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                                <div class="form-check">
                                    <input class="form-check-input" type="radio" name="exampleRadios" id="exampleRadios1" value="option1" checked>
                                    <label class="form-check-label" for="exampleRadios1">
                                        Sıfır Gibi Makina  Ekspertiz
                                    </label>
                                </div>
                              </button>
                            </h2>
                          </div>
                          <div id="collapseOne" class="collapse show" aria-labelledby="headingOne" data-parent="#accordionExample">
                            <div class="card-body">
                                <p>
                                    <i class="fas fa-map-marker-alt"></i>
                                    Çerkeşliosb Mah. İmes-17 Cad. Küçük Sanayi Sitesi D5 No: 12 İç Kapı No: 1 Dilovası – Kocaeli
                                </p>
                                <p>
                                    <i class="fas fa-phone-alt"></i>
                                    +905416074347
                                </p>
                                <p>
                                    <i class="fas fa-link"></i>
                                    www.sifirgibimakine.com
                                </p>
                            </div>
                          </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-8">
                    <div class="map">
                        <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3019.301399720301!2d29.567277315245246!3d40.82134297932022!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14cb25a4972eb655%3A0x3fe8f38f064571f2!2sS%C4%B1f%C4%B1rgibi%20Makine%20Sanayi%20ve%20Tic.%20Ltd.%20%C5%9Eti.!5e0!3m2!1str!2str!4v1649270954499!5m2!1str!2str" width="100%" height="395" style="border:0;" allowfullscreen="" loading="lazy"></iframe>
                    </div>
                </div>
                <div class="col-md-12 text-center mt-5">
                     <asp:Button ID="btnExpertiz2" runat="server" Text="Devam Et" CssClass="btn btn-success" OnClick="btnExpertiz2_Click"/>
                </div>
            </div>
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
                                <h5 class="title">Sıfır Gibi Makina  Ekspertiz</h5>
                               
                            </div>
                            <div class="card-body">
                                <p>
                                    <i class="fas fa-map-marker-alt"></i>
                                    Çerkeşliosb Mah. İmes-17 Cad. Küçük Sanayi Sitesi D5 No: 12 İç Kapı No: 1 Dilovası – Kocaeli
                                </p>
                                <p>
                                    <i class="fas fa-phone-alt"></i>
                                    0 541 607 43 47
                                </p>
                                <p>
                                    <i class="fas fa-link"></i>
                                   www.sifirgibimakine.com
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
                                <h5 class="title">Sıfır Gibi Makina Ekspertiz</h5>
                                <asp:LinkButton ID="MyLnkButton" runat="server" onClick="MyLnkButton_Click"> <i class="fas fa-undo"></i> Değiştir</asp:LinkButton>
                               
                               
                            </div>
                            <div class="card-body">
                                 <p>
                                    <i class="fas fa-map-marker-alt"></i>
                                    Çerkeşliosb Mah. İmes-17 Cad. Küçük Sanayi Sitesi D5 No: 12 İç Kapı No: 1 Dilovası – Kocaeli
                                </p>
                                <p>
                                    <i class="fas fa-phone-alt"></i>
                                    0 541 607 43 47
                                </p>
                                <p>
                                    <i class="fas fa-link"></i>
                                   www.sifirgibimakine.com
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
                                <input type="text" class="form-control" id="ad" placeholder="Adınız" runat="server">
                            </div>
                        </div>
                        <div class="col-md-6 pl-025rem sm-px-8">
                            <div class="form-group">
                                <input type="text" class="form-control" id="soyad" placeholder="Soyadınız"  runat="server">
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        
                        <div class="col-md-6 pr-025rem sm-px-8">
                            <div class="form-group">
                                <input type="number" class="form-control" id="telefonno" placeholder="Telefon Numarası"  runat="server">
                            </div>
                        </div>
                        <div class="col-md-6 pl-025rem sm-px-8">
                            <div class="form-group">
                                <input type="text" class="form-control" id="eposta" placeholder="E-Posta"  runat="server">
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
                        <p class="success-text"><strong>Sıfır Gibi Makina</strong> ekspertiz firması için <strong>
                            <asp:Label ID="lblRandevuTarihiBilgi" runat="server"></asp:Label></strong> tarihli başvuru kaydınız başarıyla alınmıştır.</p>
                    </div>
                </div>
               
            </div>
        </div>
    </div>
    </asp:Panel>

</asp:Content>
