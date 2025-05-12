using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Context.Migrations
{
    /// <inheritdoc />
    public partial class moo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "Email", "Password" },
                values: new object[] { "admin@example.com", "$2a$11$9/OGd3R6Zy50dqzzagPnsewi0LTG2Z8I4KVTOpxYQC3URNO6FN44u" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "Email", "Password" },
                values: new object[] { "admin@ecommerce.com", "$2a$11$IjQcbf4OluCfUfM.dhIl0eTlslaCRy25cJR6HizrJcgG.C4v9XIO." });
        }
    }
}
