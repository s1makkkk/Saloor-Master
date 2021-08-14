using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
public class DelayComponent : MonoBehaviour
{
    [SerializeField] private float timeDelay;
    [SerializeField] private float timfeDelay;

    private EcsEntity entity;

    void Start()
    {
        entity = GetComponent<MonoEntity>().Entity;
        ref ECS.Components.DelayComponent component = ref entity.Get<ECS.Components.DelayComponent>();
        component.TimeDelay = timeDelay;
        component.

    }
}
