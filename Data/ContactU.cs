using System;
using System.Collections.Generic;

namespace SCBankGym.Data
{
    public partial class ContactU
    {
        public int ContactUsId { get; set; }
        public string Name { get; set; } = null!;
        public string Message { get; set; } = null!;
        public string? Phone { get; set; }
        public int? TrineeId { get; set; }

        public virtual Trainee? Trinee { get; set; }
    }
}
