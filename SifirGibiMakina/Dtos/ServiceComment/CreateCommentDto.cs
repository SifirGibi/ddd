using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.ServiceComment
{
    public class CreateCommentDto
    {
       
        public Nullable<int> ServiceTargetUserID { get; set; }
        public Nullable<int> ServiceCommenterUserID { get; set; }
        public string CommentText { get; set; }
        public Nullable<int> CommentRating { get; set; }
   
    }
}