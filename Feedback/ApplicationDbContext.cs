using Feedback.Models;
using Microsoft.EntityFrameworkCore;

namespace Feedback
{
    public class FeedbackContext : DbContext
    {
        public FeedbackContext(DbContextOptions<FeedbackContext> options) : base(options) { }

        public DbSet<FeedbackViewModel> Feedbacks { get; set; }
    }
}
