using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AreaCirculoASP.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public double Radio { get; set; }

        public string? Resultado { get; set; }
        public string AreaFormateada { get; set; } = "0.00";
        public string Circunferencia { get; set; } = "0.00";
        public string Diametro { get; set; } = "0.00";

        // Radio máximo visual en el SVG = 90 unidades (radio lógico máximo = 20)
        public double RadioSvg => Radio > 0 ? Math.Min((Radio / 20.0) * 90, 90) : 0;
        public double RadioLineX2 => 100 + RadioSvg;
        public double RadioLabelX => 100 + RadioSvg * 0.45;

        public void OnGet()
        {
            // Sin radio por defecto — el campo empieza vacío
        }

        public void OnPost()
        {
            if (Radio > 0)
            {
                double area = Math.PI * Math.Pow(Radio, 2);
                AreaFormateada = area.ToString("0.00");
                Circunferencia = (2 * Math.PI * Radio).ToString("0.00");
                Diametro = (Radio * 2).ToString("0.00");
                Resultado = AreaFormateada;
            }
            else
            {
                Resultado = "El radio debe ser mayor a 0.";
            }
        }
    }
}
