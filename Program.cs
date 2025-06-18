using DesafioProjetoHospedagem.Models;
using System.Globalization;

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");

Suite suite = new Suite(tipoSuite: "Premiun", capacidade: 5, valorDiaria: 55.00m);

List<Pessoa> hospedes = new List<Pessoa> ()
{
    new Pessoa(nome: "João"),
    new Pessoa(nome: "Pedro"),
    new Pessoa(nome: "Maria", sobrenome: "Oliveira")
};

Reserva reserva = new Reserva();

// try catch para capturar exceções ao cadastrar a suíte já que o tipo de suíte não pode ser vazio
try
{
    reserva.CadastrarSuite(suite);
}
catch (Exception ex)
{
    Console.WriteLine($"Erro ao cadastrar suíte: {ex.Message}");
    return;
}

// try catch para capturar exceções ao cadastrar os hóspedes para não exceder a capacidade
try
{
    reserva.CadastrarHospedes(hospedes);
    reserva.DefinirDiasReservados(2);
    Console.WriteLine($"Número de hóspedes: {reserva.Hospedes.Count}");
    Console.WriteLine($"Quantidade de dias reservados: {reserva.DiasReservados}");
    Console.WriteLine($"Valor total da reserva: {reserva.CalcularValorTotal():C}");
}
catch (Exception ex)
{
    Console.WriteLine($"Erro ao cadastrar hóspedes: {ex.Message}");
    return;
}

Console.WriteLine($"Reserva realizada com sucesso!");