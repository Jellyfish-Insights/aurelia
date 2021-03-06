﻿// <auto-generated />
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace ApplicationModels.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180704160504_AddApplicationViews")]
    partial class AddApplicationViews
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("application")
                .HasAnnotation("Npgsql:PostgresExtension:pg_trgm", "'pg_trgm', '', ''")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("ApplicationModels.Models.ApplicationGenericTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Tag");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("Id");

                    b.ToTable("ApplicationGenericTags");
                });

            modelBuilder.Entity("ApplicationModels.Models.ApplicationMetaTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Color");

                    b.Property<string>("Tag");

                    b.Property<int>("TypeId");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("ApplicationMetaTags");
                });

            modelBuilder.Entity("ApplicationModels.Models.ApplicationMetaTagType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("ApplicationMetaTagsTypes");
                });

            modelBuilder.Entity("ApplicationModels.Models.ApplicationPersona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("Id");

                    b.ToTable("ApplicationPersonas");
                });

            modelBuilder.Entity("ApplicationModels.Models.ApplicationPersonaVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Archived");

                    b.Property<int>("PersonaId");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("Version");

                    b.HasKey("Id");

                    b.HasIndex("PersonaId");

                    b.ToTable("ApplicationPersonaVersions");
                });

            modelBuilder.Entity("ApplicationModels.Models.ApplicationPersonaVersionSourceAdSet", b =>
                {
                    b.Property<string>("AdSetId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PersonaVersionId");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("AdSetId");

                    b.HasIndex("PersonaVersionId");

                    b.ToTable("ApplicationPersonaVersionSourceAdSets");
                });

            modelBuilder.Entity("ApplicationModels.Models.ApplicationPlaylist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("ThumbnailUrl");

                    b.Property<string>("Title");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("Id");

                    b.ToTable("ApplicationPlaylists");
                });

            modelBuilder.Entity("ApplicationModels.Models.ApplicationPlaylistApplicationVideo", b =>
                {
                    b.Property<int>("ApplicationPlaylistId");

                    b.Property<int>("ApplicationVideoId");

                    b.HasKey("ApplicationPlaylistId", "ApplicationVideoId");

                    b.HasIndex("ApplicationVideoId");

                    b.ToTable("ApplicationPlaylistApplicationVideos");
                });

            modelBuilder.Entity("ApplicationModels.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ApplicationModels.Models.ApplicationVideo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Archived");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Title");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("Id");

                    b.ToTable("ApplicationVideos");
                });

            modelBuilder.Entity("ApplicationModels.Models.ApplicationVideoApplicationGenericTag", b =>
                {
                    b.Property<int>("TagId");

                    b.Property<int>("VideoId");

                    b.HasKey("TagId", "VideoId");

                    b.HasIndex("VideoId");

                    b.ToTable("ApplicationVideoApplicationGenericTags");
                });

            modelBuilder.Entity("ApplicationModels.Models.ApplicationVideoApplicationMetaTag", b =>
                {
                    b.Property<int>("TypeId");

                    b.Property<int>("VideoId");

                    b.Property<int>("TagId");

                    b.HasKey("TypeId", "VideoId");

                    b.HasIndex("TagId");

                    b.HasIndex("VideoId");

                    b.ToTable("ApplicationVideoApplicationMetaTags");
                });

            modelBuilder.Entity("ApplicationModels.Models.ApplicationVideoSourceCampaign", b =>
                {
                    b.Property<string>("CampaignId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("UpdateDate");

                    b.Property<int>("VideoId");

                    b.HasKey("CampaignId");

                    b.HasIndex("VideoId");

                    b.ToTable("ApplicationVideoSourceCampaigns");
                });

            modelBuilder.Entity("ApplicationModels.Models.ApplicationVideoSourceVideo", b =>
                {
                    b.Property<string>("SourceVideoId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApplicationVideoId");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("SourceVideoId");

                    b.HasIndex("ApplicationVideoId");

                    b.ToTable("ApplicationVideoSourceVideos");
                });

            modelBuilder.Entity("ApplicationModels.Models.GeneratedApplicationPersonaVersionSourceAdSet", b =>
                {
                    b.Property<string>("AdSetId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PersonaVersionId");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("AdSetId");

                    b.HasIndex("PersonaVersionId");

                    b.ToTable("GeneratedApplicationPersonaVersionSourceAdSets");
                });

            modelBuilder.Entity("ApplicationModels.Models.GeneratedApplicationPlaylistSourcePlaylist", b =>
                {
                    b.Property<int>("ApplicationPlaylistId");

                    b.Property<string>("SourcePlaylistId");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("ApplicationPlaylistId", "SourcePlaylistId");

                    b.ToTable("GeneratedApplicationPlaylistSourcePlaylists");
                });

            modelBuilder.Entity("ApplicationModels.Models.GeneratedApplicationVideoSourceCampaign", b =>
                {
                    b.Property<string>("CampaignId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("UpdateDate");

                    b.Property<int>("VideoId");

                    b.HasKey("CampaignId");

                    b.HasIndex("VideoId");

                    b.ToTable("GeneratedApplicationVideoSourceCampaigns");
                });

            modelBuilder.Entity("ApplicationModels.Models.GeneratedApplicationVideoSourceVideo", b =>
                {
                    b.Property<string>("SourceVideoId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApplicationVideoId");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("SourceVideoId");

                    b.HasIndex("ApplicationVideoId");

                    b.ToTable("GeneratedApplicationVideoSourceVideos");
                });

            modelBuilder.Entity("ApplicationModels.Models.Metadata.JobTrace", b =>
                {
                    b.Property<string>("Table");

                    b.Property<string>("JobName");

                    b.Property<DateTime>("StartTime");

                    b.Property<DateTime>("EndTime");

                    b.Property<string>("GitCommitHash");

                    b.Property<string>("modifications")
                        .HasColumnName("Modifications")
                        .HasColumnType("jsonb");

                    b.HasKey("Table", "JobName", "StartTime");

                    b.ToTable("JobTraces");
                });

            modelBuilder.Entity("ApplicationModels.Models.SourceAd", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdSetId");

                    b.Property<string>("CampaignId");

                    b.Property<string>("Platform");

                    b.Property<string>("Title");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("VideoId");

                    b.HasKey("Id");

                    b.HasIndex("AdSetId");

                    b.HasIndex("CampaignId");

                    b.HasIndex("VideoId");

                    b.ToTable("SourceAds");
                });

            modelBuilder.Entity("ApplicationModels.Models.SourceAdMetric", b =>
                {
                    b.Property<string>("AdId");

                    b.Property<DateTime>("EventDate");

                    b.Property<int>("Clicks");

                    b.Property<double>("Cost");

                    b.Property<double>("CostPerClick");

                    b.Property<double>("CostPerEmailCapture");

                    b.Property<double>("CostPerEngagement");

                    b.Property<double>("CostPerImpression");

                    b.Property<double>("CostPerView");

                    b.Property<int?>("EmailCapture");

                    b.Property<int?>("Engagements");

                    b.Property<int>("Impressions");

                    b.Property<int?>("Reach");

                    b.Property<int>("Views");

                    b.HasKey("AdId", "EventDate");

                    b.ToTable("SourceAdMetrics");
                });

            modelBuilder.Entity("ApplicationModels.Models.SourceAdSet", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Definition")
                        .HasColumnType("jsonb");

                    b.Property<string[]>("ExcludeAudience")
                        .HasColumnType("text[]");

                    b.Property<string[]>("IncludeAudience")
                        .HasColumnType("text[]");

                    b.Property<string>("Platform");

                    b.Property<string>("Title");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("Id");

                    b.ToTable("SourceAdSets");
                });

            modelBuilder.Entity("ApplicationModels.Models.SourceAudience", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Definition")
                        .HasColumnType("jsonb");

                    b.Property<string>("Platform");

                    b.Property<string>("Title");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("Id");

                    b.ToTable("SourceAudiences");
                });

            modelBuilder.Entity("ApplicationModels.Models.SourceCampaign", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Objective");

                    b.Property<string>("Platform");

                    b.Property<DateTime>("StartTime");

                    b.Property<string>("Status");

                    b.Property<DateTime>("StopTime");

                    b.Property<string>("Title");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("Id");

                    b.ToTable("SourceCampaigns");
                });

            modelBuilder.Entity("ApplicationModels.Models.SourceDeltaEncodedVideoMetric", b =>
                {
                    b.Property<string>("VideoId");

                    b.Property<DateTime>("StartDate");

                    b.Property<DateTime>("EndDate");

                    b.Property<long?>("ImpressionsCount");

                    b.HasKey("VideoId", "StartDate");

                    b.ToTable("SourceDeltaEncodedVideoMetrics");
                });

            modelBuilder.Entity("ApplicationModels.Models.SourcePlaylist", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("Platform");

                    b.Property<string>("ThumbnailUrl");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("Id");

                    b.ToTable("SourcePlaylists");
                });

            modelBuilder.Entity("ApplicationModels.Models.SourcePlaylistSourceVideo", b =>
                {
                    b.Property<string>("VideoId");

                    b.Property<string>("PlaylistId");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("VideoId", "PlaylistId");

                    b.HasIndex("PlaylistId");

                    b.ToTable("SourcePlaylistSourceVideos");
                });

            modelBuilder.Entity("ApplicationModels.Models.SourceVideo", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Platform");

                    b.Property<DateTime>("PublishedAt");

                    b.Property<string>("SourceUrl");

                    b.Property<string>("ThumbnailUrl");

                    b.Property<string>("Title");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<double>("VideoLength");

                    b.HasKey("Id");

                    b.ToTable("SourceVideos");
                });

            modelBuilder.Entity("ApplicationModels.Models.SourceVideoDemographicMetric", b =>
                {
                    b.Property<string>("VideoId");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Gender");

                    b.Property<string>("AgeGroup");

                    b.Property<DateTime>("EndDate");

                    b.Property<double?>("TotalViewCount");

                    b.Property<double?>("TotalViewTime");

                    b.Property<double?>("ViewerPercentage");

                    b.HasKey("VideoId", "StartDate", "Gender", "AgeGroup");

                    b.ToTable("SourceVideoDemographicMetrics");
                });

            modelBuilder.Entity("ApplicationModels.Models.SourceVideoMetric", b =>
                {
                    b.Property<string>("VideoId");

                    b.Property<DateTime>("EventDate");

                    b.Property<long?>("CommentCount");

                    b.Property<long?>("DislikeCount");

                    b.Property<long?>("LikeCount");

                    b.Property<long?>("ShareCount");

                    b.Property<long?>("ViewCount");

                    b.Property<long?>("ViewTime");

                    b.HasKey("VideoId", "EventDate");

                    b.ToTable("SourceVideoMetrics");
                });

            modelBuilder.Entity("ApplicationModels.Models.UserApplicationPersonaVersionSourceAdSet", b =>
                {
                    b.Property<string>("AdSetId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PersonaVersionId");

                    b.Property<bool>("Suppress");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("AdSetId");

                    b.HasIndex("PersonaVersionId");

                    b.ToTable("UserApplicationPersonaVersionSourceAdSets");
                });

            modelBuilder.Entity("ApplicationModels.Models.UserApplicationVideoSourceCampaign", b =>
                {
                    b.Property<string>("CampaignId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Suppress");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<int>("VideoId");

                    b.HasKey("CampaignId");

                    b.HasIndex("VideoId");

                    b.ToTable("UserApplicationVideoSourceCampaigns");
                });

            modelBuilder.Entity("ApplicationModels.Models.UserApplicationVideoSourceVideo", b =>
                {
                    b.Property<string>("SourceVideoId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApplicationVideoId");

                    b.Property<bool>("Suppress");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("SourceVideoId");

                    b.HasIndex("ApplicationVideoId");

                    b.ToTable("UserApplicationVideoSourceVideos");
                });

            modelBuilder.Entity("Common.Logging.Models.RuntimeLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Data")
                        .HasColumnType("jsonb");

                    b.Property<string>("Exception");

                    b.Property<string>("Level");

                    b.Property<string>("Message");

                    b.Property<string>("Name");

                    b.Property<DateTime>("When");

                    b.HasKey("Id");

                    b.ToTable("RuntimeLog");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ApplicationModels.Models.ApplicationMetaTag", b =>
                {
                    b.HasOne("ApplicationModels.Models.ApplicationMetaTagType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationModels.Models.ApplicationPersonaVersion", b =>
                {
                    b.HasOne("ApplicationModels.Models.ApplicationPersona", "Persona")
                        .WithMany()
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationModels.Models.ApplicationPersonaVersionSourceAdSet", b =>
                {
                    b.HasOne("ApplicationModels.Models.ApplicationPersonaVersion", "PersonaVersion")
                        .WithMany()
                        .HasForeignKey("PersonaVersionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationModels.Models.ApplicationPlaylistApplicationVideo", b =>
                {
                    b.HasOne("ApplicationModels.Models.ApplicationPlaylist", "ApplicationPlaylist")
                        .WithMany()
                        .HasForeignKey("ApplicationPlaylistId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ApplicationModels.Models.ApplicationVideo", "ApplicationVideo")
                        .WithMany()
                        .HasForeignKey("ApplicationVideoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationModels.Models.ApplicationVideoApplicationGenericTag", b =>
                {
                    b.HasOne("ApplicationModels.Models.ApplicationGenericTag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ApplicationModels.Models.ApplicationVideo", "Video")
                        .WithMany()
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationModels.Models.ApplicationVideoApplicationMetaTag", b =>
                {
                    b.HasOne("ApplicationModels.Models.ApplicationMetaTag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ApplicationModels.Models.ApplicationMetaTagType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ApplicationModels.Models.ApplicationVideo", "Video")
                        .WithMany()
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationModels.Models.ApplicationVideoSourceCampaign", b =>
                {
                    b.HasOne("ApplicationModels.Models.ApplicationVideo", "Video")
                        .WithMany()
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationModels.Models.ApplicationVideoSourceVideo", b =>
                {
                    b.HasOne("ApplicationModels.Models.ApplicationVideo", "ApplicationVideo")
                        .WithMany()
                        .HasForeignKey("ApplicationVideoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationModels.Models.GeneratedApplicationPersonaVersionSourceAdSet", b =>
                {
                    b.HasOne("ApplicationModels.Models.ApplicationPersonaVersion", "PersonaVersion")
                        .WithMany()
                        .HasForeignKey("PersonaVersionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationModels.Models.GeneratedApplicationPlaylistSourcePlaylist", b =>
                {
                    b.HasOne("ApplicationModels.Models.ApplicationPlaylist", "ApplicationPlaylist")
                        .WithMany()
                        .HasForeignKey("ApplicationPlaylistId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationModels.Models.GeneratedApplicationVideoSourceCampaign", b =>
                {
                    b.HasOne("ApplicationModels.Models.ApplicationVideo", "Video")
                        .WithMany()
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationModels.Models.GeneratedApplicationVideoSourceVideo", b =>
                {
                    b.HasOne("ApplicationModels.Models.ApplicationVideo", "ApplicationVideo")
                        .WithMany()
                        .HasForeignKey("ApplicationVideoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationModels.Models.SourceAd", b =>
                {
                    b.HasOne("ApplicationModels.Models.SourceAdSet", "AdSet")
                        .WithMany()
                        .HasForeignKey("AdSetId");

                    b.HasOne("ApplicationModels.Models.SourceCampaign", "Campaign")
                        .WithMany()
                        .HasForeignKey("CampaignId");

                    b.HasOne("ApplicationModels.Models.SourceVideo", "Video")
                        .WithMany()
                        .HasForeignKey("VideoId");
                });

            modelBuilder.Entity("ApplicationModels.Models.SourceAdMetric", b =>
                {
                    b.HasOne("ApplicationModels.Models.SourceAd", "Ad")
                        .WithMany()
                        .HasForeignKey("AdId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationModels.Models.SourceDeltaEncodedVideoMetric", b =>
                {
                    b.HasOne("ApplicationModels.Models.SourceVideo", "Video")
                        .WithMany()
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationModels.Models.SourcePlaylistSourceVideo", b =>
                {
                    b.HasOne("ApplicationModels.Models.SourcePlaylist", "Playlist")
                        .WithMany("PlaylistVideos")
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ApplicationModels.Models.SourceVideo", "Video")
                        .WithMany("PlaylistVideos")
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationModels.Models.SourceVideoDemographicMetric", b =>
                {
                    b.HasOne("ApplicationModels.Models.SourceVideo", "Video")
                        .WithMany()
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationModels.Models.SourceVideoMetric", b =>
                {
                    b.HasOne("ApplicationModels.Models.SourceVideo", "Video")
                        .WithMany()
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationModels.Models.UserApplicationPersonaVersionSourceAdSet", b =>
                {
                    b.HasOne("ApplicationModels.Models.ApplicationPersonaVersion", "PersonaVersion")
                        .WithMany()
                        .HasForeignKey("PersonaVersionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationModels.Models.UserApplicationVideoSourceCampaign", b =>
                {
                    b.HasOne("ApplicationModels.Models.ApplicationVideo", "Video")
                        .WithMany()
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationModels.Models.UserApplicationVideoSourceVideo", b =>
                {
                    b.HasOne("ApplicationModels.Models.ApplicationVideo", "ApplicationVideo")
                        .WithMany()
                        .HasForeignKey("ApplicationVideoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ApplicationModels.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ApplicationModels.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ApplicationModels.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ApplicationModels.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
