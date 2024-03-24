using Amazon.DynamoDBv2.DataModel;
using PersonalBlog.Interface;
using PersonalBlog.Models;

namespace PersonalBlog.Services
{
    public class DynamoDbDataService : IDataService
    {
        private readonly IDynamoDBContext _context;

        public DynamoDbDataService(IDynamoDBContext context)
        {
            _context = context;
        }
        public async Task Create(Post model)
        {
            await _context.SaveAsync<Post>(model);
        }

        public Task<List<Post>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
