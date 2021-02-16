using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using VideoProject.Models;
using VideoProject.Services;

namespace VideoProject.Controllers
{
    [Route("api/job")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly JobDatabaseService _jobs;
        private readonly StorageService _storage;

        public JobController(JobDatabaseService jobs, StorageService storage)
        {
            _storage = storage;
            _jobs = jobs;
        }
        
        [HttpPost("new")]
        public IActionResult Job([FromForm] Job nJob)
        {
            // video file 
            var video = nJob.VideoFile;
            
            if (video.Length > 0)
            {
                nJob.Status = "New";
                nJob.CreatedAt = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                nJob.SourcePath = _storage.GenerateFullSourcePath(nJob);
                
                // save file in "Source" folder 
                _storage.SaveSourceFile(nJob);
                
                // save Job object in MongoDB
                _jobs.Create(nJob);
            }
            else
            {
                return Problem("Empty file");
            }
            return Ok();
        }

        [HttpGet]
        public ActionResult<List<Job>> Get()
        {
            return _jobs.Get();
        }
        

    }
}