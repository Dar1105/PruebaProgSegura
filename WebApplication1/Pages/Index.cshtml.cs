using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ProgSeguraLogin.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "El campo Usuario es requerido")]
        public string Usuario { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Contraseña")]
        [BindProperty]
        [Required(ErrorMessage = "El campo Contraseña es requerido")]

        public string Password { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var usuario = this.Usuario;
                var pass = this.Password;
                var repo = new IndexRepository();
                
               if (repo.ValidarUsuario(usuario, pass))
                {

                    return RedirectToPage("./Prueba");

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "El usuario o la contraseña no son validas");
                    return Page();

                }

                return RedirectToPage("./Prueba");

            }
            else
            {

                return Page();



            }
           

        }
    }
}
