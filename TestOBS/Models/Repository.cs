using TestOBS.Models;

namespace TestOBS.Models
{
    public static class Repository
    {
        private static List<Admin> registered = new();

        public static IEnumerable<Admin> Registered => registered;
        

         public static void Add(Admin user)
         {
            registered.Add(user);
         }

    }
}