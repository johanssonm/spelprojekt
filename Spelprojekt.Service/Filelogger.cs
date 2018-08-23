using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using Spelprojekt.Services;

namespace Spelprojekt.Data
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
