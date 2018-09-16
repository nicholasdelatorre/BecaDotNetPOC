using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BecaDotNet.Domain.Model {
    public class ProjetcUser : IdentifiedEntity {


        public User User { get; set; }
        public int UserId { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        public DateTime UserProjectStartDate { get; set; }
        public DateTime? UserProjectEndDate { get; set; }
        public string Responsavel { get; set; }
        
    }
}
