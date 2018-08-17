using System.ComponentModel;
using System.IO;
using Spelprojekt.Services;

namespace Spelprojekt.Data
{
    class Filelogger : ILog
    {
        public void LogShape(Shape shape)
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
