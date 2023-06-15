using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutobotBlazor.Server.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CandidateResponses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CentreId = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    ExamDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PreviousHostIps = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    SessionRef = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    TotalAttempted = table.Column<int>(type: "int", nullable: false),
                    EndTime = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    StartTime = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateResponses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HostIPs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateResponseId = table.Column<long>(type: "bigint", nullable: false),
                    ip = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HostIPs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HostIPs_CandidateResponses_CandidateResponseId",
                        column: x => x.CandidateResponseId,
                        principalTable: "CandidateResponses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamTimes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HostIPId = table.Column<long>(type: "bigint", nullable: false),
                    date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    time = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamTimes_HostIPs_HostIPId",
                        column: x => x.HostIPId,
                        principalTable: "HostIPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HostIPId = table.Column<long>(type: "bigint", nullable: false),
                    oid = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamTypes_HostIPs_HostIPId",
                        column: x => x.HostIPId,
                        principalTable: "HostIPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExamTimes_HostIPId",
                table: "ExamTimes",
                column: "HostIPId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExamTypes_HostIPId",
                table: "ExamTypes",
                column: "HostIPId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HostIPs_CandidateResponseId",
                table: "HostIPs",
                column: "CandidateResponseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamTimes");

            migrationBuilder.DropTable(
                name: "ExamTypes");

            migrationBuilder.DropTable(
                name: "HostIPs");

            migrationBuilder.DropTable(
                name: "CandidateResponses");
        }
    }
}
