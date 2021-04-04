using Leopotam.Ecs;
using ECS;
using UnityEngine;

namespace ECS.Systems.Events
{
    sealed class CollisionPlayerEvent : IEcsRunSystem
    {
        // auto-injected fields.

        readonly EcsWorld _world = null;
        EcsFilter<Components.Events.CollisionEnterEvent, Components.Flags.PlayerFlag> filter;
        GameData gameData;

        void IEcsRunSystem.Run()
        {
            foreach (var i in filter)
            {
                ref EcsEntity sender = ref filter.Get1(i).SenderEntity;
                ref EcsEntity other = ref filter.Get1(i).OtherEntity;

                if (other.Has<Components.Flags.BulletFlag>())
                {
                    if (other.Get<ECS.Components.SenderComponent>().Sender == "Enemy")
                    {
                        DestroyEntity(filter.Get1(i).Sender, sender);
                        SendGameLoseEvent();
                    }
                }
                if(other.Has<Components.Flags.LevelPropsFlag>())
                {
                    DestroyEntity(filter.Get1(i).Sender, sender);
                    SendGameLoseEvent();

                }

                filter.GetEntity(i).Del<Components.Events.CollisionEnterEvent>();
            }
        }


        private void DestroyEntity(GameObject gameObject, EcsEntity Entity)
        {
            ref ECS.Components.Events.DestroyEntityEvent Event = ref Entity.Get<ECS.Components.Events.DestroyEntityEvent>();
            Event.Obj = gameObject;
            Object.Instantiate(gameData.ParticleEffect, gameObject.transform.position, Quaternion.identity);
        }

        private void SendGameLoseEvent()
        {
            EcsEntity entity = _world.NewEntity();
            entity.Get<Components.Events.GameLoseEvent>();
        }

    }
}