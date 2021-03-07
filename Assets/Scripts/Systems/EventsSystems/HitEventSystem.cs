using Leopotam.Ecs;
using UnityEngine;
using ECS;
namespace ECS.Systems.Events
{
    sealed class HitEventSystem : IEcsRunSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        EcsFilter<Components.Events.HitEvent> filter;


        void IEcsRunSystem.Run()
        {
            foreach(var i in filter)
            {
                
                Components.Events.HitEvent Event = filter.Get1(1);
                Object.Destroy(Event.Hit);
                Object.Destroy(Event.self);
                Object.Instantiate(Event.Particle, Event.Position, Quaternion.identity);

            }
        }
    }
}