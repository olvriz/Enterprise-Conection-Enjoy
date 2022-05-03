using Fiap.Domain.Entities;
using Fiap.Domain.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Domain.RepositoryInterface
{
    public interface ICandidateRepository
    {
        Task<bool> CreateCandidate(Candidate victimCreate);
        Task<bool> InsertSkill(int candidateId, string skill);
        Task<bool> InsertCertification(int candidateId, string certification);
        Task<List<Candidate>> GetCandidates();
        Task<List<string>> GetCandidateSkills(int candidateId);
        Task<List<string>> GetCandidateCertifications(int candidateId);
    }
}
