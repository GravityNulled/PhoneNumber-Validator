using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PhoneNumberValid
{
    class USA
    {
        public List<int> Mississippi { get; set; }

        public List<int> NorthernMarianaIslands { get; set; }
        public List<int> Oklahoma { get; set; }
        public List<int> Delaware { get; set; }
        public List<int> Minnesota { get; set; }
        public List<int> Illinois { get; set; }
        public List<int> Arkansas { get; set; }

        [JsonProperty("New Mexico")]
        public List<int> NewMexico { get; set; }
        public List<int> Indiana { get; set; }
        public List<int> Maryland { get; set; }
        public List<int> Louisiana { get; set; }
        public List<int> Idaho { get; set; }
        public List<int> Wyoming { get; set; }
        public List<int> Tennessee { get; set; }
        public List<int> Arizona { get; set; }
        public List<int> Iowa { get; set; }
        public List<int> Michigan { get; set; }
        public List<int> Kansas { get; set; }
        public List<int> Utah { get; set; }

        [JsonProperty("American Samoa")]
        public List<int> AmericanSamoa { get; set; }
        public List<int> Oregon { get; set; }
        public List<int> Connecticut { get; set; }
        public List<int> Montana { get; set; }
        public List<int> California { get; set; }
        public List<int> Massachusetts { get; set; }

        [JsonProperty("Puerto Rico")]
        public List<int> PuertoRico { get; set; }

        [JsonProperty("South Carolina")]
        public List<int> SouthCarolina { get; set; }

        [JsonProperty("New Hampshire")]
        public List<int> NewHampshire { get; set; }
        public List<int> Wisconsin { get; set; }
        public List<int> Vermont { get; set; }
        public List<int> Georgia { get; set; }

        [JsonProperty("North Dakota")]
        public List<int> NorthDakota { get; set; }
        public List<int> Pennsylvania { get; set; }

        [JsonProperty("West Virginia")]
        public List<int> WestVirginia { get; set; }
        public List<int> Florida { get; set; }
        public List<int> Hawaii { get; set; }
        public List<int> Kentucky { get; set; }
        public List<int> Alaska { get; set; }
        public List<int> Nebraska { get; set; }
        public List<int> Missouri { get; set; }
        public List<int> Ohio { get; set; }
        public List<int> Alabama { get; set; }

        [JsonProperty("Rhode Island")]
        public List<int> RhodeIsland { get; set; }

        [JsonProperty("Washington, DC")]
        public List<int> WashingtonDC { get; set; }

        [JsonProperty("Virgin Islands")]
        public List<int> VirginIslands { get; set; }

        [JsonProperty("South Dakota")]
        public List<int> SouthDakota { get; set; }
        public List<int> Colorado { get; set; }

        [JsonProperty("New Jersey")]
        public List<int> NewJersey { get; set; }
        public List<int> Virginia { get; set; }
        public List<int> Guam { get; set; }
        public List<int> Washington { get; set; }

        [JsonProperty("North Carolina")]
        public List<int> NorthCarolina { get; set; }

        [JsonProperty("New York")]
        public List<int> NewYork { get; set; }
        public List<int> Texas { get; set; }
        public List<int> Nevada { get; set; }
        public List<int> Maine { get; set; }
    }
}
