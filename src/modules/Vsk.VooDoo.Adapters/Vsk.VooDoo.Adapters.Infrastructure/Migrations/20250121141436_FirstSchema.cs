using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vsk.VooDoo.Adapters.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FirstSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "adapters");

            migrationBuilder.CreateSequence(
                name: "role_seq",
                schema: "adapters",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "user_seq",
                schema: "adapters",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "User",
                schema: "adapters",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "adapters",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    RoleName = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Role_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "adapters",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Role_UserId",
                schema: "adapters",
                table: "Role",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Role",
                schema: "adapters");

            migrationBuilder.DropTable(
                name: "User",
                schema: "adapters");

            migrationBuilder.DropSequence(
                name: "role_seq",
                schema: "adapters");

            migrationBuilder.DropSequence(
                name: "user_seq",
                schema: "adapters");
        }
    }
}
