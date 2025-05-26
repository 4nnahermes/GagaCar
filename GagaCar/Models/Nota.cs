using System.ComponentModel.DataAnnotations;

namespace GagaCar.Models
{
    public class Nota
    {
        public int Id { get; set; }

        [Display(Name = "Número")]
        public int Numero { get; set; }

        [Display(Name = "Data de emissão")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataEmissao { get; set; }

        [Display(Name = "Garantia")]
        public string Garantia { get; set; }

        [Display(Name = "Valor da venda")]
        public double ValorVenda { get; set; }

        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [Display(Name = "Vendedor")]
        public int VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }

        [Display(Name = "Carro")]
        public int CarroId { get; set; }
        public Carro Carro { get; set; }
    }
}
