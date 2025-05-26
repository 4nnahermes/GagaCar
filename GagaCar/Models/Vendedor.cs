using System.ComponentModel.DataAnnotations;

namespace GagaCar.Models
{
    public class Vendedor
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Data de admissão")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataAdmissao { get; set; }

        [Display(Name = "Matrícula")]
        public string Matricula { get; set; }

        [Display(Name = "Salário")]
        public double Salario { get; set; }
    }
}
