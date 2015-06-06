using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGenAlgorithmLib
{
    public class ParameterDelegate
    {
        public string name { get; private set; }
        public object value { get; set; }
        public Type type { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameterValue">The value to send to the ImageTransformer instance.</param>
        /// <returns>True if the value was accepted.</returns>
        public delegate bool commitParameter(object parameterValue);
        private commitParameter opToPerform;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pName">Name of the parameter. Visible to user in GUI.</param>
        /// <param name="pValue">Default value of the parameter.</param>
        /// <param name="pType">Expected type of the parameter. GUI uses this to create the correct control.</param>
        /// <param name="pOpToPerform">The delegate that attempts to set the value on the ImageTransformer instance. Returns false if the value is outside accepted parameters.</param>
        public ParameterDelegate(string pName, object pValue, Type pType, commitParameter pOpToPerform)
        {
            this.name = pName;
            this.value = pValue;
            this.type = pType;
            this.opToPerform = pOpToPerform;
        }

        public bool commit(object pValue)
        {
            this.value = pValue;
            return opToPerform(value);
        }

        public bool commit()
        {
            return opToPerform(value);
        }
    }
}
