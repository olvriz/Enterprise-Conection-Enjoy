using Dapper;
using Fiap.Domain.Entities;
using Fiap.Domain.Models.Request;
using Fiap.Domain.RepositoryInterface;
using Fiap.Infra.Data.Context;
using Fiap.Infra.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Infra.Data.Repository
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly OrcContext _orcContext;

        public CandidateRepository(OrcContext orcContext)
        {
            _orcContext = orcContext;
        }

        public async Task<bool> CreateCandidate(Candidate victimCreate)
        {
            var affectedRows = await _orcContext.Connection.ExecuteAsync(Queries.Queries.InsertCandidate, victimCreate);

            return affectedRows > 0;            
        }

        public async Task<List<string>> GetCandidateCertifications(int candidateId)
        {
            var certifications = await _orcContext.Connection.QueryAsync<string>(Queries.Queries.GetCandidateCertifications, new
            {
                candidateId
            });

            return certifications.ToList();
        }

        public async Task<List<Candidate>> GetCandidates()
        {
            var candidates = await _orcContext.Connection.QueryAsync<Candidate>(Queries.Queries.GetCandidates);

            return candidates.ToList();
        }

        public async Task<List<string>> GetCandidateSkills(int candidateId)
        {
            var skills = await _orcContext.Connection.QueryAsync<string>(Queries.Queries.GetCandidateSkills, new
            {
                candidateId
            });

            return skills.ToList();
        }

        public async Task<bool> InsertCertification(int candidateId, string certification)
        {
            var affectedRows = await _orcContext.Connection.ExecuteAsync(Queries.Queries.InsertCandidateCertification, new
            {
                candidateId,
                certification
            });

            return affectedRows > 0;
        }

        public async Task<bool> InsertSkill(int candidateId, string skill)
        {
            var affectedRows = await _orcContext.Connection.ExecuteAsync(Queries.Queries.InsertCandidateSkill, new
            {
                candidateId,
                skill
            });

            return affectedRows > 0;
        }
    }
}
