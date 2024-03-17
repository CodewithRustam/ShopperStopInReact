using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopperStopInReact_Shared.Model.Customer
{
    public class OtpVerificationLog
    {
        public int OtpVerificationLogId { get; set; }
        public int UserId { get; set; }
        public string? Mobile { get; set; }
        public string? OtpCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime OTPExpireTime { get; set; }
        public bool IsVerified { get; set; }
    }
}
