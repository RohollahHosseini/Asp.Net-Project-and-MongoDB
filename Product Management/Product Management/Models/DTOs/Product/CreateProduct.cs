namespace Product_Management.Models.DTOs.Product
{
    public class CreateProduct
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public float Price { get; set; }
        public bool IsDeleted { get; set; }
    }
}
