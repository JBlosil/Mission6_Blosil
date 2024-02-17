using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace Mission6_Blosil.Models
{
    public class MovieSubmissionContext : DbContext
    {
        public MovieSubmissionContext(DbContextOptions<MovieSubmissionContext> options) : base(options)
        {

        }
        public DbSet<MovieSubmission> MovieSubmission { get; set; }
    }
}
