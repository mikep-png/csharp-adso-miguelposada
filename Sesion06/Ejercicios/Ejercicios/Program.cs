using Ejercicios;

Celular iphone = new Celular("Iphone 28 Pro Max");

Console.WriteLine($"Marca: {iphone.Marca}");
Console.WriteLine($"Batería inicial: {iphone.Bateria}");

Console.WriteLine("===Cargar Celular===");
iphone.Cargar(80);

Console.WriteLine("===Usar Celular===");
bool resultado = iphone.Usar(40);

Console.WriteLine($"Se pudo utilizar?: {(resultado ? "Sí": "No")}.");

Console.WriteLine($"\nBatería final: {iphone.Bateria}%");