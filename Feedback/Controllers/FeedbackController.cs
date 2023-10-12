﻿using Microsoft.AspNetCore.Mvc;
using Feedback.Models;
using System.Diagnostics;


namespace Feedback.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly Feedback _context;

        public FeedbackController(Feedback context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Index(FeedbackViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Проверить, существует ли отзыв с такой почтой
                var existingFeedback = await _context.Feedbacks.FirstOrDefaultAsync(f => f.Email == model.Email);

                if (existingFeedback == null)
                {
                    // Если отзыв с такой почтой не существует, создать новый
                    var feedback = new Feedback
                    {
                        Experience = model.Experience,
                        Name = model.Name,
                        Email = model.Email,
                        Phone = model.Phone,
                        Message = model.Message,
                        Rating = model.Rating
                    };

                    _context.Feedbacks.Add(feedback);
                }
                else
                {
                    // Если отзыв с такой почтой существует, спросить пользователя о перезаписи
                    // Здесь вы можете предоставить пользователю опцию перезаписать отзыв или отказаться

                    // Например:
                    var overwrite = true; // Предположим, что пользователь согласился на перезапись
                    if (overwrite)
                    {
                        existingFeedback.Experience = model.Experience;
                        existingFeedback.Name = model.Name;
                        existingFeedback.Phone = model.Phone;
                        existingFeedback.Message = model.Message;
                        existingFeedback.Rating = model.Rating;
                    }
                }

                await _context.SaveChangesAsync();

                // Дополнительные действия после сохранения данных

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public IActionResult Confirmation()
        {
            return View();
        }

    }
}