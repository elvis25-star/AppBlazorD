using AppBlazor.Entities;
using System.Security.Cryptography.X509Certificates;

namespace AppBlazor.Client.Services
{
    public class LibroService
    {
        private List<LibroListCLS> lista;

        public event Action? OnChange;
        public LibroService()
        {
            lista=new List<LibroListCLS>();
            lista.Add(new LibroListCLS { idlibro = 1, titulo = "Libro 1" ,tipoLibro="Cuento"});
            lista.Add(new LibroListCLS { idlibro = 2, titulo = "Libro 2", tipoLibro = "Novela"});
        }
        public List<LibroListCLS> listarLibros()
        {
            return lista;
        }

        public void eliminarLibro(int idlibro)
        {
            var listaQueda = lista.Where(p => p.idlibro != idlibro).ToList();
            lista = listaQueda;
        }

        public void agregarLibro(LibroFormCLS libro)
        {
            lista.Add(new LibroListCLS
            {
                idlibro = libro.idlibro,
                titulo = libro.titulo,
                resumen=libro.resumen,
                tipoLibro=libro.tipoLibro
            });
        }

        public void actualizarLibro(LibroFormCLS libro)
        {
            var existente = lista.FirstOrDefault(p => p.idlibro == libro.idlibro);
            if(existente != null)
            {
                existente.titulo = libro.titulo;
                existente.resumen = libro.resumen;
                existente.tipoLibro = libro.tipoLibro;
            }
        }
        
        public LibroFormCLS obtenerLibro(int idlibro)
        {
            var existente = lista.FirstOrDefault(p => p.idlibro == idlibro);
            if (existente != null)
            {
                return new LibroFormCLS
                {
                    idlibro = existente.idlibro,
                    titulo = existente.titulo,
                    resumen = existente.resumen,
                    tipoLibro = existente.tipoLibro
                };
            }
            return new LibroFormCLS();
        }
        public int ObtenerSiguienteId()
        {
            if(lista.Count == 0) 
                return 1;
            return lista.Max(p => p.idlibro)+1;
        }
        
    }

}
