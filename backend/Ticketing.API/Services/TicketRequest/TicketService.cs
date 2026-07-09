using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticketing.API.DTOs;
using Ticketing.API.Entities;
using Ticketing.API.Interfaces;

namespace Ticketing.API.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        /// <summary>
        /// Logika Penerbitan E-Ticket Nyata (Sudah Diperbaiki)
        /// </summary>
        public async Task<TicketResponseDto> IssueTicketAsync(IssueTicketRequestDto request)
        {
            // 1. Generate Kode Tiket unik, misal: TKT-20260709-ABCD123
            string uniqueCode = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
            string ticketCode = $"TKT-{DateTime.UtcNow:yyyyMMdd}-{uniqueCode}";
            
            // 2. Generate Hash untuk QR Code
            string qrHash = Guid.NewGuid().ToString(); 

            // 3. Petakan data request ke Entity Database
            var ticket = new Ticket
            {
                OrderId = request.OrderId,
                OrderItemId = request.OrderItemId,
                UserId = request.UserId,
                SeatId = request.SeatId,
                TicketCode = ticketCode,
                Status = "valid",
                CreatedAt = DateTime.UtcNow,
                QrCodes = new List<QrCode>
                {
                    new QrCode
                    {
                        QrHash = qrHash,
                        GeneratedAt = DateTime.UtcNow
                    }
                }
            };

            // 4. Simpan ke Database lewat Repository
            var createdTicket = await _ticketRepository.CreateTicketAsync(ticket);

            // 5. Kembalikan data dalam bentuk Response DTO ke Controller
            return new TicketResponseDto
            {
                Id = createdTicket.Id,
                TicketCode = createdTicket.TicketCode,
                Status = createdTicket.Status,
                QrHash = qrHash,
                CreatedAt = createdTicket.CreatedAt
            };
        }

        /// <summary>
        /// Mengambil detail e-ticket berdasarkan ID
        /// </summary>
        public async Task<TicketResponseDto?> GetTicketByIdAsync(long id)
        {
            var ticket = await _ticketRepository.GetTicketByIdAsync(id);
            if (ticket == null) return null;

            // Ambil QrHash dari koleksi QrCodes (jika ada)
            string activeQrHash = ticket.QrCodes.FirstOrDefault()?.QrHash ?? string.Empty;

            return new TicketResponseDto
            {
                Id = ticket.Id,
                TicketCode = ticket.TicketCode,
                Status = ticket.Status,
                QrHash = activeQrHash,
                CreatedAt = ticket.CreatedAt
            };
        }

        /// <summary>
        /// Mengambil daftar e-ticket berdasarkan User ID
        /// </summary>
        public async Task<IEnumerable<TicketResponseDto>> GetTicketsByUserIdAsync(long userId)
        {
            var tickets = await _ticketRepository.GetTicketsByUserIdAsync(userId);
            
            return tickets.Select(t => new TicketResponseDto
            {
                Id = t.Id,
                TicketCode = t.TicketCode,
                Status = t.Status,
                QrHash = t.QrCodes.FirstOrDefault()?.QrHash ?? string.Empty,
                CreatedAt = t.CreatedAt
            }).ToList();
        }
    }
}