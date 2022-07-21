using System;
using System.Collections.Generic;
using System.Text;

namespace RESTDataEntities
{
    public class GetThirdPartyResponse
    {
        public List<ThirdPartyUser> ThirdPartyUsers { get; set; } = new List<ThirdPartyUser>();
    }
}
