using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECS;
using Leopotam.Ecs;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Vector2 Direction;
    [SerializeField] private float Speed;


    private EcsEntity Entity;
    void Start()
    {
        Entity = EcsStartup.World.NewEntity();
        ref ECS.Components.MovementComponent movement = ref Entity.Get<ECS.Components.MovementComponent>();
        movement.Direction = Direction;
        movement.self = transform;
        movement.speed = Speed;
    }

}
