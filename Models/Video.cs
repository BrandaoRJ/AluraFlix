using System.ComponentModel.DataAnnotations.Schema;

namespace AluraFlix.API.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Url { get; set; }
        //Está sendo setado um relacionamento de 1-N onde
        //um vídeo pode ter uma categoria
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
