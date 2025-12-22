using elephantocracy.Enums;

namespace elephantocracy.Interfaces
{
    public interface IInputSource
    {
        Direction? MoveDirection { get; }
        bool FirePressed { get; }
    }
}