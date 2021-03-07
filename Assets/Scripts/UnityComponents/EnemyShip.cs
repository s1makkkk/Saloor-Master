using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ECS;
using Leopotam.Ecs;


public class EnemyShip : MonoBehaviour
{
    [Header("Shoot")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private float Damage;
    [SerializeField] private ShootPoint[] Points;


    private EcsEntity Entity;

    void Start()
    {
        Entity = EcsStartup.World.NewEntity();

        ref ECS.Components.MovementComponent movement = ref Entity.Get<ECS.Components.MovementComponent>();
        movement.Direction = Vector2.down;
        movement.self = transform;
        movement.speed = 0.5f;
        movement.RotationOffset = Random.Range(-10, 10);

        ref ECS.Components.ShootComponent shootComponent = ref Entity.Get<ECS.Components.ShootComponent>();
        shootComponent.Damage = 0;
        shootComponent.Point = Points;
        shootComponent.Prefab = bullet;

        ref ECS.Components.DelayComponent Delay = ref Entity.Get<ECS.Components.DelayComponent>();
        Delay.TimeDelay = 3;
        Delay.Timer = 0;
    }

}
