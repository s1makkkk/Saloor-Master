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
            foreach (var i in filter)
            {
                ref Components.Events.HitEvent Event = ref filter.Get1(i);

                Object.Destroy(Event.Hit);
                Object.Instantiate(Event.Particle,Event.Position,Quaternion.identity);
                filter.GetEntity(i).Destroy();

            }

        }
    }
}