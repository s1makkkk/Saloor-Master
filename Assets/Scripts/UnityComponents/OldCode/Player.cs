using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECS;
using Leopotam.Ecs;
using UnityEngine.Serialization;


public class Player : MonoEntity
{

    [Header("Movement")]
    
    [SerializeField] private float speed;

    [Header("Shoot")]
    [SerializeField] private GameObject bullet; 
    [SerializeField] private float damage; 
    [SerializeField] private Transform[] points;
    void Start()
    {

        Entity = EcsStartup.World.NewEntity();
        Entity.Get<ECS.Components.InputComponent>();

        ref ECS.Components.MovementPlayerComponent movement = ref Entity.Get<ECS.Components.MovementPlayerComponent>();
        movement.self = transform;
        movement.Speed = speed;

        ref ECS.Components.ShootComponent shootComponent = ref Entity.Get<ECS.Components.ShootComponent>();
        shootComponent.Damage = damage;
        shootComponent.Point = ConvertToPoints(points);
        shootComponent.Prefab = bullet;

        Entity.Get<ECS.Components.Flags.PlayerFlag>();
    }
    private ShootPoint[] ConvertToPoints(Transform[] t)
    {
        ShootPoint[] shootPoint = new ShootPoint[t.Length];
        for (var i = 0; i < t.Length; i++)
        {
            shootPoint[i] = new ShootPoint(t[i], Vector2.up);
        }
        return shootPoint;
    }
}
