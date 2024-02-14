<%@ Page Title="" Language="C#" MasterPageFile="~/Makina.Master" AutoEventWireup="true" CodeBehind="MakinaSat.aspx.cs" Inherits="SifirGibiMakina.MakinaSat" %>
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

       <div class="makine-sat">
            <%--<div class="container py-5">
                <div class="row">
                    <div class="col-md-12">
                        <img class="img-fluid" src="/images/makine-sat.png" alt="">
                    </div>
                </div>
            </div>--%>
            <div class="nasil-satabilirim py-6 sm-py-2 bg-green-transparent">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12">
                            <h4 class="title">Makinemi Nasıl Satarım?</h4>
                        </div>
                    </div>
                    <div class="row align-items-center">
                        <div class="col-md-6 justify-content-center d-flex">
                            <p>Makineni 3 adımda kolayca satışa çıkarmak için yapman gereken; sifirgibimakine.com'a girip ücretsiz üyelikle ilan açmak!</p>
                        </div>
                        <div class="col-md-6 justify-content-center d-flex">
                            <img class="img-fluid" src="/images/nasil-satabilirim-bg-1.png" alt="">
                        </div>
                    </div>
                    <div class="row align-items-center">
                        <div class="col-md-6 justify-content-center d-flex">
                            <img class="img-fluid" src="/images/nasil-satabilirim-bg-2.png" alt="">
                        </div>
                        <div class="col-md-6 justify-content-center d-flex">
                            <p>
                                <strong>Etkileyici Bir Başlık Gir.</strong> Başlık içerisinde kullandığın kelimelerin ürünü tam olarak ifade ettiğinden emin ol. Bu sayede site içi arama çubuğunda görünür ol. </p>
                        </div>
                    </div>
                    <div class="row align-items-center">
                        <div class="col-md-6 justify-content-center d-flex">
                            <p><strong>Doğru Makine Kategorini Seç.</strong> Gerekli tüm bilgileri ve açıklama alanını doldurduğundan emin ol ve yayınla.</p>
                        </div>
                        <div class="col-md-6 justify-content-center d-flex">
                            <img class="img-fluid" src="/images/nasil-satabilirim-bg-3.png" alt="">
                        </div>
                    </div>
                    <div class="row align-items-center">
                        <div class="col-md-6 justify-content-center d-flex">
                            <img class="img-fluid" src="/images/nasil-satabilirim-bg-4.png" alt="">
                        </div>
                        <div class="col-md-6 justify-content-center d-flex">
                            <p>İşte bu kadar kolay. <strong>İlanın şimdi satışa hazır.</strong></p>
                        </div>
                    </div>
                    <div class="row justify-content-center">
                        <div class="col-md-4">
                            <a href="/makina-ekle" class="btn btn-success btn-block">Makine Sat</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
