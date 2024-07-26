namespace FocalTest2.Model
{
    public class PatientData
    {
        public int PatientId { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string MedicalHistory { get; set; }
        public string Allergies { get; set; }
    }
}
