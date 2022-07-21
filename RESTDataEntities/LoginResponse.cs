using System;
using System.Collections.Generic;
using System.Text;

namespace RESTDataEntities
{
    public class LoginResponse
    {
        public User User { get; set; } = new User();
        public string Auth { get; set; }
    }
}
