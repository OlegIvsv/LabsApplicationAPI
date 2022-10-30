﻿namespace LabsApplicationAPI.ViewModels
{
    public class CustomerVM
    {
        public int Id { get; set; }

        public string Firstname { get; set; } = null!;

        public string Lastname { get; set; } = null!;

        public int Age { get; set; }

        public string Country { get; set; } = null!;

        public bool? Gender { get; set; }

        public string EmailAddress { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? ProfilePicture { get; set; }
    }
}
