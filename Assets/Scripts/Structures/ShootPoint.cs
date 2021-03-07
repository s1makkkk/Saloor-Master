using UnityEngine;

[System.Serializable]
public struct ShootPoint
{
    public ShootPoint(Transform t, Vector2 dir)
    {
        transform = t;
        Direction = dir;
    }


    public Transform transform;
    public Vector2 Direction;
}