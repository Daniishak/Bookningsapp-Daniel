using BokningsApp.Logins;

namespace BokningsApp
{
    internal class Program
    {
        public bool IsLoggedIn { get; set; }
        static void Main(string[] args)
        {
            //@ krävs i användarnamnet för att det ska vara en admin
            Methods.Välkommen();
            
        }
    }
}