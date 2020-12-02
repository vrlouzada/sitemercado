using Library.Contracts;
using Library.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace SiteMercado.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UploadFileController : ControllerBase
    {
        private readonly IImageService _imageService;

        public UploadFileController( IImageService imageService)
        {
            _imageService = imageService;
        }


        [HttpPost("upload")]
        public ActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var idProd = Request.Form["idprod"].ToString();

                if (file.Length > 0 || !string.IsNullOrEmpty(idProd))
                {

                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        var fileBytes = ms.ToArray();

                        var result = _imageService.Insert(fileBytes, idProd);

                        if (!result)
                        {
                            return BadRequest();
                        }
                        else
                        {
                            return Ok(result);
                        }
                    }

                       
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpPost("Get")]
        public ActionResult Get(Produto produto)
        {
            return Ok(_imageService.Get(produto.Id));
        }

    }
}
