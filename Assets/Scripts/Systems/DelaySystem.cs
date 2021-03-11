using Leopotam.Ecs;
using UnityEngine;
using ECS;
namespace ECS.Systems
{
    sealed class DelaySystem : IEcsRunSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        EcsFilter<Components.DelayComponent> filter;

        void IEcsRunSystem.Run()
        {
            foreach(var i in filter)
            {
                ref Components.DelayComponent delay = ref filter.Get1(i);
                delay.Timer += Time.deltaTime;
                if(delay.Timer>delay.TimeDelay)
                {
                    delay.TimeOut = true;
                    delay.Timer = 0;
                }
                
            }
        }
    }
}