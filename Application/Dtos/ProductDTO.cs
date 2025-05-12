namespace Applications.DTOs
{
    public class ProductDTO
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int UnitsInStock { get; set; }
        public string ImagePath { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is not ProductDTO other)
                return false;

            return this.ProductID == other.ProductID;
        }

        public override int GetHashCode()
        {
            return ProductID.GetHashCode();
        }
    }
}