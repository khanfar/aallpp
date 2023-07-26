using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANPR_General.Entity
{
    public class DeviceTrigger
    {

        public int? id { get; set; } = 0;
        public int? Cam_Id { get; set; } = 0;
        public string  Dev_Id { get; set; } = "";
        public int? Act_Id { get; set; } = 0;
        public int? Dev_RelayNo { get; set; } = 0;
        public int? Lst_Id { get; set; } = 0;

        public int? Connection_Type { get; set; } = 0;
    }
}
