using System;
using System.Collections.Generic;

namespace SCBankGym.Models
{
    public partial class ContactUModel
    {
        public int ContactUsId { get; set; }
        public string Name { get; set; } = null!;
        public string Message { get; set; } = null!;
        public string? Phone { get; set; }

    }
}
