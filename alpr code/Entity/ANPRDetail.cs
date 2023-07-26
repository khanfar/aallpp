using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANPR_General.Entity
{
    public class ANPRDetail
    {
        public int ANPR_Id;
        public string ANPR_NumberPlate;
        public DateTime ANPR_Date;
        public DateTime ANPR_Time;
        public int vhc_Id;
        public int vhc_ListCode;
        public int Cam_Id;
        public string App_Code;
        public string Pic_Path;
        public string Pic_Path_HD;
        public string Web_Path;
        public double Confidence_Level;
        public DateTime CreatedOn;
    }
}
