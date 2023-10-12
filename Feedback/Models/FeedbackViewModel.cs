using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Feedback.Models
{
    public class FeedbackViewModel
    {
        [Required]
        public string Name { get; set; } //���

        [Required]
        [EmailAddress]
        public string Email { get; set; } //�����

        [Required]
        public string Message { get; set; } //�����
        [Required]
        public int Id { get; set; } //���� ������
        [Required]
        public string Experience { get; set; } //����(�����) ������������� 
        [Required]
        public int Rating { get; set; }//������
        [Required]
        public int Phone { get; set; } //�������

    }
}