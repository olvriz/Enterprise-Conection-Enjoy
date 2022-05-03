using Fiap.Domain.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Domain.Entities
{
    public class Candidate
    {
        public Candidate() { }

        public Candidate(CandidateCreateRequest candidate)
        {
            Name = candidate.Name;
            Document = candidate.Document;
            Email = candidate.Email;
            PhoneNumber = candidate.PhoneNumber;            
            BirthDate = candidate.BirthDate;
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;        
        public DateTime BirthDate { get; set; }
        public List<string>? Skills { get; set; }
        public List<string>? Certifications { get; set; }
    }
}
