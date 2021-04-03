using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leopotam.Ecs;
using LeopotamGroup.Globals;


public class ScoreUI : MonoEntity
{
    void Start()
    {
        Entity = EcsStartup.World.NewEntity();

        ref ECS.Components.ScoreComponent scoreComponent = ref Entity.Get<ECS.Components.ScoreComponent>();
        scoreComponent.text = GetComponent<Text>();
            

    }
}
