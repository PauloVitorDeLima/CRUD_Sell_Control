using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_SellController.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Column("idCliente")]
        [Display(Name="idCliente")]
        public int idCliente { get; set; }

        [Column("nmCliente")]
        [Display(Name = "nmCliente")]
        public string nmCliente { get; set; }

        [Column("cidade")]
        [Display(Name = "cidade")]
        public string cidade {  get; set; }


    }
}
