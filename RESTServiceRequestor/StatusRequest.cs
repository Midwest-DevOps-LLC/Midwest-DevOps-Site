using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RESTServiceRequestor
{
    public class StatusRequest : BaseRequest
    {
        public StatusRequest(string apiURL, string userToken)
        {
            this._apiURL = apiURL;
            //this._userSession = this._userSession ?? new RESTDataEntities.UserSession() { Token = userToken };
            this.RestClient = new RestClient(apiURL);
            this.RestClient.Headers.Add("Authorization", userToken);
        }

        public RESTDataEntities.APIResponse<HttpStatusCode> Status()
        {
            var response = new RESTDataEntities.APIResponse<HttpStatusCode>();

            try
            {
                var code = this.RestClient.SetPath("api/Status").GetStatus();

                response.Data = code;
            }
            catch (Exception ex)
            {
                return ex.Handle(response);
            }

            return response;
        }
    }
}
