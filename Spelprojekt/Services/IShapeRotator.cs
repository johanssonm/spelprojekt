namespace Spelprojekt
{
        public interface IShapeRotator
        {
            Shape RotateDefault(Shape shape);
            Shape RotateRight(Shape shape);
            Shape RotateDown(Shape shape);
            Shape RotateLeft(Shape shape);

        }
    
}