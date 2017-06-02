using Database.Services;

namespace Domain.Services
{
    public class Provider
    {
        public void Work()
        {
            using (var ctx = new Context())
            {
                Student stud = new Student() { StudentName = "New Student" };

                ctx.Students.Add(stud);
                ctx.SaveChanges();
            }
        }
    }
}
