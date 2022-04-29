﻿// <auto-generated />
using System;
using EfcData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EfcData.Migrations
{
    [DbContext(typeof(ForumContext))]
    [Migration("20220429170918_ForumMigration")]
    partial class ForumMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("BlazorApp1.Services.SubForum", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Forumid")
                        .HasColumnType("TEXT");

                    b.Property<string>("OwnedById")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Forumid");

                    b.HasIndex("OwnedById");

                    b.ToTable("SubForum");
                });

            modelBuilder.Entity("Domain.Models.Comment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PostId")
                        .HasColumnType("TEXT");

                    b.Property<string>("WrittenById")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("WrittenById");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("Domain.Models.Forum", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("forums");
                });

            modelBuilder.Entity("Domain.Models.Post", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Forumid")
                        .HasColumnType("TEXT");

                    b.Property<string>("Header")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SubForumId")
                        .HasColumnType("TEXT");

                    b.Property<string>("WrittenById")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("date_posted")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Forumid");

                    b.HasIndex("SubForumId");

                    b.HasIndex("WrittenById");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Forumid")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Forumid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Models.Vote", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("CommentId")
                        .HasColumnType("TEXT");

                    b.Property<string>("PostId")
                        .HasColumnType("TEXT");

                    b.Property<string>("VoterId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("PostId");

                    b.HasIndex("VoterId");

                    b.ToTable("Vote");
                });

            modelBuilder.Entity("BlazorApp1.Services.SubForum", b =>
                {
                    b.HasOne("Domain.Models.Forum", null)
                        .WithMany("SubForums")
                        .HasForeignKey("Forumid");

                    b.HasOne("Domain.Models.User", "OwnedBy")
                        .WithMany()
                        .HasForeignKey("OwnedById");

                    b.Navigation("OwnedBy");
                });

            modelBuilder.Entity("Domain.Models.Comment", b =>
                {
                    b.HasOne("Domain.Models.Post", null)
                        .WithMany("Comments")
                        .HasForeignKey("PostId");

                    b.HasOne("Domain.Models.User", "WrittenBy")
                        .WithMany()
                        .HasForeignKey("WrittenById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WrittenBy");
                });

            modelBuilder.Entity("Domain.Models.Post", b =>
                {
                    b.HasOne("Domain.Models.Forum", null)
                        .WithMany("AddPost")
                        .HasForeignKey("Forumid");

                    b.HasOne("BlazorApp1.Services.SubForum", null)
                        .WithMany("Posts")
                        .HasForeignKey("SubForumId");

                    b.HasOne("Domain.Models.User", "WrittenBy")
                        .WithMany()
                        .HasForeignKey("WrittenById");

                    b.Navigation("WrittenBy");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.HasOne("Domain.Models.Forum", null)
                        .WithMany("Users")
                        .HasForeignKey("Forumid");
                });

            modelBuilder.Entity("Domain.Models.Vote", b =>
                {
                    b.HasOne("Domain.Models.Comment", null)
                        .WithMany("Votes")
                        .HasForeignKey("CommentId");

                    b.HasOne("Domain.Models.Post", null)
                        .WithMany("Votes")
                        .HasForeignKey("PostId");

                    b.HasOne("Domain.Models.User", "Voter")
                        .WithMany()
                        .HasForeignKey("VoterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Voter");
                });

            modelBuilder.Entity("BlazorApp1.Services.SubForum", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("Domain.Models.Comment", b =>
                {
                    b.Navigation("Votes");
                });

            modelBuilder.Entity("Domain.Models.Forum", b =>
                {
                    b.Navigation("AddPost");

                    b.Navigation("SubForums");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Models.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Votes");
                });
#pragma warning restore 612, 618
        }
    }
}