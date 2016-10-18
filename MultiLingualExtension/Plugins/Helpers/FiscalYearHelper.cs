using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.ServiceModel;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Discovery;
using Microsoft.Xrm.Sdk.Messages;
using System.Collections.Generic;


namespace Helpers
{
    public class FiscalYearHelper
    {
        DateTime startDate;
        DateTime endDate;
        int[] _fiscalYears;

        public FiscalYearHelper(DateTime start, DateTime end)
        {            
            this.startDate = start;
            this.endDate = end;
            
        }

        public int[] getFiscalYears()
        {
            FaultException ex1 = new FaultException();
            if (this.startDate != null && this.endDate != null)
            {
                // this is somethign we can extract in a seperate class called fiscalyears or something
                int startMonth = this.startDate.Month;
                int endMonth = this.endDate.Month;
                int startYear = this.startDate.Year;
                int endYear = this.endDate.Year;
                int numberOfYears = (endYear - startYear);

                

                if (startMonth < 4)
                {
                    if (endMonth > 4)
                    {
                        numberOfYears = numberOfYears + 2;
                        endYear = endYear + 1;
                    }
                    else
                    {
                        numberOfYears = numberOfYears + 1;
                    }
                }
                else
                {
                    startYear = startYear + 1;
                    if (endMonth > 4)
                    {
                        numberOfYears = numberOfYears + 1;
                        endYear = endYear + 1;
                    }
                }

               // throw new InvalidPluginExecutionException(numberOfYears.ToString(), ex1);

                if (numberOfYears > 1)
                {
                    _fiscalYears = new int[numberOfYears];

                    for (var i = 0; i < numberOfYears; i++)
                    {
                        _fiscalYears[i] = startYear + i;
                    }
                }
                else
                {
                    //throw new InvalidPluginExecutionException(endYear.ToString(), ex1);
                    int[] arr = new int[] {endYear};
                    return arr;

                    //throw new InvalidPluginExecutionException(_fiscalYears.ToString(), ex1);
                }
               
            }
            
            return _fiscalYears;
        }


    }
}
