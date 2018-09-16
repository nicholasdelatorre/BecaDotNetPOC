using BecaDotNet.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BecaDotNet.Repository.Configs {
    class CustomerEntityConfig : BaseIdentifiedEntityConfig<Customer> {

        public CustomerEntityConfig() {

            this.ToTable("TB_CUSTOMER");
            this.Property(p => p.Name).HasColumnName("FULL_NAME").HasColumnType("varchar").HasMaxLength(200).IsRequired();
            this.Property(p => p.Cnpj).HasColumnName("CNPJ").HasColumnType("bigint").IsRequired();
            this.Property(p => p.ContactName).HasColumnName("CONTACT_NAME").HasColumnType("varchar").HasMaxLength(100).IsRequired();
            

        }

            

    }
}
