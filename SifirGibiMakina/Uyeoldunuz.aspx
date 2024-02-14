<%@ Page Language="C#" MasterPageFile="~/Makina.Master" AutoEventWireup="true" CodeBehind="Uyeoldunuz.aspx.cs" Inherits="SifirGibiMakina.Uyeoldunuz" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
  <html>
  <head>
    <link href="https://fonts.googleapis.com/css?family=Nunito+Sans:400,400i,700,900&display=swap" rel="stylesheet">
  </head>
    <style>
      body {
        text-align: center;
        padding: 40px 0;
        background: #EBF0F5;
      }
        h1 {
          color: #88B04B;
          font-family: "Nunito Sans", "Helvetica Neue", sans-serif;
          font-weight: 900;
          font-size: 40px;
          margin-bottom: 10px;
        }
        p {
          color: #404F5E;
          font-family: "Nunito Sans", "Helvetica Neue", sans-serif;
          font-size:20px;
          margin: 0;
        }
      uu {
        color: #9ABC66;
        font-size: 100px;
        line-height: 200px;
        margin-left:-15px;
      }
      .card {
        background: white;
        padding: 60px;
        border-radius: 4px;
        box-shadow: 0 2px 3px #C8D0D8;
        display: inline-block;
        margin: 0 auto;
      }
    </style>
    <body>
      <div class="card">
      <div style="border-radius:200px; height:200px; width:200px; background: #F8FAF5; margin:0 auto;">
        <uu class="checkmark">✓</uu>
      </div>
        <h1>Başarılı</h1> 
        <p>Sıfır Gibi Makine'ye Hoş Geldiniz!<br/> Kaydınız tamamlanmıştır</p>
          <p id="pService" runat="server" visible="false">Lütfen eksik alanları tamamlayınız..</p>
          <br />
         <asp:Button ID="btnAnaSayfa" runat="server" CssClass="btn btn-success px-5" Text="Anasayfa" OnClick="btnAnaSayfa_Click" />
            <asp:Button ID="btnProfil" runat="server" CssClass="btn btn-success px-5" Text="Profil" OnClick="btnProfil_Click" />

      </div>
       
    </body>
</html>
</asp:Content>
