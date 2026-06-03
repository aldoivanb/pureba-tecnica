using System;

namespace testdevbackjr.Models
{
    public class User
    {
        public int User_id { get; set; }
        public required string Login { get; set; }
        public required string Nombres { get; set; }
        public required string ApellidoPaterno { get; set; }
        public required string ApellidoMaterno { get; set; }
        public required string Password { get; set; }

        public int TipoUser_id { get; set; }
        public int Status { get; set; }

        public DateTime fCreate { get; set; }

        public int? IDArea { get; set; }

        public DateTime? LastLoginAttempt { get; set; }

        public Area Area { get; set; } = null!;
    }
}