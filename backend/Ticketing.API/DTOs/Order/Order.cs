using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ticketing.API.DTOs
{
    public class CreateOrderRequestDto
    {
        [Required]
        public long UserId { get; set; } 
        [Required]
        [MinLength(1, ErrorMessage = "Minimal harus memesan 1 tiket.")]
        public List<OrderItemRequestDto> Items { get; set; } = new List<OrderItemRequestDto>();
    }

    public class OrderItemRequestDto
    {
        [Required]
        public long TicketTypeId { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "Kuantitas per tiket adalah 1 hingga 10.")]
        public uint Quantity { get; set; }
    }

    public class OrderResponseDto
    {
        public long Id { get; set; }
        public string OrderNumber { get; set; } = null!;
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = null!;
        public DateTime ExpiresAt { get; set; }
    }
}