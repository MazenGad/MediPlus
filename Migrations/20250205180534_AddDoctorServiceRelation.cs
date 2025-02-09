using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediPlus.Migrations
{
    /// <inheritdoc />
    public partial class AddDoctorServiceRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_BlogPosts_BlogPostId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Services_ServiceId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_EmergencyCases_Doctors_DoctorId",
                table: "EmergencyCases");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_ServiceId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Doctors");

            migrationBuilder.CreateTable(
                name: "DoctorService",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorService", x => new { x.DoctorId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_DoctorService_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorService_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorService_ServiceId",
                table: "DoctorService",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_BlogPosts_BlogPostId",
                table: "Comments",
                column: "BlogPostId",
                principalTable: "BlogPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmergencyCases_Doctors_DoctorId",
                table: "EmergencyCases",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_BlogPosts_BlogPostId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_EmergencyCases_Doctors_DoctorId",
                table: "EmergencyCases");

            migrationBuilder.DropTable(
                name: "DoctorService");

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_ServiceId",
                table: "Doctors",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_BlogPosts_BlogPostId",
                table: "Comments",
                column: "BlogPostId",
                principalTable: "BlogPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Services_ServiceId",
                table: "Doctors",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmergencyCases_Doctors_DoctorId",
                table: "EmergencyCases",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");
        }
    }
}
