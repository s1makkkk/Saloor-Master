using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECS;
using Leopotam.Ecs;


public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float Speed;

    [Header("Shoot")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private float Damage;
    [SerializeField] private Transform[] Points;

    [Header("Effects")]
    [SerializeField] private GameObject particle;

    private EcsEntity Entity;
    void Start()
    {

        Entity = EcsStartup.World.NewEntity();
        Entity.Get<ECS.Components.InputComponent>();

        ref ECS.Components.MovementPlayerComponent movement = ref Entity.Get<ECS.Components.MovementPlayerComponent>();
        movement.self = transform;
        movement.Speed = Speed;
        
        ref ECS.Components.ShootComponent shootComponent = ref Entity.Get<ECS.Components.ShootComponent>();
        shootComponent.Damage = Damage;
        shootComponent.Point = ConvertToPoints(Points);
        shootComponent.Prefab = bullet;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision!!");
        if (!collision.gameObject.CompareTag("Bullet"))
        {
            ref ECS.Components.Events.DestroyPlayerEvent Event = ref Entity.Get<ECS.Components.Events.DestroyPlayerEvent>();
            Event.gameObject = gameObject;
            Event.ParticleEffect = particle;
        }
    }

    private ShootPoint[] ConvertToPoints(Transform[] t)
    {
        ShootPoint[] shootPoint = new ShootPoint[t.Length]; 
        for(int i = 0;i<t.Length;i++)
        {
            shootPoint[i] = new ShootPoint(t[i], Vector2.up);
        }
        return shootPoint;
    }
}
