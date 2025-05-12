using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Context.Migrations
{
    /// <inheritdoc />
    public partial class lastupdateuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$xsfmz.UMMmoIJ51/Ra2aqudHwpdJbIbQn.fSBDlpARgvPYK1tWOCa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$SnDPSszow3relRbNIro.CeZHeMWKtl2nGbflD/rUhIlwO9KGXiV22");
        }
    }
}
