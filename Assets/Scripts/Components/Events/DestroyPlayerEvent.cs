using Leopotam.Ecs;
using UnityEngine;
namespace ECS.Components.Events
{

    struct DestroyPlayerEvent
    {
        public GameObject gameObject;
        public GameObject ParticleEffect;
    }
}