﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Obuv1.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ObuvEntities : DbContext
    {
        private static ObuvEntities _context;
        public ObuvEntities()
            : base("name=ObuvEntities")
        {
        }

        public static ObuvEntities GetContext()
        {
            if (_context == null) { _context = new ObuvEntities(); }
            return _context;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Order_> Order_ { get; set; }
        public virtual DbSet<Shoes> Shoes { get; set; }
    }
}