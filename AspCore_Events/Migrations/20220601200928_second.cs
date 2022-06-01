using Microsoft.EntityFrameworkCore.Migrations;

namespace AspCore_Events.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "url",
                table: "Events",
                newName: "URL");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Events",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Events",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "allDay",
                table: "Events",
                newName: "AllDay");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Events",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "start",
                table: "Events",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "end",
                table: "Events",
                newName: "EndDate");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EventLabel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    Label = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLabel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventLabel_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventLabel_EventId",
                table: "EventLabel",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventLabel");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "URL",
                table: "Events",
                newName: "url");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Events",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Events",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "AllDay",
                table: "Events",
                newName: "allDay");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Events",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Events",
                newName: "start");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Events",
                newName: "end");
        }
    }
}
