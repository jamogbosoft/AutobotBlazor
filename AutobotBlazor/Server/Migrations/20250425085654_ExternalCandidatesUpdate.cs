using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutobotBlazor.Server.Migrations
{
    /// <inheritdoc />
    public partial class ExternalCandidatesUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ExamTypes_HostIPId",
                table: "ExamTypes");

            migrationBuilder.DropIndex(
                name: "IX_ExamTimes_HostIPId",
                table: "ExamTimes");

            migrationBuilder.RenameColumn(
                name: "ip",
                table: "HostIPs",
                newName: "Ip");

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "HostIPs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "HostIPs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "StartTime",
                table: "CandidateResponses",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<string>(
                name: "EndTime",
                table: "CandidateResponses",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<string>(
                name: "Duration",
                table: "CandidateResponses",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AddColumn<bool>(
                name: "Bvm",
                table: "CandidateResponses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "BvmStatus",
                table: "CandidateResponses",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Connected",
                table: "CandidateResponses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "CandidateResponses",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CandidateResponses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "CandidateResponses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "TimedOut",
                table: "CandidateResponses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Timestamp",
                table: "CandidateResponses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ExamTypes_HostIPId",
                table: "ExamTypes",
                column: "HostIPId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamTimes_HostIPId",
                table: "ExamTimes",
                column: "HostIPId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ExamTypes_HostIPId",
                table: "ExamTypes");

            migrationBuilder.DropIndex(
                name: "IX_ExamTimes_HostIPId",
                table: "ExamTimes");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "HostIPs");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "HostIPs");

            migrationBuilder.DropColumn(
                name: "Bvm",
                table: "CandidateResponses");

            migrationBuilder.DropColumn(
                name: "BvmStatus",
                table: "CandidateResponses");

            migrationBuilder.DropColumn(
                name: "Connected",
                table: "CandidateResponses");

            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "CandidateResponses");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CandidateResponses");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "CandidateResponses");

            migrationBuilder.DropColumn(
                name: "TimedOut",
                table: "CandidateResponses");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "CandidateResponses");

            migrationBuilder.RenameColumn(
                name: "Ip",
                table: "HostIPs",
                newName: "ip");

            migrationBuilder.AlterColumn<string>(
                name: "StartTime",
                table: "CandidateResponses",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "EndTime",
                table: "CandidateResponses",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Duration",
                table: "CandidateResponses",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.CreateIndex(
                name: "IX_ExamTypes_HostIPId",
                table: "ExamTypes",
                column: "HostIPId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExamTimes_HostIPId",
                table: "ExamTimes",
                column: "HostIPId",
                unique: true);
        }
    }
}
