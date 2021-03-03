using Leopotam.Ecs;
using UnityEngine;
//using System;
using System.Collections.Generic;

namespace ECS.Systems
{
    sealed class GeneratorSystem : IEcsRunSystem
    {
        // auto-injected fields.99999
        readonly EcsWorld _world = null;

        EcsFilter<Components.GeneratorComponent> filterGenerator;

        private float time;
        void IEcsRunSystem.Run()
        {
            time += Time.deltaTime;

            foreach(var i in filterGenerator)
            {
                ref Components.GeneratorComponent Generator = ref filterGenerator.Get1(i);

                if(time>=Generator.TimeDelay)
                {

                    /*
                     * TODO: Переписать эту поеботу :)
                     */
                    int r1 = Random.Range(0, Generator.LevelProps.Length - 1);
                    int r2 = Random.Range(0, Generator.Points.Length - 1);
                    GameObject obj = Generator.LevelProps[r1];
                    Vector2 Position = Generator.Points[r2];
                    GameObject.Instantiate(obj,Position,Quaternion.identity,Generator.Parrent);
                    Generator.TimeDelay -= Generator.Complexity;
                    if (Generator.TimeDelay < Generator.MinTime) { Generator.TimeDelay = Generator.MinTime; }
                    time = 0;
                }
            }
        }
        
    }
}