using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECS;
using Leopotam.Ecs;

public class LevelProps : MonoEntity
{

    void Start()
    {
        Entity = EcsStartup.World.NewEntity();
        ref ECS.Components.MovementComponent movement = ref Entity.Get<ECS.Components.MovementComponent>();
        movement.Direction = Vector2.down;
        movement.self = transform;
        movement.speed = Random.Range(0.4f,2);
        movement.RotationOffset = Random.Range(-20, 20);
    }


}
