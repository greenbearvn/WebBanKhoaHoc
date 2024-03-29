﻿using Microsoft.AspNetCore.Mvc;
using WebBanKhoaHoc.Entities;

namespace WebBanKhoaHoc.Admin.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private BusinessLayer.BLL.NguoiDungBLL BLL;

        public UserController()
        {
            BLL = new BusinessLayer.BLL.NguoiDungBLL();
        }



        [HttpGet]
        [Route("UsersHome/")]
        public async Task<ActionResult<List<NguoiDung>>> GetAll()
        {
            var posts = await BLL.GetAll();
            return Ok(posts);
        }


        [HttpPost]
        [Consumes("application/json")]
        [Route("UserCreate/")]
        public bool Add(NguoiDung us)
        {
            BLL.Create(us);
            return true;
        }

        [HttpPost]
        [Route("UserDelete/")]
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
        [Route("UserUpdate/")]
        public bool Update(NguoiDung us)
        {
            if (us == null)
            {
                return false;
            }

            BLL.Update(us);
            return true;
        }


    }
}
