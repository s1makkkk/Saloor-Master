using Leopotam.Ecs;
using ECS;
using UnityEngine;

namespace ECS.Systems.Events
{
    sealed class CollisionBulletEvent : IEcsRunSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        EcsFilter<Components.Events.CollisionEnterEvent, Components.Flags.BulletFlag> filter;
        GameData gameData;

        void IEcsRunSystem.Run()
        {
            foreach (var i in filter)
            {

                Debug.Log("Its Ready!");
                ref EcsEntity sender = ref filter.Get1(i).SenderEntity;
                ref EcsEntity other = ref filter.Get1(i).OtherEntity;

                if (other.Has<Components.Flags.PlayerFlag>())
                {
                    if (sender.Get<ECS.Components.SenderComponent>().Sender != "Player")
                    {
                        SendCollisionEvent(filter.Get1(i).Sender, sender);
                        Debug.Log("PlayerDead");
                    }
                }

                if (!other.Has<ECS.Components.Flags.PlayerFlag>())
                {
                    if (sender.Get<ECS.Components.SenderComponent>().Sender == "Player")
                    {
                        Debug.Log("I Dont know");
                        SendCollisionEvent(filter.Get1(i).Sender, sender);
                        SendCollisionEvent(filter.Get1(i).Other.gameObject,other);
                    }

                }

                filter.GetEntity(i).Del<Components.Events.CollisionEnterEvent>();
            }
        }




        private void SendCollisionEvent(GameObject Hit,EcsEntity entity)
        {
            ECS.Components.Events.HitEvent _eventSender;
            _eventSender.Hit = Hit;
            _eventSender.Particle = gameData.ParticleEffect;
            _eventSender.Position = Hit.transform.position;
            entity.Replace(_eventSender);
        }
    }
}
