using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RESTServiceRequestor
{
    public class SessionRequest : BaseRequest
    {
        public SessionRequest(string apiURL, string userToken, string applicationGUID)
        {
            this._apiURL = apiURL;
            this.RestClient = new RestClient(apiURL);
            base.SetHeaders(userToken, applicationGUID);
        }

        public RESTDataEntities.APIResponse<RESTDataEntities.UserSession> Get()
        {
            var response = new RESTDataEntities.APIResponse<RESTDataEntities.UserSession>();

            try
            {
                var code = this.RestClient.SetPath("api/Session").GetRequest();

                response = JsonConvert.DeserializeObject<RESTDataEntities.APIResponse<RESTDataEntities.UserSession>>(code);
            }
            catch (Exception ex)
            {
                return ex.Handle(response);
            }

            return response;
        }

        public RESTDataEntities.APIResponse<RESTDataEntities.UserSession> Verify()
        {
            var response = new RESTDataEntities.APIResponse<RESTDataEntities.UserSession>();

            try
            {
                var code = this.RestClient.SetPath("api/Session/Verify").GetRequest();

                response = JsonConvert.DeserializeObject<RESTDataEntities.APIResponse<RESTDataEntities.UserSession>>(code);
            }
            catch (Exception ex)
            {
                return ex.Handle(response);
            }

            return response;
        }
    }
}
