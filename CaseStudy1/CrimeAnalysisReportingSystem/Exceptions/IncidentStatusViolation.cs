using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeAnalysisReportingSystem.Exceptions
{
    public class IncidentStatusViolation:ApplicationException
    {
        public IncidentStatusViolation(string message):base(message)
        {
            
        }
    }
}
