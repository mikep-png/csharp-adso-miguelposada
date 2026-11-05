namespace Biblioteca;

public class Libro
{
    private string _titulo = "";
    private int _paginas;

    public string Autor { get; private set; }
    public bool Disponible { get; private set; } = true;

    public string Titulo
    {
        get => _titulo;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El título es obligatorio.");
            _titulo = value.Trim();
        }
    }

    public int Paginas
    {
        get => _paginas;
        private set
        {
            if (value <= 0)
                throw new ArgumentException("Un libro debe tener al menos 1 página.");
            _paginas = value;
        }
    }

    public bool EsLargo => Paginas > 300;

    public Libro(string titulo, string autor, int paginas)
    {
        Titulo = titulo;
        Autor = autor;
        Paginas = paginas;
    }

    public bool Prestar()
    {
        if (!Disponible) return false;
        Disponible = false;
        return true;
    }

    public void Devolver() => Disponible = true;

    public override string ToString() =>
        $"{Titulo,-25} {Autor,-25} {Paginas,4} pág. · {(Disponible ? "Disponible" : "Prestado")}";
}

public record Prestamo(string Titulo, string Usuario, DateTime Fecha);