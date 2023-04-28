using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademyApi.Migrations
{
    /// <inheritdoc />
    public partial class initial_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnswerStudents",
                columns: table => new
                {
                    IdAnswerStudent = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerStudent = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerStudents", x => x.IdAnswerStudent);
                });

            migrationBuilder.CreateTable(
                name: "ProfesionalSchools",
                columns: table => new
                {
                    IdProfesionalSchool = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfesionalSchools", x => x.IdProfesionalSchool);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    IdTeacher = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.IdTeacher);
                });

            migrationBuilder.CreateTable(
                name: "Careers",
                columns: table => new
                {
                    IdCareer = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCareer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdProfesionalSchool = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Careers", x => x.IdCareer);
                    table.ForeignKey(
                        name: "FK_Careers_ProfesionalSchools_IdProfesionalSchool",
                        column: x => x.IdProfesionalSchool,
                        principalTable: "ProfesionalSchools",
                        principalColumn: "IdProfesionalSchool",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    IdCourse = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCourse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTeacher = table.Column<long>(type: "bigint", nullable: false),
                    tCareerIdCareer = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.IdCourse);
                    table.ForeignKey(
                        name: "FK_Courses_Careers_tCareerIdCareer",
                        column: x => x.tCareerIdCareer,
                        principalTable: "Careers",
                        principalColumn: "IdCareer");
                    table.ForeignKey(
                        name: "FK_Courses_Teachers_IdTeacher",
                        column: x => x.IdTeacher,
                        principalTable: "Teachers",
                        principalColumn: "IdTeacher",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Examns",
                columns: table => new
                {
                    IdExam = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NroPreguntas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCourse = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examns", x => x.IdExam);
                    table.ForeignKey(
                        name: "FK_Examns_Courses_IdCourse",
                        column: x => x.IdCourse,
                        principalTable: "Courses",
                        principalColumn: "IdCourse",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    IdStudent = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCourse = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.IdStudent);
                    table.ForeignKey(
                        name: "FK_Students_Courses_IdCourse",
                        column: x => x.IdCourse,
                        principalTable: "Courses",
                        principalColumn: "IdCourse",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    IdQuestion = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tema = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdExam = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.IdQuestion);
                    table.ForeignKey(
                        name: "FK_Questions_Examns_IdExam",
                        column: x => x.IdExam,
                        principalTable: "Examns",
                        principalColumn: "IdExam",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alternatives",
                columns: table => new
                {
                    IdAlternative = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alternative = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsTheAnswer = table.Column<bool>(type: "bit", nullable: false),
                    IdQuestion = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alternatives", x => x.IdAlternative);
                    table.ForeignKey(
                        name: "FK_Alternatives_Questions_IdQuestion",
                        column: x => x.IdQuestion,
                        principalTable: "Questions",
                        principalColumn: "IdQuestion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tAnswerStudenttQuestions",
                columns: table => new
                {
                    AnswerStudentsIdAnswerStudent = table.Column<long>(type: "bigint", nullable: false),
                    QuestionsIdQuestion = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tAnswerStudenttQuestions", x => new { x.AnswerStudentsIdAnswerStudent, x.QuestionsIdQuestion });
                    table.ForeignKey(
                        name: "FK_tAnswerStudenttQuestions_AnswerStudents_AnswerStudentsIdAnswerStudent",
                        column: x => x.AnswerStudentsIdAnswerStudent,
                        principalTable: "AnswerStudents",
                        principalColumn: "IdAnswerStudent",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tAnswerStudenttQuestions_Questions_QuestionsIdQuestion",
                        column: x => x.QuestionsIdQuestion,
                        principalTable: "Questions",
                        principalColumn: "IdQuestion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alternatives_IdQuestion",
                table: "Alternatives",
                column: "IdQuestion");

            migrationBuilder.CreateIndex(
                name: "IX_Careers_IdProfesionalSchool",
                table: "Careers",
                column: "IdProfesionalSchool");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_IdTeacher",
                table: "Courses",
                column: "IdTeacher");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_tCareerIdCareer",
                table: "Courses",
                column: "tCareerIdCareer");

            migrationBuilder.CreateIndex(
                name: "IX_Examns_IdCourse",
                table: "Examns",
                column: "IdCourse");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_IdExam",
                table: "Questions",
                column: "IdExam");

            migrationBuilder.CreateIndex(
                name: "IX_Students_IdCourse",
                table: "Students",
                column: "IdCourse");

            migrationBuilder.CreateIndex(
                name: "IX_tAnswerStudenttQuestions_QuestionsIdQuestion",
                table: "tAnswerStudenttQuestions",
                column: "QuestionsIdQuestion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alternatives");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "tAnswerStudenttQuestions");

            migrationBuilder.DropTable(
                name: "AnswerStudents");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Examns");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Careers");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "ProfesionalSchools");
        }
    }
}
