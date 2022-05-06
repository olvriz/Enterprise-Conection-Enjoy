using Microsoft.IdentityModel.Tokens;
using Fiap.Domain.Auth;
using Fiap.Domain.DomainServiceInterface;
using Fiap.Domain.Entities;
using Fiap.Domain.Models;
using Fiap.Domain.Models.Request;
using Fiap.Domain.RepositoryInterface;
using Fiap.Domain.ServiceInterface;
using Fiap.Domain.Strings;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Domain.DomainService
{
    public class CandidateDomainService : ICandidateDomainService
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateDomainService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<bool> CreateCandidate(CandidateCreateRequest candidateCreate)
        {
            return await _candidateRepository.CreateCandidate(new Candidate(candidateCreate));
        }

        public async Task<List<Candidate>> GetCandidates()
        {
            var candidates = await _candidateRepository.GetCandidates();
            
            return await GetCandidatesInfos(candidates);
        }
        

        public async Task<List<Candidate>> GetCandidatesWithFilter(string? skill, string? certification)
        {
            var candidates = await _candidateRepository.GetCandidatesWithFilter(skill, certification);

            return await GetCandidatesInfos(candidates);
        }

        private async Task<List<Candidate>> GetCandidatesInfos(List<Candidate> candidates)
        {
            foreach (var candidate in candidates)
            {
                candidate.Certifications = await _candidateRepository.GetCandidateCertifications(candidate.Id);
                candidate.Skills = await _candidateRepository.GetCandidateSkills(candidate.Id);
            }

            return candidates;
        }

        public async Task<bool> InsertCandidateCertifications(int candidateId, List<string> certifications)
        {
            foreach (var certification in certifications)
            {
                await _candidateRepository.InsertCertification(candidateId, certification);
            }

            return true;
        }

        public async Task<bool> InsertCandidateSkills(int candidateId, List<string> skills)
        {
            foreach (var skill in skills)
            {
                await _candidateRepository.InsertSkill(candidateId, skill);
            }

            return true;
        }
    }
}
