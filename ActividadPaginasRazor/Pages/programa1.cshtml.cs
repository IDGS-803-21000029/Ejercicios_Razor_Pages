using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ActividadPaginasRazor.Pages
{
    public class programa1Model : PageModel
    {
        // Definir los atributos
        [BindProperty]
        public string pesoStr { get; set; } = "";
        [BindProperty]
        public string alturaStr { get; set; } = "";
        public double imc = 0;

        public void OnPost()
        {   
            double peso = Convert.ToDouble(pesoStr);
            double altura = Convert.ToDouble(alturaStr);
            imc = (peso) / (altura * altura);

            ModelState.Clear();
        }
    }
}
