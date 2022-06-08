using NTTDATA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NTTDATA.Application.Interfaces.Repositories
{
    public interface IMovementRepository
    {
        Task<ResulsetBase> GetDetailsMov(MovementBase mov);
        Task<Resulset> GenerateProcessMov(MovementBase mov);        
    }
}
