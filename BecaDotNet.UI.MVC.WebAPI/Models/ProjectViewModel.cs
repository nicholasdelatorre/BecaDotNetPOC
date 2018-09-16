using BecaDotNet.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BecaDotNet.UI.MVC.WebAPI.Models {
    public class ProjectViewModel {



        public string projectName { get; set; }
        public DateTime startDate { get; set; }
        public DateTime? endDate { get; set; }
        public int? id { get; set; }
        public int customerId { get; set; }

        public Project GetProject() {
            return new Project {

                ProjectName = projectName,
                StartDate = DateTime.Now,
                EndDate = endDate,
                CustomerId = customerId

            };
        }

    }
}