using Landsoft.UserContent.DAL;
using Landsoft.UserContent.Helpers;
using Landsoft.UserContent.Models;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace Landsoft.UserContent.Controllers
{
    [RoutePrefix("api/images")]
    public class ImagesController : ApiController
    {
        private readonly UserContentUnitOfWork unitOfWork = new UserContentUnitOfWork();

        // POST api/images
        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> Create(CreateImageBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var image = new Image
            {
                Name = model.Name,
                MimeType = model.MimeType,
                Data = model.Data,
                CreatedAt = Common.Now()
            };

            var errorCode = await unitOfWork.ImageRepository.CreateAsync(image);

            return Ok(new { ImageId = image.Id });
        }

        // GET api/images/abcxyz
        [Route("{imageId}")]
        [HttpGet]
        public async Task<IHttpActionResult> Get(string imageId)
        {
            if (string.IsNullOrWhiteSpace(imageId))
            {
                return BadRequest();
            }

            var image = await unitOfWork.ImageRepository.FindOneAsync(imageId);

            if (image == null)
            {
                return NotFound();
            }

            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new ByteArrayContent(image.Data);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue(image.MimeType);

            return ResponseMessage(response);
        }
    }
}
