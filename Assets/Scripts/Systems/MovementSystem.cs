using Leopotam.Ecs;
using UnityEngine;
namespace ECS.Systems
{
    sealed class MovementSystem : IEcsRunSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        EcsFilter<Components.MovementComponent> filter;
        void IEcsRunSystem.Run()
        {
            foreach (var i in filter)
            {
                ref Components.MovementComponent movement = ref filter.Get1(i);
                if (!movement.isLocal)
                {
                    movement.self.Translate(movement.Direction * movement.speed * Time.deltaTime, Space.World);
                }
                else
                {
                    movement.self.Translate(movement.Direction * movement.speed * Time.deltaTime, Space.Self);
                }

                if (movement.RotationOffset != 0)
                {
                    movement.self.Rotate(0, 0, movement.RotationOffset*Time.deltaTime);
                }

            }
        }
    }
}