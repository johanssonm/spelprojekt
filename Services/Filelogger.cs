using Infrastructure.Contracts;
using Spelprojekt.Services;
using System.ComponentModel;
using System.IO;

namespace Spelprojekt.Data
{
    class Filelogger : ILog
    {
        public void LogShape(IShape shape)
        {
            var filepath = "../../log.txt";
            var sr = new StreamWriter(filepath, true);
            var name = TypeDescriptor.GetClassName(shape);

            using (sr)
            {
                sr.WriteLine($"{name}, {shape.ShapeColor}");
            }

        }

    }
}
