using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Context.Migrations
{
    /// <inheritdoc />
    public partial class moha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$rbShhOTE78tJfVZhTNT8WekuZnLqbb2E4/cSLwtUWmgjBkEmndI2u");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$KQWhF7TPcYocDukz8RJnDOBSsyvX3Af9l8JnmmdZEQy3IPt9MAyDq");
        }
    }
}
