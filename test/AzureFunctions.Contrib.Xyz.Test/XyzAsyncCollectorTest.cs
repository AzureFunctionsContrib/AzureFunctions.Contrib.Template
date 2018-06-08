using AzureFunctions.Contrib.Xyz;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AzureFunctions.Contrib.SignalR.Test
{
    /// <summary>
    /// Tests <see cref="XyzAsyncCollector"/>
    /// </summary>
    public class XyzAsyncCollectorTest
    {
        [Fact]
        public async Task Setting_FunctionScopeValue_UsesFunctionScopeValue()
        {
            var config = new XyzConfiguration()
            {
            };

            var attr = new XyzAttribute()
            {
            };

            var outputContent = new StringBuilder();
            var output = new StringWriter(outputContent);
            

            var target = new XyzAsyncCollector(config, attr, output);

            await target.AddAsync(new XyzItem()
            {
                Text = "From Item"
            });
            await target.FlushAsync();

            Assert.Equal("From Item", outputContent.ToString());
        }

        [Fact]
        public async Task NotSetting_FunctionScopeValue_UsesAttributeScopeValue()
        {
            var config = new XyzConfiguration()
            {
            };

            var attr = new XyzAttribute()
            {
                Text = "From Attribute"
            };

            var outputContent = new StringBuilder();
            var output = new StringWriter(outputContent);


            var target = new XyzAsyncCollector(config, attr, output);

            await target.AddAsync(new XyzItem());
            await target.FlushAsync();

            Assert.Equal("From Attribute", outputContent.ToString());
        }
    }
}
