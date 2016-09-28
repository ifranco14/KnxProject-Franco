﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KnxProject_Franco.Models
{
    public class myContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public myContext() : base("name=myContext")
        {
        }

        public System.Data.Entity.DbSet<KnxProject_Franco.Models.LawyerModel> LawyerModels { get; set; }

        public System.Data.Entity.DbSet<KnxProject_Franco.Models.DocumentTypeModel> DocumentTypeModels { get; set; }

        public System.Data.Entity.DbSet<KnxProject_Franco.Models.NewsModel> NewsModels { get; set; }
    }
}
