using System;
using System.Windows.Forms;
using Inventario.Datos;
using Inventario.Servicios;

namespace Inventario.Escritorio
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Ahora el escritorio utiliza SQLite con Entity Framework Core.
            var repositorio = new RepositorioEf();
            var servicio = new ServicioInventario(repositorio);

            Application.Run(new FormPrincipal(servicio));
        }
    }
}