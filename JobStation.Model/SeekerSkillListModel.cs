using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStation.Model
{
    public class SeekerSkillListModel
    {
        public int Id { get; set; }
        public int SeekerId { get; set; }
        public string SeekerSkills { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}
