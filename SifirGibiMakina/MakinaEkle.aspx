<%@ Page Title="" Language="C#" MasterPageFile="~/Makina.Master" AutoEventWireup="true" CodeBehind="MakinaEkle.aspx.cs" Inherits="SifirGibiMakina.MakinaEkle" %>

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
    <link rel="stylesheet" href="/styles/image-uploader.min.css">
    <style>
        .toggle-btn {
            padding: 20px 0px;
        }

        .text-danger{
            font-size:13px
        }


        .ck-editor__editable[role="textbox"] {
            /* editing area */
            min-height: 200px
        }

        .ck-content .image {
            /* block images */
            max-width: 80%;
            margin: 20px auto;
        }

        .container-fluid {
            font-family: Arial, sans-serif; /* Choose your preferred font here */
            color: #333; /* Dark text for better readability */
            margin-top: 20px; /* Space from the top */
        }

        .card {
            width: 350%; /* Adjust the width to your preferred value, for example, 80% */
            margin: 0 auto; /* Center the card horizontally */
        }

        .cizgi {
            width: 100%; /* Çizginin genişliği */
            height: 2px; /* Çizginin kalınlığı */
            background-color: yellowgreen; /* Çizginin rengi */
            margin-top: 20px; /* Üstten boşluk */
            margin-bottom: 20px;
        }

        .frame {
            position: absolute;
            top: 50%;
            left: 50%;
            width: 400px;
            height: 400px;
            margin-top: -200px;
            margin-left: -200px;
            border-radius: 2px;
            box-shadow: 4px 8px 16px 0 rgba(0, 0, 0, 0.1);
            overflow: hidden;
            background: linear-gradient(to top right, darkmagenta 0%, hotpink 100%);
            color: #333;
            font-family: "Open Sans", Helvetica, sans-serif;
        }

        .dropzone {
            width: 100px;
            height: 80px;
            border: 1px dashed #999;
            border-radius: 3px;
            text-align: center;
        }

        .upload-icon {
            margin: 25px 2px 2px 2px;
        }

        .upload-input {
            position: relative;
            top: -62px;
            left: 0;
            width: 100%;
            height: 100%;
            opacity: 0;
        }

        .big-ticket-size {
            font-size: 35px;
        }

        .btn-extra {
            width: 220%;
        }

        .p-extra {
            display: ruby;
        }



        @import url('https://fonts.googleapis.com/css2?family=Poppins&display=swap');

        .box-right {
            padding: 30px 25px;
            background-color: white;
            border-radius: 15px
        }

        .box-left {
            padding: 20px 20px;
            background-color: white;
            border-radius: 15px
        }

        .textmuted {
            color: #7a7a7a
        }

        .bg-green {
            background-color: #d4f8f2;
            color: #06e67a;
            padding: 3px 0;
            display: inline;
            border-radius: 25px;
            font-size: 11px
        }

        .p-blue {
            font-size: 14px;
            color: #1976d2
        }

        .fas.fa-circle {
            font-size: 12px
        }

        .p-org {
            font-size: 14px;
            color: #fbc02d
        }

        .h7 {
            font-size: 15px
        }

        .h8 {
            font-size: 12px
        }

        .h9 {
            font-size: 10px
        }

        .bg-blue {
            background-color: #dfe9fc9c;
            border-radius: 5px
        }

        .form-control {
            box-shadow: none !important
        }

        .card input::placeholder {
            font-size: 14px
        }

        ::placeholder {
            font-size: 14px
        }

        input.card {
            position: relative
        }

        .far.fa-credit-card {
            position: absolute;
            top: 10px;
            padding: 0 15px
        }

        .fas,
        .far {
            cursor: pointer
        }

        .cursor {
            cursor: pointer
        }

        .btn.btn-primary {
            box-shadow: none;
            height: 40px;
            padding: 11px
        }

        .bg.btn.btn-primary {
            background-color: transparent;
            border: none;
            color: #1976d2
        }

            .bg.btn.btn-primary:hover {
                color: #539ee9
            }

        @media(max-width:320px) {
            .h8 {
                font-size: 11px
            }

            .h7 {
                font-size: 13px
            }

            ::placeholder {
                font-size: 10px
            }
        }

        .ticket-size {
            font-size: 16px;
            color: #fff;
            display: block
        }

        .card {
            width: 100%
        }

        .form-group label {
            font-weight: bold
        }

        .card .card-header {
            background-color: #45b076;
            color: #fff
        }

            .card .card-header .btn-link {
                padding: 0
            }

            .card .card-header .card-title {
                margin-bottom: 0px;
                display: inline
            }

                .card .card-header .card-title i {
                    padding-right: 10px
                }

            .card .card-header .header-text {
                font-weight: bold
            }

        .card .c-body {
            padding: 20px
        }

        .rbl_status tr td {
            padding-right: 20px
        }

            .rbl_status tr td input[type=radio] {
                margin-right: 5px
            }

            .rbl_status tr td label {
                font-weight: normal
            }

        .btn-link {
            color: #fff !important
        }

        .stepper-wrapper {
            margin-top: 30px;
            display: flex;
            justify-content: space-between;
            margin-bottom: 20px;
        }

        .stepper-item {
            position: relative;
            display: flex;
            flex-direction: column;
            align-items: center;
            flex: 1;
            font-weight: bold
        }

        @media(max-width:768px) {
            .stepper-item {
                font-size: 12px;
            }
        }

        .stepper-item::before {
            position: absolute;
            content: "";
            border-bottom: 2px solid #ccc;
            width: 100%;
            top: 20px;
            left: -50%;
            z-index: 2;
        }

        .stepper-item::after {
            position: absolute;
            content: "";
            border-bottom: 2px solid #ccc;
            width: 100%;
            top: 20px;
            left: 50%;
            z-index: 2;
        }

        .stepper-item .step-counter {
            position: relative;
            z-index: 5;
            display: flex;
            justify-content: center;
            align-items: center;
            width: 40px;
            height: 40px;
            border-radius: 50%;
            background: #ccc;
            margin-bottom: 6px;
            color: #fff
        }

        .stepper-item.active {
            font-weight: bold;
        }

        .stepper-item.completed .step-counter {
            background-color: #45b076;
        }

        .stepper-item.active .step-counter {
            background: #23305f;
            color: #fff;
            width: 45px;
            height: 45px;
            box-shadow: 0 1px 1px rgba(0,0,0,0.11), 0 2px 2px rgba(0,0,0,0.11), 0 4px 4px rgba(0,0,0,0.11), 0 6px 8px rgba(0,0,0,0.11), 0 8px 16px rgba(0,0,0,0.11)
        }

        .stepper-item.completed::after {
            position: absolute;
            content: "";
            border-bottom: 2px solid #45b076;
            width: 100%;
            top: 20px;
            left: 50%;
            z-index: 3;
        }

        .stepper-item:first-child::before {
            content: none;
        }

        .stepper-item:last-child::after {
            content: none;
        }

        @import url("https://fonts.googleapis.com/css2?family=Play:wght@400;700&display=swap");

        .container {
            width: 100%;
        }
        .elementor-shape-bottom svg {
    width: calc(260% + 1.3px);
    height: 70px;
    transform: translateX(-50%) rotateY(180deg);
}
    .elementor-shape-bottom svg path {
        fill: #f8f9fa !important ;
        transform-origin: center !important;
        transform: rotateY(0deg) !important;
    }

.elementor-shape {
    overflow: hidden;
    position: absolute;
    left: 0;
    width: 100%;
    line-height: 0;
    direction: ltr;
}

