using Leopotam.Ecs;
using LeopotamGroup.Globals;
using UnityEngine;
using ECS;
using ECS.Systems.Events;
using Leopotam.Ecs.Ui.Systems;
using UnityEngine.Assertions.Must;
using UnityEngine.Serialization;

internal class EcsStartupMenu : MonoBehaviour
{


    /// <summary>
    /// TODO: Need refactoringgg
    /// </summary>

    public static EcsWorld World;

    [SerializeField] private Leopotam.Ecs.Ui.Systems.EcsUiEmitter uiEmitter = null;

    //Dependeies:
    private ScoreService scoreService = new ScoreService();
    public MenuUI MenuUi = new MenuUI();

    private EcsSystems systemsUpdate;

    void Awake()
    {
        // void can be switched to IEnumerator for support coroutines.

        scoreService.Init();
        Debug.Log(scoreService.BestResult);
        Service<ScoreService>.Set(scoreService);
        Debug.Log(Service<ScoreService>.Get().BestResult);


            World = new EcsWorld();
        systemsUpdate = new EcsSystems(World);
#if UNITY_EDITOR
        Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(World);
        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(systemsUpdate);
#endif

        //Init Systems:
        systemsUpdate.Add(new ECS.Systems.MenuUiInitSystem());

        //Update Systems:

        //Events:

        //Events UI:
        systemsUpdate.Add(new ECS.Systems.Events.MenuButtonsClicksSystem());

        // register one-frame components (order is important), for example:
        // .OneFrame<TestComponent1> ()
        // .OneFrame<TestComponent2> ()

        // inject service instances here (order doesn't important), for example:
        // .Inject (new CameraService ())
        // .Inject (new NavMeshSupport ())
        systemsUpdate.Inject(scoreService);

        systemsUpdate.Inject(MenuUi);
        systemsUpdate.InjectUi(uiEmitter);
        systemsUpdate.Init();
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

        World.Destroy();
        World = null;
    }
}
