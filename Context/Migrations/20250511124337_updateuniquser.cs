using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Context.Migrations
{
    /// <inheritdoc />
    public partial class updateuniquser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$SnDPSszow3relRbNIro.CeZHeMWKtl2nGbflD/rUhIlwO9KGXiV22");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$N/lPH/thDgTCX0T.GGezEeDj2j6sRuOP1rUI6zS9oJUV79DAL/0de");
        }
    }
}
