<%@ Page Language="C#" MasterPageFile="~/Makina.Master" AutoEventWireup="true" CodeBehind="ServisFirm.aspx.cs" Inherits="SifirGibiMakina.ServisFirm" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>

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
    <style>
        
.star-rating{
  font-size:0;
  white-space:nowrap;
  display:inline-block;
  width:250px;
  height:50px;
  overflow:hidden;
  position:inherit;
  background:
      url('data:image/svg+xml;base64,PHN2ZyB2ZXJzaW9uPSIxLjEiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgeG1sbnM6eGxpbms9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkveGxpbmsiIHg9IjBweCIgeT0iMHB4IiB3aWR0aD0iMjBweCIgaGVpZ2h0PSIyMHB4IiB2aWV3Qm94PSIwIDAgMjAgMjAiIGVuYWJsZS1iYWNrZ3JvdW5kPSJuZXcgMCAwIDIwIDIwIiB4bWw6c3BhY2U9InByZXNlcnZlIj48cG9seWdvbiBmaWxsPSIjREREREREIiBwb2ludHM9IjEwLDAgMTMuMDksNi41ODMgMjAsNy42MzkgMTUsMTIuNzY0IDE2LjE4LDIwIDEwLDE2LjU4MyAzLjgyLDIwIDUsMTIuNzY0IDAsNy42MzkgNi45MSw2LjU4MyAiLz48L3N2Zz4=');
  background-size: contain;
  margin-top:200px;
  margin-left:630px;
  i{
    opacity: 0;
    position: absolute;
    left: 0;
    top: 0;
    height: 100%;
    width: 20%;
    z-index: 1;
    background: 
        url('data:image/svg+xml;base64,PHN2ZyB2ZXJzaW9uPSIxLjEiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgeG1sbnM6eGxpbms9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkveGxpbmsiIHg9IjBweCIgeT0iMHB4IiB3aWR0aD0iMjBweCIgaGVpZ2h0PSIyMHB4IiB2aWV3Qm94PSIwIDAgMjAgMjAiIGVuYWJsZS1iYWNrZ3JvdW5kPSJuZXcgMCAwIDIwIDIwIiB4bWw6c3BhY2U9InByZXNlcnZlIj48cG9seWdvbiBmaWxsPSIjRkZERjg4IiBwb2ludHM9IjEwLDAgMTMuMDksNi41ODMgMjAsNy42MzkgMTUsMTIuNzY0IDE2LjE4LDIwIDEwLDE2LjU4MyAzLjgyLDIwIDUsMTIuNzY0IDAsNy42MzkgNi45MSw2LjU4MyAiLz48L3N2Zz4=');  
    background-size: contain;
  }
  input{ 
    -moz-appearance:none;
    -webkit-appearance:none;
    opacity: 0;
    display:inline-block;
    width: 20%;
    height: 100%; 
    margin:0;
    padding:0;
    z-index: 2;
    position: relative;
    &:hover + i,
    &:checked + i{
      opacity:1;    
    }
  }
  i ~ i{
    width: 40%;
  }
  i ~ i ~ i{
    width: 60%;
  }
  i ~ i ~ i ~ i{
    width: 80%;
  }
  i ~ i ~ i ~ i ~ i{
    width: 100%;
  }
}


.choice{
  position: inherit;
  top: 215px;

  right:-615px;
  text-align: center;
 
}

