using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AVS.CoreLib.Services.Logger;

namespace AVS.Nicehash.Infrastructure
{
    /// <summary>
    /// Represents a composite logger includes ConsoleLogger and DatabaseLogger
    /// </summary>
    public class Logger : BufferedLogger
    {
        public Logger()
        {
            AddLogger(new FileLogger());
        }
    }
}
