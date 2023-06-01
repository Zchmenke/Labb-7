namespace Labb_7
{
    public class Program
    {
        static void Main(string[] args)
        {
            RunInterface();
        }
        public static void RunInterface()
        {
            UserInterface userInterface = new UserInterface();
            userInterface.Menu();
        }
    }
}