.star-rating-comment{
font-size: 0;
  white-space: nowrap;
  display: inline-block;
  width: 100px;
  height: 20px;
  overflow: hidden;
  position: absolute;
  background: url('data:image/svg+xml;base64,PHN2ZyB2ZXJzaW9uPSIxLjEiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgeG1sbnM6eGxpbms9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkveGxpbmsiIHg9IjBweCIgeT0iMHB4IiB3aWR0aD0iMjBweCIgaGVpZ2h0PSIyMHB4IiB2aWV3Qm94PSIwIDAgMjAgMjAiIGVuYWJsZS1iYWNrZ3JvdW5kPSJuZXcgMCAwIDIwIDIwIiB4bWw6c3BhY2U9InByZXNlcnZlIj48cG9seWdvbiBmaWxsPSIjREREREREIiBwb2ludHM9IjEwLDAgMTMuMDksNi41ODMgMjAsNy42MzkgMTUsMTIuNzY0IDE2LjE4LDIwIDEwLDE2LjU4MyAzLjgyLDIwIDUsMTIuNzY0IDAsNy42MzkgNi45MSw2LjU4MyAiLz48L3N2Zz4=');
    background-size: auto;
  background-size: contain;
  margin-top: 20px;
  margin-left: 630px;i{
  opacity: 0;
  position: absolute;
  left: 0;
  top: 0;
  height: 100%;
  width: 20%;
  z-index: 1;
  background: 
      url('data:image/svg+xml;base64,PHN2ZyB2ZXJzaW9uPSIxLjEiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgeG1sbnM6eGxpbms9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkveGxpbmsiIHg9IjBweCIgeT0iMHB4IiB3aWR0aD0iMjBweCIgaGVpZ2h0PSIyMHB4IiB2aWV3Qm94PSIwIDAgMjAgMjAiIGVuYWJsZS1iYWNrZ3JvdW5kPSJuZXcgMCAwIDIwIDIwIiB4bWw6c3BhY2U9InByZXNlcnZlIj48cG9seWdvbiBmaWxsPSIjRkZERjg4IiBwb2ludHM9IjEwLDAgMTMuMDksNi41ODMgMjAsNy42MzkgMTUsMTIuNzY0IDE2LjE4LDIwIDEwLDE2LjU4MyAzLjgyLDIwIDUsMTIuNzY0IDAsNy42MzkgNi45MSw2LjU4MyAiLz48L3N2Zz4=');  
  background-size: contain;

}  input{ 
    -moz-appearance:none;
    -webkit-appearance:none;
    opacity: 0;
    display:inline-block;
    width: 20%;
    height: 100%; 
    margin:0;
    padding:0;
    z-index: 2;
    position: relative;
    &:hover + i,
    &:checked + i{
      opacity:1;    
    }
  }
  i ~ i{
    width: 40%;
  }
  i ~ i ~ i{
    width: 60%;
  }
  i ~ i ~ i ~ i{
    width: 80%;
  }
  i ~ i ~ i ~ i ~ i{
    width: 100%;
  }
}

.card-white  .card-heading {
  color: #333;
  background-color: #fff;
  border-color: #ddd;
   border: 1px solid #dddddd;
}
.card-white  .card-footer {
  background-color: #fff;
  border-color: #ddd;
}
.card-white .h5 {
    font-size:14px;
    //font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
}
.card-white .time {
    font-size:12px;
    //font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
}
.post .post-heading {
  height: 95px;
  padding: 20px 15px;
}
.post .post-heading .avatar {
  width: 60px;
  height: 60px;
  display: block;
  margin-right: 15px;
}
.post .post-heading .meta .title {
  margin-bottom: 0;
}
.post .post-heading .meta .title a {
  color: black;
}
.post .post-heading .meta .title a:hover {
  color: #aaaaaa;
}
.post .post-heading .meta .time {
  margin-top: 8px;
  color: #999;
}
.post .post-image .image {
  width: 100%;
  height: auto;
}
.post .post-description {
  padding: 15px;
}
.post .post-description p {
  font-size: 14px;
}
.post .post-description .stats {
  margin-top: 20px;
}
.post .post-description .stats .stat-item {
  display: inline-block;
  margin-right: 15px;
}
.post .post-description .stats .stat-item .icon {
  margin-right: 8px;
}
.user-profile-image {
    width: 60px;
    height: 60px;

}
.post .post-footer {
  border-top: 1px solid #ddd;
  padding: 15px;
}
.post .post-footer .input-group-addon a {
  color: #454545;
}
.post .post-footer .comments-list {
  padding: 0;
  margin-top: 20px;
  list-style-type: none;
}
.post .post-footer .comments-list .comment {
  display: block;
  width: 100%;
  margin: 20px 0;
}
.post .post-footer .comments-list .comment .avatar {
  width: 35px;
  height: 35px;
}
.post .post-footer .comments-list .comment .comment-heading {
  display: block;
  width: 100%;
}
.post .post-footer .comments-list .comment .comment-heading .user {
  font-size: 14px;
  font-weight: bold;
  display: inline;
  margin-top: 0;
  margin-right: 10px;
}
.post .post-footer .comments-list .comment .comment-heading .time {
  font-size: 12px;
  color: #aaa;
  margin-top: 0;
  display: inline;
}
.post .post-footer .comments-list .comment .comment-body {
  margin-left: 50px;
}
.post .post-footer .comments-list .comment > .comments-list {
  margin-left: 50px;
}
.rating {
   display: inline-flex;
    margin-top: -10px;
    flex-direction: row-reverse;
   
    
}

