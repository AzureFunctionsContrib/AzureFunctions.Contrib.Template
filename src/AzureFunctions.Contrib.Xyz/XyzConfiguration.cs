using Microsoft.Azure.WebJobs.Host.Config;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AzureFunctions.Contrib.Xyz
{
    /// <summary>
    /// Extension for binding <see cref="XyzItem"/>
    /// </summary>
    public class XyzConfiguration : IExtensionConfigProvider
    {
        public void Initialize(ExtensionConfigContext context)
        {
            context.AddConverter<JObject, XyzItem>(input => input.ToObject<XyzItem>());
            context.AddBindingRule<XyzAttribute>()                
                .BindToCollector<XyzItem>(attr => new XyzAsyncCollector(this, attr));
        }        
    }
}
