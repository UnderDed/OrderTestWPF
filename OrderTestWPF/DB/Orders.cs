using System.ComponentModel.DataAnnotations;

namespace OrderTestWPF.DB
{
    public class Orders
    {
        [Key]
       public int OrderID { get; set; }
       public string OrderStatus { get; set; }
       public string OrderDeliveryTime { get; set; }
       public string OrderPickUpPoint { get; set; }
    }
}
