﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChiJunKaiOAMis.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OADBEntities : DbContext
    {
        public OADBEntities()
            : base("name=OADBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Classes> Classes { get; set; }
        public virtual DbSet<Dep> Dep { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<View_Employees> View_Employees { get; set; }
    }
}
