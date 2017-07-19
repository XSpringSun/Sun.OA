using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sun.OA.Common
{
    public class log4netWriter : ILogWriter
    {
        public void WriteLogInfo(string txt)
        {
            ILog logWriter = LogManager.GetLogger("systemLog");
            logWriter.Error(txt);
        }
    }
}
