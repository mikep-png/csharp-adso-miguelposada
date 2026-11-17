
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

            var repositorio = new RepositorioJson();
            var servicio = new ServicioInventario(repositorio);

            Application.Run(new FormPrincipal(servicio));
        }
    }
}
