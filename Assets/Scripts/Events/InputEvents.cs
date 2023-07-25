using UnityEngine.Events;

public static class InputEvents
{
    public static UnityEvent moveLeftEvent = new UnityEvent();
    public static UnityEvent moveRightEvent = new UnityEvent();
    public static UnityEvent moveForwardEvent = new UnityEvent();
    public static UnityEvent moveBackwardEvent = new UnityEvent();

    public static UnityEvent exitEvent = new UnityEvent();
}
