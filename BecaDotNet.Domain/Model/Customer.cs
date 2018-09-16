using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BecaDotNet.Domain.Model {
    public class Customer : IdentifiedEntity {

        public string Name { get; set; }
        public long Cnpj { get; set; }
        public string ContactName { get; set; }
        public ICollection<Project> Projects { get; set; }

        public Customer() {

        }

       
    }
}
