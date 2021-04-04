using UnityEngine;
using UnityEngine.SceneManagement;
using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Components;

namespace ECS.Systems.Events
{
    public class MenuButtonsClicksSystem : IEcsRunSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        readonly EcsFilter<EcsUiClickEvent> _clickEvents = null;

        public void Run()
        {
            foreach (var idx in _clickEvents)
            {
                ref EcsUiClickEvent data = ref _clickEvents.Get1(idx);
                if (data.WidgetName.Equals("ButtonPlay"))
                {
                    SceneManager.LoadScene("Level");
                }
            }
        }
    }
}
