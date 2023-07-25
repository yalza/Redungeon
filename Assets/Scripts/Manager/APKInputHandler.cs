using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APKInputHandler : MonoBehaviour
{
    public static KeyCode moveKeyCode;

    public void OnMoveLeft()
    {
        InputEvents.moveLeftEvent.Invoke();
        moveKeyCode = KeyCode.A;
    }
    public void OnMoveRight()
    {
        InputEvents.moveRightEvent.Invoke();
        moveKeyCode = KeyCode.D;
    }
    public void OnMoveForward()
    {
        InputEvents.moveForwardEvent.Invoke();
        moveKeyCode = KeyCode.W;
    }
    public void OnMoveBackward()
    {
        InputEvents.moveBackwardEvent.Invoke();
        moveKeyCode = KeyCode.S;
    }
}
