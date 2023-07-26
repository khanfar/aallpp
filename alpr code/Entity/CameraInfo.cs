using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANPR_General.Entity
{
    public class CameraInfo
    {
        public int CamId;
        public string CamName;
        public int CamDirectionCode;
        public string CamDirection;
        public string CamStreamURL;
        public string CamIP;
        public string UserID;
        public string Password;
        public int ThersholdSeconds;
        public bool CamEnable;
        public bool isRecording;
        public DateTime CreatedOn;
        public int ResolutWidth;
        public int ResolutHeight;
        public string RecordingPath;
        public string ANPRImagePath;
        public int RecordingDeleteHours;
    }
}
