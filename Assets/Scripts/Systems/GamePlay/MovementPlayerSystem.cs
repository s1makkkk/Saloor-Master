using Leopotam.Ecs;
using UnityEngine;
using ECS;
namespace ECS.Systems
{
    sealed class MovementPlayerSystem : IEcsRunSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        EcsFilter<Components.InputComponent, Components.MovementPlayerComponent> filter;

        void IEcsRunSystem.Run()
        {
            foreach (var i in filter)
            {
                ref Components.InputComponent input = ref filter.Get1(i);
                ref Components.MovementPlayerComponent movement = ref filter.Get2(i);

                movement.self.Translate(input.Direction * movement.Speed * Time.deltaTime);
            }


        }
    }
}