using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Albergue_aspnet_DAS.Migrations
{
    /// <inheritdoc />
    public partial class asd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_DISTRITOS",
                columns: table => new
                {
                    id_dist = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion_dist = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    estado = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TB_DISTR__972B439DCE608B8D", x => x.id_dist);
                });

            migrationBuilder.CreateTable(
                name: "TB_PROVINCIAS",
                columns: table => new
                {
                    id_prov = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion_prov = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    estado = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TB_PROVI__0DA3485D97828659", x => x.id_prov);
                });

            migrationBuilder.CreateTable(
                name: "TB_RAZA_MASCOTA",
                columns: table => new
                {
                    id_raz_mas = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion_raz_mas = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TB_RAZA___7290F9FDDD9B4FF3", x => x.id_raz_mas);
                });

            migrationBuilder.CreateTable(
                name: "TB_ROLES_USUARIO",
                columns: table => new
                {
                    id_rol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_rol = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TB_ROLES__6ABCB5E073930C9B", x => x.id_rol);
                });

            migrationBuilder.CreateTable(
                name: "TB_TIPO_MASCOTA",
                columns: table => new
                {
                    id_tip_mas = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion_tip_mas = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TB_TIPO___1904A0A36E0CBF11", x => x.id_tip_mas);
                });

            migrationBuilder.CreateTable(
                name: "TB_ALBERGUE",
                columns: table => new
                {
                    id_alb = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_alb = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    direccion_alb = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    id_dist = table.Column<int>(type: "int", nullable: true),
                    id_prov = table.Column<int>(type: "int", nullable: true),
                    capacidad_alb = table.Column<int>(type: "int", nullable: true),
                    correo_alb = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TB_ALBER__6BE93B0C3C2AB683", x => x.id_alb);
                    table.ForeignKey(
                        name: "Fk_ADIST_CODIGO",
                        column: x => x.id_dist,
                        principalTable: "TB_DISTRITOS",
                        principalColumn: "id_dist");
                    table.ForeignKey(
                        name: "Fk_APROV_CODIGO",
                        column: x => x.id_prov,
                        principalTable: "TB_PROVINCIAS",
                        principalColumn: "id_prov");
                });

            migrationBuilder.CreateTable(
                name: "TB_USUARIOS",
                columns: table => new
                {
                    id_us = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_us = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    correo_us = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    clave_us = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    id_rol = table.Column<int>(type: "int", nullable: true),
                    imagen_us = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TB_USUAR__014848A59A0E52CB", x => x.id_us);
                    table.ForeignKey(
                        name: "Fk_USUID_ROL_CODIGO",
                        column: x => x.id_rol,
                        principalTable: "TB_ROLES_USUARIO",
                        principalColumn: "id_rol");
                });

            migrationBuilder.CreateTable(
                name: "TB_MASCOTA",
                columns: table => new
                {
                    id_mas = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_mas = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    id_tip_mas = table.Column<int>(type: "int", nullable: false),
                    id_raz_mas = table.Column<int>(type: "int", nullable: false),
                    sexo_mas = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    tamaño_mas = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    color_mas = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    fecha_nac_mas = table.Column<DateOnly>(type: "date", nullable: true),
                    edad_mas = table.Column<int>(type: "int", nullable: true, computedColumnSql: "(datediff(year,[fecha_nac_mas],getdate()))", stored: false),
                    imagen_mas = table.Column<byte[]>(type: "image", nullable: true),
                    estado = table.Column<bool>(type: "bit", nullable: false),
                    id_alb = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TB_MASCO__6C8AD5B02239F910", x => x.id_mas);
                    table.ForeignKey(
                        name: "Fk_MTIP_MAS_CODIGO",
                        column: x => x.id_tip_mas,
                        principalTable: "TB_TIPO_MASCOTA",
                        principalColumn: "id_tip_mas",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_Mraz_ALB_CODIGO",
                        column: x => x.id_alb,
                        principalTable: "TB_ALBERGUE",
                        principalColumn: "id_alb",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_Mraz_MAs_CODIGO",
                        column: x => x.id_raz_mas,
                        principalTable: "TB_RAZA_MASCOTA",
                        principalColumn: "id_raz_mas",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_ADOPCION",
                columns: table => new
                {
                    id_adop = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_us = table.Column<int>(type: "int", nullable: true),
                    dni_us = table.Column<string>(type: "char(8)", unicode: false, fixedLength: true, maxLength: 8, nullable: true),
                    telefono_us = table.Column<string>(type: "varchar(9)", unicode: false, maxLength: 9, nullable: true),
                    direccion_us = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    id_mas = table.Column<int>(type: "int", nullable: true),
                    fecha_adop = table.Column<DateOnly>(type: "date", nullable: true),
                    obs1_adop = table.Column<string>(type: "text", nullable: true),
                    obs2_adop = table.Column<string>(type: "text", nullable: true),
                    obs3_adop = table.Column<string>(type: "text", nullable: true),
                    obs4_adop = table.Column<string>(type: "text", nullable: true),
                    obs5_adop = table.Column<string>(type: "text", nullable: true),
                    obs6_adop = table.Column<string>(type: "text", nullable: true),
                    obs7_adop = table.Column<string>(type: "text", nullable: true),
                    obs8_adop = table.Column<string>(type: "text", nullable: true),
                    obs9_adop = table.Column<string>(type: "text", nullable: true),
                    obs10_adop = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TB_ADOPC__B431877B7ECAC70A", x => x.id_adop);
                    table.ForeignKey(
                        name: "Fk_ADOPID_MAS_CODIGO",
                        column: x => x.id_mas,
                        principalTable: "TB_MASCOTA",
                        principalColumn: "id_mas");
                    table.ForeignKey(
                        name: "Fk_ADOPID_USU_CODIGO",
                        column: x => x.id_us,
                        principalTable: "TB_USUARIOS",
                        principalColumn: "id_us");
                });

            migrationBuilder.CreateTable(
                name: "TB_HISTORIAL_ATENCION_MASCOTA",
                columns: table => new
                {
                    id_his = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_mas = table.Column<int>(type: "int", nullable: false),
                    nombre_med = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    apellidos_med = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    cod_colegiatura = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    consulta_medica = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    observacion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TB_HISTO__D6EA82DD553CD8C8", x => x.id_his);
                    table.ForeignKey(
                        name: "Fk_HIS_CODIGO",
                        column: x => x.id_mas,
                        principalTable: "TB_MASCOTA",
                        principalColumn: "id_mas");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ADOPCION_id_mas",
                table: "TB_ADOPCION",
                column: "id_mas");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ADOPCION_id_us",
                table: "TB_ADOPCION",
                column: "id_us");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ALBERGUE_id_dist",
                table: "TB_ALBERGUE",
                column: "id_dist");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ALBERGUE_id_prov",
                table: "TB_ALBERGUE",
                column: "id_prov");

            migrationBuilder.CreateIndex(
                name: "IX_TB_HISTORIAL_ATENCION_MASCOTA_id_mas",
                table: "TB_HISTORIAL_ATENCION_MASCOTA",
                column: "id_mas");

            migrationBuilder.CreateIndex(
                name: "IX_TB_MASCOTA_id_alb",
                table: "TB_MASCOTA",
                column: "id_alb");

            migrationBuilder.CreateIndex(
                name: "IX_TB_MASCOTA_id_raz_mas",
                table: "TB_MASCOTA",
                column: "id_raz_mas");

            migrationBuilder.CreateIndex(
                name: "IX_TB_MASCOTA_id_tip_mas",
                table: "TB_MASCOTA",
                column: "id_tip_mas");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USUARIOS_id_rol",
                table: "TB_USUARIOS",
                column: "id_rol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ADOPCION");

            migrationBuilder.DropTable(
                name: "TB_HISTORIAL_ATENCION_MASCOTA");

            migrationBuilder.DropTable(
                name: "TB_USUARIOS");

            migrationBuilder.DropTable(
                name: "TB_MASCOTA");

            migrationBuilder.DropTable(
                name: "TB_ROLES_USUARIO");

            migrationBuilder.DropTable(
                name: "TB_TIPO_MASCOTA");

            migrationBuilder.DropTable(
                name: "TB_ALBERGUE");

            migrationBuilder.DropTable(
                name: "TB_RAZA_MASCOTA");

            migrationBuilder.DropTable(
                name: "TB_DISTRITOS");

            migrationBuilder.DropTable(
                name: "TB_PROVINCIAS");
        }
    }
}
