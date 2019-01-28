using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Swintake.domain.FilesToUpload;
using System.IO;
using Swintake.services.JobApplications;
using Swintake.api.Helpers.Files;
using Swintake.services.Files;

namespace Swintake.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly FileMapper _fileMapper;
        private readonly IFileService _fileService;
        public FilesController(FileMapper fileMapper, IFileService fileService)
        {
            _fileMapper = fileMapper;
            _fileService = fileService;
        }

        [HttpPost, DisableRequestSizeLimit]
        [Authorize]
        public async Task<IActionResult> UpLoadFile([FromHeader] FileDTOToCreate fileDto)
        {
            var file = Request.Form.Files[0];
            var fileDtoWithFormFile = _fileMapper.ToFileDtoWithFormFile(fileDto, file);

            var result = await _fileService.UploadFile(_fileMapper.ToDomainFile(fileDtoWithFormFile), fileDto.jobApplicationId);
            return Created($"api/files/{result.Id}", result);
        }

    }
}