namespace OutboxPattern_Email.EmailService
{
    // This class is going to set all information inside the appsettings.json file to the Program.cs file
    public class EmailSettings
    {
        public const string SectionName = "EmailSettings";
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
