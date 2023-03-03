using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    public static event UnityAction SpacePressed;
    public static void OnSpacePressed() => SpacePressed?.Invoke();
}
