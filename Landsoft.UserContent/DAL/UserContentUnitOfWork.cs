using MongoDB.Driver;
using System.Configuration;

namespace Landsoft.UserContent.DAL
{
    public class UserContentUnitOfWork
    {
        private static readonly IMongoDatabase db;

        private ImageRepository imageRepository;

        static UserContentUnitOfWork()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["UserContentContext"].ConnectionString;
            var mongoUrl = new MongoUrl(connectionString);
            var mongoClient = new MongoClient(mongoUrl);
            db = mongoClient.GetDatabase(mongoUrl.DatabaseName);
        }

        public IImageRepository ImageRepository
        {
            get
            {
                if (this.imageRepository == null)
                {
                    this.imageRepository = new ImageRepository(db);
                }
                return this.imageRepository;
            }
        }
    }
}