using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStation.Core.Domain
{
    public class SkillList
    {
        public int Id { get; set; }
        public string UniqueGuid { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}
