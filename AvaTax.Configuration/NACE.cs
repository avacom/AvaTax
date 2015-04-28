using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaTax.Configuration
{
    /// <summary>
    /// Represents the NACE (КВЕД) object
    /// </summary>
    public class NACE
    {
        string number;
        string description;

        /// <summary>
        /// Create the instance of NACE
        /// </summary>
        /// <param name="number">NACE number</param>
        /// <param name="description">NACE description</param>
        public NACE(string number, string description)
        {
            this.number = number;
            this.description = description;
        }

        /// <summary>
        /// Create the empty instance of NACE
        /// </summary>
        public NACE()
        {
            this.number = string.Empty;
            this.description = string.Empty;
        }

        /// <summary>
        /// Get or set the NACE number
        /// </summary>
        public string Number
        {
            get { return number; }
            set { number = value; }
        }

        /// <summary>
        /// Get or set the NACE description
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
