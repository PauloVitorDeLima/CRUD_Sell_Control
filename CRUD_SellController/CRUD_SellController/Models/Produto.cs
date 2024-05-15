using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_SellController.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Column("idProduto")]
        [Display(Name = "idProduto")]
        public int idProduto {  get; set; }
        
        [Column("dscProduto")]
        [Display(Name = "dscProduto")]
        public string dscProduto { get; set; }
        
        [Column("vlrUnitario")]
        [Display(Name = "vlrUnitario")]
        public float vlrUnitario {  get; set; }

    }
}
