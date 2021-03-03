using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems.Events {
    sealed class DestroyPlayerEventSystem : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        EcsFilter<Components.Events.DestroyPlayerEvent> filter;
        
        void IEcsRunSystem.Run () {
            foreach(var i in filter)
            {
                Object.Instantiate(filter.Get1(i).ParticleEffect, filter.Get1(i).gameObject.transform.position, Quaternion.identity);
                Object.Destroy(filter.Get1(i).gameObject);

                filter.GetEntity(i).Destroy();
            }
            
        }
    }
}