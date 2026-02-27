using System.Collections.Generic;
using UnityEngine;

public class TeleportPoint : MonoBehaviour
{
    public Vector2 Position => transform.position;
    public static readonly List<TeleportPoint> TeleportPoints = new();

    private void OnEnable() => TeleportPoints.Add(this);
    private void OnDisable() => TeleportPoints.Remove(this);
}
