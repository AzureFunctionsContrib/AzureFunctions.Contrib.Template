using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AzureFunctions.Contrib.Xyz
{
    /// <summary>
    /// Template payload
    /// </summary>
    public class XyzItem
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public XyzItem()
        {

        }


        /// <summary>
        /// Text
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
