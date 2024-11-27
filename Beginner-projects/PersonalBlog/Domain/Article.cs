namespace PersonalBlog.Domain;

public class Article
{
    public int Id { get; set; }
    public Body Body { get; set; }
    public DateTime PublishedAt { get; set; }
}
