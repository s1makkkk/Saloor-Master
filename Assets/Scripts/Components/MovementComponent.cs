using UnityEngine;
using System;

namespace ECS.Components
{
    struct MovementComponent
    {
        public Transform self;
        public float speed;
        public Vector2 Direction;
        public float RotationOffset;
    }
}