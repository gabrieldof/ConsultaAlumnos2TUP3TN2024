using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Subject> Subjects { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasDiscriminator(u => u.UserType);

            modelBuilder.Entity<Subject>()
                        .Property(b => b.Id)
                        .ValueGeneratedOnAdd();

            modelBuilder.Entity<Student>().HasData(CreateStudentDataSeed());

            modelBuilder.Entity<Professor>().HasData(CreateProfessorDataSeed());

            modelBuilder.Entity<Subject>().HasData(CreateSubjectDataSeed());

            modelBuilder.Entity<Subject>()
                          .HasMany(x => x.Professors)
                          .WithMany(x => x.Subjects)
                          .UsingEntity(j => j
                              .ToTable("ProfessorSubject")
                              .HasData(CreateProfessorSubjectDataSeed()
                              ));

            /* modelBuilder.Entity<Professor>()
                 .HasMany(s => s.Subjects)
                 .WithOne(p => p.Professor)
                 .HasForeignKey(pi => pi.ProfessorId);*/



        }



        private object[] CreateProfessorSubjectDataSeed()
        {
            object[] result;
            result = new[]
                {
                new { ProfessorsId = 4, SubjectsId = 1},
                new { ProfessorsId= 5, SubjectsId = 1},
                new { ProfessorsId = 4, SubjectsId = 2},
            };


            return result;
        }

        private Student[] CreateStudentDataSeed()
        {
            Student[] result;

            result = [
                new Student
                {

                    Name = "Nicolas",
                    Email = "nbologna31@gmail.com",
                    Password = "123456",
                    Id = 1
                },
                new Student
                {
                    Name = "Juan",
                    Email = "Jfurrer@gmail.com",
                    Password = "123456",
                    Id = 2
                },
                new Student
                {
                    Name = "Pedro",
                    Email = "pgarcia@gmail.com",
                    Password = "123456",
                    Id = 3
                }];

            return result;
        }



        private Professor[] CreateProfessorDataSeed()
        {
            Professor[] result;

            result = [
                new Professor
                {

                    Name = "carlos",
                    Email = "cbologna31@gmail.com",
                    Password = "123456",
                    Id = 4
                },
                new Professor
                {
                    Name = "Gabriel",
                    Email = "gfurrer@gmail.com",
                    Password = "123456",
                    Id = 5
                }];

            return result;
        }

        private Subject[] CreateSubjectDataSeed()
        {
            Subject[] result;

            result = [
                new Subject
                {
                    Id = 1,
                    Name = "Programación 3"
                  
                },
                new Subject
                {
                    Id = 2,
                    Name = "Programación 4"
                }];

            return result;
        }

    }
}
