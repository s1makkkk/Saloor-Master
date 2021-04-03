using Leopotam.Ecs;

namespace ECS.Systems {
    sealed class ScoreOutSystem : IEcsRunSystem {

        readonly EcsWorld _world = null;
        readonly ScoreService scoreService = null;

        EcsFilter<Components.ScoreComponent> filter;


        void IEcsRunSystem.Run () {
            foreach(var i in filter)
            {
                filter.Get1(i).text.text = "Score: " + (int)scoreService.Result;
            }

        }
    }
}