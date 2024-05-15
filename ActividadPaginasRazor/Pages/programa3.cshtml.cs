using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.ResponseCompression;
using System.Diagnostics;

namespace ActividadPaginasRazor.Pages
{
    public class programa3Model : PageModel
    {
        [BindProperty]
        public string aStr { get; set; } = "";
        [BindProperty]
        public string bStr { get; set; } = "";
        [BindProperty]
        public string xStr { get; set; } = "";
        [BindProperty]
        public string yStr { get; set; } = "";
        [BindProperty]
        public string nStr { get; set; } = "";

        public double res1 { get; set; } = 0;
        public double res2 { get; set; } = 0;

        public void OnPost()
        {
            if (double.TryParse(aStr, out double a) &&
                double.TryParse(bStr, out double b) &&
                double.TryParse(xStr, out double x) &&
                double.TryParse(yStr, out double y) &&
                int.TryParse(nStr, out int n))
            {
                List<double> subtotales = new List<double>();

                // Cálculo directo de (ax + by)^n
                res1 = Math.Pow((a * x) + (b * y), n);

                for (var k = 0; k <= n; k++)
                {
                    double factorialN = CalcularFactorial(n);
                    double factorialK = CalcularFactorial(k);
                    double factorialNK = CalcularFactorial(n - k);

                    // Cálculo del coeficiente binomial
                    double binomCoef = factorialN / (factorialK * factorialNK);

                    // Cálculo del término específico
                    double term = binomCoef * Math.Pow(a * x, (n - k)) * Math.Pow(b * y, k);

                    subtotales.Add(term);
                }

                res2 = 0;
                foreach (double valor in subtotales)
                {
                    res2 += valor;
                }
            }
        }

        private double CalcularFactorial(int x)
        {
            double fact = 1;

            for (int i = 1; i <= x; i++)
            {
                fact *= i;
            }

            return fact;
        }
    }
}
