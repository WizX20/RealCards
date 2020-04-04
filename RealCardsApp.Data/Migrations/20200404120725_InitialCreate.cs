using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealCardsApp.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deck",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    ShuffleOnGameStart = table.Column<bool>(nullable: false),
                    ShuffleOnDeckMerge = table.Column<bool>(nullable: false),
                    HasDiscardPile = table.Column<bool>(nullable: false),
                    ShuffleDiscardPile = table.Column<bool>(nullable: false),
                    GameId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deck", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deck_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    DeckId = table.Column<int>(nullable: true),
                    DeckId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Card_Deck_DeckId",
                        column: x => x.DeckId,
                        principalTable: "Deck",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Card_Deck_DeckId1",
                        column: x => x.DeckId1,
                        principalTable: "Deck",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CardProperty",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    CardId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardProperty_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CardType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    CardId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardType_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    AvatarUrl = table.Column<string>(nullable: true),
                    GameInstanceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameInstances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GameId = table.Column<int>(nullable: true),
                    ActivePlayerId = table.Column<int>(nullable: true),
                    TurnCount = table.Column<int>(nullable: false),
                    GameStartDateTime = table.Column<DateTime>(nullable: false),
                    GameEndDateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameInstances_Player_ActivePlayerId",
                        column: x => x.ActivePlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameInstances_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Card_DeckId",
                table: "Card",
                column: "DeckId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_DeckId1",
                table: "Card",
                column: "DeckId1");

            migrationBuilder.CreateIndex(
                name: "IX_CardProperty_CardId",
                table: "CardProperty",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_CardType_CardId",
                table: "CardType",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Deck_GameId",
                table: "Deck",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameInstances_ActivePlayerId",
                table: "GameInstances",
                column: "ActivePlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_GameInstances_GameId",
                table: "GameInstances",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_GameInstanceId",
                table: "Player",
                column: "GameInstanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_GameInstances_GameInstanceId",
                table: "Player",
                column: "GameInstanceId",
                principalTable: "GameInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameInstances_Games_GameId",
                table: "GameInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_GameInstances_Player_ActivePlayerId",
                table: "GameInstances");

            migrationBuilder.DropTable(
                name: "CardProperty");

            migrationBuilder.DropTable(
                name: "CardType");

            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "Deck");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "GameInstances");
        }
    }
}
