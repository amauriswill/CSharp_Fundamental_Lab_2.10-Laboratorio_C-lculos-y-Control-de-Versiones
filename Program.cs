using System.Globalization;
using System.Text;

ConfigurarConsola();

string cliente = LeerTexto("Ingrese el nombre del cliente: ");
decimal saldoAnterior = LeerDecimal("Ingrese el saldo actual: ");
decimal deposito = LeerDecimal("Ingrese el monto a depositar: ");

decimal nuevoSaldo = CalcularNuevoSaldo(saldoAnterior, deposito);

MostrarResumenTransaccion(cliente, saldoAnterior, deposito, nuevoSaldo);

static void ConfigurarConsola()
{
    Console.OutputEncoding = Encoding.UTF8;
    Console.InputEncoding = Encoding.UTF8;
}

static string LeerTexto(string mensaje)
{
    Console.Write(mensaje);
    return Console.ReadLine()?.Trim() ?? string.Empty;
}

static decimal LeerDecimal(string mensaje)
{
    Console.Write(mensaje);
    string entrada = Console.ReadLine() ?? string.Empty;
    entrada = entrada.Replace("RD$", "", StringComparison.OrdinalIgnoreCase).Replace("$", "").Trim();

    if (decimal.TryParse(entrada, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valor))
    {
        return valor;
    }

    if (decimal.TryParse(entrada, NumberStyles.Any, CultureInfo.CurrentCulture, out valor))
    {
        return valor;
    }

    return 0m;
}

static decimal CalcularNuevoSaldo(decimal saldoActual, decimal deposito)
{
    return saldoActual + deposito;
}

static void MostrarResumenTransaccion(string cliente, decimal saldoAnterior, decimal deposito, decimal nuevoSaldo)
{
    Console.WriteLine();
    Console.WriteLine("========================================");
    Console.WriteLine("        RESUMEN DE TRANSACCIÓN          ");
    Console.WriteLine("========================================");
    Console.WriteLine();
    Console.WriteLine($"Cliente:         {cliente}");
    Console.WriteLine($"Saldo Anterior:  RD${saldoAnterior.ToString("N2", CultureInfo.InvariantCulture)}");
    Console.WriteLine($"Depósito:        RD${deposito.ToString("N2", CultureInfo.InvariantCulture)}");
    Console.WriteLine($"Nuevo Saldo:     RD${nuevoSaldo.ToString("N2", CultureInfo.InvariantCulture)}");
    Console.WriteLine();
    Console.WriteLine("========================================");
}
