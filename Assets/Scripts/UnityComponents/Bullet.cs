using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECS;
using Leopotam.Ecs;
public class Bullet : MonoEntity
{
    //public Vector2 Dir { get; set; }


    [SerializeField] private Vector2 Direction;
    [SerializeField] private float Speed;
    [SerializeField] private GameObject Particle;
    [SerializeField] private float Delay;

    [HideInInspector] public string Sender;

    void Start()
    {
        Entity = EcsStartup.World.NewEntity();
        ref ECS.Components.MovementComponent movement = ref Entity.Get<ECS.Components.MovementComponent>();
        movement.Direction = Direction;
        movement.self = transform;
        movement.speed = Speed;
        movement.isLocal = true;

        ref ECS.Components.DelayComponent delay = ref Entity.Get<ECS.Components.DelayComponent>();
        delay.TimeDelay = Delay;

        Entity.Get<ECS.Components.Flags.BulletFlag>();

        Entity.Get<ECS.Components.SenderComponent>().Sender = Sender;
    }
    public void SetDirection(Vector2 dir)
    {
        Direction = dir;
    }

}
