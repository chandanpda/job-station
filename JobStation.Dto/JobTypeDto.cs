using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStation.Dto
{
    public class JobTypeDto
    {
        public int Id { get; set; }
        public string UniqueGuid { get; set; }
        public string TypeName { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
    }
}
