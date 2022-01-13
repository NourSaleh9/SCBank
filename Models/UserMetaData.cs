using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace SCBank.Models
{
    [MetadataType(typeof(UserMetaData))]
    public partial class Trainee
    {
    }
    class UserMetaData
    {
        [Remote("IsUserExists", "Home", ErrorMessage = "Email already in use")]
        public string Email { get; set; }
    }
}