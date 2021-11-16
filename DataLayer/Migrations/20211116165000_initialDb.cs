using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class initialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleMakes",
                columns: table => new
                {
                    MakeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleMakes", x => x.MakeId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    RegistrationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    VehicleTypeTypeId = table.Column<int>(type: "int", nullable: true),
                    MakeId = table.Column<int>(type: "int", nullable: false),
                    VehicleMakeMakeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.RegistrationId);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleMakes_VehicleMakeMakeId",
                        column: x => x.VehicleMakeMakeId,
                        principalTable: "VehicleMakes",
                        principalColumn: "MakeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleTypes_VehicleTypeTypeId",
                        column: x => x.VehicleTypeTypeId,
                        principalTable: "VehicleTypes",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "VehicleMakes",
                columns: new[] { "MakeId", "Description" },
                values: new object[,]
                {
                    { 1, "Volvo" },
                    { 2, "Saab" },
                    { 3, "Honda" },
                    { 4, "Suzuki" }
                });

            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "TypeId", "Description" },
                values: new object[,]
                {
                    { 1, "Car" },
                    { 2, "Bike" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "RegistrationId", "Description", "MakeId", "TypeId", "VehicleMakeMakeId", "VehicleTypeTypeId" },
                values: new object[,]
                {
                    { "AAA111", "Big white volvo car", 1, 1, null, null },
                    { "BBB222", "Green fast Suzuki bike", 4, 2, null, null },
                    { "CCC333", "This is a Saab car", 2, 1, null, null },
                    { "DDD444", "Exclusive Honda bike", 3, 2, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleMakeMakeId",
                table: "Vehicles",
                column: "VehicleMakeMakeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleTypeTypeId",
                table: "Vehicles",
                column: "VehicleTypeTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "VehicleMakes");

            migrationBuilder.DropTable(
                name: "VehicleTypes");
        }
    }
}
