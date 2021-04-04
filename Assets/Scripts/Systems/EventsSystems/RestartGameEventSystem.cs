using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace ECS.Systems.Events
{
    sealed class RestartGameEventSystem : IEcsRunSystem
    {
        readonly EcsWorld _world = null;
        readonly GameData data;
        readonly ScoreService scoreService;

        EcsFilter<Components.Events.GameLoseEvent> filter;

        void IEcsRunSystem.Run()
        {
            foreach(var i in filter)
            {
                if(Input.anyKeyDown)
                {
                    scoreService.UpdateResult();
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }

        }
    }
}