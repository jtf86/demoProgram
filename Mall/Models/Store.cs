namespace Mall.Models
{
    public class Store
    {
       private int _id;
       private string _name;
       private int _productId;
       private int _floorId;

       public Store(string name, int floorId, int productId, int id=0)
       {
           _name = name;
           _floorId = floorId;
           _productId = productId;
           _id = id;
       }

       public int GetId()
       {
           return _id;
       }
       public string GetName()
       {
           return _name;
       }
       public int GetFloorId()
       {
           return _floorId;
       }
       public int GetProductId()
       {
           return _productId;
       }

    }
}