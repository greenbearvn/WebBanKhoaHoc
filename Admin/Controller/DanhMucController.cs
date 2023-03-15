using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBanKhoaHoc.Entities;
using BusinessLayer.Service;
using BusinessLayer;

namespace WebBanKhoaHoc.Admin.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucController : ControllerBase
    {
        private BusinessLayer.DanhMucBLL BLL;

        public DanhMucController()
        {
            BLL = new BusinessLayer.DanhMucBLL();

        }

        [HttpGet]
        [Route("ListDanhMuc")]
        public async Task<ActionResult<List<DanhMuc>>> GetAll()
        {
            return await BLL.GetAll();
        }

        [Route("TaoDanhMuc")]
        [HttpPost]
        public bool Create(DanhMuc dm)
        {
             BLL.Insert(dm);
                return true;
        }

        

        [Route("UpdateDanhMuc")]
        [HttpPost]
        public bool Update([FromForm] DanhMuc dm)
        {
            return BLL.Update(dm);
        }

        [Route("DeleteDanhMuc")]
        [HttpPost]
        public bool Delete([FromForm] int?  id)
        {
            if (id == null)
            {
                return false;
            }
            return BLL.Delete(id);
        }



    }
}
