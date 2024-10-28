using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStation.Core.Domain
{
    public class OrganisationDetails
    {
        public int Id { get; set; }
        public string OrganisationName { get; set; }
        public string Domain { get; set; }
        public string  EstablishedYear { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}
