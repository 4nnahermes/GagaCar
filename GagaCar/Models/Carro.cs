using System.ComponentModel.DataAnnotations;

namespace GagaCar.Models
{
    public class Carro
    {
        public int Id { get; set; }

        [Display(Name = "Marca")]
        public string Marca { get; set; }

        [Display(Name = "Modelo")]
        public string Modelo { get; set; }

        [Display(Name = "Ano de fabricação")]
        public int AnoDeFabricacao { get; set; }

        [Display(Name = "Ano do modelo")]
        public int AnoModelo { get; set; }

        [Display(Name = "Chassi")]
        public string Chassi { get; set; }

        [Display(Name = "Preço")]
        public double Preco { get; set; }
    }
}
