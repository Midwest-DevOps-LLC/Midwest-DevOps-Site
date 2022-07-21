using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RESTServiceRequestor
{
    public class EmployeeRequest : BaseRequest
    {
        public EmployeeRequest(string apiURL, string userToken, string applicationGUID)
        {
            this._apiURL = apiURL;
            this.RestClient = new RestClient(apiURL);
            base.SetHeaders(userToken, applicationGUID);
        }

        public RESTDataEntities.APIResponse<RESTDataEntities.Employee> Get(int employeeID)
        {
            var response = new RESTDataEntities.APIResponse<RESTDataEntities.Employee>();

            try
            {
                var code = this.RestClient.SetPath("api/Employee").GetRequest(new Dictionary<string, string>() { { "employeeID", employeeID.ToString()} });
                //var code = this.RestClient.SetPath("api/Employee").PostRequest(JsonConvert.SerializeObject(request));

                response = JsonConvert.DeserializeObject<RESTDataEntities.APIResponse<RESTDataEntities.Employee>>(code);
            }
            catch (Exception ex)
            {
                return ex.Handle(response);
            }

            return response;
        }

        public RESTDataEntities.APIResponse<List<RESTDataEntities.Employee>> GetAll(bool? active)
        {
            var response = new RESTDataEntities.APIResponse<List<RESTDataEntities.Employee>>();

            try
            {
                var code = this.RestClient.SetPath("api/Employee/GetAll").GetRequest(new Dictionary<string, string>() { { "active", active.ToString() } });
                //var code = this.RestClient.SetPath("api/Employee").PostRequest(JsonConvert.SerializeObject(request));

                response = JsonConvert.DeserializeObject<RESTDataEntities.APIResponse<List<RESTDataEntities.Employee>>>(code);
            }
            catch (Exception ex)
            {
                return ex.Handle(response);
            }

            return response;
        }

        public RESTDataEntities.APIResponse<long?> Put(RESTDataEntities.Employee employee)
        {
            var response = new RESTDataEntities.APIResponse<long?>();

            try
            {
                var requestData = JsonConvert.SerializeObject(employee);

                var code = this.RestClient.SetPath("api/Employee").PutRequest(requestData);
                //var code = this.RestClient.SetPath("api/Employee").PostRequest(JsonConvert.SerializeObject(request));

                response = JsonConvert.DeserializeObject<RESTDataEntities.APIResponse<long?>>(code);
            }
            catch (Exception ex)
            {
                return ex.Handle(response);
            }

            return response;
        }
    }
}
