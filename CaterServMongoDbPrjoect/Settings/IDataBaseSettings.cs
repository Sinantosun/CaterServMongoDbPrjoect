namespace CaterServMongoDbPrjoect.Settings
{
    public interface IDataBaseSettings
    {
        public string ConnectionString { get; set; }
        public string DataBaseName {  get; set; }
        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string FeatureCollectionName { get; set; }
        public string AboutCollectionName { get; set; }
        public string ServiceCollectionName { get; set; }
        public string EventCollectionName { get; set; }
        public string EventCategoryCollectionName { get; set; }
        public string CheffCollectionName { get; set; }
        public string TestimonailCollectionName { get; set; }
        public string BookingCollectionName { get; set; }



    }
}
