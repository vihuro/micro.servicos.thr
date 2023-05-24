using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace THR.OBRA.NOTAS.Migrations
{
    /// <inheritdoc />
    public partial class tabelaUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tab_usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Apelido = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tab_time",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Time = table.Column<string>(type: "text", nullable: false),
                    UsuarioCadastroId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_time", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_time_tab_usuario_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "tab_usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_time_tab_usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "tab_usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tab_nota",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NumeroNota = table.Column<int>(type: "integer", nullable: false),
                    Fornecedor = table.Column<string>(type: "text", nullable: false),
                    ValorTotalNota = table.Column<decimal>(type: "numeric", nullable: false),
                    Cnpj = table.Column<string>(type: "text", nullable: false),
                    DescricaoProdutoServico = table.Column<string>(type: "text", nullable: true),
                    AvulsoFinalidade = table.Column<string>(type: "text", nullable: true),
                    Autorizador = table.Column<string>(type: "text", nullable: false),
                    TipoExportacao = table.Column<string>(type: "text", nullable: false),
                    UsuarioCadastroId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TimeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_nota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_nota_tab_time_TimeId",
                        column: x => x.TimeId,
                        principalTable: "tab_time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_nota_tab_usuario_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "tab_usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_nota_tab_usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "tab_usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tab_parcela",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NumeroParcela = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Vencimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NotaId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsuarioCadastroId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioAlteracaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_parcela", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_parcela_tab_nota_NotaId",
                        column: x => x.NotaId,
                        principalTable: "tab_nota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_parcela_tab_usuario_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "tab_usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_parcela_tab_usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "tab_usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tab_produtoServico",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DescricaoProdutoServico = table.Column<string>(type: "text", nullable: false),
                    Complemento = table.Column<string>(type: "text", nullable: false),
                    NotaId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_produtoServico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tab_produtoServico_tab_nota_NotaId",
                        column: x => x.NotaId,
                        principalTable: "tab_nota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tab_nota_TimeId",
                table: "tab_nota",
                column: "TimeId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_nota_UsuarioAlteracaoId",
                table: "tab_nota",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_nota_UsuarioCadastroId",
                table: "tab_nota",
                column: "UsuarioCadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_parcela_NotaId",
                table: "tab_parcela",
                column: "NotaId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_parcela_UsuarioAlteracaoId",
                table: "tab_parcela",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_parcela_UsuarioCadastroId",
                table: "tab_parcela",
                column: "UsuarioCadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_produtoServico_NotaId",
                table: "tab_produtoServico",
                column: "NotaId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_time_UsuarioAlteracaoId",
                table: "tab_time",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_tab_time_UsuarioCadastroId",
                table: "tab_time",
                column: "UsuarioCadastroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tab_parcela");

            migrationBuilder.DropTable(
                name: "tab_produtoServico");

            migrationBuilder.DropTable(
                name: "tab_nota");

            migrationBuilder.DropTable(
                name: "tab_time");

            migrationBuilder.DropTable(
                name: "tab_usuario");
        }
    }
}
