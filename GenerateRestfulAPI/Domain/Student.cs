namespace GenerateRestfulAPI.Domain
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Guid CourseID { get; set; }
        public Course Course { get; set;}
    }
}
