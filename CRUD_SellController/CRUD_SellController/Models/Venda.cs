namespace CRUD_SellController.Models
{
    public class Venda
    {
        public int idVenda { get; set; }
        public int idCliente { get; set; }
        public int idProduto { get; set; }
        public int qtdVenda { get; set; }
        public int vlrUnitarioVenda { get; set; }
        public DateTime dthVenda { get; set; }
        public float vlrTotalVenda { get; set;}

    }
}
