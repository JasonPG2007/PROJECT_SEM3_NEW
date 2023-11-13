using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ObjectBussiness.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    CandidateID = table.Column<int>(type: "int", nullable: false),
                    CandidateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hometown = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.CandidateID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Testes",
                columns: table => new
                {
                    TestID = table.Column<int>(type: "int", nullable: false),
                    QuestionID = table.Column<int>(type: "int", nullable: false),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    DateCreateTest = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TestDay = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testes", x => x.TestID);
                });

            migrationBuilder.CreateTable(
                name: "ExamRegister",
                columns: table => new
                {
                    ExamRegisterID = table.Column<int>(type: "int", nullable: false),
                    CandidateID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamRegister", x => x.ExamRegisterID);
                    table.ForeignKey(
                        name: "FK_ExamRegister_Candidates_CandidateID",
                        column: x => x.CandidateID,
                        principalTable: "Candidates",
                        principalColumn: "CandidateID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionID = table.Column<int>(type: "int", nullable: false),
                    TestID = table.Column<int>(type: "int", nullable: false),
                    QuestionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrectAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Point = table.Column<double>(type: "float", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionID);
                    table.ForeignKey(
                        name: "FK_Questions_Testes_TestID",
                        column: x => x.TestID,
                        principalTable: "Testes",
                        principalColumn: "TestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResultOfCandidates",
                columns: table => new
                {
                    ResultOfCandidateID = table.Column<int>(type: "int", nullable: false),
                    TestID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultOfCandidates", x => x.ResultOfCandidateID);
                    table.ForeignKey(
                        name: "FK_ResultOfCandidates_Testes_TestID",
                        column: x => x.TestID,
                        principalTable: "Testes",
                        principalColumn: "TestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rounds",
                columns: table => new
                {
                    RoundID = table.Column<int>(type: "int", nullable: false),
                    TestID = table.Column<int>(type: "int", nullable: false),
                    RoundNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rounds", x => x.RoundID);
                    table.ForeignKey(
                        name: "FK_Rounds_Testes_TestID",
                        column: x => x.TestID,
                        principalTable: "Testes",
                        principalColumn: "TestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    TestID = table.Column<int>(type: "int", nullable: false),
                    ExamRegisterID = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountID);
                    table.ForeignKey(
                        name: "FK_Accounts_ExamRegister_ExamRegisterID",
                        column: x => x.ExamRegisterID,
                        principalTable: "ExamRegister",
                        principalColumn: "ExamRegisterID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_Testes_TestID",
                        column: x => x.TestID,
                        principalTable: "Testes",
                        principalColumn: "TestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Elects",
                columns: table => new
                {
                    ElectID = table.Column<int>(type: "int", nullable: false),
                    ResultOfCandidateID = table.Column<int>(type: "int", nullable: false),
                    ResultElect = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elects", x => x.ElectID);
                    table.ForeignKey(
                        name: "FK_Elects_ResultOfCandidates_ResultOfCandidateID",
                        column: x => x.ResultOfCandidateID,
                        principalTable: "ResultOfCandidates",
                        principalColumn: "ResultOfCandidateID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Decentralizations",
                columns: table => new
                {
                    DecentralizationID = table.Column<int>(type: "int", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    RoleGrantDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decentralizations", x => x.DecentralizationID);
                    table.ForeignKey(
                        name: "FK_Decentralizations_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Decentralizations_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    NewsID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contents = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    DateSubmitted = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.NewsID);
                    table.ForeignKey(
                        name: "FK_News_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleID", "RoleName" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Candidate" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ExamRegisterID",
                table: "Accounts",
                column: "ExamRegisterID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_TestID",
                table: "Accounts",
                column: "TestID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Decentralizations_AccountID",
                table: "Decentralizations",
                column: "AccountID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Decentralizations_RoleID",
                table: "Decentralizations",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Elects_ResultOfCandidateID",
                table: "Elects",
                column: "ResultOfCandidateID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExamRegister_CandidateID",
                table: "ExamRegister",
                column: "CandidateID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_News_AccountID",
                table: "News",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TestID",
                table: "Questions",
                column: "TestID");

            migrationBuilder.CreateIndex(
                name: "IX_ResultOfCandidates_TestID",
                table: "ResultOfCandidates",
                column: "TestID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_TestID",
                table: "Rounds",
                column: "TestID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Decentralizations");

            migrationBuilder.DropTable(
                name: "Elects");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Rounds");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "ResultOfCandidates");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "ExamRegister");

            migrationBuilder.DropTable(
                name: "Testes");

            migrationBuilder.DropTable(
                name: "Candidates");
        }
    }
}
