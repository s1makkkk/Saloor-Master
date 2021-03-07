using Leopotam.Ecs;
using UnityEngine;
namespace ECS.Components.Events
{
    struct HitEvent
    {
        public GameObject Hit;
        public GameObject self;
        public GameObject Particle;
        public Vector2 Position;
    }
}