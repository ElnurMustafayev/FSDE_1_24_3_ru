namespace WebApiApp.Controllers;

using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApiApp.Options;

[ApiController]
[Route("api/[controller]")]
public class FileController : ControllerBase
{
    private readonly IAmazonS3 amazonS3;
    private readonly S3Options options;

    public FileController(IOptions<S3Options> options, IAmazonS3 amazonS3)
    {
        this.options = options.Value;
        this.amazonS3 = amazonS3;
    }

    [HttpPost]
    public async Task<ActionResult> UploadFile(IFormFile file)
    {
        using var fileReadStream = file.OpenReadStream();
        var key = Guid.NewGuid();

        var request = new PutObjectRequest()
        {
            BucketName = this.options.Bucket,
            Key = $"general/{key}",
            InputStream = fileReadStream,
            ContentType = file.ContentType
        };

        var response = await this.amazonS3.PutObjectAsync(request);

        return base.Ok(key);
    }

    [HttpGet]
    public async Task<ActionResult> DownloadFile(Guid key)
    {
        var request = new GetObjectRequest()
        {
            BucketName = options.Bucket,
            Key = $"general/{key}",
        };
        var response = await this.amazonS3.GetObjectAsync(request);

        return base.File(
            fileStream: response.ResponseStream,
            contentType: response.Headers.ContentType
        );
    }
}