using System.ComponentModel.DataAnnotations;

namespace OrderTestWPF.DB
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }
        public string Photo { get; set; }
        public string Manufacturer { get; set; }
        public int Price { get; set; }
        public string PriceString { get; set; }
        public int PriceSale { get; set; }
        public string PriceSaleString { get; set; }
        public string MinSale { get; set; }
        public string Coment { get; set; }
    }
}
