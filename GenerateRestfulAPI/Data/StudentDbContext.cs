﻿using Microsoft.EntityFrameworkCore;
using GenerateRestfulAPI.Domain;
using System.Net;

namespace GenerateRestfulAPI.Data
{
    public class StudentDbContext: DbContext
    {
        public StudentDbContext (DbContextOptions<StudentDbContext> options): base(options) 
        { }
        public DbSet<Student> students { get; set; }
        public DbSet<Course> courses { get; set; }
    }
}