.rating>input {
    display: none
}

.rating>label {
    position: relative;
    width: 28px;
    font-size: 35px;
    color: #e5bb18;
    cursor: pointer;
}

.rating>label::before {
    content: "\2605";
    position: absolute;
    opacity: 0
}

.rating>label:hover:before,
.rating>label:hover~label:before {
    opacity: 1 !important
}

.rating>input:checked~label:before {
    opacity: 1
}

.rating:hover>input:checked~label:before {
    opacity: 0.4
}
.star-rating-comment input[type="radio"] {
    pointer-events: none;
}
.star-rating input[type="radio"] {
    pointer-events: none;
}
.marginSizePhoto{
    margin-left:-5px;
}
.marginSizeName{
    margin-left:15px;
}
.customWhiteBox
{
  height: 270px;
  margin-top: 20px;
}
.customDespriction{
    height:120px;

}
.customTextBox {
    width: 710px;
    height: 100px;
    text-align: left;
}
.Custombtn
{
  margin-left: 538px;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="breadcrumb-comp">
        <div class="container">
          <div class="row">
            <div class="col-md-12">
              <a href="/">Anasayfa</a>
              <span><i class="fas fa-angle-right"></i></span>
              <a href="/urunler">Ilanlar</a>
              <span><i class="fas fa-angle-right"></i></span>
              <p><asp:Label ID="lblServerFirmName" runat="server"></asp:Label></p>
            </div>
          </div>
        </div>
      </div>
      
      <div class="satici-detay bg-light py-5">
          <div class="container">
              <div class="row">
                  <div class="col-md-12 position-relative">
                      <div class="satici-banner"></div>
                      <div class="satici-logo">
                        <asp:Image ID="imgLogo" runat="server" Width="207px" Height="209px" ToolTip='<%# Eval("Baslik") %>' AlternateText='<%# Eval("Baslik") %>' />
                        
<span class="star-rating">
    <input type="radio" name="rating_44" value="1"><i></i>
    <input type="radio" name="rating_44" value="2"><i></i>
    <input type="radio" name="rating_44" value="3"><i></i>
    <input type="radio" name="rating_44" value="4"><i></i>
    <input type="radio" name="rating_44" value="5"><i></i>
</span>

<%--           <form id="ratingForm" method="post">
    <span class="star-rating">
        <input type="radio" name="rating" value="1"><i></i>
        <input type="radio" name="rating" value="2"><i></i>
        <input type="radio" name="rating" value="3"><i></i>
        <input type="radio" name="rating" value="4"><i></i>
        <input type="radio" name="rating" value="5"><i></i>
    </span>
    <input type="submit" value="Submit Rating">
</form>--%>

<strong class="choice">Puan</strong>
                    
                      </div>

                  </div>
              </div>
              <div class="row">
                  <div class="col-md-3">
                      <div class="card satici-card-comp">
                          <div class="card-body">
                              <h4 class="title"><asp:Label ID="lblFirmaismi" runat="server"></asp:Label></h4>
                              <p class="text"><strong>E-Mail:</strong> <asp:Literal ID="ltTelefon" runat="server"></asp:Literal></p>
                              <p class="text"><strong>Adres:</strong> <asp:Label ID="lblAdres" runat="server"></asp:Label></p>
                          </div>
                      </div>
                                             <div class="card satici-card-comp">
    <div class="card-body">
        <h4 class="title">Ülkeler</h4>
<asp:Repeater ID="RepaterCountry" runat="server">
  <ItemTemplate>
    <p class="text text-light-gray"><%# Eval("CountryName") %></p>

      </ItemTemplate>
      </asp:Repeater>
        
        
    </div>
</div>
                       <div class="card satici-card-comp">

                          <div class="card-body">
                              <h4 class="title">Ekipmanlar</h4>
                      <asp:Repeater ID="rptEkipmanlar" runat="server">
                        <ItemTemplate>
                          <p class="text text-light-gray"><%# Eval("ServiceEquipmentDetailName") %></p>

                            </ItemTemplate>
                            </asp:Repeater>
                              
                              
                          </div>
                      </div>
                        
                  </div>
                  <div class="col-md-9">
                      <div class="row">
                          <div class="col-md-12">
                              <div class="card satici-card-comp">
                                  <div class="card-body">
                                      <h4 class="title">Hakkımızda</h4>
                                      <p class="text">
                                          <asp:Literal ID="ltHakkimizda" runat="server"></asp:Literal>
                                      </p>
                                  </div>
                              </div>
                          </div>
                      </div>
                          <div class="row">
        <div class="col-md-12">
            <div class="card satici-card-comp">
                <div class="card-body">
                    <h4 class="title">Hizmet Verilen Kategoriler</h4>
                    <p class="text">

                            <div class="col-md-12 sm-px-8" id="WorkZoneArea">
                                <div class="form-group">
                               

                                    <asp:Repeater ID="RepeaterCategory" runat="server">
                                        <HeaderTemplate>
                                            <table class="table custom-table">
                                                <thead>
                                                    <tr>
                                                        <th>
                                                         #

                                                        </th>

                                                               <th scope="col">Kategori Adı</th>
          <th scope="col">Alt Kategori</th>
          <th scope="col">Alt-Alt Kategori</th>

                                              
                                                    </tr>
                                                </thead>
                                                <tbody>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                               <td><%# Container.ItemIndex + 1 %></td>
 <td><%# Eval("CategoryName") %></td>
 <td><%# Eval("SubCategoryName") %></td>
 <td>
   <%# Eval("SubSubCategoryName") != null && !string.IsNullOrEmpty(Eval("SubSubCategoryName").ToString()) ? Eval("SubSubCategoryName") : "-" %>
              
 </td>


                                             
                                            </tr>

                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </tbody>
</table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                         


                                </div>
                            </div>
                    </p>
                </div>
            </div>
        </div>
    </div>
                  
                      
                                                <div class="row">
        <div class="col-md-12">
            <div class="card satici-card-comp">
                <div class="card-body">
                    <h4 class="title">Yorumlar</h4>
                    <p class="text">
                        
      

        <div class="col-12">
               <asp:Repeater runat="server" ID="commentRepeater" OnItemDataBound="rptCommenterPhoto_ItemDataBound">
    <ItemTemplate>
                <input type="hidden" class="comment-rating" value='<%# Eval("CommentRating") %>' />
            <span class="star-rating-comment">
                <input type="radio" name="rating_<%# Container.ItemIndex %>" value="1"><i></i>
                <input type="radio" name="rating_<%# Container.ItemIndex %>" value="2"><i></i>
                <input type="radio" name="rating_<%# Container.ItemIndex %>" value="3"><i></i>
                <input type="radio" name="rating_<%# Container.ItemIndex %>" value="4"><i></i>
                <input type="radio" name="rating_<%# Container.ItemIndex %>" value="5"><i></i>
            </span>
            <div class="card card-white post">
                <div class="post-heading">
                    <div class="float-left image marginSizePhoto">
                        <asp:Image ID="imgPicture" runat="server" ToolTip='<%# Eval("CommenterUserPhoto") %>' AlternateText='<%# Eval("CommenterUserPhoto") %>' class="img-circle avatar" alt="user profile image"   CssClass="user-profile-image"/>
                    </div>
                    <div class="float-left meta marginSizeName">
                        <div class="title h5">
                            <b><%# Eval("CommenterUserName") %></b>
                        </div>
                      <h6 class="text-muted time"><asp:Label runat="server" ID="lblCommentTime"></asp:Label></h6>
                    </div>
                </div>
                <div class="post-description">
                    <p><%# Eval("CommentText") %></p>
                </div>
            </div>
            </ItemTemplate>
</asp:Repeater>
            <asp:Panel ID="pnlCommentNonUser" runat="server" Visible="true" style="margin-top: 10px;">


      <h4>Yorum yapmak için lütfen girş yapınız</h4>
               

                <asp:Button ID="returnurl" runat="server" Text="Giriş Yap" CssClass="btn btn-success Custombtnreturn" Width="100%"   OnClick="btnReturnComment_Click"/>


  </asp:Panel> 
            <asp:Panel ID="pnlCommentUser" runat="server" Visible="false">
                        <div class="card card-white post customWhiteBox">
                           
                <div class="post-heading">
                    <div class="float-left image">
                 
                    </div>
                    <div class="float-left meta">
                        <div class="title h5">
                            <b>Yorum Ekle</b>
                           
                        </div>
                    <div class="rating"> <input type="radio" name="rating" value="5" id="5"><label for="5">☆</label> <input type="radio" name="rating" value="4" id="4"><label for="4">☆</label> <input type="radio" name="rating" value="3" id="3"><label for="3">☆</label> <input type="radio" name="rating" value="2" id="2"><label for="2">☆</label> <input type="radio" name="rating" value="1" id="1"><label for="1">☆</label> </div>
                    </div>
                </div> 
                <div class="post-description customDespriction"> 
    <input type="text" class="form-control customTextBox" id="txtComment"  name="txtComment" required="" runat="server">




                </div>
                             <asp:Button ID="btnComment" runat="server" Text="Yorum Ekle" CssClass="btn btn-success Custombtn" Width="25%"  OnClick="btnAddComment_Click"/>
                               
                          
            </div>
                   </asp:Panel>
        </div>



                       
                    </p>
                </div>
            </div>
        </div>
    </div>






                      <div class="row">
                      
                          <asp:HiddenField runat="server" ID="AverageRatingHiddenField" ClientIDMode="Static" />
                    
                            
                          
                      </div>
                  </div>
              </div>
          </div>
      </div>



   




<script>
    window.onload = function () {
        var veri = document.getElementById('<%= AverageRatingHiddenField.ClientID %>').value;
        if (veri !== '') {
            $('.star-rating input').prop('disabled', true);
            $('.star-rating input[value="' + veri + '"]').prop('checked', true);
        }
        var commentRatings = document.querySelectorAll('.comment-rating');
        commentRatings.forEach(function (commentRating) {
            var ratingValue = parseInt(commentRating.value);

            var starRating = commentRating.nextElementSibling; // Yıldızların bulunduğu span elementi
            var ratingInputs = starRating.querySelectorAll('input[type="radio"]');
            ratingInputs.forEach(function (ratingInput, index) {
                if (index + 1 <= ratingValue) {
                    ratingInput.checked = true;

                }
            });
        });
    };
   
      
   
</script>



 


</asp:Content>







