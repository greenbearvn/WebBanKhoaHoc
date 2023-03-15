using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Linq;
using WebBanKhoaHoc.Entities.GiangVien;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.Extensions.Options;


namespace WebBanKhoaHoc.Admin.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiangVienController : ControllerBase
    {
        public static IWebHostEnvironment env;
        private BusinessLayer.BLL.GiangVienBLL BLL;

        public GiangVienController(IWebHostEnvironment envi)
        {
            BLL = new BusinessLayer.BLL.GiangVienBLL();
            env = envi;
        }


        /*[HttpGet]
        [Route("UsersHome/")]
        public async Task<ActionResult<List<NguoiDung>>> GetAll()
        {
            var posts = await BLL.GetAll();
            return Ok(posts);
        }*/


        [HttpPost]
        [Route("GiangViewCreate/")]
        public bool Add(GiangVienCRUD gvn)
        {
            if (gvn == null)
            {
                return false;
            }

            if (gvn.AnhDaiDien.Length > 0)
            {
                if (!Directory.Exists(env.WebRootPath + "\\Upload\\Avatar"))
                {
                    Directory.CreateDirectory(env.WebRootPath + "\\Upload\\Avatar");
                }
                using (FileStream fileStream = System.IO.File.Create(env.WebRootPath + "\\Upload\\Avatar" + gvn.AnhDaiDien.FileName))
                {


                    gvn.AnhDaiDien.CopyTo(fileStream);
                    fileStream.Flush();
                    var urlAnh = "\\Upload\\Avatar" + gvn.AnhDaiDien.FileName;

                    GiangVien gv = new GiangVien();
                    gv.TenGiangVien = gvn.TenGiangVien;
                    gv.Email = gvn.Email;
                    gv.SoDienThoai = gvn.SoDienThoai;
                    gv.AnhDaiDien = urlAnh;
                    gv.MoTa = gvn.MoTa;
                    BLL.Create(gv);
                    return true;
                }
            }

            
            return true;
        }

        [HttpPost]
        [Route("GiangVienDelete/")]
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
        [Route("GiangVienDelete/")]
        public bool Update(GiangVienCRUD gvn)
        {
            if (gvn == null)
            {
                return false;
            }

            if (gvn.AnhDaiDien.Length > 0)
            {
                if (!Directory.Exists(env.WebRootPath + "\\Upload\\Avatar"))
                {
                    Directory.CreateDirectory(env.WebRootPath + "\\Upload\\Avatar");
                }
                using (FileStream fileStream = System.IO.File.Create(env.WebRootPath + "\\Upload\\Avatar" + gvn.AnhDaiDien.FileName))
                {


                    gvn.AnhDaiDien.CopyTo(fileStream);
                    fileStream.Flush();
                    var urlAnh = "\\Upload\\Avatar" + gvn.AnhDaiDien.FileName;

                    GiangVien gv = new GiangVien();
                    gv.TenGiangVien = gvn.TenGiangVien;
                    gv.Email = gvn.Email;
                    gv.SoDienThoai = gvn.SoDienThoai;
                    gv.AnhDaiDien = urlAnh;
                    gv.MoTa = gvn.MoTa;
                    BLL.Update(gv);
                    return true;
                }
            }
            return true;
        }

    }
}
