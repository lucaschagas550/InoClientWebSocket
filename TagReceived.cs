using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InoClientSocketTCP_3_1
{
    public class TagReceived
    {
        [JsonProperty("epc")]
        public string epc { get; set; }

        [JsonProperty("rssi")]
        public int rssi { get; set; }

        [JsonProperty("antenna")]
        public int antenna { get; set; }

        public TagReceived()
        {

        }

        public TagReceived(string epc, int antenna, int rssi)
        {
            this.epc = epc;
            this.antenna = antenna;
            this.rssi = rssi;
        }
    }
}
