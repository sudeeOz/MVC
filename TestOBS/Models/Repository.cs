using TestOBS.Models;
using System.Linq;

namespace TestOBS.Models
{
    public static class Repository
    {
        private static List<Admin> registered = new();
        private static List<Teacher> teachers = new();
        private static List<Student> students = new();
        private static List<Lesson> lessonsList = new();

        public static IEnumerable<Admin> Registered => registered;
        public static IEnumerable<Teacher> Teachers => teachers;
        public static IEnumerable<Student> Students => students;
        public static IEnumerable<Lesson> Lessons => lessonsList;
   
         public static void Add(Admin user)
         {
            registered.Add(user);
         }

         public static void Add(Teacher teacher)
         {
            teachers.Add(teacher);
         }

         public static void Add(Student student)
         {
            students.Add(student);
         }

         public static void Add(Lesson lesson)
         {
            lessonsList.Add(lesson);
         }

    }
}