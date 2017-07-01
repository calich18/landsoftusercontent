using Landsoft.UserContent.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace Landsoft.UserContent.DAL
{
    public class ImageRepository : IImageRepository
    {
        private IMongoDatabase db;

        public ImageRepository(IMongoDatabase db)
        {
            this.db = db;
        }

        public async Task<int> CreateAsync(Image image)
        {
            try
            {
                await db.GetCollection<Image>(CollectionNames.Images).InsertOneAsync(image);
                return 0;
            }
            catch (Exception)
            {
                return 1;
            }
        }

        public async Task<Image> FindOneAsync(string imageId)
        {
            ObjectId id;
            if (!ObjectId.TryParse(imageId, out id))
            {
                return null;
            }

            return await db.GetCollection<Image>(CollectionNames.Images).Find(i => i.Id == id).FirstOrDefaultAsync();
        }
    }
}