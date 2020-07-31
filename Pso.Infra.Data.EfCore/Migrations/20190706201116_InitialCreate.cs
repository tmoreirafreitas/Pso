using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Pso.BackEnd.Infra.Data.EFCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "Cliente",
                schema: "public",
                columns: table => new
                {
                    ClienteId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Nome = table.Column<string>(type: "varchar(80)", maxLength: 60, nullable: false),
                    Rg = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    Cpf = table.Column<string>(type: "varchar(11)", maxLength: 15, nullable: false),
                    Filiacao = table.Column<string>(type: "varchar(200)", maxLength: 150, nullable: true),
                    IsSPC = table.Column<bool>(nullable: true),
                    Nascimento = table.Column<DateTime>(type: "date", nullable: false),
                    Sexo = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Oculos",
                schema: "public",
                columns: table => new
                {
                    OculosId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Cor = table.Column<string>(type: "varchar(30)", nullable: true),
                    DP = table.Column<float>(type: "float", nullable: false),
                    ALT = table.Column<float>(type: "float", nullable: false),
                    PedidoOculosId = table.Column<long>(nullable: false),
                    Adicao = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oculos", x => x.OculosId);
                });

            migrationBuilder.CreateTable(
                name: "Contato",
                schema: "public",
                columns: table => new
                {
                    ContatoId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Nome = table.Column<string>(type: "varchar(80)", maxLength: 15, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    ClienteId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contato", x => x.ContatoId);
                    table.ForeignKey(
                        name: "FK_Cliente_Contato",
                        column: x => x.ClienteId,
                        principalSchema: "public",
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                schema: "public",
                columns: table => new
                {
                    EnderecoId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Cep = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    Bairro = table.Column<string>(type: "varchar(60)", maxLength: 40, nullable: false),
                    Cidade = table.Column<string>(type: "varchar(40)", maxLength: 30, nullable: false),
                    Estado = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Numero = table.Column<int>(type: "integer", nullable: true),
                    Complemento = table.Column<string>(type: "varchar(150)", maxLength: 100, nullable: true),
                    ClienteId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.EnderecoId);
                    table.ForeignKey(
                        name: "FK_Cliente_Endereco",
                        column: x => x.ClienteId,
                        principalSchema: "public",
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                schema: "public",
                columns: table => new
                {
                    PedidoId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Servico = table.Column<string>(type: "varchar(1000)", nullable: false),
                    Obs = table.Column<string>(type: "varchar(255)", nullable: false),
                    Medico = table.Column<string>(type: "varchar(80)", nullable: false),
                    DataEntrega = table.Column<DateTime>(type: "date", nullable: false),
                    DataSolicitacao = table.Column<DateTime>(type: "date", nullable: false),
                    ClienteId = table.Column<long>(nullable: false),
                    FaturaId = table.Column<long>(nullable: false),
                    Preco = table.Column<decimal>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PedidoIdPk", x => x.PedidoId);
                    table.ForeignKey(
                        name: "FK_Cliente_Pedido",
                        column: x => x.ClienteId,
                        principalSchema: "public",
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lente",
                schema: "public",
                columns: table => new
                {
                    LenteId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Grau = table.Column<float>(type: "float", nullable: false),
                    Cyl = table.Column<float>(type: "float", nullable: false),
                    Eixo = table.Column<byte>(type: "smallint", nullable: false),
                    LenteType = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    OculosId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lente", x => x.LenteId);
                    table.ForeignKey(
                        name: "FK_Lente_Oculos_OculosId",
                        column: x => x.OculosId,
                        principalSchema: "public",
                        principalTable: "Oculos",
                        principalColumn: "OculosId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fatura",
                schema: "public",
                columns: table => new
                {
                    FaturaId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Valor = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    Total_A_Pagar = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    Sinal = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    IsPaga = table.Column<bool>(nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "date", nullable: false),
                    NumeroParcelas = table.Column<int>(type: "integer", nullable: false),
                    FormaPagamento = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    PedidoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fatura", x => x.FaturaId);
                    table.ForeignKey(
                        name: "FK_Fatura_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalSchema: "public",
                        principalTable: "Pedido",
                        principalColumn: "PedidoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidoOculos",
                schema: "public",
                columns: table => new
                {
                    PedidoId = table.Column<long>(nullable: false),
                    OculosId = table.Column<long>(nullable: false),
                    Id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido_Oculos", x => new { x.PedidoId, x.OculosId });
                    table.ForeignKey(
                        name: "FK_Oculos",
                        column: x => x.OculosId,
                        principalSchema: "public",
                        principalTable: "Oculos",
                        principalColumn: "OculosId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido",
                        column: x => x.PedidoId,
                        principalSchema: "public",
                        principalTable: "Pedido",
                        principalColumn: "PedidoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parcela",
                schema: "public",
                columns: table => new
                {
                    ParcelaId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "date", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "date", nullable: false),
                    Recebido = table.Column<bool>(type: "boolean", nullable: false),
                    FaturaId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcela", x => x.ParcelaId);
                    table.ForeignKey(
                        name: "FK_Fatura_Parcela",
                        column: x => x.FaturaId,
                        principalSchema: "public",
                        principalTable: "Fatura",
                        principalColumn: "FaturaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contato_ClienteId",
                schema: "public",
                table: "Contato",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_ClienteId",
                schema: "public",
                table: "Endereco",
                column: "ClienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fatura_PedidoId",
                schema: "public",
                table: "Fatura",
                column: "PedidoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lente_OculosId",
                schema: "public",
                table: "Lente",
                column: "OculosId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcela_FaturaId",
                schema: "public",
                table: "Parcela",
                column: "FaturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ClienteId",
                schema: "public",
                table: "Pedido",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoOculos_OculosId",
                schema: "public",
                table: "PedidoOculos",
                column: "OculosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contato",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Endereco",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Lente",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Parcela",
                schema: "public");

            migrationBuilder.DropTable(
                name: "PedidoOculos",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Fatura",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Oculos",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Pedido",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Cliente",
                schema: "public");
        }
    }
}
