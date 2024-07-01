﻿using HeadHunterClone.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HeadHunterClone.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        // Создание таблицы Вакансий
        public DbSet<Vacancy> Vacancies => Set<Vacancy>();
        public DbSet<Company> Companies => Set<Company>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            // Гарантия создания БД
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vacancy>().HasData(
            new Vacancy()
            {
                Id = 1,
                Title = "Title 1",
                SalaryFrom = 1000,
                SalaryTo = 3000,
                SalaryCurrency = "USD",
                Description = "This is Description 1",
                Requirements = "Require 1, Require 2, Require 3",
                WorkTerms = "WorkTerm 1, WorkTerm2",
                Skills = "Skill1"
            });
        }
    }
}
