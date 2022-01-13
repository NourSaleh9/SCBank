using System;
using System.Collections.Generic;

namespace SCBankGym.Models
{
    public partial class TraineeModel
    {
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

        public List<TrainerModel> TraineeNavigation { get; set; } = null!;
        public List<ContactUModel> ContactU { get; set; } = null!;
    }
}
