namespace WebApiApp.Options;

public class S3Options
{
    public required string Region { get; set; }
    public required string Bucket { get; set; }
}