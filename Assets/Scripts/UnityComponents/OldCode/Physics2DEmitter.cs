using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class Physics2DEmitter : MonoBehaviour
{
    private MonoEntity _monoEntity;

    private void Start()
    {
        _monoEntity = GetComponent<MonoEntity>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ref ECS.Components.Events.CollisionEnterEvent eventEnter =
            ref _monoEntity.Entity.Get<ECS.Components.Events.CollisionEnterEvent>();
        eventEnter.Other = collision;
        eventEnter.Sender = gameObject;
        eventEnter.SenderEntity = _monoEntity.Entity;
        eventEnter.OtherEntity = collision.gameObject.GetComponent<MonoEntity>().Entity;
    }
}