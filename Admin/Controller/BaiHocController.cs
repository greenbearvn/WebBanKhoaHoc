using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebBanKhoaHoc.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.Extensions.Options;


namespace WebBanKhoaHoc.Admin.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaiHocController : ControllerBase
    {
        private BusinessLayer.BLL.BaiHocBLL BLL;

        public BaiHocController()
        {
            BLL = new BusinessLayer.BLL.BaiHocBLL();
        }

        [HttpGet]
        [Route("BaiHocHome/")]
        public async Task<ActionResult<List<BaiHoc>>> GetAll()
        {
            var lists = await BLL.GetAll();
            return Ok(lists);
        }

        [HttpPost]
        [Route("BaiHocCreate/")]
        public bool Add([FromForm]BaiHocCRUD bh)
        {
            if(bh == null)
            {
                return false;
            }
            
            BLL.Create(bh);
            return true;
        }

        [HttpPost]
        [Route("BaiHocDelete/")]
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
        [Route("BaiHocUpdate/")]
        public bool Update([FromForm] BaiHocCRUD bh)
        {
            if (bh == null)
            {
                return false;
            }

            BLL.Update(bh);
            return true;
        }
    }
}
