using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PhoneNumbers;

namespace PhoneNumberValid
{
    class Program
    {
        static void Main(string[] args)
        {
            var phoneNumberUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();
            var phoneA = phoneNumberUtil.Parse("+254720179 897", "US");
            var x = phoneNumberUtil.IsValidNumber(phoneA);
            var countryCode = phoneNumberUtil.GetCountryCodeForRegion("KE");
            Console.WriteLine(x);
            Thread.Sleep(-1);
        }
    }
}
