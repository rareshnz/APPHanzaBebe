using APPHanzaBebe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPHanzaBebe.Services
{
    public interface IPacientService
    {
        Task<List<PacientModel>> GetPacientList();
        Task<int> AddPacient(PacientModel pacientModel);
        Task<int> DeletePacient(PacientModel pacientModel);
        Task<int> UpdatePacient(PacientModel pacientModel);
    }
}