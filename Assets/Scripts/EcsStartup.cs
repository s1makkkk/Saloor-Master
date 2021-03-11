using Leopotam.Ecs;
using UnityEngine;
using ECS;

sealed class EcsStartup : MonoBehaviour
{
    public static EcsWorld World;
    EcsSystems SystemsUpdate;
    EcsSystems SystemsFixedUpdate;




    void Awake()
    {
        // void can be switched to IEnumerator for support coroutines.

        World = new EcsWorld();
        SystemsUpdate = new EcsSystems(World);
        SystemsFixedUpdate = new EcsSystems(World);

#if UNITY_EDITOR
       Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(World);
       Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(SystemsUpdate);
       Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(SystemsFixedUpdate);
#endif
        SystemsUpdate.Add(new ECS.Systems.InputSystem());
        SystemsUpdate.Add(new ECS.Systems.DelaySystem());
        SystemsUpdate.Add(new ECS.Systems.MovementPlayerSystem());
        SystemsUpdate.Add(new ECS.Systems.MovementSystem());
        SystemsUpdate.Add(new ECS.Systems.ShootPlayerSystem());
        SystemsUpdate.Add(new ECS.Systems.GeneratorSystem());
        SystemsUpdate.Add(new ECS.Systems.ShootSystem());


        //Events:
        SystemsUpdate.Add(new ECS.Systems.Events.DestroyEntityEventSystem());
        SystemsUpdate.Add(new ECS.Systems.Events.HitEventSystem());


        // register one-frame components (order is important), for example:
        // .OneFrame<TestComponent1> ()
        // .OneFrame<TestComponent2> ()

        // inject service instances here (order doesn't important), for example:
        // .Inject (new CameraService ())
        // .Inject (new NavMeshSupport ())
        SystemsUpdate.Init();

        SystemsFixedUpdate.Init();
    }

    void Update()
    {
        SystemsUpdate?.Run();
    }

    void OnDestroy()
    {


        if (SystemsUpdate != null)
        {
            SystemsUpdate.Destroy();
            SystemsUpdate = null;
        }
        if (SystemsFixedUpdate != null)
        {
            SystemsFixedUpdate.Destroy();
            SystemsFixedUpdate = null;
        }
        World.Destroy();
        World = null;
    }
}
