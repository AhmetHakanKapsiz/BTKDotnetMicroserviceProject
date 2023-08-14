using BtkAkademi.Service.CouponAPI.Models.Dto;

namespace BtkAkademi.Service.CouponAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCouponByCode(string couponCode);
    }
}
