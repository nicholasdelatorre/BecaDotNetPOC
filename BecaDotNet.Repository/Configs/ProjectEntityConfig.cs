using BecaDotNet.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BecaDotNet.Repository.Configs {
    class ProjectEntityConfig : BaseIdentifiedEntityConfig<Project>{


        public ProjectEntityConfig(){
            this.ToTable("TB_PROJECT");
            this.Property(p => p.ProjectName).HasColumnName("PROJECT_NAME").HasColumnType("varchar").HasMaxLength(200).IsRequired();
            this.Property(p => p.StartDate).HasColumnName("START_DATE").HasColumnType("DateTime").IsRequired();
            this.Property(p => p.EndDate).HasColumnName("END_DATE").HasColumnType("DateTime").IsOptional();
            this.Property(p => p.CustomerId).HasColumnName("CLIENT_ID").HasColumnType("int").IsRequired();


        }


    }
}
