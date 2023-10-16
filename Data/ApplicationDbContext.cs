using CRUDWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUDWebApi.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext():base("WebApiCrudDBConn") {}

        public DbSet<Employee> Employees { get; set; }
    }
}