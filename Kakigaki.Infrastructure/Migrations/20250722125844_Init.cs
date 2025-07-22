using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kakigaki.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__categori__3213E83FF96E60E1", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "levels",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__levels__3213E83F91E27F0F", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    google_id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    displayname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    password_hash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    role = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__users__3213E83F0FCF202C", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "lessons",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    content = table.Column<string>(type: "text", nullable: true),
                    audio_url = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: true),
                    level_id = table.Column<int>(type: "int", nullable: true),
                    access_level = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__lessons__3213E83FDE78F204", x => x.id);
                    table.ForeignKey(
                        name: "FK__lessons__categor__4CA06362",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__lessons__level_i__4D94879B",
                        column: x => x.level_id,
                        principalTable: "levels",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "refresh_tokens",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    refresh_token = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    issued_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    expires_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    revoked = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__refresh___3213E83FC32A9AA1", x => x.id);
                    table.ForeignKey(
                        name: "FK__refresh_t__user___49C3F6B7",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user_daily_activity",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    activity_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    lessons_completed = table.Column<int>(type: "int", nullable: true),
                    study_time_minutes = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__user_dai__3213E83F870F6B06", x => x.id);
                    table.ForeignKey(
                        name: "FK__user_dail__user___4BAC3F29",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user_statistics",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    current_streak_days = table.Column<int>(type: "int", nullable: true),
                    longest_streak_days = table.Column<int>(type: "int", nullable: true),
                    total_lessons_completed = table.Column<int>(type: "int", nullable: true),
                    total_study_time_minutes = table.Column<int>(type: "int", nullable: true),
                    last_login_date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__user_sta__3213E83F31FF2295", x => x.id);
                    table.ForeignKey(
                        name: "FK__user_stat__user___4AB81AF0",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "lesson_details",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    lesson_id = table.Column<int>(type: "int", nullable: true),
                    lesson_id_seq = table.Column<int>(type: "int", nullable: true),
                    start_time_seconds = table.Column<int>(type: "int", nullable: true),
                    end_time_seconds = table.Column<int>(type: "int", nullable: true),
                    transcript = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__lesson_d__3213E83FC0250A69", x => x.id);
                    table.ForeignKey(
                        name: "FK__lesson_de__lesso__4E88ABD4",
                        column: x => x.lesson_id,
                        principalTable: "lessons",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "lesson_sessions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    lesson_id = table.Column<int>(type: "int", nullable: true),
                    duration_minutes = table.Column<int>(type: "int", nullable: true),
                    last_sequence = table.Column<int>(type: "int", nullable: true),
                    total_completed_times = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__lesson_s__3213E83FAAE42471", x => x.id);
                    table.ForeignKey(
                        name: "FK__lesson_se__lesso__5165187F",
                        column: x => x.lesson_id,
                        principalTable: "lessons",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__lesson_se__user___5070F446",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "lesson_translations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    lesson_detail_id = table.Column<int>(type: "int", nullable: true),
                    language_code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    translation = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__lesson_t__3213E83F59CFF9CF", x => x.id);
                    table.ForeignKey(
                        name: "FK__lesson_tr__lesso__4F7CD00D",
                        column: x => x.lesson_detail_id,
                        principalTable: "lesson_details",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_lesson_details_lesson_id",
                table: "lesson_details",
                column: "lesson_id");

            migrationBuilder.CreateIndex(
                name: "IX_lesson_sessions_lesson_id",
                table: "lesson_sessions",
                column: "lesson_id");

            migrationBuilder.CreateIndex(
                name: "IX_lesson_sessions_user_id",
                table: "lesson_sessions",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_lesson_translations_lesson_detail_id",
                table: "lesson_translations",
                column: "lesson_detail_id");

            migrationBuilder.CreateIndex(
                name: "IX_lessons_category_id",
                table: "lessons",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_lessons_level_id",
                table: "lessons",
                column: "level_id");

            migrationBuilder.CreateIndex(
                name: "IX_refresh_tokens_user_id",
                table: "refresh_tokens",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_daily_activity_user_id",
                table: "user_daily_activity",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_statistics_user_id",
                table: "user_statistics",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "UQ__users__AB6E6164FEBD02FC",
                table: "users",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lesson_sessions");

            migrationBuilder.DropTable(
                name: "lesson_translations");

            migrationBuilder.DropTable(
                name: "refresh_tokens");

            migrationBuilder.DropTable(
                name: "user_daily_activity");

            migrationBuilder.DropTable(
                name: "user_statistics");

            migrationBuilder.DropTable(
                name: "lesson_details");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "lessons");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "levels");
        }
    }
}
