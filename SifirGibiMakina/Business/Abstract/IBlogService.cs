using SifirGibiMakina.Dtos.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business
{
    public interface IBlogService
    {
        List<BlogListDto> GetBlogList(int id);
        tbl_Duyurular GetBlog(int id);
    }
}