<%@ Page Title="" Language="C#" MasterPageFile="~/Makina.Master" AutoEventWireup="true" CodeBehind="Kategoriler.aspx.cs" Inherits="SifirGibiMakina.Kategoriler" %>


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
      
    <div class="breadcrumb-comp">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <a href="/">Anasayfa</a>
                    <span><i class="fas fa-angle-right"></i></span>
                    <p>Kategoriler</p>
                </div>
            </div>
        </div>
    </div>

    <div class="sgm-makine-al bg-light">
        <div class="container">
                     <div class="row">
                <div class="col-md-12">
                    <div class="accordion" id="makineAlCollapse">
                        <div class="row">
                            <div class="col-md-6">
                                <button class="btn btn-link text-center makine-al-collapse-button collapsed" type="button" data-toggle="collapse" data-target="#collapseOne" aria-expanded="false" aria-controls="collapseOne">
                                    Fiyata Göre
                                </button>
                                <button class="btn btn-link text-center makine-al-collapse-button collapsed" type="button" data-toggle="collapse" data-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                                   Kategori - Markaya Göre
                                </button>
                                <button class="btn btn-link text-center makine-al-collapse-button" type="button" data-toggle="collapse" data-target="#collapseThree" aria-expanded="true" aria-controls="collapseThree">
                                    Açıklamaya - Modele Göre
                                </button>
                            </div>
                        </div>
                      
                        <div id="collapseOne" class="collapse collapse-body" aria-labelledby="headingOne" data-parent="#makineAlCollapse">
                            <div class="card-body">
                                <div class="row align-items-center">
                                    <div class="col-md-6 input-column">
                                        <div class="input-group">
                                            <input type="text" class="form-control" placeholder="Min Fiyat ₺" id="txtMinFiyat" runat="server">
                                        </div>
                                        <div class="input-group">
                                            <input type="text" class="form-control" placeholder="Max Fiyat ₺" id="txtMaxFiyat" runat="server">
                                        </div>
                                        <div class="input-group offset-md-1">
                                            <asp:DropDownList ID="ddParaBirimi" runat="server" CssClass="form-control" Font-Size="Small"><asp:ListItem Text="TL" Value="1"></asp:ListItem><asp:ListItem Text="Euro" Value="2"></asp:ListItem><asp:ListItem Text="Dolar" Value="3"></asp:ListItem></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 offset-md-3">
                                         <button class="btn btn-success" type="submit" runat="server" id="btnKategoriFiyat" onserverclick="btnKategoriFiyat_Click">
                        Uygun Makineleri Listele
                    </button>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div id="collapseTwo" class="collapse collapse-body" aria-labelledby="headingTwo" data-parent="#makineAlCollapse">
                            <div class="card-body">
                                <div class="row align-items-center">
                                    <div class="col-md-6 input-column">
                                        <div class="input-group">
                                         <asp:DropDownList ID="ddTurler" runat="server" CssClass="form-control select-input offset-md-1" Font-Size="Small"></asp:DropDownList>

                                        </div>
                                        <div class="input-group">
                                       <asp:DropDownList ID="ddMarkalar" runat="server" CssClass="form-control select-input offset-md-1" Font-Size="Small"></asp:DropDownList>

                                        </div>
                                        
                                        
                                        
                                    </div>
                                    <div class="col-md-3 offset-md-3 text-right">
                                         <button class="btn btn-success" type="submit" runat="server" id="btnkategorimarka" onserverclick="btnKategoriMarkaSearch_Click">
                        Uygun Makineleri Listele
                    </button>
                                      
                                    </div>
                                </div>
                            </div>
                        </div>
                            
                        <div id="collapseThree" class="collapse show collapse-body" aria-labelledby="headingThree" data-parent="#makineAlCollapse">
                            <div class="card-body">
                                <div class="row align-items-center">
                                    <div class="col-md-6 input-column">
                                        <div class="input-group">
                                            <input type="text" class="form-control" placeholder="Marka, Model veya İlan No ile Arama" style="min-width: 300px" runat="server" id="kategori_search_input" name="kategori_search_input">
                                        </div>
                                    </div>
                                    <div class="col-md-3 offset-md-3 text-right">
                                        <button class="btn btn-success" type="submit" runat="server" id="btnkategorisearch" onserverclick="btnKategoriSearch_Click">
                        Uygun Makineleri Listele
                    </button>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>

                 <asp:Repeater ID="rptKategoriler" runat="server" OnItemDataBound="rptKategoriler_ItemDataBound">
                     <HeaderTemplate> <div class="row mt-5"></HeaderTemplate>
                        <ItemTemplate>
                        <div class="col-md-4">
                            <div class="card">
                                <div class="position-relative">
                                    <a href="/kategori/<%# ReWriterPath("1", Eval("Kategori").ToString(), "1")%>/ikinci-el-makina/<%# Eval("tur_ID") %>"><asp:Image ID="imgKategori" runat="server" CssClass="card-img-top" ToolTip='<%# Eval("Kategori") %>' ImageUrl='<%# Eval("Resim") %>' AlternateText='<%# Eval("Kategori") %>'/></a>
                                    <div class="slider-card-text">
                                        <h5><%# Eval("Kategori") %></h5>
                                        <p><asp:Literal ID="ltKategoriIlanAdeti" runat="server"></asp:Literal></p>
                                    </div>
                                </div>
                                <div class="card-body p-0">
                                    <div class="slider-card-items">
                                         <asp:Repeater ID="rptAltKategoriler" runat="server">
                                        <ItemTemplate>
                                        <a href="/alt-kategori/<%# ReWriterPath("1", Eval("Kategori").ToString(), "1")%>/ikinci-el-makina/<%# Eval("Alttur_ID") %>"><%# Eval("Kategori") %> <i class="fas fa-angle-right float-right"></i></a>
                                        </ItemTemplate></asp:Repeater>
                                       
                                    </div>
                                    <a href="/kategori/<%# ReWriterPath("1", Eval("Kategori").ToString(), "1")%>/list/<%# Eval("tur_ID") %>" class="btn btn-success btn-block">Daha Fazla </a>
                                   
                                </div>
                            </div><br />
                        </div>
                            </ItemTemplate>
                     <FooterTemplate></div>
           </FooterTemplate>
                                 </asp:Repeater>
            
            Sıfır Gibi Makine, endüstri makineleri ve ikinci el makine alım satımında güvenilir bir platformdur.
