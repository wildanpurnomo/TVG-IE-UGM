using _3DSimulator.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DSimulator.Util
{
    class SettingData
    {
        public static int pageIndex
        {
            get
            {
                return Settings.Default.pageIndex;
            }

            set
            {
                Settings.Default.pageIndex = value;
                Settings.Default.Save();
            }
        }
    }
}
