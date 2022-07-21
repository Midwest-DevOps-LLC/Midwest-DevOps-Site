using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RESTServiceRequestor
{
    public class RegistrationRequestor : BaseRequest
    {
        public RegistrationRequestor(string apiURL, string userToken, string applicationGUID)
        {
            this._apiURL = apiURL;
            this.RestClient = new RestClient(apiURL);
            base.SetHeaders(userToken, applicationGUID);
        }

        public RESTDataEntities.APIResponse<RESTDataEntities.RegistrationResponse> Login(RESTDataEntities.RegisterRequest request)
        {
            var response = new RESTDataEntities.APIResponse<RESTDataEntities.RegistrationResponse>();

            try
            {
                var code = this.RestClient.SetPath("api/Registration").PostRequest(JsonConvert.SerializeObject(request));

                response = JsonConvert.DeserializeObject<RESTDataEntities.APIResponse<RESTDataEntities.RegistrationResponse>>(code);
            }
            catch (Exception ex)
            {
                return ex.Handle(response);
            }

            return response;
        }
    }
}
