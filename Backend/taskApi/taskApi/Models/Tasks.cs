using System.ComponentModel.DataAnnotations;

namespace taskApi.Models
{
    public class Tasks
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Categoria { get; set; }

        public string Detalhes { get; set; }

        public string Status { get; set; }

    }
}
