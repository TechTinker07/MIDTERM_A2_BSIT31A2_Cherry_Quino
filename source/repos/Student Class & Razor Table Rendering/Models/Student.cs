namespace Student_Class___Razor_Table_Rendering.Models
{
    public enum Gender {Unknown,Male, Female}
    public class Student
    {
        private string FirstName;
        private string LastName;
        private Gender gender = Gender.Unknown;

        public string Title{ get; set; }
        public string Course { get; set; }
        public string Section { get; set; }
        public DateTime Birthday { get; set; }

        //Constructors  
        public Student ()
        {
            FirstName = "Unknown";
            LastName = "Unknown";
        }

        public Student (string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        //Settters
        public void SetFirstName(string name) => FirstName = name;
        public void SetLastName(string name) => LastName = name;
        public void SetGender(Gender g) => gender = g;


        //computed properties
        public string FullName => $"{Title} {FirstName} {LastName}";
        public Gender Gender => gender;

        public int Age
        {
            get
            {
                var today = DateTime.Today;
                int age = today.Year - Birthday.Year;
                if (Birthday.Date > today.AddYears(-age)) age--;
                return age;
            }
        }
    }
}
