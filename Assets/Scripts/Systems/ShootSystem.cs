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
                Debug.Log(shootComponent.Point[i].Direction.ToString());
            }

        }

        void IEcsRunSystem.Run()
        {
            foreach (var i in filter)
            {

                ref Components.ShootComponent shootComponent = ref filter.Get1(i);
                ref Components.DelayComponent Delay = ref filter.Get2(i);

                Delay.Timer += Time.deltaTime;
                if(Delay.Timer>=Delay.TimeDelay)
                {
                    Delay.Timer = 0;
                    Shoot(ref shootComponent);
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