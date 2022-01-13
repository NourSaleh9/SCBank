using System;
using System.Collections.Generic;

namespace SCBankGym.Data
{
    public partial class Trainee
    {
        public Trainee()
        {
            ContactUs = new HashSet<ContactU>();
            Trainers = new HashSet<Trainer>();
        }

        public int TraineeId { get; set; }
        public string FirstName { get; set; } = null!;
        public int Age { get; set; }
        public string Gender { get; set; } = null!;
        public string? Passwordd { get; set; }
        public string? Photo { get; set; }
        public string? Subscription { get; set; }
        public string? Class { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? City { get; set; }

        public virtual ICollection<ContactU> ContactUs { get; set; }
        public virtual ICollection<Trainer> Trainers { get; set; }
    }
}
