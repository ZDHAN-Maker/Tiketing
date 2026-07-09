using System;
using System.Threading.Tasks;
using Ticketing.API.DTOs;
using Ticketing.API.Entities;
using Ticketing.API.Interfaces;

namespace Ticketing.API.Services
{
    public class CheckInService : ICheckInService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly ICheckInRepository _checkInRepository;

        public CheckInService(ITicketRepository ticketRepository, ICheckInRepository checkInRepository)
        {
            _ticketRepository = ticketRepository;
            _checkInRepository = checkInRepository;
        }

        public async Task<CheckInResponseDto> ProcessCheckInAsync(CheckInRequestDto request, long gateOfficerId)
        {
            // 1. Validasi Keaslian Tiket
            var ticket = await _ticketRepository.GetTicketByCodeAsync(request.TicketCode);
            if (ticket == null)
            {
                return new CheckInResponseDto 
                { 
                    IsSuccess = false, 
                    Message = "Tiket tidak ditemukan atau tidak valid." 
                };
            }

            // 2. Pastikan tiket belum pernah digunakan
            if (ticket.Status.Equals("Checked In", StringComparison.OrdinalIgnoreCase))
            {
                return new CheckInResponseDto 
                { 
                    IsSuccess = false, 
                    Message = "Tiket sudah digunakan sebelumnya." 
                };
            }

            // 3. Ubah status tiket
            ticket.Status = "Checked In";
            await _ticketRepository.UpdateAsync(ticket);

            // 4. Catat riwayat Check-In
            var checkInRecord = new CheckIn
            {
                TicketId = ticket.Id,
                GateOfficerId = gateOfficerId,
                GateNumber = request.GateNumber,
                ScannedAt = DateTime.UtcNow,
                Status = "success"
            };

            await _checkInRepository.AddAsync(checkInRecord);

            // 5. Kembalikan respons sukses
            return new CheckInResponseDto
            {
                IsSuccess = true,
                Message = "Check-in berhasil.",
                TicketCode = ticket.TicketCode,
                ScannedAt = checkInRecord.ScannedAt
            };
        }
    }
}