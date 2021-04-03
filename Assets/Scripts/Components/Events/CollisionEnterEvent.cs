using UnityEngine;
using Leopotam.Ecs;
namespace ECS.Components.Events
{
    struct CollisionEnterEvent
    {
        public GameObject Sender;
        public Collision2D Other;

        public EcsEntity SenderEntity;
        public EcsEntity OtherEntity;
    }
}