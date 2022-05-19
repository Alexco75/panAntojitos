
//using Microsoft;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Cors;
using System.Web.Http.Cors;

namespace Cravings.BusinessLogic
{
    public class AccessPolicyCors : Attribute, ICorsPolicyProvider, IDisposable
    {
        public void Dispose()
        {
        }

        public async Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var corsRequestContext = request.GetCorsRequestContext();
            var originRequested = corsRequestContext.Origin;

            if (await IsOriginFromCustomer(originRequested))
            {
                var policy = new CorsPolicy
                {
                    AllowAnyHeader = true,
                    AllowAnyMethod = true
                };
                policy.Origins.Add(originRequested);
                //Ip Especifica
                //policy.Origins.Add(@"http://localhost:4200/");
                return policy;
            };
            return null;
        }

        //private Task<bool> IsOriginFromCustomer(string originRequested)
        //{
        //    throw new NotImplementedException();
        //}
        private async Task<bool> IsOriginFromCustomer(string originRequested)
        {
            return true;
        }
    }
}




//var policy = null;
//public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken)
//{
//    var corsRequestContext = request.GetCorsRequestContext();
//    var originRequested = corsRequestContext.Origin;
//    if (await isOriginFromCustomer(originRequested))
//    {
//        policy = new CorsPolicy();
//        AllowAnyHeader = true;
//        AllowAnyMethod = true;

//        policy.Origins.Add(originRequested);
//        return policy;
//    }
//}
