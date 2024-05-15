using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ActividadPaginasRazor.Pages
{
    public class programa4Model : PageModel
    {
        public int[] Numeros { get; set; }
        public int Sum { get; set; }
        public double Prom { get; set; }
        public List<int> Moda { get; set; }
        public double Median { get; set; }

        public void OnPost()
        {
            // Generar 20 números aleatorios entre 0 y 100
            Random random = new Random();
            Numeros = new int[20];
            for (int i = 0; i < 20; i++)
            {
                Numeros[i] = random.Next(0, 101);
            }

            // Calcular la suma
            Sum = 0;
            for (int i = 0; i < Numeros.Length; i++)
            {
                Sum += Numeros[i];
            }

            // Calcular la media aritmética
            Prom = (double)Sum / Numeros.Length;

            // Calcular la moda
            Dictionary<int, int> frequency = new Dictionary<int, int>();
            foreach (var number in Numeros)
            {
                if (frequency.ContainsKey(number))
                {
                    frequency[number]++;
                }
                else
                {
                    frequency[number] = 1;
                }
            }

            int maxCount = 0;
            Moda = new List<int>();
            foreach (var pair in frequency)
            {
                if (pair.Value > maxCount)
                {
                    maxCount = pair.Value;
                    Moda.Clear();
                    Moda.Add(pair.Key);
                }
                else if (pair.Value == maxCount)
                {
                    Moda.Add(pair.Key);
                }
            }

            // Calcular la mediana
            Array.Sort(Numeros);
            if (Numeros.Length % 2 == 0)
            {
                Median = (Numeros[Numeros.Length / 2 - 1] + Numeros[Numeros.Length / 2]) / 2.0;
            }
            else
            {
                Median = Numeros[Numeros.Length / 2];
            }
        }
    }
}
