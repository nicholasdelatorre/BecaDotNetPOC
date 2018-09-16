using BecaDotNet.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BecaDotNet.Repository.Configs {
    public class ProjectUserConfig : BaseIdentifiedEntityConfig<ProjetcUser> {


        public ProjectUserConfig() {
            this.ToTable("TB_PROJECT_USER");
            this.Property(p => p.UserId).HasColumnName("USER_ID").HasColumnType("int").IsRequired();
            this.Property(p => p.ProjectId).HasColumnName("PROJECT_ID").HasColumnType("int").IsRequired();
            this.Property(p => p.UserProjectStartDate).HasColumnName("START_DATE").HasColumnType("DateTime").IsRequired();
            this.Property(p => p.UserProjectEndDate).HasColumnName("END_DATE").HasColumnType("DateTime").IsOptional();
            this.Property(p => p.Responsavel).HasColumnName("RESPONSIBLE").HasColumnType("varchar").HasMaxLength(200).IsOptional();


        }


    }
}
