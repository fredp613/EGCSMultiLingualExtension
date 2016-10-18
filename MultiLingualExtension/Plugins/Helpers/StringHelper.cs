using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;

namespace Helpers
{
   
    class StringHelper
    {
        
        public StringHelper()
        {        
        }

        private int getValueLength(string value) {            
            return value.Length;
        }

        public string concatenateAfterCalc(string value1, string value2, int maxLength, string seperator)
        {          
            int totalLength = value1.Length + value2.Length + seperator.Length;
            
            //FaultException ex1 = new FaultException();
            //throw new InvalidPluginExecutionException(maxLength.ToString() + "-" + totalLength.ToString(), ex1);
            if (totalLength > maxLength)
            {
                int lengthForString = (maxLength / 2) - 9;
                
                string firstPart;
                string secondPart;
                if (value1.Length < lengthForString) {
                    firstPart = value1; 
                } else {
                    firstPart = (value1.Substring(0, lengthForString) + "..."); 
                }

                if (value2.Length < lengthForString)
                {
                    secondPart = value2;
                }
                else
                {
                    secondPart = (value2.Substring(0, lengthForString) + "...");
                }

                
                return firstPart + seperator + secondPart;                
            }

          
            return value1 + seperator + value2;
        }
    }
}
