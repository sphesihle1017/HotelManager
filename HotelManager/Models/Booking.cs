using System;
using System.ComponentModel.DataAnnotations;

public class Booking
{
    [Key]
    public int BookingId { get; set; }

    [Required(ErrorMessage = "Check-in date is required.")]
    [DataType(DataType.Date)]
    public DateTime CheckInDate { get; set; }

    [Required(ErrorMessage = "Check-out date is required.")]
    [DataType(DataType.Date)]
    public DateTime CheckOutDate { get; set; }

    [Required]
    [Range(1, 1000000, ErrorMessage = "Total amount must be greater than 0.")]
    public decimal TotalAmount { get; set; }

    [Required]
    public string BookingStatus  { get; set; }

    [Required]
    public int CustomerId { get; set; }

    [Required]
    public int RoomId { get; set; }

    public virtual Customer Customer { get; set; }
    public virtual Room Room { get; set; }
}
