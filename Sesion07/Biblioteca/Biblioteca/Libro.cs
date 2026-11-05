using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca // La "carpeta" del proyecto
{
    public class Libro // El nombre del molde
    {
        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public bool Disponible { get; private set; } = true;
        
        // Constructor: Creador de un libro
        public Libro(String titulo, String autor, int paginas) 
        {
            Titulo = titulo;
            Autor = autor;
            Paginas = paginas;
        }

        public Libro(String titulo) : this(titulo, "autor", 100) 
        {
            
        }

        // Métodos: Lo que el libro SABE HACER
        public bool Prestar()
        {
            if (!Disponible) return false;
            Disponible = false;
            Console.WriteLine("Libro prestado");
            return true;
        }
        
        public void Devolver()
        {
            Disponible = true;
        }

        public override string ToString() =>
            $"{Titulo} - {Autor} - {(Disponible ? "Disponible" : "No disponible")}";

        private int _paginas;

    }
}
