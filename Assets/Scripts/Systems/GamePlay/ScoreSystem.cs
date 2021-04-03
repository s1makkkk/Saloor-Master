using Leopotam.Ecs;
using UnityEngine.UI;

namespace ECS.Systems
{
    sealed class ScoreSystem : IEcsRunSystem
    {
        readonly EcsWorld _world = null;
        ScoreService scoreService = null;

        EcsFilter<Components.Events.GameLoseEvent> filter;

        void IEcsRunSystem.Run()
        {
            if (filter.GetEntitiesCount() == 0)
            {
                scoreService.Result += 0.2f;
            }

        }
    }
}