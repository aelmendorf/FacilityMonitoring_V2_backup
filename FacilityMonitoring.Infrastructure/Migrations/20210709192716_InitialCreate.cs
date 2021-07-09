using Microsoft.EntityFrameworkCore.Migrations;

namespace FacilityMonitoring.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModbusDevices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Port = table.Column<int>(type: "int", nullable: false),
                    SlaveAddress = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BypassAlarms = table.Column<bool>(type: "bit", nullable: false),
                    ReadInterval = table.Column<double>(type: "float", nullable: false),
                    SaveInterval = table.Column<double>(type: "float", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModbusComAddr = table.Column<int>(type: "int", nullable: true),
                    SoftwareMainAddress = table.Column<int>(type: "int", nullable: true),
                    AlarmAddress = table.Column<int>(type: "int", nullable: true),
                    StateAddress = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModbusDevices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sensors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZeroValue = table.Column<double>(type: "float", nullable: false),
                    Slope = table.Column<double>(type: "float", nullable: false),
                    Factor = table.Column<double>(type: "float", nullable: false),
                    Units = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Channels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemChannel = table.Column<int>(type: "int", nullable: false),
                    ChannelAddress_Channel = table.Column<int>(type: "int", nullable: true),
                    ChannelAddress_ModuleSlot = table.Column<int>(type: "int", nullable: true),
                    ModbusAddress_Address = table.Column<int>(type: "int", nullable: true),
                    ModbusAddress_RegisterLength = table.Column<int>(type: "int", nullable: true),
                    ModbusAddress_RegisterType = table.Column<int>(type: "int", nullable: true),
                    Connected = table.Column<bool>(type: "bit", nullable: false),
                    BypassAlert = table.Column<bool>(type: "bit", nullable: false),
                    ModbusDeviceId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentValue = table.Column<double>(type: "float", nullable: true),
                    SensorId = table.Column<int>(type: "int", nullable: true),
                    ChannelState = table.Column<int>(type: "int", nullable: true),
                    StartState = table.Column<int>(type: "int", nullable: true),
                    DiscreteOutput_ChannelState = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Channels_ModbusDevices_ModbusDeviceId",
                        column: x => x.ModbusDeviceId,
                        principalTable: "ModbusDevices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Channels_Sensors_SensorId",
                        column: x => x.SensorId,
                        principalTable: "Sensors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActionOutput",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OutputId = table.Column<int>(type: "int", nullable: true),
                    OnLevel = table.Column<int>(type: "int", nullable: false),
                    OffLevel = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionOutput", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActionOutput_Actions_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Actions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActionOutput_Channels_OutputId",
                        column: x => x.OutputId,
                        principalTable: "Channels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Alerts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlertAction = table.Column<int>(type: "int", nullable: false),
                    Bypass = table.Column<bool>(type: "bit", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    ChannelId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SetPoint = table.Column<double>(type: "float", nullable: true),
                    TriggerOn = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alerts_Channels_ChannelId",
                        column: x => x.ChannelId,
                        principalTable: "Channels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Readings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChannelId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: true),
                    DiscreteChannelReading_Value = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Readings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Readings_Channels_ChannelId",
                        column: x => x.ChannelId,
                        principalTable: "Channels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionOutput_OutputId",
                table: "ActionOutput",
                column: "OutputId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionOutput_OwnerId",
                table: "ActionOutput",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_ChannelId",
                table: "Alerts",
                column: "ChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_Channels_ModbusDeviceId",
                table: "Channels",
                column: "ModbusDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Channels_SensorId",
                table: "Channels",
                column: "SensorId");

            migrationBuilder.CreateIndex(
                name: "IX_Readings_ChannelId",
                table: "Readings",
                column: "ChannelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionOutput");

            migrationBuilder.DropTable(
                name: "Alerts");

            migrationBuilder.DropTable(
                name: "Readings");

            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "Channels");

            migrationBuilder.DropTable(
                name: "ModbusDevices");

            migrationBuilder.DropTable(
                name: "Sensors");
        }
    }
}
