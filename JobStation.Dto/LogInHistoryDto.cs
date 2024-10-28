using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStation.Dto
{
    public class LogInHistoryDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset LastLoginDate { get; set; }
    }
}
