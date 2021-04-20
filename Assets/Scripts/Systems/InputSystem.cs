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

            //Vector2 dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            Vector2 dir = Input.acceleration;
            bool onMouseDown;
            if(Input.GetMouseButtonDown(0))
            {
                onMouseDown = true;
            }
            else
            {
                onMouseDown = false;
            }

            foreach (var i in filter)
            {
                ref Components.InputComponent input = ref filter.Get1(i);
                input.Direction = dir;
                input.IsShoot = onMouseDown;
                input.PressAnyKey = onMouseDown;
            }
        }
    }
}