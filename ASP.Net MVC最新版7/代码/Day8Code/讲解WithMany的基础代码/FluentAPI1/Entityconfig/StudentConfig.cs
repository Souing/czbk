using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI1.Entityconfig
{
    class StudentConfig:EntityTypeConfiguration<Student>
    {
        public StudentConfig()
        {
            ToTable("T_Students");
            //如果配置了反向的集合属性，则WithMany(e=>e.Students)必须带参数
            this.HasRequired(e => e.Class).WithMany(e=>e.Students)
                .HasForeignKey(e=>e.ClassId);
        }
    }
}
