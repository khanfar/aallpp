using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ANPR_General.Entity;

namespace ANPR_General.Services
{
    public  class SystemSetting
    {

        public CaptureSetting CaptureSetting()
        {
            CaptureSetting c = new CaptureSetting();

            try
            {
                DAL dal = new DAL();

                DataSet ds = new DataSet();

                ds = dal.Read_CaptureSetting();

                int MinNPLength = 0;
                int MaxNPLength = 0;

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    c.AccuracyLevel = Convert.ToDouble(dr["AccuracyLevel"].ToString());
                    c.MinNPLength = Convert.ToInt16(dr["MinNPLength"].ToString());
                    c.MaxNPLength = Convert.ToInt16(dr["MaxNPLength"].ToString());
                    c.MotionFrameNo = Convert.ToInt16(dr["MotionFrame"].ToString());
                }

            }
            catch(Exception ex1)
            {
                MessageBox.Show(ex1.Message);
            }

            return c;
        }
    }
}
