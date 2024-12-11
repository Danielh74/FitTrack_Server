﻿// <auto-generated />
using System;
using DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241210131754_initDb")]
    partial class initDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DAL.Models.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("AbdominalCircumference")
                        .HasColumnType("float");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<bool>("AgreedToTerms")
                        .HasColumnType("bit");

                    b.Property<double>("ArmCircumference")
                        .HasColumnType("float");

                    b.Property<double>("BodyFatPrecentage")
                        .HasColumnType("float");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Goal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<double>("HipsCircumference")
                        .HasColumnType("float");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<double>("NeckCircumference")
                        .HasColumnType("float");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PecsCircumference")
                        .HasColumnType("float");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("RegistrationDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ThighsCircumference")
                        .HasColumnType("float");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<double>("WaistCircumference")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AbdominalCircumference = 0.0,
                            AccessFailedCount = 0,
                            Age = 0,
                            AgreedToTerms = false,
                            ArmCircumference = 0.0,
                            BodyFatPrecentage = 0.0,
                            City = "",
                            ConcurrencyStamp = "5e7bb12b-7c36-40c5-9630-b88edba696dc",
                            Email = "a@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Avner",
                            Gender = "",
                            Goal = "",
                            Height = 0,
                            HipsCircumference = 0.0,
                            LastName = "Hazan",
                            LockoutEnabled = false,
                            NeckCircumference = 0.0,
                            NormalizedEmail = "A@GMAIL.COM",
                            NormalizedUserName = "A@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEMlh7yqmDb4SHhsZJENA/0Xfv5khA7am5UY4m/KqogS1dokVW5rTUSC4WzJJKJ6KGQ==",
                            PecsCircumference = 0.0,
                            PhoneNumberConfirmed = false,
                            RegistrationDate = "",
                            SecurityStamp = "139eb895-0408-46f3-9a12-52c34ff37860",
                            ThighsCircumference = 0.0,
                            TwoFactorEnabled = false,
                            UserName = "a@gmail.com",
                            WaistCircumference = 0.0
                        },
                        new
                        {
                            Id = 2,
                            AbdominalCircumference = 0.0,
                            AccessFailedCount = 0,
                            Age = 24,
                            AgreedToTerms = false,
                            ArmCircumference = 0.0,
                            BodyFatPrecentage = 0.0,
                            City = "",
                            ConcurrencyStamp = "0ea25d6b-767f-4bca-8321-2d8e2bf2c951",
                            Email = "d@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Daniel",
                            Gender = "Male",
                            Goal = "",
                            Height = 0,
                            HipsCircumference = 0.0,
                            LastName = "Hazan",
                            LockoutEnabled = false,
                            NeckCircumference = 0.0,
                            NormalizedEmail = "D@GMAIL.COM",
                            NormalizedUserName = "D@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEJ1SIdWdhfjPfZNSWi/3mP5oUmFdyeOknBuYQnZfANx+BKElCExSCy00N1Xq8Yk8eA==",
                            PecsCircumference = 0.0,
                            PhoneNumberConfirmed = false,
                            RegistrationDate = "10/12/2024",
                            SecurityStamp = "eeb82654-5927-4dae-b5fc-cd74ebf19a8e",
                            ThighsCircumference = 0.0,
                            TwoFactorEnabled = false,
                            UserName = "d@gmail.com",
                            WaistCircumference = 0.0
                        });
                });

            modelBuilder.Entity("DAL.Models.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MuscleGroupId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MuscleGroupId");

                    b.ToTable("Exercises");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MuscleGroupId = 7,
                            Name = "Leg curls",
                            VideoURL = ""
                        },
                        new
                        {
                            Id = 2,
                            MuscleGroupId = 1,
                            Name = "Bench press",
                            VideoURL = "https://fittrackmedia.blob.core.windows.net/videos/benchPress.mp4"
                        },
                        new
                        {
                            Id = 3,
                            MuscleGroupId = 3,
                            Name = "Hammer curls",
                            VideoURL = ""
                        },
                        new
                        {
                            Id = 4,
                            MuscleGroupId = 4,
                            Name = "Skull Crushers",
                            VideoURL = ""
                        },
                        new
                        {
                            Id = 5,
                            MuscleGroupId = 6,
                            Name = "Shoulder press",
                            VideoURL = "https://fittrackmedia.blob.core.windows.net/videos/Shoulder_press_with_dumbells.mp4"
                        },
                        new
                        {
                            Id = 6,
                            MuscleGroupId = 5,
                            Name = "Plank",
                            VideoURL = ""
                        },
                        new
                        {
                            Id = 7,
                            MuscleGroupId = 2,
                            Name = "Pull-down",
                            VideoURL = ""
                        });
                });

            modelBuilder.Entity("DAL.Models.HealthDeclaration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<bool>("AsthmaTreatment")
                        .HasColumnType("bit");

                    b.Property<bool>("ChestPainInActivity")
                        .HasColumnType("bit");

                    b.Property<bool>("ChestPainInDaily")
                        .HasColumnType("bit");

                    b.Property<bool>("ChestPainInRest")
                        .HasColumnType("bit");

                    b.Property<bool>("ChronicIllness")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DateOfSignature")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Dizzy")
                        .HasColumnType("bit");

                    b.Property<bool>("FamilyDeathHeartDisease")
                        .HasColumnType("bit");

                    b.Property<bool>("FamilySuddenEarlyAgeDeath")
                        .HasColumnType("bit");

                    b.Property<bool>("HeartDisease")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPregnant")
                        .HasColumnType("bit");

                    b.Property<bool>("LostConsciousness")
                        .HasColumnType("bit");

                    b.Property<bool>("ShortBreath")
                        .HasColumnType("bit");

                    b.Property<bool>("TrainUnderSupervision")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId")
                        .IsUnique();

                    b.ToTable("HealthDeclarations");
                });

            modelBuilder.Entity("DAL.Models.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CarbsPoints")
                        .HasColumnType("int");

                    b.Property<int?>("FatsPoints")
                        .HasColumnType("int");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int?>("ProteinPoints")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("DAL.Models.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("DAL.Models.MuscleGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MuscleGroups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Chest"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Back"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Biceps"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Triceps"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Abs"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Shoulders"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Legs"
                        });
                });

            modelBuilder.Entity("DAL.Models.Plan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Plans");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AppUserId = 2,
                            IsCompleted = false,
                            Name = "Push"
                        },
                        new
                        {
                            Id = 2,
                            AppUserId = 2,
                            IsCompleted = false,
                            Name = "Pull"
                        });
                });

            modelBuilder.Entity("DAL.Models.PlanDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double?>("CurrentWeight")
                        .HasColumnType("float");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderInPlan")
                        .HasColumnType("int");

                    b.Property<int>("PlanId")
                        .HasColumnType("int");

                    b.Property<double?>("PreviousWeight")
                        .HasColumnType("float");

                    b.Property<int?>("Reps")
                        .HasColumnType("int");

                    b.Property<int?>("Sets")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("PlanId");

                    b.ToTable("PlansDetails");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CurrentWeight = 15.0,
                            ExerciseId = 2,
                            OrderInPlan = 1,
                            PlanId = 1,
                            PreviousWeight = 12.5,
                            Reps = 12,
                            Sets = 4
                        },
                        new
                        {
                            Id = 2,
                            ExerciseId = 5,
                            OrderInPlan = 2,
                            PlanId = 1,
                            Reps = 10,
                            Sets = 4
                        },
                        new
                        {
                            Id = 3,
                            ExerciseId = 3,
                            OrderInPlan = 1,
                            PlanId = 2,
                            Reps = 10,
                            Sets = 4
                        },
                        new
                        {
                            Id = 4,
                            ExerciseId = 7,
                            OrderInPlan = 2,
                            PlanId = 2,
                            Reps = 10,
                            Sets = 3
                        });
                });

            modelBuilder.Entity("DAL.Models.Weight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AppUserId")
                        .HasColumnType("int");

                    b.Property<string>("TimeStamp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Weight");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "babc68b5-9ab6-43a9-a743-13eab11f3839",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "b0e06b94-ab1e-4a26-aab1-d6e1494c788d",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("DAL.Models.Exercise", b =>
                {
                    b.HasOne("DAL.Models.MuscleGroup", "MuscleGroup")
                        .WithMany("Exercises")
                        .HasForeignKey("MuscleGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MuscleGroup");
                });

            modelBuilder.Entity("DAL.Models.HealthDeclaration", b =>
                {
                    b.HasOne("DAL.Models.AppUser", "AppUser")
                        .WithOne("HealthDeclaration")
                        .HasForeignKey("DAL.Models.HealthDeclaration", "AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("DAL.Models.Meal", b =>
                {
                    b.HasOne("DAL.Models.Menu", "Menu")
                        .WithMany("Meals")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("DAL.Models.Menu", b =>
                {
                    b.HasOne("DAL.Models.AppUser", "AppUser")
                        .WithOne("Menu")
                        .HasForeignKey("DAL.Models.Menu", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("DAL.Models.Plan", b =>
                {
                    b.HasOne("DAL.Models.AppUser", "AppUser")
                        .WithMany("Plans")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("DAL.Models.PlanDetails", b =>
                {
                    b.HasOne("DAL.Models.Exercise", "Exercise")
                        .WithMany("PlanDetails")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.Plan", "Plan")
                        .WithMany("PlanDetails")
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("Plan");
                });

            modelBuilder.Entity("DAL.Models.Weight", b =>
                {
                    b.HasOne("DAL.Models.AppUser", null)
                        .WithMany("Weight")
                        .HasForeignKey("AppUserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("DAL.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("DAL.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("DAL.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Models.AppUser", b =>
                {
                    b.Navigation("HealthDeclaration");

                    b.Navigation("Menu");

                    b.Navigation("Plans");

                    b.Navigation("Weight");
                });

            modelBuilder.Entity("DAL.Models.Exercise", b =>
                {
                    b.Navigation("PlanDetails");
                });

            modelBuilder.Entity("DAL.Models.Menu", b =>
                {
                    b.Navigation("Meals");
                });

            modelBuilder.Entity("DAL.Models.MuscleGroup", b =>
                {
                    b.Navigation("Exercises");
                });

            modelBuilder.Entity("DAL.Models.Plan", b =>
                {
                    b.Navigation("PlanDetails");
                });
#pragma warning restore 612, 618
        }
    }
}