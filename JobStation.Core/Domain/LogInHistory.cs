using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStation.Core.Domain
{
    public class LogInHistory
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}
