using BecaDotNet.ApplicationService;
using BecaDotNet.Domain.Model;
using BecaDotNet.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BecaDotNet.UI.MVC.RazorView.Models.ViewModel {
    public class ProjectUserViewModel {

        [Display(Name = "User")]
        public int UserId { get; set; }
        [Display(Name = "Project")]
        public int ProjectId { get; set; }

        [Display(Name = "Project")]
        public string ProjectName { get; set; }
        

        public IEnumerable<SelectListItem> DdlUsuarios { get; set; }

        public ProjectUserViewModel() {
            DdlUsuarios = new List<SelectListItem>();
        }

        public ProjectUserViewModel(int projetoId) {

            var result = new ProjectAppSvcGeneric().Get(projetoId);
            ProjectId = result.Id;
            ProjectName = result.ProjectName;



            var allUsers = new UserAppSvcGeneric().FindBy(null);
            var dispUser = allUsers.ToList();
            var usersInproject = new ProjectUserAppSvcGeneric().FindBy(new ProjetcUser { ProjectId = projetoId });

            foreach (var inProj in usersInproject) {
                dispUser.RemoveAll(r => r.Id == inProj.UserId);
            }
            DdlUsuarios = HelperForDropdown<User>.GetDropDownListFrom(dispUser, "Name");
        }

        private DateTime _actualDate = DateTime.Now;

        [Display(Name = "Start")]
        public DateTime UserProjectStartDate { get => _actualDate; set => value = _actualDate; }
        [Display(Name = "Start Date")]
        public string DataInicio {
            get => UserProjectStartDate.ToString("dd/MM/yyyy");
            set {
                DateTime.TryParse(value, out DateTime newDate);
                if (newDate.Date == DateTime.MinValue.Date) {
                    newDate = DateTime.Now.Date;
                }
                UserProjectStartDate = newDate;
            }
        }
        [Display(Name = "End")]
        public DateTime? UserProjectEndDate { get; set; }

        public string DataFim {
            get => UserProjectEndDate.HasValue ? UserProjectEndDate.Value.ToString("yyyy-MM-dd") : string.Empty;
            set {
                DateTime.TryParse(value, out DateTime newDate);
                UserProjectEndDate = newDate.Date == DateTime.MinValue.Date ? null : (DateTime?)newDate;
            }
        }

        [Display(Name = "Responsible")]
        public string Responsavel { get; set; }

        public bool IsEdit { get; set; }
        public int Id { get; set; }

        public ProjetcUser GetEntity() {
            return new ProjetcUser {

                Id = this.Id,
                ProjectId = this.ProjectId,
                UserId = this.UserId,
                UserProjectEndDate = this.UserProjectEndDate,
                UserProjectStartDate = DateTime.Now,
                Responsavel = this.Responsavel
                

            };
        }



    }
}