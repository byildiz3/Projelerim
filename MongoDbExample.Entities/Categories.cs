namespace MongoDbExample.Entities
{
    public class Categories : BaseModel
    {
        public string Name { get; set; }
        public string Picture { get; set; }
    }


    public class Product : BaseModel
    {
        public string ProductName { get; set; }
        public string Picture { get; set; }
        public Categories Categories { get; set; }
        public Employees Publisher { get; set; }

    }

}