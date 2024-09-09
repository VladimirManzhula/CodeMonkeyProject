using UnityEngine;

namespace Databases.Keyboard
{
    public interface IKeyboardDatabase
    {
        KeyCode Interact { get; }
        KeyCode MoveForward { get; }
        KeyCode MoveBack { get; }
        KeyCode MoveLeft { get; }
        KeyCode MoveRight { get; }
    }
}