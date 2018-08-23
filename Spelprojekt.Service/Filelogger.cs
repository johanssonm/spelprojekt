using System.IO;

namespace Spelprojekt.Services
{
    class Filelogger : ILog
    {
        public void LogShape(string message)
        {
            var filepath = "../../log.txt";
            var sr = new StreamWriter(filepath, true);

            using (sr)
            {
                sr.WriteLine($"{message}");
            }




        }
    }
}
