using Leopotam.Ecs;
using LeopotamGroup.Globals;
using UnityEngine;
using ECS;
using ECS.Systems.Events;
using Leopotam.Ecs.Ui.Systems;
using Voody.UniLeo;

internal class EcsStartup : MonoBehaviour
{
    public static EcsWorld World; 

    /// <summary>
    /// TODO: Need refactoring!!
    /// </summary>
    
    [SerializeField] private Leopotam.Ecs.Ui.Systems.EcsUiEmitter uiEmitter = null;
    //Dependeies:
    private ScoreService scoreService = new ScoreService();
    public GameData gameData;

    private EcsSystems systemsUpdate;
    private EcsSystems systemsFixedUpdate;

    void Awake()
    {

        scoreService.Init();
        Service<ScoreService>.Set(scoreService);




        World = new EcsWorld();
        systemsUpdate = new EcsSystems(World);
        systemsFixedUpdate = new EcsSystems(World);
#if UNITY_EDITOR
       Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(World);
       Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(systemsUpdate);
       Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(systemsFixedUpdate);
#endif

        //Init Systems:
        systemsUpdate.ConvertScene();
        //Update Systems:
        systemsUpdate.Add(new ECS.Systems.InputSystem());
        systemsUpdate.Add(new ECS.Systems.DelaySystem());
        systemsUpdate.Add(new ECS.Systems.MovementPlayerSystem());
        systemsUpdate.Add(new ECS.Systems.MovementSystem());
        systemsUpdate.Add(new ECS.Systems.ShootPlayerSystem());
        systemsUpdate.Add(new ECS.Systems.GeneratorSystem());
        systemsUpdate.Add(new ECS.Systems.ShootSystem());
        systemsUpdate.Add(new ECS.Systems.ScoreSystem());
        systemsUpdate.Add(new ECS.Systems.ScoreOutSystem());

        
        
        //Events:
        systemsUpdate.Add(new ECS.Systems.Events.CollisionPlayerEvent());
        systemsUpdate.Add(new ECS.Systems.Events.CollisionBulletEvent());
        systemsUpdate.Add(new ECS.Systems.Events.HitEventSystem());
        systemsUpdate.Add(new ECS.Systems.Events.RestartGameEventSystem());
        systemsUpdate.Add(new ECS.Systems.Events.DestroyEntityEventSystem());
        
        //Events UI:

        // register one-frame components (order is important), for example:
        // .OneFrame<TestComponent1> ()
        // .OneFrame<TestComponent2> ()

        // inject service instances here (order doesn't important), for example:
        // .Inject (new CameraService ())
        // .Inject (new NavMeshSupport ())


        systemsUpdate.Inject(gameData);
        systemsUpdate.Inject(scoreService);
        systemsUpdate.InjectUi(uiEmitter);
        systemsUpdate.Init();

        systemsFixedUpdate.Init();
    }




    void Update()
    {
        systemsUpdate?.Run();
    }

    void OnDestroy()
    {


        if (systemsUpdate != null)
        {
            systemsUpdate.Destroy();
            systemsUpdate = null;
        }
        if (systemsFixedUpdate != null)
        {
            systemsFixedUpdate.Destroy();
            systemsFixedUpdate = null;
        }
        World.Destroy();
        World = null;
    }
}
