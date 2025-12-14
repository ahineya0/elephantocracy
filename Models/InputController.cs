using elephantocracy.Enums;
using InputForm;

public class InputController : IInputSource
{
    private readonly HashSet<Keys> pressedKeys = new();

    private readonly Keys moveUpKey;
    private readonly Keys moveDownKey;
    private readonly Keys moveLeftKey;
    private readonly Keys moveRightKey;
    private readonly Keys fireKey;

    private bool firePressed;

    public InputController(Keys up, Keys down, Keys left, Keys right, Keys fire)
    {
        if (new HashSet<Keys> { up, down, left, right, fire }.Count != 5)
            throw new ArgumentException("Клавиши управления должны быть уникальными");

        moveUpKey = up;
        moveDownKey = down;
        moveLeftKey = left;
        moveRightKey = right;
        fireKey = fire;
    }

    public Direction? MoveDirection
    {
        get
        {
            if (pressedKeys.Contains(moveUpKey)) return Direction.Up;
            if (pressedKeys.Contains(moveDownKey)) return Direction.Down;
            if (pressedKeys.Contains(moveLeftKey)) return Direction.Left;
            if (pressedKeys.Contains(moveRightKey)) return Direction.Right;
            return null;
        }
    }

    public bool FirePressed => firePressed;

    public void OnKeyDown(Keys key)
    {
        pressedKeys.Add(key);
        if (key == fireKey) firePressed = true;
    }

    public void OnKeyUp(Keys key)
    {
        pressedKeys.Remove(key);
        if (key == fireKey) firePressed = false;
    }

    public void Reset() => firePressed = false;
}