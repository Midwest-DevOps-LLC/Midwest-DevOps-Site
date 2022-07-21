using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace RESTServiceRequestor
{
    public static class HandleException
    {
        public static RESTDataEntities.APIResponse<T> Handle<T>(this Exception ex, RESTDataEntities.APIResponse<T> response)
        {
            if (ex.GetType() == typeof(WebException))
            {
                var webException = (WebException)ex;

                var s = webException.Status;

                if (webException.Status == WebExceptionStatus.UnknownError)
                {
                    response.AddError("Unable to connect to background service. Please try again later");
                }
            }

            MDO.Utility.Standard.LogHandler.SaveException(ex);
            response.Status = RESTDataEntities.APIResponse<T>.StatusEnum.Error;
            response.ValidationModel.ValidationStatus = RESTDataEntities.ValidationStatus.Error;
            response.Error = ex.Message;

            return response;
        }
    }
}
