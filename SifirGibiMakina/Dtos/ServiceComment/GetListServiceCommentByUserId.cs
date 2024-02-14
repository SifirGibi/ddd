using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.ServiceComment
{
    public class GetListServiceCommentByUserId
    {

        
        public string CommenterUserPhoto {  get; set; }  
        public string CommenterUserName {  get; set; }  
        public string CommentText {  get; set; }  
        public int CommentRating {  get; set; }
        public  Nullable<DateTime> CommentTime {  get; set; }  



    }
}