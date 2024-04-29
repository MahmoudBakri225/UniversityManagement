using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UniversityManagement.Models;

public partial class UniversityManagementContext : DbContext
{
    public UniversityManagementContext()
    {
    }

    public UniversityManagementContext(DbContextOptions<UniversityManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Faculty> Faculties { get; set; }

    public virtual DbSet<Fee> Fees { get; set; }

    public virtual DbSet<Library> Libraries { get; set; }

    public virtual DbSet<Prof> Profs { get; set; }

    public virtual DbSet<ProfessorDepartment> ProfessorDepartments { get; set; }

    public virtual DbSet<ProfessorFaculty> ProfessorFaculties { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentCourse> StudentCourses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=UniversityManagement;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Books__3214EC0749E3878E");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Author)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LibraryId).HasColumnName("Library_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Library).WithMany(p => p.Books)
                .HasForeignKey(d => d.LibraryId)
                .HasConstraintName("FK__Books__Library_i__4D94879B");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Courses__3214EC07CE74E7C8");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CourseCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DeptId).HasColumnName("Dept_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Dept).WithMany(p => p.Courses)
                .HasForeignKey(d => d.DeptId)
                .HasConstraintName("FK__Courses__Dept_id__4AB81AF0");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC07FD520B32");

            entity.ToTable("Department");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Faculty).WithMany(p => p.Departments)
                .HasForeignKey(d => d.FacultyId)
                .HasConstraintName("FK__Departmen__Facul__4222D4EF");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC0760AC7848");

            entity.ToTable("Employee");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Salary).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Faculty).WithMany(p => p.Employees)
                .HasForeignKey(d => d.FacultyId)
                .HasConstraintName("FK__Employee__Facult__3F466844");
        });

        modelBuilder.Entity<Faculty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Faculty__3214EC070BE10DAB");

            entity.ToTable("Faculty");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.LibraryId).HasColumnName("Library_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Library).WithMany(p => p.Faculties)
                .HasForeignKey(d => d.LibraryId)
                .HasConstraintName("FK__Faculty__Library__3C69FB99");
        });

        modelBuilder.Entity<Fee>(entity =>
        {
            entity.HasKey(e => e.FeeId).HasName("PK__Fees__B387B209E7CBA4B1");

            entity.Property(e => e.FeeId)
                .ValueGeneratedNever()
                .HasColumnName("FeeID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.FeeType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PaymentDate).HasColumnType("date");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.StudentId).HasColumnName("student_id");

            entity.HasOne(d => d.Student).WithMany(p => p.Fees)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Fees__student_id__5070F446");
        });

        modelBuilder.Entity<Library>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Library__3214EC07BCA5E372");

            entity.ToTable("Library");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Prof>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Prof__3214EC07D3A4672E");

            entity.ToTable("Prof");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.DeptId).HasColumnName("Dept_id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Fname)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Lname)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.OfficeNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Dept).WithMany(p => p.Profs)
                .HasForeignKey(d => d.DeptId)
                .HasConstraintName("FK__Prof__Dept_id__47DBAE45");

            entity.HasMany(d => d.Courses).WithMany(p => p.Professors)
                .UsingEntity<Dictionary<string, object>>(
                    "ProfessorCourse",
                    r => r.HasOne<Course>().WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Professor__Cours__5BE2A6F2"),
                    l => l.HasOne<Prof>().WithMany()
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Professor__Profe__5AEE82B9"),
                    j =>
                    {
                        j.HasKey("ProfessorId", "CourseId").HasName("PK__Professo__AF963856251A7FA8");
                        j.ToTable("Professor_Course");
                        j.IndexerProperty<int>("ProfessorId").HasColumnName("Professor_id");
                        j.IndexerProperty<int>("CourseId").HasColumnName("Course_id");
                    });
        });

        modelBuilder.Entity<ProfessorDepartment>(entity =>
        {
            entity.HasKey(e => new { e.ProfessorId, e.DepartmentId }).HasName("PK__Professo__8C4E143F4476AE56");

            entity.ToTable("Professor_Department");

            entity.Property(e => e.ProfessorId).HasColumnName("Professor_ID");
            entity.Property(e => e.DepartmentId).HasColumnName("Department_ID");
            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("start_date");

            entity.HasOne(d => d.Department).WithMany(p => p.ProfessorDepartments)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Professor__Depar__5812160E");

            entity.HasOne(d => d.Professor).WithMany(p => p.ProfessorDepartments)
                .HasForeignKey(d => d.ProfessorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Professor__Profe__571DF1D5");
        });

        modelBuilder.Entity<ProfessorFaculty>(entity =>
        {
            entity.HasKey(e => new { e.ProfessorId, e.FacultyId }).HasName("PK__Professo__39F0BDC610F4968D");

            entity.ToTable("Professor_Faculty");

            entity.Property(e => e.ProfessorId).HasColumnName("Professor_ID");
            entity.Property(e => e.FacultyId).HasColumnName("Faculty_ID");
            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("end_date");
            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("start_date");

            entity.HasOne(d => d.Faculty).WithMany(p => p.ProfessorFaculties)
                .HasForeignKey(d => d.FacultyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Professor__Facul__5441852A");

            entity.HasOne(d => d.Professor).WithMany(p => p.ProfessorFaculties)
                .HasForeignKey(d => d.ProfessorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Professor__Profe__534D60F1");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3214EC07C96B65DA");

            entity.ToTable("Student");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.DeptId).HasColumnName("Dept_id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Fname)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Lname)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Dept).WithMany(p => p.Students)
                .HasForeignKey(d => d.DeptId)
                .HasConstraintName("FK__Student__Dept_id__44FF419A");

            entity.HasMany(d => d.Books).WithMany(p => p.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentBook",
                    r => r.HasOne<Book>().WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Student_B__Book___6383C8BA"),
                    l => l.HasOne<Student>().WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Student_B__Stude__628FA481"),
                    j =>
                    {
                        j.HasKey("StudentId", "BookId").HasName("PK__Student___7ED5E10DE521DE2F");
                        j.ToTable("Student_Books");
                        j.IndexerProperty<int>("StudentId").HasColumnName("Student_id");
                        j.IndexerProperty<int>("BookId").HasColumnName("Book_id");
                    });
        });

        modelBuilder.Entity<StudentCourse>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.CourseId }).HasName("PK__Student___8189DD68141C9434");

            entity.ToTable("Student_Course");

            entity.Property(e => e.StudentId).HasColumnName("Student_id");
            entity.Property(e => e.CourseId).HasColumnName("Course_id");
            entity.Property(e => e.Degree)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Semester)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Course).WithMany(p => p.StudentCourses)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Student_C__Cours__5FB337D6");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentCourses)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Student_C__Stude__5EBF139D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
