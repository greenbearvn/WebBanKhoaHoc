using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBanKhoaHoc.Entities;
using BusinessLayer.Service;

namespace WebBanKhoaHoc.Admin.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhoaHocController : ControllerBase
    {
        public static IWebHostEnvironment env;

        /*private IKhoaHocBLL BLL;

        public KhoaHocController(IKhoaHocBLL bll, IWebHostEnvironment envi)
        {
            BLL = bll;
            env = envi;
        }*/


        private BusinessLayer.BLL.KhoaHocBLL BLL;

        public KhoaHocController(IWebHostEnvironment envi)
        {
            BLL = new BusinessLayer.BLL.KhoaHocBLL();
            env = envi;


        }


        [HttpGet]
        [Route("ListDanhMuc")]
        public async Task<ActionResult<List<KhoaHocEdit>>> GetAll()
        {
            return await BLL.GetAll();
        }


        [HttpPost]
        [Route("CourseCreate/")]
        public bool CourseCreate([FromForm] KhoaHoc kh)
        {

            if (kh == null)
            {
                return false;
            }

            if (kh.AnhKhoaHoc.Length > 0)
            {
                if (!Directory.Exists(env.WebRootPath + "\\Upload\\"))
                {
                    Directory.CreateDirectory(env.WebRootPath + "\\Upload\\");
                }
                using (FileStream fileStream = System.IO.File.Create(env.WebRootPath + "\\Upload\\" + kh.AnhKhoaHoc.FileName))
                {


                    kh.AnhKhoaHoc.CopyTo(fileStream);
                    fileStream.Flush();
                    var urlAnh = "\\Upload\\" + kh.AnhKhoaHoc.FileName;

                    KhoaHocEdit khed = new KhoaHocEdit();
                    khed.TenKhoaHoc = kh.TenKhoaHoc;
                    khed.AnhKhoaHoc = urlAnh;
                    khed.MoTaNgan = kh.MoTaNgan;
                    khed.MoTaDayDu = kh.MoTaDayDu;
                    khed.ThoiGian = kh.ThoiGian;
                    khed.LuotXem = kh.LuotXem;
                    khed.ThoiLuongKhoaHoc = kh.ThoiLuongKhoaHoc;
                    khed.GiaCu = kh.GiaCu;
                    khed.GiamGia = kh.GiamGia;
                    khed.GiaMoi = kh.GiaCu - ((kh.GiamGia / 100) * kh.GiaCu);
                    khed.MaDanhMuc = kh.MaDanhMuc;
                    khed.TrangThai = kh.TrangThai;
                    khed.MaGiangVien = kh.MaGiangVien;
                    BLL.Create(khed);
                    return true;
                }
            }

            return false;
        }
        

        /*[HttpPost]
        [Route("DeleteCourse/")]
        public async Task<IActionResult> DeleteCourse(int? id)
        {
            if (id != null)
            {
                var khoahoc = (from kh in db.KhoaHocs where kh.MaKhoaHoc == id select kh).FirstOrDefault();
                if (khoahoc != null)
                {
                    db.KhoaHocs.Remove(khoahoc);
                    await db.SaveChangesAsync();
                    return (Ok(true));
                }
                else
                {
                    return (Ok(true));
                }

            }
            else
            {
                return (Ok(false));
            }
        }


        [HttpPost]
        [Route("UpdateCourse/")]
        public async Task<IActionResult> UpdateCourse(KhoaHoc khoaHoc)
        {
            if (khoaHoc != null)
            {
                var khoahoc = (from kh in db.KhoaHocs where kh.MaKhoaHoc == khoaHoc.MaKhoaHoc select kh).FirstOrDefault();
                if (khoahoc != null)
                {
                    khoahoc.TenKhoaHoc = khoaHoc.TenKhoaHoc;
                    await db.SaveChangesAsync();
                    return (Ok(true));
                }
                else
                {
                    return (Ok(true));
                }

            }
            else
            {
                return (Ok(false));
            }
        }*/
    }
}
