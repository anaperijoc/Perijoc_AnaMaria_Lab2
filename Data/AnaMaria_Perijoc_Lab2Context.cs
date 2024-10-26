﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AnaMaria_Perijoc_Lab2.Models;

namespace AnaMaria_Perijoc_Lab2.Data
{
    public class AnaMaria_Perijoc_Lab2Context : DbContext
    {
        public AnaMaria_Perijoc_Lab2Context (DbContextOptions<AnaMaria_Perijoc_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<AnaMaria_Perijoc_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<AnaMaria_Perijoc_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<AnaMaria_Perijoc_Lab2.Models.Author> Author { get; set; } = default!;
    }
}
