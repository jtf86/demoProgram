namespace Mall.Models
{
    public class Product
    {
        private int _id;
        private string _description;

        public Product(string description, int id=0)
        {
            _description = description;
            _id = id;
        }

        public int GetId()
        {
            return _id;
        }

        public string GetDescription()
        {
           return _description;
        }

    }
}