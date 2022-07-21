﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace CityInfoAPI.Controllers
{
    [Route("api/files")]
    [ApiController]
    [Authorize]
    public class FilesController : ControllerBase
    {
        private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;
        public FilesController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
            _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider ?? throw new System.ArgumentNullException(nameof(fileExtensionContentTypeProvider));
        }

    [HttpGet("{fileId}")]
    public ActionResult GetFile(string fileId)
    {
        //look up the actual file, depending on the file Id
        var pathToFile = "pdfcoffee.com_ccat-pdf-free.pdf";
        //Check if file exists
        if (!System.IO.File.Exists(pathToFile))
        {
            return NotFound();
        }

        if(!_fileExtensionContentTypeProvider.TryGetContentType(
            pathToFile, out var contentType))
            {
                contentType = "application/octet-stream";
            }
        var bytes = System.IO.File.ReadAllBytes(pathToFile);
        return File(bytes, contentType, Path.GetFileName(pathToFile));
    }
}
}
