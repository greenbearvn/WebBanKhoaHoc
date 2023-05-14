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


namespace WebBanKhoaHoc.Admin.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BinhLuanController : ControllerBase
    {
        private BusinessLayer.BLL.BinhLuanBLL BLL;

        public BinhLuanController()
        {
            BLL = new BusinessLayer.BLL.BinhLuanBLL();

        }

        [Route("TaoBinhLuan")]
        [HttpPost]
        public bool Create(BinhLuan bl)
        {
            BLL.Create(bl);
            return true;
        }



        [Route("SuaBinhLuan")]
        [HttpPost]
        public bool Update(BinhLuan bl)
        {
            return BLL.Update(bl);
        }

        [Route("XoaBinhLuan")]
        [HttpPost]
        public bool Delete(int? id)
        {
            if (id == null)
            {
                return false;
            }
            return BLL.Delete(id);
        }
    }
}
