﻿using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories;


namespace TestProject
{
    public class DatabaseFixture : IDisposable
    {
        public OurStoreContext Context { get; private set; }

        public DatabaseFixture()
        {
            var options = new DbContextOptionsBuilder<OurStoreContext>()
            .UseSqlServer("server=srv2\\pupils;Database=Tests;Trusted_Connection=True;TrustServerCertificate=True;")
            .Options;
            Context = new OurStoreContext(options);
            Context.Database.EnsureCreated();
        }

        public void Dispose()
        {
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }

    }
}
