using elephantocracy.Enums;

namespace InputForm
{
    public interface IInputSource
    {
        Direction? MoveDirection { get; }
        bool FirePressed { get; }
        void Reset();
    }
}