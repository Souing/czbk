//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFDBFirst1
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_Students
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Nullable<long> ClassId { get; set; }
        public bool IsDeleted { get; set; }
        public System.DateTime CreateDateTime { get; set; }
        public System.DateTime DeleteDateTime { get; set; }
    
        public virtual T_Classes T_Classes { get; set; }
    }
}
