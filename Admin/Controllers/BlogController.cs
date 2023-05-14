using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Linq;
using WebBanKhoaHoc.Entities;
using Microsoft.Extensions.Options;


namespace WebBanKhoaHoc.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        public static IWebHostEnvironment env;
        private BusinessLayer.BLL.BlogBLL BLL;

        public BlogController(IWebHostEnvironment envi)
        {
            BLL = new BusinessLayer.BLL.BlogBLL();
            env = envi;
        }

        [HttpPost]
        [Route("ThemBlog/")]
        public bool Add([FromForm]BlogImg blm)
        {
            if (blm == null)
            {
                return false;
            }

            if (blm.AnhMinhHoa.Length > 0)
            {
                if (!Directory.Exists(env.WebRootPath + "\\Upload\\Blog\\"))
                {
                    Directory.CreateDirectory(env.WebRootPath + "\\Upload\\Blog\\");
                }
                using (FileStream fileStream = System.IO.File.Create(env.WebRootPath + "\\Upload\\Blog\\" + blm.AnhMinhHoa.FileName))
                {


                    blm.AnhMinhHoa.CopyTo(fileStream);
                    fileStream.Flush();
                    var urlAnh = "\\Upload\\Blog\\" + blm.AnhMinhHoa.FileName;

                    Blog bl = new Blog();
                    bl.TenBaiViet = blm.TenBaiViet;
                    bl.NoiDung = blm.NoiDung;
                    bl.AnhMinhHoa = urlAnh;
                    bl.NgayDang = blm.NgayDang;
                    bl.MaDanhMuc = blm.MaDanhMuc;
                    bl.MaNguoiDung = blm.MaNguoiDung;
                    BLL.Create(bl);
                    return true;
                }
            }


            return true;
        }

        [HttpPost]
        [Route("XoaBlog/")]
        public bool Delete(int? id)
        {
            if (id == null)
            {
                return false;
            }

            BLL.Delete(id);
            return true;
        }

        [HttpPost]
        [Route("SuaBlog/")]
        public bool Update(BlogImg blm)
        {
           
            if (blm == null)
            {
                return false;
            }

            if (blm.AnhMinhHoa.Length > 0)
            {
                if (!Directory.Exists(env.WebRootPath + "\\Upload\\Blog\\"))
                {
                    Directory.CreateDirectory(env.WebRootPath + "\\Upload\\Blog\\");
                }
                using (FileStream fileStream = System.IO.File.Create(env.WebRootPath + "\\Upload\\Blog\\" + blm.AnhMinhHoa.FileName))
                {


                    blm.AnhMinhHoa.CopyTo(fileStream);
                    fileStream.Flush();
                    var urlAnh = "\\Upload\\Blog\\" + blm.AnhMinhHoa.FileName;

                    Blog bl = new Blog();
                    bl.TenBaiViet = blm.TenBaiViet;
                    bl.NoiDung = blm.NoiDung;
                    bl.AnhMinhHoa = urlAnh;
                    bl.NgayDang = blm.NgayDang;
                    bl.MaDanhMuc = blm.MaDanhMuc;
                    bl.MaNguoiDung = blm.MaNguoiDung;
                    BLL.Update(bl);
                    return true;
                }
            }
            return true;
        }
    }
}
