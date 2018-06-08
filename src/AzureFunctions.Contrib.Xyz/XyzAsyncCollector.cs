using Microsoft.Azure.WebJobs;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AzureFunctions.Contrib.Xyz
{

    /// <summary>
    /// Collector for <see cref="XyzItem"/>
    /// </summary>
    public class XyzAsyncCollector : IAsyncCollector<XyzItem>
    {
        private readonly XyzConfiguration config;
        private readonly XyzAttribute attr;
        private readonly TextWriter output;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="config"></param>
        /// <param name="attr"></param>
        public XyzAsyncCollector(XyzConfiguration config, XyzAttribute attr) : this(config, attr, System.Console.Out)
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="config"></param>
        /// <param name="attr"></param>
        public XyzAsyncCollector(XyzConfiguration config, XyzAttribute attr, TextWriter output) 
        {
            this.config = config;
            this.attr = attr;
            this.output = output;            
        }

        /// <inheritdoc />
        public async Task AddAsync(XyzItem item, CancellationToken cancellationToken = default(CancellationToken))
        {
            var mergedItem = MergeMessageProperties(item, config, attr);

            if (string.IsNullOrEmpty(mergedItem.Text))
                throw new InvalidOperationException($"Missing text");
           
            await ProcessItem(mergedItem, attr, cancellationToken);
        }

        /// <inheritdoc />
        public Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Combine <see cref="XyzItem"/> with <see cref="XyzConfiguration"/> and <see cref="XyzAttribute"/>
        /// </summary>
        /// <param name="item"></param>
        /// <param name="config"></param>
        /// <param name="attr"></param>
        /// <returns></returns>
        private static XyzItem MergeMessageProperties(XyzItem item, XyzConfiguration config, XyzAttribute attr)
        {
            var result = new XyzItem
            {
                Text = Utils.MergeValueForProperty(item.Text, attr.Text),
            };
            

            return result;
        }
 
        async Task ProcessItem(XyzItem item, XyzAttribute attribute, CancellationToken cancellationToken = default(CancellationToken))
        {
            await output.WriteAsync(item.Text);

        }        
    }
}