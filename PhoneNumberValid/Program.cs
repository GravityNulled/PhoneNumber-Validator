using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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
            //GenerateJsonFile();
            Console.Write("Enter the Country Dial Code: ");
            var countryDialCode = Console.ReadLine();
            JsonDec(countryDialCode);
            var phoneNumberUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();
            var phoneA = phoneNumberUtil.Parse("+385-975-555-405", null);
            var x = phoneNumberUtil.IsValidNumber(phoneA); // Check if the No if valid
            //var countryCode = phoneNumberUtil.GetCountryCodeForRegion("KE"); //From User (KE) or Code
            var geo = PhoneNumberOfflineGeocoder.GetInstance();
            var description = geo.GetDescriptionForNumber(phoneA, Locale.English);
            //Console.WriteLine(description);
            //Console.WriteLine(phoneNumberUtil.ge);
            //JsonDec();
            //Console.WriteLine(PhoneNumber("+1")); // Generate Numbers
           // GenUSNumber("Alabama");
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

        private static void JsonDec(string countryDialCode)
        {
            var url = new WebClient();
            var x = url.DownloadString(
                "https://cdn.discordapp.com/attachments/480880918861578250/941262058656247828/countries.json");
            var codes = JsonConvert.DeserializeObject<List<Codes>>(x);
            foreach (var code in codes)
            {

                if (code.code == countryDialCode) //From user
                {
                   
                    if (code.size != "" && code.prefix != "")
                    {
                        var inPrefix = code.prefix.Split(',')[0];
                        var total = Convert.ToInt16(code.size);
                        var numWithPrefix = countryDialCode + inPrefix;
                        var amountToGen = total - Convert.ToInt16(inPrefix.Length);
                        var phoneNumber = PhoneNumber(numWithPrefix, amountToGen); //From user
                        Console.WriteLine(phoneNumber);
                    }

                    else if(code.size == "" && code.prefix != "")
                    {
                        var inPrefix = code.prefix.Split(',')[0];
                        var pluSign = countryDialCode; // From user
                        var removedPlus = pluSign.Split('+')[1];

                        var amountToGen = 12 - Convert.ToInt16(removedPlus.Length + inPrefix.Length);  //Amount to generate

                        var numWithPrefix = countryDialCode + inPrefix;
                        var phoneNumber = PhoneNumber(numWithPrefix, amountToGen); //From user
                        Console.WriteLine(phoneNumber);
                        Console.WriteLine(phoneNumber.Length);
                        
                    }
                    else if (code.size == "" && code.prefix == "")
                    {
                        var inPrefix = code.prefix.Split(',')[0];
                        var pluSign = countryDialCode; // From user
                        var removedPlus = pluSign.Split('+')[1];
                        var amountToGen = 12 - Convert.ToInt16(removedPlus.Length + inPrefix.Length);  //Amount to generate

                        var numWithPrefix = countryDialCode + inPrefix;
                        var phoneNumber = PhoneNumber(numWithPrefix, amountToGen); //From user
                        Console.WriteLine(phoneNumber);

                    }
                    else if (code.prefix == "" && code.size != "")
                    {
                        var inPrefix = code.prefix.Split(',')[0];
                        var pluSign = countryDialCode; // From user
                        var removedPlus = pluSign.Split('+')[1];
                        var amountToGen = 12 - Convert.ToInt16(removedPlus.Length + inPrefix.Length);  //Amount to generate

                        var numWithPrefix = countryDialCode + inPrefix;
                        var phoneNumber = PhoneNumber(numWithPrefix, amountToGen); //From user
                        Console.WriteLine(phoneNumber);
                        Console.WriteLine(phoneNumber.Length);

                    }
                    Console.WriteLine(code.size);
                }
                
            }

        }
        private static readonly Random _rdm = new Random();
        private static string PhoneNumber(string code, int digits)
        {

            var _min = (int)Math.Pow(10, 10 - Convert.ToInt16(digits));
            var _max = (int)Math.Pow(10, Convert.ToInt16(digits)) - 1;
            return code + _rdm.Next(_min, _max).ToString();
            
        }

        //private static void GenerateJsonFile()
        //{
        //    var wb = new WebClient();
        //    var rawData = wb.DownloadString("https://phone-number-generator.datagemba.com/kenya");
        //    //Console.WriteLine(rawData);
        //    Regex rg = new Regex("<option value='(.*?)' data-slug=");
        //    var matches = rg.Matches(rawData);
        //    foreach (Match match in matches)
        //    {
        //        string countryInfo = match.Groups[1].Value + ",";
        //        Console.Write(countryInfo);
        //        using (var sr = new StreamWriter("CountriesJson.txt", true))
        //        {
        //            sr.Write(countryInfo);
        //        }
        //        //StreamWriter sr = new StreamWriter("Codes.txt", true);
        //        Console.WriteLine("Json Writing completed!");
        //    }


        //}
        //private static void ClassTest()
        //{
        //    var url = new WebClient();
        //    var x = url.DownloadString(
        //        "https://cdn.discordapp.com/attachments/480880918861578250/941246755763286046/countries.json");
        //    var codes = JsonConvert.DeserializeObject<List<Codes>>(x);
        //    foreach (var code in codes)
        //    {
        //        Console.WriteLine(code.name);
        //    }
        //}
    }
}
