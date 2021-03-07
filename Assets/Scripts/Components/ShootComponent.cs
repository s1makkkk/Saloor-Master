using ECS;
using UnityEngine;
using System;
using System.Collections.Generic;
namespace ECS.Components
{
    struct ShootComponent
    {
        public ShootPoint[] Point;
        public float Damage;
        public GameObject Prefab;
    }
}