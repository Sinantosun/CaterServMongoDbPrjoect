﻿namespace CaterServMongoDbPrjoect.Settings
{
    public interface IDataBaseSettings
    {
        public string ConnectionString { get; set; }
        public string DataBaseName {  get; set; }
        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
    }
}
