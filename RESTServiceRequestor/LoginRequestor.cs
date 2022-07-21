using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace RESTServiceRequestor
{
    public class LoginRequestor : BaseRequest
    {
        public LoginRequestor(string apiURL, string userToken, string applicationGUID)
        {
            this._apiURL = apiURL;
            this.RestClient = new RestClient(apiURL);
            base.SetHeaders(userToken, applicationGUID);
        }

        public RESTDataEntities.APIResponse<RESTDataEntities.LoginResponse> Login(RESTDataEntities.LoginRequest request)
        {
            var response = new RESTDataEntities.APIResponse<RESTDataEntities.LoginResponse>();

            try
            {
                var code = this.RestClient.SetPath("api/Login").PostRequest(JsonConvert.SerializeObject(request));

                response = JsonConvert.DeserializeObject<RESTDataEntities.APIResponse<RESTDataEntities.LoginResponse>>(code);
            }
            catch (Exception ex)
            {
                return ex.Handle(response);
            }

            return response;
        }
    }
}
