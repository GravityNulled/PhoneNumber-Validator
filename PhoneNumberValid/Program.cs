using Colorful;
using Newtonsoft.Json;
using PhoneNumbers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Console = Colorful.Console;

namespace PhoneNumberValid
{
    internal class Program
    {
        private static int _gen;
        private static int _hits;
        private static int _errors = 0;
        private static int _bad;

        private static readonly Random Rdm = new Random();

        private static void Main(string[] args)
        {
            
            var font = FigletFont.Load("doom.flf");
            var figlet = new Figlet(font);

            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Console.Title =
                        $"Phone Number Generator | Generated  {_gen} | Hits {_hits} | Bad {_bad} | Errors {_errors}";
                    Thread.Sleep(1000);
                }
            });
            Console.WriteLine(figlet.ToAscii("Phone Number Gen"), Color.Gold);
            Console.WriteLine("                                            Phone Number Gen", Color.Gold);
            Console.WriteLine("                                          Project by Noxy#7878", Color.Gold);

            Console.Write("Enter the Country Dial Code: ", Color.DeepSkyBlue);
            var countryDialCode = Console.ReadLine();
            Console.Write("Enter Amount to Generate: ", Color.BlueViolet);
            var amount = Console.ReadLine();
            JsonDec(countryDialCode, Convert.ToInt16(amount));
 
            #region Obsolute

            //GenerateJsonFile();
            //var phoneNumberUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();
            //var phoneA = phoneNumberUtil.Parse("+385-975-555-405", null);
            //var valid = phoneNumberUtil.IsValidNumber(phoneA); // Check if the No if valid
            ////var countryCode = phoneNumberUtil.GetCountryCodeForRegion("KE"); //From User (KE) or Code
            //var geo = PhoneNumberOfflineGeocoder.GetInstance();
            //var description = geo.GetDescriptionForNumber(phoneA, Locale.English);
            //Console.WriteLine(description);
            //Console.WriteLine(phoneNumberUtil.ge);
            //JsonDec();
            //Console.WriteLine(PhoneNumber("+1")); // Generate Numbers
            // GenUSNumber("Alabama");

            #endregion

            Thread.Sleep(-1);
        }

        private static int GenUsNumber(string state)
        {
            //Console.Write("Enter the state: ");
            //var code = Console.ReadLine();
            var webclient = new WebClient();
            var jsonFile = webclient.DownloadString(
                "https://gist.githubusercontent.com/rkorkosz/11f16ce6493abf950e67/raw/db8ece30dc00695d46da86459a68f728f3083b3a/us_area_codes.json");
            var c = JsonConvert.DeserializeObject<Usa>(jsonFile);
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

        private static void JsonDec(string countryDialCode, int genAmount)
        {
            Parallel.For(0, genAmount, new ParallelOptions { MaxDegreeOfParallelism = 1 }, t =>
              {
                  var url = new WebClient();
                  var webApi = url.DownloadString(
                      "https://cdn.discordapp.com/attachments/480880918861578250/944203858702381056/countries.json");
                  var codes = JsonConvert.DeserializeObject<List<Codes>>(webApi);
                  foreach (var code in codes)
                      if (code.Code == countryDialCode) //From user
                          if (code.Size != "" && code.Prefix != "")
                          {
                              var random = new Random();
                              var chosen = random.Next(code.Prefix.Split(',').Length);
                              var inPrefix = code.Prefix.Split(',')[chosen];

                              var total = Convert.ToInt16(code.Size);
                              var numWithPrefix = countryDialCode + inPrefix;
                              var amountToGen = total - Convert.ToInt16(inPrefix.Length);
                              var phoneNumber = PhoneNumber(numWithPrefix, amountToGen); //From user
                              var phoneNumberUtil = PhoneNumberUtil.GetInstance();
                              var phoneA = phoneNumberUtil.Parse(phoneNumber, null);
                              var valid = phoneNumberUtil.IsValidNumber(phoneA); // Check if the No if valid
                              if (valid)
                              {
                                  Interlocked.Increment(ref _hits);
                                  var geo = PhoneNumberOfflineGeocoder.GetInstance();
                                  var description = geo.GetDescriptionForNumber(phoneA, Locale.English);
                                  Console.WriteLine($"{phoneNumber} - {description} - Working", Color.Aqua);
                              a:
                                  try
                                  {
                                      using (var sr = new StreamWriter($"PhoneNumbers {countryDialCode}.txt", true))
                                      {
                                          sr.WriteLine($"{phoneNumber} - {description}");
                                      }
                                  }
                                  catch
                                  {
                                      Interlocked.Increment(ref _errors);
                                      Thread.Sleep(100);
                                      goto a;
                                  }
                              }
                              else
                              {
                                  Interlocked.Increment(ref _bad);
                                  Console.WriteLine($"{phoneNumber} - Invalid", Color.Crimson);
                              }

                              Interlocked.Increment(ref _gen);
                          }

                          else if (code.Size == "" && code.Prefix != "")
                          {
                              var inPrefix = code.Prefix.Split(',')[0];
                              var pluSign = countryDialCode; // From user
                              var removedPlus = pluSign.Split('+')[1];

                              var amountToGen =
                                  12 - Convert.ToInt16(removedPlus.Length + inPrefix.Length); //Amount to generate

                              var numWithPrefix = countryDialCode + inPrefix;
                              var phoneNumber = PhoneNumber(numWithPrefix, amountToGen); //From user

                              //Number Validation
                              var phoneNumberUtil = PhoneNumberUtil.GetInstance();
                              var phoneA = phoneNumberUtil.Parse(phoneNumber, null);
                              var valid = phoneNumberUtil.IsValidNumber(phoneA); // Check if the No if valid
                              if (valid)
                              {
                                  Interlocked.Increment(ref _hits);
                                  var geo = PhoneNumberOfflineGeocoder.GetInstance();
                                  var description = geo.GetDescriptionForNumber(phoneA, Locale.English);
                                  Console.WriteLine($"{phoneNumber} - {description} - Working", Color.Aqua);
                              a:
                                  try
                                  {
                                      using (var sr = new StreamWriter($"PhoneNumbers {countryDialCode}.txt", true))
                                      {
                                          sr.WriteLine($"{phoneNumber} - {description}");
                                      }
                                  }
                                  catch
                                  {
                                      Interlocked.Increment(ref _errors);
                                      Thread.Sleep(100);
                                      goto a;
                                  }
                              }
                              else
                              {
                                  Interlocked.Increment(ref _bad);
                                  Console.WriteLine($"{phoneNumber} - Invalid", Color.Crimson);
                              }

                              Interlocked.Increment(ref _gen);
                          }
                          else if (code.Size == "" && code.Prefix == "")
                          {
                              var inPrefix = code.Prefix.Split(',')[0];
                              var pluSign = countryDialCode; // From user
                              var removedPlus = pluSign.Split('+')[1];
                              var amountToGen =
                                  12 - Convert.ToInt16(removedPlus.Length + inPrefix.Length); //Amount to generate

                              var numWithPrefix = countryDialCode + inPrefix;
                              var phoneNumber = PhoneNumber(numWithPrefix, amountToGen); //From user


                              //Number Validation
                              var phoneNumberUtil = PhoneNumberUtil.GetInstance();
                              var phoneA = phoneNumberUtil.Parse(phoneNumber, null);
                              var valid = phoneNumberUtil.IsValidNumber(phoneA); // Check if the No if valid
                              if (valid)
                              {
                                  Interlocked.Increment(ref _hits);
                                  var geo = PhoneNumberOfflineGeocoder.GetInstance();
                                  var description = geo.GetDescriptionForNumber(phoneA, Locale.English);
                                  Console.WriteLine($"{phoneNumber} - {description} - Working", Color.Aqua);
                              a:
                                  try
                                  {
                                      using (var sr = new StreamWriter($"PhoneNumbers {countryDialCode}.txt", true))
                                      {
                                          sr.WriteLine($"{phoneNumber} - {description}");
                                      }
                                  }
                                  catch
                                  {
                                      Interlocked.Increment(ref _errors);
                                      Thread.Sleep(100);
                                      goto a;
                                  }
                              }
                              else
                              {
                                  Interlocked.Increment(ref _bad);
                                  Console.WriteLine($"{phoneNumber} - Invalid", Color.Crimson);
                              }

                              Interlocked.Increment(ref _gen);
                          }
                          else if (code.Prefix == "" && code.Size != "")
                          {
                              var inPrefix = code.Prefix.Split(',')[0];
                              var pluSign = countryDialCode; // From user
                              var removedPlus = pluSign.Split('+')[1];
                              var amountToGen =
                                  12 - Convert.ToInt16(removedPlus.Length + inPrefix.Length); //Amount to generate


                              var numWithPrefix = countryDialCode + inPrefix;
                              var phoneNumber = PhoneNumber(numWithPrefix, amountToGen); //From user

                              //Number Validation
                              var phoneNumberUtil = PhoneNumberUtil.GetInstance();
                              var phoneA = phoneNumberUtil.Parse(phoneNumber, null);
                              var valid = phoneNumberUtil.IsValidNumber(phoneA); // Check if the No if valid
                              if (valid)
                              {
                                  Interlocked.Increment(ref _hits);
                                  var geo = PhoneNumberOfflineGeocoder.GetInstance();
                                  var description = geo.GetDescriptionForNumber(phoneA, Locale.English);
                                  Console.WriteLine($"{phoneNumber} - {description} - Working", Color.Aqua);
                              a:
                                  try
                                  {
                                      using (var sr = new StreamWriter($"PhoneNumbers {countryDialCode}.txt", true))
                                      {
                                          sr.WriteLine($"{phoneNumber} - {description}");
                                      }
                                  }
                                  catch
                                  { 
                                      Interlocked.Increment(ref _errors);
                                      Thread.Sleep(100);
                                      goto a;
                                  }
                              }
                              else
                              {
                                  Interlocked.Increment(ref _bad);
                                  Console.WriteLine($"{phoneNumber} - Invalid", Color.Crimson);
                              }

                              Interlocked.Increment(ref _gen);
                          }
              });
            Console.WriteLine("                                            Generating Done", Color.Gold);

        }

        private static string PhoneNumber(string code, int digits)
        {
            a: try
            {
                var min = (int)Math.Pow(10, 10 - Convert.ToInt16(digits));
                var max = (int)Math.Pow(10, Convert.ToInt16(digits)) - 1;
                return code + Rdm.Next(min, max);
            }
            catch
            {
                Interlocked.Increment(ref _errors);
                goto a;
            }
        }

        #region webLink

        //private static void GenerateJsonFile()
        // {
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

        #endregion
    }
}