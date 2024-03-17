using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopperStopInReact_Shared.ViewModel.Customer
{
    public class LoginViewModel
    {
        public string? EmailOrMobile { get; set; }
        public string? Password { get; set; }
        public string? Mobile { get; set; }
        public string? OTP { get; set; }
        public bool UseOTP { get; set; }
        public bool OTPRequested { get; set; } = false;
    }
}
