using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NTTDATA.Application.Interfaces.Services
{
    public interface IMovementService
    {
        Task<ResulsetDto> GenerateProcess(MovementDTO mov);
    }
}
