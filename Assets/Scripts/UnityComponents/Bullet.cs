using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECS;
using Leopotam.Ecs;
public class Bullet : MonoBehaviour
{
    //public Vector2 Dir { get; set; }


    [SerializeField] private Vector2 Direction;
    [SerializeField] private float Speed;
    [SerializeField] GameObject Particle;
    EcsEntity Entity;

    void Start()
    {
        Entity = EcsStartup.World.NewEntity();
        ref ECS.Components.MovementComponent movement = ref Entity.Get<ECS.Components.MovementComponent>();
        movement.Direction = Direction;
        movement.self = transform;
        movement.speed = Speed;
        movement.isLocal = true;
    }

    public void SetDirection(Vector2 dir)
    {
        Direction = dir;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       ref ECS.Components.Events.HitEvent _event = ref Entity.Get<ECS.Components.Events.HitEvent>();
        _event.Hit = collision.gameObject;
        _event.self = gameObject;
        _event.Particle = Particle;
    }
}
