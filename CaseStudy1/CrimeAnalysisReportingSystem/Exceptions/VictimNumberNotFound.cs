using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeAnalysisReportingSystem.Exceptions
{
    internal class VictimNumberNotFound:ApplicationException
    {
        public VictimNumberNotFound(string msg) : base(msg) 
        {
            
        }
    }
}
