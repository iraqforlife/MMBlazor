using System;
using System.Collections.Generic;
using System.Text;

namespace MM.Model
{
    public class UserToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
