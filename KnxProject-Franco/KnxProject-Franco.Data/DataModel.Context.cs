﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KnxProject_Franco.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KnxProject_FrancoDBEntities : DbContext
    {
        public KnxProject_FrancoDBEntities()
            : base("name=KnxProject_FrancoDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<CourtBranches> CourtBranches { get; set; }
        public virtual DbSet<CourtCaseDetails> CourtCaseDetails { get; set; }
        public virtual DbSet<CourtCases> CourtCases { get; set; }
        public virtual DbSet<DocumentTypes> DocumentTypes { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Lawyers> Lawyers { get; set; }
        public virtual DbSet<Scopes> Scopes { get; set; }
        public virtual DbSet<States> States { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<webpages_Membership> webpages_Membership { get; set; }
        public virtual DbSet<webpages_OAuthMembership> webpages_OAuthMembership { get; set; }
        public virtual DbSet<webpages_Roles> webpages_Roles { get; set; }
        public virtual DbSet<webpages_UsersInRoles> webpages_UsersInRoles { get; set; }
        public virtual DbSet<About> About { get; set; }
        public virtual DbSet<QAs> QAs { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<People> People { get; set; }
    }
}
