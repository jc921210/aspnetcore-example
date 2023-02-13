﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Empresa.Proyecto.Infra.Migrations
{
    public partial class newEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailTranslation");

            migrationBuilder.DropTable(
                name: "EmailNotifications");

            migrationBuilder.CreateTable(
                name: "NewEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    OptionId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewEntity_SimpleEntity_OptionId",
                        column: x => x.OptionId,
                        principalTable: "SimpleEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewEntity_OptionId",
                table: "NewEntity",
                column: "OptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewEntity");

            migrationBuilder.CreateTable(
                name: "EmailNotifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailNotifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailTranslation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmailNotificationId = table.Column<int>(type: "int", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailTranslation_EmailNotifications_EmailNotificationId",
                        column: x => x.EmailNotificationId,
                        principalTable: "EmailNotifications",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmailTranslation_EmailNotificationId",
                table: "EmailTranslation",
                column: "EmailNotificationId");
        }
    }
}