Sitemizde otomasyon, kompresör, endüstriyel hırdavat, komple fabrika, taşıma ve istifleme gibi
birçok endüstriyel ihtiyaca yönelik makineler bulunmaktadır.<br /><br />
Endüstri makineleri, üretim süreçlerinde kullanılan büyük ölçekli ve yüksek kapasiteli makinelerdir.
İmalat, otomotiv, gıda, metal işleme, enerji ve inşaat gibi çeşitli sektörlerde bu makinelerin kullanımı
yaygındır. İşletmeler, endüstri makinelerini kullanarak üretim verimliliğini artırabilir, iş gücünü
azaltabilir ve kaliteyi iyileştirebilir. Sıfır Gibi Makine olarak, bu ihtiyaçları karşılamak için birbirinden
kaliteli ve uygun fiyatlı makineler sunuyoruz.<br /><br />
Sitemizdeki kategoriler arasında endüstri makineleri, endüstriyel hırdavat, taşıma ve istifleme
ekipmanları gibi geniş bir yelpaze bulunmaktadır. İhtiyaçlarınıza uygun olan makineyi seçerek,
işletmenizin üretim süreçlerini otomatikleştirebilir ve verimliliği artırabilirsiniz.<br /><br />
İkinci el makine alım satımı konusunda da Sıfır Gibi Makine size kolaylık sağlar. İhtiyaç duyduğunuz
makineyi satın alabilir veya kullanmadığınız makinelerinizi satabilirsiniz. Güvenli alışveriş imkanı ve
kaliteli makineleri bir araya getiren platformumuz, işletmelerin ihtiyaçlarını karşılamak için ideal bir
seçenektir.<br /><br />
Sıfır Gibi Makine olarak, müşterilerimize en iyi hizmeti sunmak için çalışıyoruz. Her bir makineyi
detaylı bir şekilde inceliyor, kalite ve performans açısından test ediyoruz. Bu sayede,
kullanıcılarımızın güvenli ve sağlam makineler satın almasını sağlıyoruz.<br /><br />
Endüstri makineleri, işletmelerin verimliliklerini artırmak ve rekabetçi avantaj elde etmek için önemli
bir yatırımdır. Sıfır Gibi Makine üzerinden makine alım satımı yaparak, uygun fiyatlarla kaliteli
makineler elde edebilirsiniz.<br /><br />
İhtiyaçlarınıza uygun endüstri makineleri için hemen Sıfır Gibi Makine'ye göz atın ve makine al veya
sat işlemlerinizi kolaylıkla gerçekleştirin.


        </div>
    </div>
                    
</asp:Content>
