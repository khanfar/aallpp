using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANPR_General.Entity
{
    public class ShellyRelayControl
    {
    }

    public class Data
    {
        public string device_id { get; set; }
    }

    public class RootData
    {
        public bool isok { get; set; }
        public Data data { get; set; }
    }

    public class ControlBody
    {
        public string id { get; set; }
        public string auth_key { get; set; }
        public int channel { get; set; }
        public string turn { get; set; }
    }



}
