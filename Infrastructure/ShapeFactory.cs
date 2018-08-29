using System;
using Infrastructure.Contracts;
using TetrisUI;

namespace Spelprojekt.Services
{
    public class ShapeFactory : IShape
    {

        public static IShape MakeShape(string shapeType)
        {
            IShape shape = null;

            switch (shapeType.ToLower())
            {
                case "i":
                    shape = new iShape();
                    break;
                case "j":
                    shape = new jShape();
                    break;
                case "l":
                    shape = new lShape();
                    break;
                case "o":
                    shape = new oShape();
                    break;
                case "s":
                    shape = new sShape();
                    break;
                case "t":
                    shape = new tShape();
                    break;
                case "z":
                    shape = new zShape();
                    break;
                case "test":
                    shape = new testShape();
                    break;

                    default:
                    throw new ArgumentException("Invalid shape name");
                    
            }

            return shape;
        }

        public int Id { get; set; }
        public bool IsInPlay { get; set; }
        public string Name { get; set; }
        public bool CanBeRotated { get; set; }
        public bool[,] ShapeGrid { get; set; }
        public int GameGridXPosition { get; set; }
        public int GameGridYPosition { get; set; }
        public ShapeColor ShapeColor { get; set; }
    }
}
