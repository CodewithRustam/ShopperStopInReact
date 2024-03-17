using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopperStopInReact_Shared.OTPGenerate
{
    public class GenerateOTP
    {
        public (string otp, DateTime expirationTime) GenerateOtp()
        {
            Random random = new Random();
            int otpValue = random.Next(100000, 999999);

            // Set the expiration time to 1 minute from now
            DateTime expirationTime = DateTime.Now.AddMinutes(1);

            // Concatenate the OTP and expiration time as a string
            string otp = otpValue.ToString();

            return (otp, expirationTime);
        }

    }
}
