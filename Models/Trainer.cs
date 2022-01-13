using System;
using System.Collections.Generic;

namespace SCBankGym.Models
{
    public partial class TrainerModel
    {
        public int TrainerId { get; set; }
        public string Name { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public int Age { get; set; }
        public string Passwordd { get; set; } = null!;
        public string? Dayss { get; set; }
        public string? Photo { get; set; }
        public string? HoursFrom { get; set; }
        public string? HoursTo { get; set; }

        public TraineeModel Trainee { get; set; } = null!;
    }
}
