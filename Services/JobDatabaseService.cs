using System.Collections.Generic;
using MongoDB.Driver;
using VideoProject.Models;

namespace VideoProject.Services
{
    public class JobDatabaseService
    {
        private readonly IMongoCollection<Job> _jobs;

        public JobDatabaseService(IMDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _jobs = database.GetCollection<Job>(settings.CollectionName);
        }

        public List<Job> Get()
        {
            return _jobs.Find(job => true).ToList();
        }

        public Job Get(string id)
        {
            return _jobs.Find(job => job.Id == id).FirstOrDefault();
        }

        public Job Create(Job nJob)
        {
            _jobs.InsertOne(nJob);
            return nJob;
        }

        public void Update(string id, Job nJob)
        {
            _jobs.ReplaceOne(job => job.Id == nJob.Id, nJob);
        }

        public void Remove(Job nJob)
        {
            _jobs.DeleteOne(job => job.Id == nJob.Id);
        }

        public void Remove(string id)
        {
            _jobs.DeleteOne(job => job.Id == id);

        }
    }
}