using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticketing.API.DTOs;
using Ticketing.API.Entities;
using Ticketing.API.Interfaces;

namespace Ticketing.API.Services
{
    public class TicketTypeService : ITicketTypeService
    {
        private readonly ITicketTypeRepository _repository;

        public TicketTypeService(ITicketTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<TicketTypeResponseDto> CreateTicketTypeAsync(CreateTicketTypeDto dto)
        {
            // 1. Map DTO ke Entity
            var ticketType = new TicketType
            {
                EventId = dto.EventId,
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                TotalQuota = dto.TotalQuota,
                StartSales = dto.StartSales,
                EndSales = dto.EndSales,
                IsNumberedSeat = dto.IsNumberedSeat,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(ticketType);
            
            // 2. Buat Stock awal
            var ticketStock = new TicketStock
            {
                TicketType = ticketType,
                AvailableStock = (uint)dto.TotalQuota,
                BookedStock = 0,
                SoldStock = 0,
                UpdatedAt = DateTime.UtcNow
            };

            await _repository.AddStockAsync(ticketStock);
            
            // 3. Simpan Transaksi
            await _repository.SaveChangesAsync();

            // 4. Map ke Response DTO
            return new TicketTypeResponseDto
            {
                Id = ticketType.Id,
                EventId = ticketType.EventId,
                Name = ticketType.Name,
                Description = ticketType.Description,
                Price = ticketType.Price,
                TotalQuota = ticketType.TotalQuota,
                IsNumberedSeat = ticketType.IsNumberedSeat,
                AvailableStock = ticketStock.AvailableStock
            };
        }

        public async Task<IEnumerable<TicketTypeResponseDto>> GetTicketTypesByEventAsync(long eventId)
        {
            var ticketTypes = await _repository.GetByEventIdAsync(eventId);
            
            // Note: Idealnya join dengan TicketStock Repository untuk mengambil AvailableStock.
            // Untuk kesederhanaan contoh, kita asumsikan pemetaan dasar.
            return ticketTypes.Select(t => new TicketTypeResponseDto
            {
                Id = t.Id,
                EventId = t.EventId,
                Name = t.Name,
                Description = t.Description,
                Price = t.Price,
                TotalQuota = t.TotalQuota,
                IsNumberedSeat = t.IsNumberedSeat
            });
        }
    }
}