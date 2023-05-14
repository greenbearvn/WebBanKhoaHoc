using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBanKhoaHoc.Entities;
using BusinessLayer.Service;
using BusinessLayer;

namespace WebBanKhoaHoc.Admin.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonHangController : ControllerBase
    {
        private BusinessLayer.BLL.DonHangBLL BLL;

        public DonHangController()
        {
            BLL = new BusinessLayer.BLL.DonHangBLL();

        }

        [Route("TaoDonHang")]
        [HttpPost]
        public bool Create(List<DangKyKhoaHoc> ListCTDH, int makh, bool tinhtrang, decimal tongtien)
        {
            BLL.Create(ListCTDH, makh, tinhtrang, tongtien);
            return true;
        }

        [Route("SuaDonHang")]
        [HttpPost]
        public bool Update(List<DangKyKhoaHoc> ListCTDH, int mahd, int us, bool tinhtrang, double totalBefore)
        {
            return BLL.Update(ListCTDH, us, mahd, tinhtrang, totalBefore);
        }

        [Route("XoaDonHang")]
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
