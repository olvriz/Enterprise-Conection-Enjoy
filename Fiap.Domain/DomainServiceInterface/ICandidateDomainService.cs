using Fiap.Domain.Entities;
using Fiap.Domain.Models;
using Fiap.Domain.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Domain.DomainServiceInterface
{
    public interface ICandidateDomainService
    {
        Task<bool> CreateCandidate(CandidateCreateRequest victimCreate);
        Task<bool> InsertCandidateSkills(int candidateId, List<string> skills);
        Task<bool> InsertCandidateCertifications(int candidateId, List<string> certifications);
        Task<List<Candidate>> GetCandidates();
        Task<List<Candidate>> GetCandidatesWithFilter(string? skill, string? certification);
    }
}
