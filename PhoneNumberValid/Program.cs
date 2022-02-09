using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            var phoneA = phoneNumberUtil.Parse("+385-975-555-405", null);
            var x = phoneNumberUtil.IsValidNumber(phoneA); // Check if the No if valid
            //var countryCode = phoneNumberUtil.GetCountryCodeForRegion("KE"); //From User (KE) or Code
            var geo = PhoneNumberOfflineGeocoder.GetInstance();
            var description = geo.GetDescriptionForNumber(phoneA, Locale.English);
            Console.WriteLine(description);
            //Console.WriteLine(phoneNumberUtil.ge);
            //JsonDec();
            Console.WriteLine(PhoneNumber("+1"));
            GenUSNumber("Alabama");
            Thread.Sleep(-1);
        }

        static int GenUSNumber(string state)
        {
            //Console.Write("Enter the state: ");
            //var code = Console.ReadLine();
            var webclient = new WebClient();
            var jsonFile = webclient.DownloadString("https://gist.githubusercontent.com/rkorkosz/11f16ce6493abf950e67/raw/db8ece30dc00695d46da86459a68f728f3083b3a/us_area_codes.json");
            var c = JsonConvert.DeserializeObject<USA>(jsonFile);
            var s = c.Alabama[0];
            Console.WriteLine(s);
            //foreach (var stateUsa in c)
            //{
            //    if (stateUsa == "Alabama")
            //    {

            //    }
            //}
            return 1;
        }

        private static void JsonDec()
        {
            var url = new WebClient();
            var x = url.DownloadString(
                "https://gist.githubusercontent.com/Goles/3196253/raw/9ca4e7e62ea5ad935bb3580dc0a07d9df033b451/CountryCodes.json");
            var country = JsonConvert.DeserializeObject<List<Countries>>(x);
            foreach (var countriese in country)
            {
                if (countriese.name == "Kenya")
                {
                    Console.WriteLine(countriese.dial_code);
                }
            }
        }
        private static readonly Random _rdm = new Random();
        private static string PhoneNumber(string code)
        {

            var _min = (int)Math.Pow(10, 10 - 1);
            var _max = (int)Math.Pow(10, 10) - 1;
            return code + _rdm.Next(_min, _max).ToString();
            
        }
    }
}
