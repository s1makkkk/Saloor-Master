using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECS;
using Leopotam.Ecs;
public class LevelProps : MonoBehaviour
{
    private EcsEntity Entity;

    void Start()
    {
        Entity = EcsStartup.World.NewEntity();
        ref ECS.Components.MovementComponent movement = ref Entity.Get<ECS.Components.MovementComponent>();
        movement.Direction = Vector2.down;
        movement.self = transform;
        movement.speed = 0.5f;
        movement.RotationOffset = Random.Range(-10, 10);
    }


}
