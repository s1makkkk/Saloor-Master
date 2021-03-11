using Leopotam.Ecs;
using UnityEngine;
using System;
using ECS;
namespace ECS.Systems
{
    sealed class InputSystem : IEcsRunSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        EcsFilter<ECS.Components.InputComponent> filter;



        void IEcsRunSystem.Run()
        {

            // Vector2 Dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            Vector2 Dir = Input.acceleration;
            bool MouseDown = false;
            if(Input.GetMouseButtonDown(0))
            {
                MouseDown = true;
            }
            else
            {
                MouseDown = false;
            }

            foreach (var i in filter)
            {
                ref Components.InputComponent input = ref filter.Get1(i);
                input.Direction = Dir;
                input.isShoot = MouseDown;
            }
        }
    }
}