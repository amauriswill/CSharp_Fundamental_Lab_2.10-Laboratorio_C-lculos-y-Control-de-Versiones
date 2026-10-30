using System.Globalization;
using System.Text;

ConfigurarConsola();

string cliente = LeerTexto("Ingrese el nombre del cliente: ");
decimal saldoAnterior = LeerDecimal("Ingrese el saldo actual: ");
decimal deposito = LeerDecimal("Ingrese el monto a depositar: ");

Console.WriteLine($"Cliente: {cliente}");

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
