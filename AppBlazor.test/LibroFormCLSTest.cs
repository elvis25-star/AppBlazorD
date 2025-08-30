using AppBlazor.Entities;
using System.ComponentModel.DataAnnotations;
using Xunit;
namespace AppBlazor.test
{
    public class LibroFormCLSTest
    {
        private List<ValidationResult> ValidaModelo(object modelo)
        {
            var resultados=new List<ValidationResult>();
            var contexto = new ValidationContext(modelo,null,null);
            Validator.TryValidateObject(modelo, contexto, resultados, true);
            return resultados;
        }
        [Fact]
        public void ValidacionCamposVacios()
        {
            var libro=new LibroFormCLS();
            var errores = ValidaModelo(libro);
            Assert.Contains(errores, e => e.ErrorMessage!.Contains("El id es requerido") ||
                e.ErrorMessage!.Contains("El valor debe ser un numero positivo"));
            Assert.Contains(errores, e => e.ErrorMessage!.Contains("El titulo es requerido"));
            Assert.Contains(errores, e => e.ErrorMessage!.Contains("El resumen es requerido"));
        }
        [Fact]
        public void ValidacionCamposCorrectos()
        {
            var libro = new LibroFormCLS
            {
                idlibro = 1,
                titulo = "Libro de Prueba",
                resumen = "Es un resumen del libro de prueba."
            };
            var errores=ValidaModelo(libro);
            Assert.Empty(errores);

        }
    }
}