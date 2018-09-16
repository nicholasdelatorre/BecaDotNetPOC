using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BecaDotNet.Domain.Model {

    public class Project : IdentifiedEntity{

        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

      

        public Project() {
            StartDate = DateTime.Now;
        }
    }
}
