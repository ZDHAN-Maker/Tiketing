using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticketing.API.DTOs;
using Ticketing.API.Entities;
using Ticketing.API.Interfaces;

namespace Ticketing.API.Services
{
    public class RefundService : IRefundService
    {
        private readonly IRefundRepository _refundRepository;

        public RefundService(IRefundRepository refundRepository)
        {
            _refundRepository = refundRepository;
        }

        public async Task<RefundResponseDto> CreateRefundRequestAsync(CreateRefundRequestDto request)
        {
            // Business Logic: Customer mengajukan refund
            var refund = new Refund
            {
                OrderId = request.OrderId,
                UserId = request.UserId,
                Amount = request.Amount,
                Reason = request.Reason,
                Status = "requested",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var createdRefund = await _refundRepository.AddAsync(refund);
            return MapToDto(createdRefund);
        }

        public async Task<RefundResponseDto> ProcessRefundStatusAsync(long id, UpdateRefundStatusDto request)
        {
            // Business Logic: Finance/CS memverifikasi dan memproses refund
            var refund = await _refundRepository.GetByIdAsync(id);
            if (refund == null) throw new KeyNotFoundException("Refund not found.");

            // Update data status dan log prosesnya
            refund.Status = request.Status;
            refund.ProcessedBy = request.ProcessedBy;
            refund.UpdatedAt = DateTime.UtcNow;

            // Jika approved, idealnya di sini Anda akan memanggil layanan Payment Gateway 
            // untuk mengembalikan dana (Refund diproses).

            await _refundRepository.UpdateAsync(refund);
            return MapToDto(refund);
        }

        public async Task<RefundResponseDto?> GetRefundByIdAsync(long id)
        {
            var refund = await _refundRepository.GetByIdAsync(id);
            return refund == null ? null : MapToDto(refund);
        }

        public async Task<IEnumerable<RefundResponseDto>> GetAllRefundsAsync()
        {
            var refunds = await _refundRepository.GetAllAsync();
            return refunds.Select(MapToDto);
        }

        // Helper mapper (Bisa diganti menggunakan AutoMapper)
        private static RefundResponseDto MapToDto(Refund refund)
        {
            return new RefundResponseDto
            {
                Id = refund.Id,
                OrderId = refund.OrderId,
                UserId = refund.UserId,
                Amount = refund.Amount,
                Reason = refund.Reason,
                Status = refund.Status,
                CreatedAt = refund.CreatedAt,
                UpdatedAt = refund.UpdatedAt
            };
        }
    }
}