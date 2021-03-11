using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ECS;
using Leopotam.Ecs;


public class EnemyShip : MonoEntity
{
    [Header("Shoot")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private float Damage;
    [SerializeField] private ShootPoint[] Points;


    void Start()
    {
        Entity = EcsStartup.World.NewEntity();

        ref ECS.Components.MovementComponent movement = ref Entity.Get<ECS.Components.MovementComponent>();
        movement.Direction = Vector2.down;
        movement.self = transform;
        movement.speed = Random.Range(0.4f, 2);
        movement.RotationOffset = Random.Range(-20, 20);

        ref ECS.Components.ShootComponent shootComponent = ref Entity.Get<ECS.Components.ShootComponent>();
        shootComponent.Damage = 0;
        shootComponent.Point = Points;
        shootComponent.Prefab = bullet;

        ref ECS.Components.DelayComponent Delay = ref Entity.Get<ECS.Components.DelayComponent>();
        Delay.TimeDelay = 3;
        Delay.Timer = 0;
    }

}
