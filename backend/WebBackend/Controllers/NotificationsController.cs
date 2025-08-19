using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBackend.Dtos.Notifications;
using WebBackend.Models;
using WebBackend.Services.Generic;

namespace WebBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly IGenericService<Notification> _notificationService;
        public NotificationsController(IGenericService<Notification> notificationService)
        {
            _notificationService = notificationService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var notifications = await _notificationService.GetAll();
            return Ok(notifications);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var notification = await _notificationService.GetById(id);
            if (notification == null)
            {
                return NotFound($"Notification with ID {id} not found");
            }
            return Ok(notification);
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateNotificationDto notificationDto)
        {
            var notification = new Notification
            {
                UserId = notificationDto.UserId,
                Message = notificationDto.Message,
                Link = notificationDto.Link,
                IsRead = notificationDto.IsRead,
                CreatedAt = notificationDto.CreatedAt

            };

            if (notification == null)
            {
                return BadRequest("Notification cannot be null");
            }
            await _notificationService.Add(notification);
            return CreatedAtAction(nameof(GetById), new { id = notification.Id }, notification);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateNotificationDto notificationDto)
        {
            var existingNotification = await _notificationService.GetById(id);
            if (existingNotification == null)
            {
                return NotFound($"Notification with ID {id} not found");
            }

            existingNotification.UserId = notificationDto.UserId;
            existingNotification.Message = notificationDto.Message;
            existingNotification.Link = notificationDto.Link;
            existingNotification.IsRead = notificationDto.IsRead;
            existingNotification.CreatedAt = notificationDto.CreatedAt;


            await _notificationService.Update(existingNotification);
            return Ok(existingNotification);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingNotification = await _notificationService.GetById(id);
            if (existingNotification == null)
            {
                return NotFound($"Notification with ID {id} not found");
            }
            await _notificationService.Delete(id);
            return Ok();
        }
    }
}
