using Leopotam.Ecs;
using ECS;
using UnityEngine;
namespace ECS.Systems
{
    sealed class ShootSystem : IEcsRunSystem
    {
        EcsFilter<Components.ShootComponent, Components.DelayComponent> filter;
        readonly EcsWorld _world = null;

        private void Shoot(ref Components.ShootComponent shootComponent)
        {
            for (int i = 0; i < shootComponent.Point.Length; i++)
            {
                GameObject bullet = GameObject.Instantiate(shootComponent.Prefab,
                    shootComponent.Point[i].transform.position, shootComponent.Point[i].transform.rotation);
                bullet.GetComponent<Bullet>().SetDirection(shootComponent.Point[i].Direction);
                bullet.GetComponent<Bullet>().Sender = "Enemy";
            }

        }

        void IEcsRunSystem.Run()
        {
            foreach (var i in filter)
            {

                ref Components.ShootComponent shootComponent = ref filter.Get1(i);
                ref Components.DelayComponent delay = ref filter.Get2(i);
                if (delay.TimeOut)
                {
                    Shoot(ref shootComponent);
                    delay.TimeOut = false;
                }

            }

        }
        /// <summary>
        /// TODO: Нужно вынести в отдельный класс.
        /// </summary>
        /// <param name="point"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
    }
}