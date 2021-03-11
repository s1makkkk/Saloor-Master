using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECS;
using Leopotam.Ecs;
public class Bullet : MonoEntity
{
    //public Vector2 Dir { get; set; }


    [SerializeField] private Vector2 Direction;
    [SerializeField] private float Speed;
    [SerializeField] private GameObject Particle;
    [SerializeField] private float Delay;

    [HideInInspector] public string Sender;

    void Start()
    {
        Entity = EcsStartup.World.NewEntity();
        ref ECS.Components.MovementComponent movement = ref Entity.Get<ECS.Components.MovementComponent>();
        movement.Direction = Direction;
        movement.self = transform;
        movement.speed = Speed;
        movement.isLocal = true;
        ref ECS.Components.DelayComponent delay = ref Entity.Get<ECS.Components.DelayComponent>();
        delay.TimeDelay = Delay;
    }
    //TODO: Здесь срочно нжен рефакторинг.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Sender != "Player")
        {
            string Log = "";
            SendCollisionEvent(gameObject);

            Debug.Log(Log);
        }
        if (!collision.gameObject.CompareTag("Player") && Sender == "Player")
        {
            SendCollisionEvent(gameObject);
            SendCollisionEvent(collision.gameObject,true);

        }
    }
    public void SetDirection(Vector2 dir)
    {
        Direction = dir;
    }
    private void SendCollisionEvent(GameObject Hit, bool isSendOfHit = false)
    {

        if (!isSendOfHit)
        {
            ref ECS.Components.Events.HitEvent _eventSender = ref Entity.Get<ECS.Components.Events.HitEvent>();
            _eventSender.Hit =  Hit;
            _eventSender.Particle = Particle;
            _eventSender.Position = transform.position;
        }
        if (isSendOfHit)
        {
            ref ECS.Components.Events.HitEvent _eventSender = ref Hit.GetComponent<MonoEntity>().Entity.Get<ECS.Components.Events.HitEvent>();
            _eventSender.Hit = Hit;
            _eventSender.Particle = Particle;
            _eventSender.Position = Hit.transform.position;
        }

    }
    private void SendDestroyPlayerEvent()
    {

    }

}
