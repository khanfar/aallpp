using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANPR_V1
{
    public class DataModelTest
    {

        public bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }
    }
}
