namespace Milestone_4_Mongo.Models
{
    public class ProductStoreSetting
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string ProductsDatabaseCollectionName { get; set; } = null!;

    }
}
