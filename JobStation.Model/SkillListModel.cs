using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStation.Model
{
    public class SkillListModel
    {
        public int Id { get; set; }
        public string UniqueGuid { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedOn { get; set; }

    }
}
