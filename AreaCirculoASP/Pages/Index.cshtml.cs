using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AreaCirculoASP.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public double Radio { get; set; }

        public string? Resultado { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (Radio > 0)
            {
                double area = Math.PI * Math.Pow(Radio, 2);
                Resultado = "El área del círculo es: " + area.ToString("0.00");
            }
            else
            {
                Resultado = "La longitud del radio debe ser mayor a 0.";
            }
        }
    }
}