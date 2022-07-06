using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace AluraFlix.ViewModels
{
    public class CreateCategoriaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório", AllowEmptyStrings = false)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        public string Cor{ get; set; }
    }
}
