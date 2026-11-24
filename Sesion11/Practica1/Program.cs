
using Practica1;

using var db = new AgendaContext();

// Crear la base de datos si no existe.
db.Database.EnsureCreated();

// Agregar contactos.
db.Contactos.Add(new Contacto
{
    Nombre = "Ana",
    Telefono = "3001234567",
    Correo = "ana@gmail.com"
});

db.Contactos.Add(new Contacto
{
    Nombre = "Luis",
    Telefono = "3109876543",
    Correo = "luis@gmail.com"
});

// Guardar los contactos.
db.SaveChanges();

Console.WriteLine("===== CONTACTOS REGISTRADOS =====");

// Consultar y mostrar los contactos.
foreach (var contacto in db.Contactos.OrderBy(c => c.Nombre).ToList())
{
    Console.WriteLine(
        $"{contacto.Id} - {contacto.Nombre} - {contacto.Telefono}");
}

// Actualizar el teléfono de Ana.
var ana = db.Contactos.FirstOrDefault(c => c.Nombre == "Ana");

if (ana != null)
{
    ana.Telefono = "3110000000";
    db.SaveChanges();

    Console.WriteLine("\nTeléfono de Ana actualizado.");
}

// Buscar el contacto con Id 1.
var primero = db.Contactos.Find(1);

if (primero != null)
{
    db.Contactos.Remove(primero);
    db.SaveChanges();

    Console.WriteLine("Contacto con Id 1 eliminado.");
}

// Mostrar los contactos finales.
Console.WriteLine("\n===== CONTACTOS FINALES =====");

foreach (var contacto in db.Contactos.OrderBy(c => c.Nombre).ToList())
{
    Console.WriteLine(
        $"{contacto.Id} - {contacto.Nombre} - {contacto.Telefono}");
}

Console.WriteLine(
    $"\nBase de datos: {Path.GetFullPath("agenda.db")}");
