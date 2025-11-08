using Infraestructura.Datos.Contexts;
using System.Xml.Linq;

namespace Infraestructura.Datos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Creando la BD ");
            VentaContext db =  new VentaContext();
            db.Database.EnsureCreated();
            Console.WriteLine("DB creada.");
            Console.ReadKey();
        }
    }
}