using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Description;

namespace AzureFunctions.Contrib.Xyz
{
    /// <summary>
    /// Attribute for 
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    [Binding]
    public class XyzAttribute : Attribute
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public XyzAttribute()
        {
        }


        /// <summary>
        /// Text       
        /// </summary>
        [AutoResolve]
        public string Text { get; set; }
    }
}
