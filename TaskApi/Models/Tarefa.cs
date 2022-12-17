using System.ComponentModel.DataAnnotations;

namespace TaskApi.Models
{
    public class Tarefa
    {
        public int Codigo { get; set; }        
        public string Descricao { get; set; }
        public char Status { get; set; }
    }
}