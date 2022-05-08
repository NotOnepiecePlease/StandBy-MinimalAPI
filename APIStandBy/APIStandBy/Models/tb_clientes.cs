using System.ComponentModel.DataAnnotations;

namespace APIStandBy.Models
{
    public class tb_clientes
    {
        [Key]
        public int cl_id { get; set; }
        public string? cl_nome { get; set; }
        public string? cl_telefone { get; set; }
        public string? cl_cpf { get; set; }
        public string? cl_telefone_recado { get; set; }


    }
}
