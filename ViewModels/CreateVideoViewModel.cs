using System.ComponentModel.DataAnnotations;

namespace AluraFlix.API.ViewModels
{
    public class CreateVideoViewModel
    {
        public int Id { get; set; }

        [StringLength(100, MinimumLength =3, ErrorMessage = "Título deve ter no mínimo 3 e no máximo 100 caracteres")]
        public string Titulo { get; set; }

        [StringLength(100, MinimumLength =3, ErrorMessage ="A descrição deve ter no mínimo 3 e no máximo 100 caracteres")]
        public string Descricao { get; set; }

        [RegularExpression(@"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()!@:%_\+.~#?&\/\/=]*)")]
        public string Url { get; set; }

        public int? CategoriaId { get; set; }
    }
}
