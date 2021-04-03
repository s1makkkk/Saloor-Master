using Leopotam.Ecs;
using UnityEngine;
using System;
namespace ECS.Systems
{
    sealed class ShootPlayerSystem : IEcsRunSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        EcsFilter<Components.InputComponent, Components.ShootComponent> filter;

        void IEcsRunSystem.Run()
        {
            foreach(var i in filter)
            {

                ref Components.InputComponent input = ref filter.Get1(i);
                ref Components.ShootComponent shootComponent = ref filter.Get2(i);

                if(input.isShoot)
                {
                    Debug.Log("Shoot");
                    Shoot(ref shootComponent);   
                }


            }

        }

        private void Shoot(ref Components.ShootComponent shootComponent)
        {
            for (int i = 0; i < shootComponent.Point.Length; i++)
            {
                GameObject bullet = GameObject.Instantiate(shootComponent.Prefab,
                    shootComponent.Point[i].transform.position,Quaternion.identity);
                bullet.GetComponent<Bullet>().Sender = "Player";
            }

        }
    }
}