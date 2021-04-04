using Leopotam.Ecs;

namespace ECS.Systems
{
    sealed class MenuUiInitSystem : IEcsInitSystem
    {
        readonly EcsWorld _world = null;
        private readonly MenuUI menuUI;
        private readonly ScoreService scoreService;

        public void Init()
        {
            menuUI.BestScore.text = "Best Score: " + (int) scoreService.BestResult;
        }
    }
}