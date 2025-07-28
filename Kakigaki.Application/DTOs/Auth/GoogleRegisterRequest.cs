using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kakigaki.Application.DTOs.Auth
{
    public class GoogleRegisterRequest
    {
        public required string Email { get; set; }
        public required string GoogleId { get; set; }
        public string DisplayName { get; set; } = string.Empty;
    }
}
