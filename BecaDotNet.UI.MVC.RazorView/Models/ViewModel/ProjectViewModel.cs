using BecaDotNet.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BecaDotNet.UI.MVC.RazorView.Models.ViewModel {

    public class ProjectViewModel : IdentifiedEntity {


        [Required(ErrorMessage = "Informe o Nome")]
        [Display(Name = "Name")]
        public string ProjectName { get; set; }

        private DateTime _actualDate = DateTime.Now;

        [Display(Name = "Start Date")]
        public DateTime StartDate { get => _actualDate; set => value = _actualDate; }

        [Display(Name = "Start Date")]
        public string DataInicio {
            get => StartDate.ToString("dd/MM/yyyy");
            set {
                DateTime.TryParse(value, out DateTime newDate);
                if (newDate.Date == DateTime.MinValue.Date) {
                    newDate = DateTime.Now.Date;
                }
                StartDate = newDate;
            }
        }


        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        public string DataFim {
            get => EndDate.HasValue ? EndDate.Value.ToString("yyyy-MM-dd") : string.Empty;
            set {
                DateTime.TryParse(value, out DateTime newDate);
                EndDate = newDate.Date == DateTime.MinValue.Date ? null : (DateTime?)newDate;
            }
        }

        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        



        public bool IsEdit { get; set; }
        


        public Project GetEntity() {
            return new Project {

                ProjectName = this.ProjectName,
                StartDate = DateTime.Now,
                EndDate = this.EndDate,
                Id = this.Id,
                CustomerId = this.CustomerId

            };
        }

    }
}
