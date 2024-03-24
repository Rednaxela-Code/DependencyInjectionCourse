using Amazon.DynamoDBv2.DataModel;

namespace PersonalBlog.Models
{
    [DynamoDBTable(tableName: "post")]
    public class Post
    {
        [DynamoDBHashKey]
        public string Id { get; set; }
        public DateTime PostDateTime { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public Post()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
