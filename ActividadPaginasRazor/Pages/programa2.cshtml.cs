using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace ActividadPaginasRazor.Pages
{
    public class programa2Model : PageModel
    {
        [BindProperty]
        public string Mensaje { get; set; } = string.Empty;
        [BindProperty]
        public int N { get; set; }
        [BindProperty]
        public string Accion { get; set; } = string.Empty;
        public string Resultado { get; set; } = string.Empty;

        public void OnPost()
        {
            if (Accion == "codificar")
            {
                Resultado = CodificarMensaje(Mensaje, N);
            }
            else if (Accion == "decodificar")
            {
                Resultado = DecodificarMensaje(Mensaje, N);
            }
        }

        private string CodificarMensaje(string mensaje, int n)
        {
            StringBuilder mensajeCifrado = new StringBuilder();

            foreach (char caracter in mensaje.ToUpper())
            {
                if (caracter >= 'A' && caracter <= 'Z')
                {
                    char nuevoCaracter = (char)(caracter + n);
                    if (nuevoCaracter > 'Z')
                    {
                        nuevoCaracter = (char)(nuevoCaracter - 26);
                    }
                    mensajeCifrado.Append(nuevoCaracter);
                }
                else
                {
                    mensajeCifrado.Append(caracter);
                }
            }

            return mensajeCifrado.ToString();
        }

        private string DecodificarMensaje(string mensaje, int n)
        {
            StringBuilder mensajeDecifrado = new StringBuilder();

            foreach (char caracter in mensaje.ToUpper())
            {
                if (caracter >= 'A' && caracter <= 'Z')
                {
                    char nuevoCaracter = (char)(caracter - n);
                    if (nuevoCaracter < 'A')
                    {
                        nuevoCaracter = (char)(nuevoCaracter + 26);
                    }
                    mensajeDecifrado.Append(nuevoCaracter);
                }
                else
                {
                    mensajeDecifrado.Append(caracter);
                }
            }

            return mensajeDecifrado.ToString();
        }
    }
}
