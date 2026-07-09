using System;
using System.Linq;
using System.Threading.Tasks;
using Ticketing.API.DTOs;
using Ticketing.API.Entities;
using Ticketing.API.Interfaces;

namespace Ticketing.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        // Catatan: Dalam skenario nyata, Anda harus meng-inject ITicketTypeRepository 
        // untuk mengambil harga (UnitPrice) asli dari database demi keamanan.

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderResponseDto> CreateOrderAsync(CreateOrderRequestDto request)
        {
            // 1. Generate Nomor Order (Contoh: ORD-20231025-ABCD)
            string orderNumber = $"ORD-{DateTime.UtcNow:yyyyMMdd}-{Guid.NewGuid().ToString().Substring(0, 4).ToUpper()}";

            // 2. Mapping DTO ke Entity dan hitung harga
            var order = new Order
            {
                UserId = request.UserId,
                OrderNumber = orderNumber,
                Status = "pending",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddMinutes(15), // Diberi waktu 15 menit untuk bayar
                
                OrderItems = request.Items.Select(item => 
                {
                    decimal mockUnitPrice = 50000m; // TODO: Ambil UnitPrice dari database berdasarkan item.TicketTypeId
                    
                    return new OrderItem
                    {
                        TicketTypeId = item.TicketTypeId,
                        Quantity = item.Quantity,
                        UnitPrice = mockUnitPrice,
                        Subtotal = item.Quantity * mockUnitPrice
                    };
                }).ToList()
            };

            // Hitung Total Amount dari seluruh Subtotal OrderItems
            order.TotalAmount = order.OrderItems.Sum(i => i.Subtotal);

            // 3. Simpan ke database
            var createdOrder = await _orderRepository.CreateOrderAsync(order);

            // 4. Return DTO response
            return new OrderResponseDto
            {
                Id = createdOrder.Id,
                OrderNumber = createdOrder.OrderNumber,
                TotalAmount = createdOrder.TotalAmount,
                Status = createdOrder.Status,
                ExpiresAt = createdOrder.ExpiresAt
            };
        }
    }
}