using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sample.API.Models.Requests
{
    public class MeetingEventRequest
    {
        [DefaultValue("00000000-0000-0000-0000-000000000000")]
        public Guid Id { get; set; } = Guid.Empty;

        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public DateTime? StartDate { get; set; }

        [Required]
        public DateTime? EndDate { get; set; }
    }
}