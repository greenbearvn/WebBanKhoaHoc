using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Linq;
using WebBanKhoaHoc.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.Extensions.Options;

namespace WebBanKhoaHoc.Admin.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoCOntroller : ControllerBase
    {
        private BusinessLayer.BLL.VideoBLL BLL;

        public VideoCOntroller()
        {
            BLL = new BusinessLayer.BLL.VideoBLL();
        }


        [HttpGet]
        [Route("VideosHome/")]
        public async Task<ActionResult<List<Video>>> GetAll()
        {
            var lists = await BLL.GetAll();
            return Ok(lists);
        }


        [HttpPost]
        [Route("VideoCreate/")]
        public bool Add(Video vd)
        {
            BLL.Create(vd);
            return true;
        }

        [HttpPost]
        [Route("VideoDelete/")]
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
        [Route("VideoUpdate/")]
        public bool Update(Video vd)
        {
            if (vd == null)
            {
                return false;
            }

            BLL.Update(vd);
            return true;
        }
    }
}