.elementor-shape-bottom {
    bottom: -1px;
    transform: rotate(180deg);
}
        .packages {
            padding: 20px 10px;
            text-align: center;
            border-radius: 20px;
            box-shadow: 0 19px 38px rgb(201, 201, 201), 0 15px 12px rgb(255, 255, 255);
            color: #060606;
            border-top: 10px solid #23305f;
            border-bottom: 10px solid #23305f;
            flex: 1 1 0;
            margin: 0 20px 20px 0px;
            display: flex;
            flex-direction: column;
        }
        .packages .head-bg{
            position:relative;
           
background: linear-gradient(180deg, rgba(35,48,95,1) 35%, rgba(69,176,118,1) 100%);
             margin: -20px -10px 0px -10px;
                border-top-left-radius: 10px;
                border-top-right-radius: 10px;
                padding: 30px 30px 65px 30px;
        }
            .packages .button1 {
                font-size: 16px;
                border:none
            }

            .packages .headerText {
                font-size: 25px;
                
                color: #fff;
               
            }

            .packages .price1 {
                font-size: 18px
            }

            .packages .price2 {
                font-size: 35px;
                color: #32a577
            }

            .packages:last-child {
                margin-right: 0px
            }

            .packages .list li {
                font-size: 16px;
    list-style: none;
    border-bottom: 1px solid #23305f26;
    padding-inline-start: 0;
    border-width: 1px;
    padding: 15px 10px;
    display: flex;
    align-items: center;
            }

                .packages .list li i {
                    padding-right: 10px;
                    color: #00cc99
                }

        .first {
            margin-top: 30px;
           
        }

        .packages .list {
          height: 100%;
    margin-right: -10px;
    position: relative;
    margin-left: -10px;
        }

        ol,
        ul {
            padding: 0;
        }

        .top {
            display: flex;
            flex-direction: column;
            align-items: center;
        }

        input,
        label {
            display: inline-block;
            vertical-align: middle;
            margin: 10px 0;
        }

        .button {
            padding: 10px 30px;
            text-decoration: none;
            font-size: 1.4em;
            margin: 15px 15px;
            border-radius: 50px;
            color: #f4f4f4;
            transition: all 0.3s ease 0s;
        }

            .button:hover {
                transform: scale(1.1);
                color: #fff;
                text-transform: none;
                text-decoration: none
            }

        .button1 {
            background-color: #00cc99;
            padding: 10px 30px;
            font-size: 18px
        }

        .button2 {
            background-color: #ff007c;
            box-shadow: 0 0 10px 0 #ff007c inset, 0 0 20px 2px #ff007c;
        }

        .button3 {
            background-color: #ffae42;
            box-shadow: 0 0 10px 0 #ffae42 inset, 0 0 20px 2px #ffae42;
        }

        .switch {
            position: relative;
            display: inline-block;
            width: 60px;
            height: 34px;
        }

            .switch input {
                opacity: 0;
                width: 0;
                height: 0;
            }

        .slider {
            position: absolute;
            cursor: pointer;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            background-color: #32a577;
            box-shadow: 2px 6px 25px #efefef;
            transform: translate(0px, 0px);
            transition: 0.6s ease transform, 0.6s box-shadow;
        }

            .slider:before {
                position: absolute;
                content: "";
                height: 26px;
                width: 26px;
                left: 4px;
                bottom: 4px;
                background-color: white;
                -webkit-transition: 0.4s;
                transition: 0.4s;
            }

        input:checked + .slider {
            background-color: #23305f;
        }

        input:focus + .slider {
            box-shadow: 0 0 1px #50bfe6;
        }

        input:checked + .slider:before {
            -webkit-transform: translateX(26px);
            -ms-transform: translateX(26px);
            transform: translateX(26px);
        }

        .slider.round {
            border-radius: 34px;
        }

            .slider.round:before {
                border-radius: 50%;
            }

        .package-container {
            display: flex;
            justify-content: center;
            margin: 20px 0 0px 0px;
        }

        .urun-detay.desktop {
            padding-bottom: 10px;
            position: relative;
            margin-bottom: 90px;
        }

            .urun-detay.desktop .previewText {
                position: absolute;
               
                background: none;
                transform-origin: 0 0;
                top: 50%;
     left: 50%;
     transform: translate(-50%, -50%);
                z-index: 11;
                font-size: 4vw;
                color: #787878;
            }

            .urun-detay.desktop:before {
                content: "";
                position: absolute;
                background: #d9d9d9ba;
                width: 100%;
                height: 100%;
                z-index: 10;
                border-radius: 20px
            }

        .urun-detay .detay-aciklama {
            margin: 0px 0 0 0
        }

        .profilim {
            margin: 10px 0;
        }

        .mt0 {
            margin-top: 0px
        }

        .seperator {
            display: flex;
            align-items: center;
            justify-content: center;
            padding: 10px;
        }

        .agreeCheck label {
            margin: 0
        }

        .btn-next {
            padding: 5px 35px;
            font-size: 20px;
            border: none;
            border-radius: 15px;
        }

        .btn-prev {
            padding: 5px 35px;
            font-size: 20px;
            border: none;
            border-radius: 15px;
            margin-right: 10px;
            background-color: #b5b5b5 !important;
            color: #fff
        }

        .form-payment label {
            font-weight: bold
        }

        .toggleContainer {
            position: relative;
            display: grid;
            grid-template-columns: repeat(2, 1fr);
            width: fit-content;
            border: 3px solid #343434;
            border-radius: 20px;
            background: #343434;
            font-weight: bold;
            color: #343434;
            cursor: pointer;
        }

            .toggleContainer::before {
                content: '';
                position: absolute;
                width: 50%;
                height: 100%;
                left: 0%;
                border-radius: 20px;
                background: white;
                transition: all 0.3s;
            }

        .toggleCheckbox:checked + .toggleContainer::before {
            left: 50%;
        }

        .toggleContainer div {
            padding: 6px;
            text-align: center;
            z-index: 1;
        }

        .toggleCheckbox {
            display: none;
        }

            .toggleCheckbox:checked + .toggleContainer div:first-child {
                color: white;
                transition: color 0.3s;
            }

            .toggleCheckbox:checked + .toggleContainer div:last-child {
                color: #343434;
                transition: color 0.3s;
            }

            .toggleCheckbox + .toggleContainer div:first-child {
                color: #343434;
                transition: color 0.3s;
            }

            .toggleCheckbox + .toggleContainer div:last-child {
                color: white;
                transition: color 0.3s;
            }

        @media (max-width: 992px) {
            .package-container {
                display: block
            }
        }

        @media (max-width: 767px) {
            .btn-extra {
                width: auto; /* Mobilde genişliği otomatik ayarla */
            }

            .urun-detay.desktop {
                margin-bottom: 10px !important
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="profilim accordion" id="profil-accordion">
        <div class="container">
            <%--<div class="col-md-3 sm-d-none">
                </div>--%>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <%-- Stepler--%>
            <div class="stepper-wrapper">
                <div class="stepper-item active step1" runat="server" id="stepperV1">
                    <div class="step-counter">1</div>
                    <div class="step-name">Kategori Seç</div>
                </div>
                <div class="stepper-item step2" runat="server" id="stepperV2">
                    <div class="step-counter">2</div>
                    <div class="step-name">İlan Detayları</div>
                </div>
                <div class="stepper-item step3" runat="server" id="stepperV3">
                    <div class="step-counter">3</div>
                    <div class="step-name">İlan Önizleme</div>
                </div>
                <div class="stepper-item step4" runat="server" id="stepperV4">
                    <div class="step-counter">4</div>
                    <div class="step-name">Paketler/Ödeme</div>
                </div>
            </div>
            <%--    Kategori Seçimi --%>
            <asp:Panel ID="pnlAddCategories" runat="server" Visible="true">
                <div class="card">
                    <div class="card-header">
                        <span class="header-text">Adım Adım Kategori Seç</span>
                        <asp:Label ID="lblNoticeCount" CssClass="big-ticket-size ticket-size" runat="server"></asp:Label>
                    </div>
                    <div class="c-body">
                        <div class="row">
                            <div class="col-md-4">
                                <p>
                                    <i class="fa fa-tags"></i>Kategori   
                                </p>
                                <asp:ListBox ID="lbMainCategories" runat="server" CssClass="list-box form-control" AutoPostBack="true" OnSelectedIndexChanged="lbMainCategories_SelectedIndexChanged" Height="300px"></asp:ListBox>
                                <asp:CustomValidator ID="CustomValidatorMainCat" runat="server" ErrorMessage="Lütfen bir ana kategori seçiniz" ForeColor="Red" OnServerValidate="CustomValidatorMainCat_ServerValidate"></asp:CustomValidator>
                            </div>
                            <div class="col-md-4 ">
                                <p runat="server" id="txtSubCategories" visible="False">
                                    <i class="fa fa-tags"></i>Alt Kategori   
                                </p>
                                <asp:ListBox ID="lbSubCategories" runat="server" CssClass="list-box form-control" AutoPostBack="True" OnSelectedIndexChanged="lbSubCategories_SelectedIndexChanged" Visible="False" Height="300px"></asp:ListBox>
                            </div>
                            <div class="col-md-4 ">
                                <p runat="server" id="txtSubSubCategories" visible="False">
                                    <i class="fa fa-tags"></i>Alt-Alt Kategori   
                                </p>
                                <asp:ListBox ID="lbSubSubCategories" runat="server" CssClass="list-box form-control" Visible="False" Height="300px"></asp:ListBox>
                            </div>
                        </div>
                        <div class="">
                            <asp:Button ID="btnBackPnl" Visible="false" runat="server" Text="< Geri" CssClass="btn btn-prev  login-button btn-lg" OnClick="btnBackPnl1_Click" />
                            <asp:Button ID="btNextPnl1" runat="server" Text="İleri >" CssClass="btn btn-next btn-success login-button btn-lg float-right" OnClick="btNextPnl1_Click" />
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlMachineDetails" runat="server" Visible="false" CssClass="pnlMachineDetails">
                <%-- Ürüm Özellikleri ADIM 2-%>
                                <%--   Ürün hakkında--%>
                <div class="container-fluid">
                    <div class="card ">
                        <div class="card-header">
                            <i class="fa fa-folder-open" aria-hidden="true"></i>
                            <h5 class="card-title">İlan Bilgileri</h5>
                        </div>
                        <div class="card-body">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="form-group">
                                        <label for="rblStatus">Durum:</label>
                                        <asp:RadioButtonList ID="rblStatus" runat="server" CssClass="rbl_status" RepeatDirection="Horizontal " AutoPostBack="true" OnSelectedIndexChanged="rblStatus_SelectedIndexChanged">
                                        </asp:RadioButtonList>
                                        <asp:CustomValidator ID="CustomValidatorStatus" runat="server" ErrorMessage="Durum seçimi zorunludur." ForeColor="Red" OnServerValidate="CustomValidatorStatus_ServerValidate"></asp:CustomValidator>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="form-group">
                                <label for="txtMachineName">Makine Başlığı:</label>
                                <asp:TextBox ID="txtMachineName" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorMachineName" runat="server" ControlToValidate="txtMachineName" ErrorMessage="Makine başlığı gerekli." ForeColor="Red" Display="Dynamic" CssClass="form-text text-danger"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label for="txtCKeditor">Açıklama:</label>
                                <asp:TextBox ID="txtCKeditor" runat="server" TextMode="MultiLine" Rows="5" Width="100%" placeholder="Açıklama" CssClass="form-control" MaxLength="3000"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorCKeditor" runat="server" ControlToValidate="txtCKeditor" ErrorMessage="Açıklama gerekli. 3000 satırdan fazla olamaz" ForeColor="Red" Display="Dynamic" CssClass="form-text text-danger"></asp:RequiredFieldValidator>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <div class="form-group">
                                        <asp:Label ID="Label1" runat="server" Text="Fiyat :"></asp:Label>
                                        <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control mb-2 txtOnlyNumber"></asp:TextBox>
                                    </div>
                                    <asp:Panel ID="PricePanel" runat="server" Visible="true">
                                        <div class="row">
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <asp:Label ID="lblDayPrice" runat="server" Text="Günlük Fiyat:"></asp:Label>
                                                    <asp:TextBox ID="txtDayPrice" runat="server" CssClass="form-control mb-2"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <asp:Label ID="lblWeekPrice" runat="server" Text="Haftalık Fiyat:"></asp:Label>
                                                    <asp:TextBox ID="txtWeekPrice" runat="server" CssClass="form-control mb-2"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <asp:Label ID="lblMonthPrice" runat="server" Text="Aylık Fiyat:"></asp:Label>
                                                    <asp:TextBox ID="txtMonthPrice" runat="server" CssClass="form-control mb-2"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <div class="form-group">
                                        <asp:Label ID="Label5" runat="server" Text="Para Birimi :"></asp:Label>
                                        <asp:DropDownList ID="ddlCurrency" runat="server" CssClass="form-control mb-2">
                                        </asp:DropDownList>
                                    </div>
                                    <asp:CustomValidator ID="CustomValidatorPrice" runat="server" ControlToValidate="txtPrice" ValidateEmptyText="true" ErrorMessage="Fiyat gerekli." ForeColor="Red" OnServerValidate="CustomValidatorPrice_ServerValidate"></asp:CustomValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorPrice" runat="server" ControlToValidate="txtPrice" ErrorMessage="Geçerli bir fiyat giriniz." ValidationExpression="^\d+(\.\d{1,2})?$" ForeColor="Red" Display="Dynamic" CssClass="form-text text-danger"></asp:RegularExpressionValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtDayPrice" ErrorMessage="Geçerli bir fiyat giriniz." ValidationExpression="^\d+(\.\d{1,2})?$" ForeColor="Red" Display="Dynamic" CssClass="form-text text-danger"></asp:RegularExpressionValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtWeekPrice" ErrorMessage="Geçerli bir fiyat giriniz." ValidationExpression="^\d+(\.\d{1,2})?$" ForeColor="Red" Display="Dynamic" CssClass="form-text text-danger"></asp:RegularExpressionValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtMonthPrice" ErrorMessage="Geçerli bir fiyat giriniz." ValidationExpression="^\d+(\.\d{1,2})?$" ForeColor="Red" Display="Dynamic" CssClass="form-text text-danger"></asp:RegularExpressionValidator>
                                    <asp:CustomValidator ID="CustomValidatorPanel" runat="server" ErrorMessage="En az bir fiyat girilmelidir."
                                        ForeColor="Red" OnServerValidate="CustomValidatorPanel_ServerValidate"></asp:CustomValidator>
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <div class="form-check">
                                                <asp:CheckBox ID="chkShowPrice" runat="server" CssClass="form-check-input" AutoPostBack="true" />
                                                <label class="form-check-label" for="chkShowPrice">Fiyat gösterilmesin</label>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="cizgi"></div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Makine Üretim Yılı :</label>
                                        <asp:DropDownList ID="ddYillar" runat="server" CssClass="form-control select2" Width="100%" OnSelectedIndexChanged="ddYillar_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:CustomValidator ID="CustomValidatorYillar" runat="server" ControlToValidate="ddYillar" ErrorMessage="Üretim yılı seçimi zorunludur." ForeColor="Red" OnServerValidate="CustomValidatorYillar_ServerValidate" CssClass="form-text text-danger"></asp:CustomValidator>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Makine Markalar :</label>
                                        <asp:DropDownList ID="ddMarkalar" runat="server" CssClass="form-control select2" Width="100%" OnSelectedIndexChanged="ddMarkalar_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:CustomValidator ID="CustomValidatorddMarkalar" runat="server" ControlToValidate="ddMarkalar" ErrorMessage="Makine marka seçimi zorunludur." ForeColor="Red" OnServerValidate="CustomValidatorddMarkalar_ServerValidate" CssClass="form-text text-danger"></asp:CustomValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtModel">Makine Modeli :</label>
                                <asp:TextBox ID="txtModel" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <%--   Ürün DEtayları--%>
                <div class="container-fluid">
                    <div class="card ">
                        <div class="card-header">
                            <h5 class="card-title">Detaylı Bilgi</h5>
                        </div>
                        <div class="card-body">
                            <div id="accordion">
                                <!-- First Card -->
                                <div class="border-primary conteiner-fluid">
                                    <div class="card-header" id="headingOne">
                                        <h5 class="mb-0">
                                            <button class="btn btn-link btn-block text-left collapsed" type="button" data-toggle="collapse" data-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                                                Makine Ek Bilgi
                                            </button>
                                        </h5>
                                    </div>
                                    <div id="collapseOne" class="collapse show" aria-labelledby="headingOne" data-parent="#accordion">
                                        <div class="card-body">
                                            <div class="form-group">
                                                <asp:Label ID="lblNoCategory" runat="server" Text="Seçtiğiniz Kategoriye Uygun Makine Detay Bilgisi Bulunmamaktadır!"></asp:Label>
                                            </div>
                                            <asp:Panel ID="MachineDetailPanel" runat="server">
                                                <asp:Panel ID="CncPanel" runat="server">
                                                    <div class="form-group">
                                                        <label>Ayna Ölçüsü :</label>
                                                        <asp:DropDownList ID="ddMirrorSize" runat="server" CssClass="form-control select2" Width="100%">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <label>Tornalama Boyu  :</label>
                                                        <asp:DropDownList ID="ddTurningLenght" runat="server" CssClass="form-control select2" Width="100%">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <label>Kontrol Ünitesi :</label>
                                                        <asp:DropDownList ID="ddControlUnit" runat="server" CssClass="form-control select2" Width="100%">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <label>Eksen Sayısı :</label>
                                                        <asp:DropDownList ID="ddNumberOfAxes" runat="server" CssClass="form-control select2" Width="100%">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <label>Spindle rpm :</label>
                                                        <asp:DropDownList ID="ddSpindleRpm" runat="server" CssClass="form-control select2" Width="100%">
                                                        </asp:DropDownList>
                                                    </div>
                                                </asp:Panel>
                                                <asp:Panel ID="IslemeMerkezi" runat="server">
                                                    <div class="form-group">
                                                        <label>X Eksen Ölçüsü  :</label>
                                                        <asp:DropDownList ID="ddXAxisSize" runat="server" CssClass="form-control select2" Width="100%">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <label>Y Eksen Ölçüsü  :</label>
                                                        <asp:DropDownList ID="ddYAxisSize" runat="server" CssClass="form-control select2" Width="100%">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <label>Kontrol Ünitesi  :</label>
                                                        <asp:DropDownList ID="ddContolUnitIsleme" runat="server" CssClass="form-control select2" Width="100%">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <label>Eksen Sayısı  :</label>
                                                        <asp:DropDownList ID="ddAxesSizeIsleme" runat="server" CssClass="form-control select2" Width="100%">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <label>Spindle Rpm :</label>
                                                        <asp:DropDownList ID="ddSpindleRpmIsleme" runat="server" CssClass="form-control select2" Width="100%">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <label>Tabla Sayısı :</label>
                                                        <asp:DropDownList ID="ddTableSize" runat="server" CssClass="form-control select2" Width="100%">
                                                        </asp:DropDownList>
                                                    </div>
                                                </asp:Panel>
                                            </asp:Panel>
                                        </div>
                                    </div>
                                </div>
                                <!-- Second Card -->
                                <%--                   <div class="card" hidden="true">
                                        <div class="card-header" id="headingTwo">
                                            <h2 class="mb-0">
                                                <div class="float-left">
                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                        <ContentTemplate>
                                                            <asp:CheckBox ID="optionCheck" runat="server" CssClass="mt-1" Checked="false" AutoPostBack="true" OnCheckedChanged="optionCheck_CheckedChanged" />
                                                            <label for="optionCheck" class="mt-1 mr-2">Eksper Bilgisi Girmek İstemiyorum</label>
                                                            <asp:CheckBox ID="sifirGibiCheck" runat="server" CssClass="mt-1" Checked="false" AutoPostBack="true" />
                                                            <label for="sifirGibiCheck" class="mt-1 mr-2">Sifir Gibi Eksper Talep Etmek İstiyorum</label>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                                <button class="btn btn-link btn-block text-left collapsed" type="button" data-toggle="collapse" data-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                                                    Eksper Bilgileri
                                                </button>
                                            </h2>
                                        </div>
                                        <div id="collapseTwo" class="collapse" aria-labelledby="headingTwo" data-parent="#accordion">
                                            <div class="card-body">
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="GridViewExperts" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridViewExperts_RowDataBound" Visible="true">
                                                            <Columns>
                                                                <asp:BoundField DataField="eksper_ID" HeaderText="Expert ID" />
                                                                <asp:BoundField DataField="Kategori" HeaderText="Expert Name" />
                                                                <asp:TemplateField HeaderText="Score">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddlScore" runat="server">
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>--%>
                                <!-- Third Card -->
                                <%--  <div class="card" hidden="true">
                                        <div class="card-header" id="headingThree">
                                            <h2 class="mb-0">
                                                <div class="float-left">
                                                    <asp:CheckBox ID="optionCheck2" runat="server" CssClass="mt-1" Enabled="false" Checked="true" />
                                                    <label for="optionCheck2" class="mt-1 mr-2">İhale Başlatmak İstemiyorum</label>
                                                </div>
                                                <button class="btn btn-link btn-block text-left collapsed" type="button" data-toggle="collapse" data-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                                                    İhale Bilgileri
                                                </button>
                                            </h2>
                                        </div>
                                        <div id="collapseThree" class="collapse" aria-labelledby="headingThree" data-parent="#accordion">
                                            <div class="card-body">
                                                <form>
                                                    <div class="form-row">
                                                        <div class="form-group col-md-6">
                                                            <label for="baslangicTarihi">İhale Başlangıç Tarihi</label>
                                                            <asp:TextBox ID="TextBox1" type="date" runat="server" CssClass="form-control" Enabled="false" />
                                                        </div>
                                                        <div class="form-group col-md-6">
                                                            <label for="bitisTarihi">İhale Bitiş Tarihi</label>
                                                            <asp:TextBox ID="TextBox2" type="date" runat="server" CssClass="form-control" Enabled="false" />
                                                        </div>
                                                    </div>
                                                    <div class="form-row">
                                                        <div class="form-group col-md-4">
                                                            <label for="baslangicFiyati">İhale Başlangıç Fiyatı</label>
                                                            <asp:TextBox ID="TextBox3" type="number" runat="server" CssClass="form-control" Enabled="false" />
                                                        </div>
                                                        <div class="form-group col-md-4">
                                                            <label for="minSatisFiyati">Min. Satış Fiyatı</label>
                                                            <asp:TextBox ID="TextBox4" type="number" runat="server" CssClass="form-control" Enabled="false" />
                                                        </div>
                                                        <div class="form-group col-md-4">
                                                            <label for="teminatBedeli">Teminat Bedeli</label>
                                                            <asp:TextBox ID="TextBox5" type="number" runat="server" CssClass="form-control" Enabled="false" />
                                                        </div>
                                                    </div>
                                                    <!-- Daha fazla form elemanı eklenebilir -->
                                                </form>
                                            </div>
                                        </div>
                                    </div>--%>
                            </div>
                        </div>
                    </div>
                </div>
                <%--      İletişim Bilgileri--%>
                <div class="container-fluid">
                    <div class="card ">
                        <div class="card-header">
                            <h5 class="card-title">Adres Bilgileri</h5>
                        </div>
                        <div class="card-body">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <div class="address-form">
                                        <div class="row">
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label>Ülkeler :</label>
                                                    <asp:DropDownList ID="ddUlkeler" runat="server" AutoPostBack="true" CssClass="form-control select2" Width="100%" OnSelectedIndexChanged="ddUlkeler_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-field form-group">
                                                    <label for="city">Şehir :</label>
                                                    <asp:TextBox ID="txtCity" runat="server" CssClass="form-control mt0"></asp:TextBox>
                                                    <asp:DropDownList ID="ddcitylist" runat="server" AutoPostBack="true" CssClass="form-control select2" Width="100%" OnSelectedIndexChanged="ddcitylist_SelectedIndexChanged" Visible="false">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-field form-group">
                                                    <label for="district">İlçe :</label>
                                                    <asp:TextBox ID="txtDistrict" runat="server" CssClass="form-control mt0"></asp:TextBox>
                                                    <asp:DropDownList ID="ddistrictlist" runat="server" CssClass="form-control select2" Width="100%" Visible="false">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <%--                    Fotoğraf Bilgileri--%>
                <div class="container-fluid">
                    <div class="card ">
                        <div class="card-header">
                            <h5 class="card-title">Fotoğraf</h5>
                        </div>
                        <div class="" id="fileUploadContainer">
                            <asp:FileUpload ID="uplResimler" runat="server" AllowMultiple="True" CssClass="uploaded" />
                        </div>
                        <!-- /.form-group -->
                    </div>
                </div>
                <%--  İletişim Bilgileri--%>
                <div class="container-fluid">
                    <div class="card ">
                        <div class="card-header">
                            <h5 class="card-title">İletişim Bilgileri</h5>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Satış Temsilcisi</label>
                                        <div>
                                            <asp:Label runat="server" ID="lblSatisTemsilcisiAdi"></asp:Label>
                                        </div>
                                    </div>
                                    <!-- /.form-group -->
                                </div>
                                <!-- /.col -->
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Email</label>
                                        <div>
                                            <asp:Label runat="server" ID="lblSatisTemsilcisiEmail"></asp:Label>

                                        </div>
                                    </div>
                                    <!-- /.form-group -->
                                </div>
                                <!-- /.col -->
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Telefon</label>
                                        <div>
                                            <asp:Label runat="server" ID="lblSatisTemsilcisiTelefon"></asp:Label>
                                        </div>

                                    </div>

                                    <!-- /.form-group -->
                                </div>
                                <!-- /.col -->
                            </div>
                        </div>
                    </div>
                </div>
                <div class="container-fluid">
                    <asp:Button ID="btnBackMachineDetail" runat="server" Text="< Geri" CssClass="btn btn-prev login-button btn-lg" OnClick="btnBackMachineDetail_Click" type="button" />
                    <asp:Button ID="btnNextMachineDetail" runat="server" Text="İleri >" CssClass="btn btn-next btn-success login-button float-right btn-lg" OnClick="btnNextMachineDetail_Click" />
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlCheckMachine" runat="server" Visible="false">
                <%--  Ürün DEtay Kısmı ADIM 3--%>
                <div class="urun-detay desktop bg-light sm-py-0">
                    <h3 class="previewText">Önizleme</h3>
                    <div class="container" style="margin-top: 20px;">
                        <div class="row">
                            <div class="urun-detay just-mobile text-center col-12">
                                <div class="col-12">
                                    <div class="row">
                                        <div class="col-12">
                                            <div class="d-flex justify-content-around align-items-center">
                                                <p class="date">
                                                    <asp:Label ID="lblYayinTarihi" runat="server" CssClass="date"></asp:Label>
                                                </p>
                                            </div>
                                        </div>
                                        <div class="col-12">
                                            <img src="/images/LIVE2.gif" runat="server" id="live" visible="false" width="50" height="50" />
                                            <h4 class="title">
                                                <asp:Label ID="lblBaslik1" runat="server" CssClass="title"></asp:Label></h4>
                                        </div>
                                        <div class="col-12">
                                            <h5 class="location">
                                                <i class="fas fa-map-marker-alt"></i>
                                                <asp:Label ID="lblil" runat="server"></asp:Label>
                                            </h5>
                                        </div>
                                        <div class="col-12">
                                            <asp:Literal ID="ltTeklifTalebi1" runat="server" Visible="false"></asp:Literal>
                                            <asp:Panel runat="server" ID="mobilSolPrice" Visible="False">
                                                <h3 class="price">
                                                    <p>Satılık</p>
                                                    <asp:Literal ID="ltFiyat" runat="server"></asp:Literal>
                                                    <asp:Literal ID="ltParaBirimi" runat="server"></asp:Literal>
                                                </h3>
                                            </asp:Panel>
                                            <asp:Panel runat="server" ID="mobilRentPrice" Visible="False">
                                                <h3 class="price">
                                                    <p>Günlük Fiyat</p>
                                                    <asp:Literal ID="ltMobilDailyPrice" runat="server"></asp:Literal>
                                                    <asp:Literal ID="ltParaBirim2" runat="server"></asp:Literal>
                                                    <p>Haftalık Fiyat</p>
                                                    <asp:Literal ID="ltMobilWeeklyPrice" runat="server"></asp:Literal>
                                                    <asp:Literal ID="ltParaBirim3" runat="server"></asp:Literal>
                                                    <p>Aylık Fiyat</p>
                                                    <asp:Literal ID="ltMobilMonthlyPrice" runat="server"></asp:Literal>
                                                    <asp:Literal ID="ltParaBirim4" runat="server"></asp:Literal>
                                                </h3>
                                            </asp:Panel>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-7">
                                <div class="owl-carousel owl-theme" id="urun-detay-slider">
                                    <div class="item ">
                                        <img src="images/blog-horizontal-2.png" alt="Örnek Resim">
                                    </div>
                                    <div class="item ">
                                        <img src="images/blog-horizontal-2.png" alt="Örnek Resim">
                                    </div>
                                </div>
                                <div class="mt-3">
                                    <div class="row px-2">
                                        <div class="col-lg-3 col-md-3 col-sm-3 col-3 px-1">
                                            <a class=" secondary url" href="#example">
                                                <img class="img-fluid" src="images/blog-horizontal-2.png" alt="Örnek Resim">
                                            </a>
                                            <br />
                                            <br />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <h3 class="title">
                                    <asp:Label ID="lblBaslik2" runat="server" CssClass="title"></asp:Label></h3>
                                <div class="favoriye-ekle">
                                    <asp:LinkButton runat="server" ID="btnFavorilereEkle">
                                <i class="fas fa-star"></i>
                                        <p class="mb-0">Favori İlanlara Ekle</p></asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="btnFavorilerdenCikar" class="mb-0">
                                <i class="fas fa-minus"></i> 
                                        <p class="mb-0">Favorilerden Çıkar</p></asp:LinkButton>
                                </div>
                                <div class="price">
                                    <asp:Literal ID="ltTeklifTalebi" runat="server" Visible="false"></asp:Literal>
                                    <asp:Panel runat="server" ID="pnlPrice2" Visible="False">
                                        <h2>
                                            <asp:Literal ID="ltFiyat1" runat="server"></asp:Literal>
                                            <asp:Literal ID="ltParaBirimi1" runat="server"></asp:Literal></h2>
                                    </asp:Panel>
                                </div>
                                <div class="price">
                                    <asp:Literal ID="ltTeklifTalebi2" runat="server" Visible="false"></asp:Literal>
                                    <asp:Panel runat="server" ID="pnlRent" Visible="False">
                                        <h2>
                                            <p>Günlük Fiyat</p>
                                            <asp:Literal ID="ltMobilDailyPrice1" runat="server"></asp:Literal>
                                            <asp:Literal ID="ltParaBirim5" runat="server"></asp:Literal>
                                            <p>Haftalık Fiyat</p>
                                            <asp:Literal ID="ltMobilWeeklyPrice1" runat="server"></asp:Literal>
                                            <asp:Literal ID="ltParaBirim6" runat="server"></asp:Literal>
                                            <p>Aylık Fiyat</p>
                                            <asp:Literal ID="ltMobilMonthlyPrice1" runat="server"></asp:Literal>
                                            <asp:Literal ID="ltParaBirim7" runat="server"></asp:Literal>
                                        </h2>
                                    </asp:Panel>
                                </div>
                                <div class="card bg-transparent">
                                    <div class="card-body p-4">
                                        <div class="satici-card">
                                            <div class="first-line">
                                                <div class="img">
                                                    <asp:Literal ID="ltLink" runat="server"></asp:Literal>
                                                    <asp:Image ID="imgLogo" runat="server" ImageUrl="images/logo.png" Visible="false" />
                                                </div>
                                                <div class="texts">
                                                    <h6>
                                                        <p class="p-extra">
                                                            <asp:Literal ID="ltTemsilci" runat="server"></asp:Literal>
                                                        </p>
                                                    </h6>
                                                </div>
                                            </div>
                                            <div class="second-line">
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:LinkButton runat="server" ID="linkBtnTelefonGoster">
                               <span class="btn btn-danger "><i class="fas fa-phone"></i> Telefon Numarasını Göster</span>
                                                        </asp:LinkButton>
                                                        <asp:Panel runat="server" ID="pnlTelefon" Visible="False">
                                                            <asp:LinkButton runat="server" ID="linkBtnTelefonGizle" class="mb-0" Visible="False">
                                <span class="btn btn-warning">Telefon Numarasını Gizle <i class="fas fa-arrow-up"></i></span></asp:LinkButton>
                                                            <p>
                                                                <i class="fas fa-phone"></i>
                                                                <asp:Literal ID="ltTemsilciTel" runat="server"></asp:Literal>
                                                            </p>
                                                        </asp:Panel>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="linkBtnTelefonGoster" EventName="click" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </div>
                                            <div class="second-line">
                                                <p>
                                                    <i class="fas fa-map-marker-alt"></i>
                                                    <asp:Label ID="lblIl1" runat="server"></asp:Label>
                                                </p>
                                                <p class="date">
                                                    <i class="fas fa-calendar"></i>
                                                    <asp:Label ID="lblYayinTarihi1" runat="server" CssClass="date"></asp:Label>
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <asp:LinkButton ID="whatsappLink" runat="server" CssClass="btn btn-success btn-block detay-button my-3">
    <i class="fas fa-phone-alt"></i> Whatsapp
                                </asp:LinkButton>
                                <asp:LinkButton ID="MessageLink" runat="server" CssClass="btn btn-outline-success btn-block detay-button">
    <i class="far fa-envelope"></i> Mesaj Gönder
                                </asp:LinkButton>
                            </div>
                            <asp:ListView ID="lstPhotos" GroupItemCount="50" runat="server" DataKeyNames="makinaResim_ID" Visible="false">
                                <LayoutTemplate>
                                    <asp:PlaceHolder ID="groupPlaceholder" runat="server" />
                                </LayoutTemplate>
                                <GroupTemplate>
                                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                                </GroupTemplate>
                                <ItemTemplate>
                                    <a href='<%= ResolveUrl("~/images/blog-horizontal-2.png") %>' data-fancybox="gallery">
                                        <img src='<%= ResolveUrl("~/images/blog-horizontal-2.png") %>' class="urunresimleri" />
                                    </a>
                                </ItemTemplate>
                            </asp:ListView>
                            <div class="col-md-12">
                                <div class="card mt-4">
                                    <div class="card-body">
                                        <div class="urun-ozellikleri">
                                            <div>
                                                <div class="item">
                                                    <p>Marka: </p>
                                                    <asp:Literal ID="ltMarka1" runat="server"></asp:Literal>
                                                </div>
                                                <div class="item">
                                                    <p>Kategori: </p>
                                                    <asp:Literal ID="ltTur1" runat="server"></asp:Literal>
                                                </div>
                                            </div>
                                            <div>
                                                <div class="item">
                                                    <p>Model: </p>
                                                    <span>
                                                        <asp:Label ID="lblModel1" runat="server"></asp:Label></span>
                                                </div>
                                                <div class="item">
                                                    <p>Alt Kategori: </p>
                                                    <asp:Literal ID="ltAltTur1" runat="server"></asp:Literal>
                                                </div>
                                            </div>
                                            <div>
                                                <div class="item">
                                                    <p>Model Yılı: </p>
                                                    <span>
                                                        <asp:Label ID="lblYil1" runat="server"></asp:Label></span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12 detay-aciklama">
                                <div class="card mt-4">
                                    <div class="card-body">
                                        <h5 class="title">Açıklama</h5>
                                        <p>
                                            <asp:Literal ID="ltAciklama" runat="server"></asp:Literal>
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="" style="margin-top: 50px">
                    <asp:Button ID="btnBackCheckMachine" runat="server" Text="< Geri" CssClass="btn btn-prev login-button btn-lg" OnClick="btnBackCheckMachine_Click" />
                    <asp:Button ID="btnNextCheckMachine" runat="server" Text="İleri >" CssClass="btn btn-next btn-success login-button btn-lg  float-right" OnClick="btnNextCheckMachine_Click" />
                </div>
            </asp:Panel>
            <%--        ADIM 4--%>
            <asp:Panel ID="pnlDoping" runat="server" Visible="false">
                <div class="container-fluid">
                    <div class="border-primary">
                        <div class="top">
                            <h1>Abonelik Planları</h1>
                        </div>
                        <div class="package-container">
                            <asp:Panel CssClass="packages" ID="pnlOneTime" runat="server" Visible="false">
                               
                                <div class="head-bg">
                                             <h1 class="headerText">Tek defalık satıcı</h1>
                                            <div class="elementor-shape elementor-shape-bottom" data-negative="false" bis_skin_checked="1">
                                                <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 1000 100" preserveAspectRatio="none">
                                                    <path class="elementor-shape-fill" d="M421.9,6.5c22.6-2.5,51.5,0.4,75.5,5.3c23.6,4.9,70.9,23.5,100.5,35.7c75.8,32.2,133.7,44.5,192.6,49.7
        c23.6,2.1,48.7,3.5,103.4-2.5c54.7-6,106.2-25.6,106.2-25.6V0H0v30.3c0,0,72,32.6,158.4,30.5c39.2-0.7,92.8-6.7,134-22.4
        c21.2-8.1,52.2-18.2,79.7-24.2C399.3,7.9,411.6,7.5,421.9,6.5z">
                                                    </path>
                                                </svg>
                                            </div>
                                        </div>
                                <%--<h2 class="text1" id="txth1" runat="server"></h2>
                                <h2 class="text2" id="txth2" runat="server"></h2>--%>
                                <ul class="list">
                                    <li class="first">1 Ucretsiz ilan hakkı</li>
                                </ul>
                                <div class="toggle-btn">
                                    <span style="margin: 0.8em;"><span class="text1" id="txth1" runat="server"></span></span>
                                    <label class="switch">
                                        <asp:CheckBox ID="myCheckBox" runat="server" />

                                        <span class="slider round"></span>
                                    </label>
                                    <span style="margin: 0.8em;"><span class="text2" id="txth2" runat="server"></span></span>

                                </div>
                                <asp:Button runat="server" ID="btnOpenAppointment" class="button button1" Text="Tarife Olustur" OnClick="btnOpenAppointment2_Click" />
                            </asp:Panel>
                            <asp:Repeater ID="rptMembershipVersion" runat="server" OnItemDataBound="paymentSelect_ItemDataBound">
                                <ItemTemplate>
                                    <div class="packages">
                                        <div class="head-bg">
                                             <h1 class="headerText"><%# Eval("MembershipName") %></h1>
                                            <div class="elementor-shape elementor-shape-bottom" data-negative="false" bis_skin_checked="1">
                                                <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 1000 100" preserveAspectRatio="none">
                                                    <path class="elementor-shape-fill" d="M421.9,6.5c22.6-2.5,51.5,0.4,75.5,5.3c23.6,4.9,70.9,23.5,100.5,35.7c75.8,32.2,133.7,44.5,192.6,49.7
        c23.6,2.1,48.7,3.5,103.4-2.5c54.7-6,106.2-25.6,106.2-25.6V0H0v30.3c0,0,72,32.6,158.4,30.5c39.2-0.7,92.8-6.7,134-22.4
        c21.2-8.1,52.2-18.2,79.7-24.2C399.3,7.9,411.6,7.5,421.9,6.5z">
                                                    </path>
                                                </svg>
                                            </div>
                                        </div>

                                        <ul class="list">
                                            <li class="first"><i class="fas fa-check-circle"></i><%# Eval("MaxAds") %> Ucretsiz ilan hakkı</li>
                                            <li>
                                                <i class='<%# Eval("PriceWeekTr").ToString() == "0" ? "" : "fas fa-check-circle" %>'></i>
                                                <%# Eval("PriceWeekTr").ToString() == "0" ? " " : ("Kurumsal Üyelik") %></li>
                                            <li>
                                                <i class='<%# Eval("PriceWeekTr").ToString() == "0" ? "" : "fas fa-check-circle" %>'></i>
                                                <%# Eval("PriceWeekTr").ToString() == "0" ? " " : ("Firma Logosu Gösterimi") %></li>
                                            <li>
                                                <i class='<%# Eval("PriceWeekTr").ToString() == "0" ? "" : "fas fa-check-circle" %>'></i>
                                                <%# Eval("PriceWeekTr").ToString() == "0" ? " " : ("Firma Mağazası") %></li>
                                            <li>
                                                <i class='<%# Eval("PriceWeekTr").ToString() == "0" ? "" : "fas fa-check-circle" %>'></i>
                                                <%# Convert.ToInt32(Eval("MaxDisplayAds")) > 0 ? Eval("MaxDisplayAds") + " adet Ana sayfa vitrin ilanı" : string.Empty %>
                                            </li>
                                        </ul>

                                        <%--  <div class="form-check">
                                                <input runat="server" class="form-check-input" type="radio" name="flexRadioDefault" id="radioMonht">
                                                <label class="form-check-label" for="radioMonht">
                                                    <%# Eval("PriceWeekTr").ToString() == "0" ? "Ücretsiz" : ("&#8378;" + Eval("PriceWeekTr") + " / Ay" ) %>
                                                </label>
                                            </div>
                                        
                                        <div class="form-check">
                                            <input runat="server" class="form-check-input" type="radio" name="flexRadioDefault" id="radioYear">
                                            <label class="form-check-label" for="radioYear">
                                                <%# Eval("PriceYearTr").ToString() == "0" ? "Ücretsiz" : ("&#8378;" + Eval("PriceYearTr") + " / Yıl") %>
                                            </label>
                                        </div>--%>
                                        <div class="toggle-btn">
                                            <span style="margin: 0.8em;"><%# Eval("PriceWeekTr").ToString() == "0" ? "Ücretsiz" : ("&#8378;" + Eval("PriceWeekTr") + " / Ay" ) %></span>
                                            <label class="switch">
                                                <asp:CheckBox ID="myCheckBox" runat="server" />

                                                <span class="slider round"></span>
                                            </label>
                                            <span style="margin: 0.8em;"><%# Eval("PriceYearTr").ToString() == "0" ? "Ücretsiz" : ("&#8378;" + Eval("PriceYearTr") + " / Yıl") %></span>

                                        </div>
                                        <asp:Button runat="server" ID="btnOpenAppointment" class="button button1" Text="Tarife Olustur" CommandArgument='<%# Eval("MembershipVersionID") %>' data-uye-id='<%# Eval("MembershipVersionID") %>' OnClick="btnOpenAppointment_Click" />
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                    <div class="form-group form-check mb-0px mt-3 register-checboxs">
                        <asp:Label ID="lblErrorPnlPayment" runat="server" Visible="false"></asp:Label>
                    </div>
                </div>
                <div class="container-fluid">
                    <asp:Button ID="btnBackDoping" runat="server" Text="< Geri" Visible="false" CssClass="btn btn-next btn-success login-button btn-lg" OnClick="btnBackDoping_Click" />
                </div>
            </asp:Panel>
            <%--            ADIM 5--%>
            <asp:Panel ID="pnlPayment" runat="server" Visible="false">
                <div class="container">
                    <div class="row m-0">
                        <div class="col-md-7 col-12">
                            <div class="">
                                <div class="col-12 mb-4">
                                    <%--         Fiyat alanı--%>
                                    <div class="row box-right">
                                        <div class="col-md-12 ps-0 ">
                                            <p class="ps-3 textmuted fw-bold h6 mb-0">TOPLAM</p>
                                            <hr />
                                            <input type="hidden" id="hiddenField" name="hiddenField" runat="server">
                                            <p runat="server" id="planPayment" class="ps-3 textmuted fw-bold h6 mb-0"></p>
                                            <p class="h1 fw-bold d-flex">
                                                <asp:Panel ID="pnlTotal" runat="server" Visible="true">
                                                    <span class=" text-muted pe-1 h6 align-text-top mt-1" id="spnBigPayment" runat="server"></span>
                                                    <span class="text-muted">.00 </span><i class="fas fa-lira-sign"></i>
                                                    <p runat="server" id="paymentplanYear" class="textmuted h8">* 12 AY TAKSITLE ODEME IMKANI</p>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlFree" runat="server" Visible="false">
                                                    <span class="fas text-muted pe-1 h6 align-text-top mt-1">Ucretsiz</span>
                                                </asp:Panel>
                                            </p>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-12 px-0 mb-4">
                                    <div class="box-right">
                                        <asp:Panel ID="cardInfo" runat="server" Visible="true">
                                            <%--              Kart ve adres bilgileri--%>
                                            <div class="card p-3">
                                                <h6 class="text-uppercase">Ödeme Detayları</h6>
                                                <div class="row">
                                                    <div class="form-group col-sm-7">
                                                        <label for="card-holder">Kartın Üzerindeki İsim</label>
                                                        <input id="txtCardholderName" type="text" class="form-control" runat="server" placeholder="Kartın Üzerindeki İsim" aria-label="Kart Sahibi" aria-describedby="basic-addon1">
                                                    </div>
                                                    <div class="form-group col-sm-5">
                                                        <label for="">SKT</label>
                                                        <div class="input-group expiration-date">
                                                            <input id="txtExpireMonth" runat="server" type="text" class="form-control" placeholder="MM" aria-label="MM" aria-describedby="basic-addon1">
                                                            <span class="date-separator seperator">/</span>
                                                            <input id="txtExpireYear" runat="server" type="text" class="form-control" placeholder="YYYY" aria-label="YYYY" aria-describedby="basic-addon1">
                                                        </div>
                                                    </div>
                                                    <div class="form-group col-sm-8">
                                                        <label for="card-number">Kart Numarası</label>
                                                        <input id="txtCardNumber" runat="server" type="text" class="form-control" placeholder="Kart Numarası" aria-label="Card Holder" aria-describedby="basic-addon1">
                                                    </div>
                                                    <div class="form-group col-sm-4">
                                                        <label for="cvc">CVC</label>
                                                        <input id="txtCvc" runat="server" type="text" class="form-control" placeholder="CVC" aria-label="Card Holder" aria-describedby="basic-addon1">
                                                    </div>
                                                    <asp:Panel ID="MonthlyButton" runat="server">
                                                        <div class="form-group">
                                                            <div class="form-check agreeCheck">
                                                                <input class="form-check-input " type="checkbox" value="" id="invalidCheck23" required>
                                                                <label class="form-check-label" for="invalidCheck23">
                                                                    Kart Bilgilerini Kaydet
                                                                </label>
                                                            </div>
                                                        </div>
                                                    </asp:Panel>
                                                </div>
                                                <h6 class="text-uppercase">Fatura Bilgileri</h6>
                                                <div class="row mt-3">
                                                    <div class="col-md-12">
                                                        <div class="inputbox mt-3 mr-2">
                                                            <input type="text" name="name" id="txtAddres" runat="server" class="form-control" required="required">
                                                            <span>Adres</span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row mt-2">
                                                    <div class="col-md-6">
                                                        <div class="inputbox mt-3 mr-2">
                                                            <input type="text" id="txtInfoCountry" runat="server" name="name" class="form-control" required="required">
                                                            <span>Ülke</span>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class="inputbox mt-3 mr-2">
                                                            <input type="text" id="txtInfoCity" runat="server" name="name" class="form-control" required="required">
                                                            <span>Şehir</span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <asp:Button ID="btnPayWithCard" runat="server" Text="ÖDE ve Makine Oluştur" CssClass="btn btn-primary d-block h8 my-3" OnClick="btnPayWithCard_Click" />
                                                <asp:Label ID="lblKod" runat="server" Visible="false"></asp:Label>
                                            </div>
                                        </asp:Panel>
                                        <asp:Panel ID="carnonInfo" runat="server" Visible="true">
                                            <asp:Button ID="btnNonInfoPaymentBack" runat="server" Text="< Geri" CssClass="btn btn-prev login-button" OnClick="btnNonInfoPaymentBack_Click" />
                                            <asp:Button ID="btnNonInfoPaymentNext" runat="server" Text="Makine Olustur" CssClass="btn btn-next btn-success login-button" Visible="false" OnClick="btnNonInfoPaymentNext_Click" />
                                        </asp:Panel>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%--              Kullanıcı bilgileri--%>
                        <div class="col-md-5 col-12 ps-md-5 p-0 ">
                            <div class="box-left form-payment">
                                <div class="form-row">
                                    <div class="col-md-6 mb-3">
                                        <label for="txtBuyerName">İsim</label>
                                        <input type="text" class="form-control " runat="server" id="txtBuyerName" placeholder="İsim" required>
                                    </div>
                                    <div class="col-md-6 mb-3">
                                        <label for="txtBuyerSurname">Soyadı</label>
                                        <input type="text" class="form-control " runat="server" id="txtBuyerSurname" placeholder="Soyadı" required>
                                    </div>
                                </div>
                                <asp:Panel ID="pnlContact" runat="server" Visible="true">
                                    <div class="form-row">
                                        <div class="col-md-6 mb-3">
                                            <label for="txtBuyerTelefon">Telefon</label>
                                            <input type="text" class="form-control " runat="server" placeholder="Telefon" id="txtBuyerTelefon" required>
                                        </div>
                                        <div class="col-md-6 mb-3">
                                            <label for="txtBuyerTc">TC</label>
                                            <input type="text" class="form-control " oninput="this.value = this.value.replace(/[^0-9]/g, '')" id="txtBuyerTc" placeholder="TC Kimlik" runat="server" required>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <div class="form-row">
                                    <div class="col-md-12 mb-3">
                                        <label for="txtBuyerEMail">Email</label>
                                        <input type="text" class="form-control " runat="server" id="txtBuyerEMail" placeholder="examle@examle.com" required>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="form-check agreeCheck">
                                        <input class="form-check-input " type="checkbox" value="" id="invalidCheck3" required>
                                        <label class="form-check-label" for="invalidCheck3">
                                            Agree to terms and conditions
                                        </label>
                                    </div>
                                </div>
                                <div class="">
                                    <div class="row m-0 border mb-3">
                                        <div class="col-6  pe-0 ps-2">
                                            <p class="textmuted py-2">Paket</p>
                                            <span class="d-block py-2 " id="mmbrName" runat="server"></span>
                                        </div>
                                        <div class="col-2 text-center p-0">
                                            <p class="textmuted p-2">Adet</p>
                                            <span class="d-block p-2 m">1</span>
                                        </div>
                                        <div class="col-2 p-0 text-center  border-end">
                                            <p class="textmuted p-2">Fiyat</p>
                                            <span class="d-block  py-2"><span id="ftrPrice" runat="server"></span><i class="fas fa-lira-sign"></i></span>
                                        </div>
                                        <div class="col-2 p-0 text-center">
                                            <p class="textmuted p-2">Toplam</p>
                                            <span class="d-block py-2 "><span id="ftrPriceTotal" runat="server"></span><i class="fas fa-lira-sign"></i></span>
                                        </div>
                                    </div>
                                    <div class="d-flex h7 mb-2">
                                        <p id="txtPricePay" runat="server" class="">Toplam Fiyat</p>
                                        <p class="ms-auto" style="flex: 1 auto; text-align: right;"><span class="fas fa-lira-sign" id="totalPrice" runat="server"></span></p>
                                    </div>
                                    <div class=" mb-5">
                                        <p class="textmuted">Teşekkürler</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlSuccess" runat="server" Visible="false">
                <div class="container-fluid">
                    <div class="card">
                        <div class="vh-100 d-flex justify-content-center align-items-center">
                            <div class="col-md-12 bg-white shadow-md p-5">
                                <div class="mb-4 text-center">
                                    <svg xmlns="http://www.w3.org/2000/svg" class="text-success" width="75" height="75"
                                        fill="currentColor" class="bi bi-check-circle" viewBox="0 0 16 16">
                                        <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14zm0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16z" />
                                        <path
                                            d="M10.97 4.97a.235.235 0 0 0-.02.022L7.477 9.417 5.384 7.323a.75.75 0 0 0-1.06 1.06L6.97 11.03a.75.75 0 0 0 1.079-.02l3.992-4.99a.75.75 0 0 0-1.071-1.05z" />
                                    </svg>
                                </div>
                                <div class="text-center">
                                    <h1>Teşekkürler , Ürün başarıyla eklendi !</h1>
                                    <p>İlan onaylandığında size geri dönüş yapacağız!</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
