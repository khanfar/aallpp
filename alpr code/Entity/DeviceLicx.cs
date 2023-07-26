using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANPR_General.Entity
{
    public class DeviceLicx
    {

        public string CustCode;
        public string MacAddress;
        public string MachineName;

        public string ExpDate;
        public string CurrSysDate;
        public string CurrServerDate;

        public int? ExpHours { get; set; } = 0;
        public int? ActivateHours { get; set; } = 0;
        public int? SpendHours { get; set; } = 0;
        public int? ChanelNo { get; set; } = 0;

        public string LastActivationDate; 
        public int? IsActivated { get; set; } = 0;
        public int? ActivationType { get; set; } = 0; // 1 for Online 2 for Offline
        public string message;
        
    }
}
