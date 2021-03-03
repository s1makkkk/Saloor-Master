using ECS;
using UnityEngine;
using System;

namespace ECS.Components
{
    struct ShootComponent
    {
        public Transform[] Point;
        public float Damage;
        public GameObject Prefab;

    }
}