﻿using System.ComponentModel.DataAnnotations;

namespace BtkAkademi.Service.CouponAPI.Models
{
    public class Coupon
    {
        [Key]
        public int CouponId { get; set; }
        public string CouponCode { get; set; }
        public double DiscountAmount { get; set; }
    }
}
