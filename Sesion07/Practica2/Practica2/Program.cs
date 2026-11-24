
using System.Text.Json;

List<Contacto> contactos =
[
    new("Ana", "3001234567"),
    new("Luis", "3109876543")
];

// Configuración para que el JSON sea legible
var opciones = new JsonSerializerOptions
{
    WriteIndented = true
};

// Serializar: convertir objetos a JSON
File.WriteAllText(
    "contactos.json",
    JsonSerializer.Serialize(contactos, opciones)
);

// Deserializar: recuperar objetos desde JSON
List<Contacto> recuperados = [];

try
{
    string json = File.ReadAllText("contactos.json");

    recuperados =
        JsonSerializer.Deserialize<List<Contacto>>(json) ?? [];
}
catch (JsonException)
{
    Console.WriteLine("El archivo está dañado. Empiezo vacío.");
}

Console.WriteLine("\n=== CONTACTOS RECUPERADOS ===");

foreach (var c in recuperados)
{
    Console.WriteLine($"{c.Nombre}: {c.Telefono}");
}

Console.WriteLine(
    $"\nGuardado en: {Path.GetFullPath("contactos.json")}"
);

// Modelo de contacto
record Contacto(string Nombre, string Telefono);
