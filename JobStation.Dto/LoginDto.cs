using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStation.Dto
{
    public class LoginDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
