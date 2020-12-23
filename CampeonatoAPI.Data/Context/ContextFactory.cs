using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampeonatoAPI.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            var conectionString = "Password=123321;Persist Security Info=True;User ID=sa;Initial Catalog=CampeonatoAPI;Data Source=DESKTOP-LRABKU8\\SQLEXPRESS";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseSqlServer(conectionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}
