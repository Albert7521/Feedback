using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Feedback.Models
{
    public class FeedbackViewModel
    {
        [Required]
        public string Name { get; set; } //имя
        [Required]
        [EmailAddress]
        public string Email { get; set; } //почта

        [Required]
        public string Message { get; set; } //отзыв
        [Required]
        public int Id { get; set; } //айди отзыва
        [Required]
        public string Experience { get; set; } //Опыт(время) использования 
        [Required]
        public int Rating { get; set; }//оценка
        [Required]
        public int Phone { get; set; } //Телефон
    }
}