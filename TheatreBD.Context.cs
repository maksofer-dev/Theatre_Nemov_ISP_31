﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Theatre_Nemov_ISP_31
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TheatreEntities : DbContext
    {
        private static TheatreEntities _context;

        public TheatreEntities()
            : base("name=TheatreEntities")
        {
        }
        public static TheatreEntities GetContext()
        {
            if (_context == null)
            {
                _context = new TheatreEntities();

            }
            return _context;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Spectacle> Spectacles { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}