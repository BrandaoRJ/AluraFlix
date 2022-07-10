using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace AluraFlix.API.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Cor { get; set; }
        //Está sendo setado um relacionamento de 1-N onde
        //uma categoria pode ter muitos vídeos
    }
}
