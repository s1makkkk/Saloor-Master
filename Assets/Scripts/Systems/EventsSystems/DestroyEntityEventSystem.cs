using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems.Events
{
    sealed class DestroyEntityEventSystem : IEcsRunSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        EcsFilter<Components.Events.DestroyEntityEvent> filter;

        void IEcsRunSystem.Run()
        {
            foreach (var i in filter)
            { 
                Object.Destroy(filter.Get1(i).Obj);
                filter.GetEntity(i).Destroy();
            }

        }
    }
}