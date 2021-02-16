using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using VideoProject.Models;

namespace VideoProject.Services
{
    public class StorageService
    {
        private readonly string _prefixSource;
        private readonly string _prefixDestination;

        public StorageService(IStorageSettings settings)
        {
            _prefixSource = settings.PathPrefixSource;
            _prefixDestination = settings.PathPrefixDestination;
        }

        public void SaveSourceFile(Job job)
        {
            var file = job.VideoFile;
            var fullPath = GenerateFullSourcePath(job);
            
            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
        }
        
        public void Delete(Job job){}
        
        public string GenerateFullSourcePath(Job njob)
        {
            string fileName = njob.VideoFile.FileName;
            char[] invalid = Path.GetInvalidPathChars();
            string valid =  new string(fileName.Where(letter => !invalid.Contains(letter)).ToArray());
         
            return Path.Combine(_prefixSource, valid);
        }
        
        public string GenerateFullDestinationPath(Job njob)
        {
            string fileName = njob.VideoFile.FileName;
            char[] invalid = Path.GetInvalidPathChars();
            string valid =  new string(fileName.Where(letter => !invalid.Contains(letter)).ToArray());

            return Path.Combine(_prefixDestination, valid);
        }
    }
}