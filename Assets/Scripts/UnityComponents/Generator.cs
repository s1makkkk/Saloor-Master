using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECS;
using Leopotam.Ecs;
public class Generator : MonoBehaviour
{

    [SerializeField] private GameObject[] Props;
    [SerializeField] private Transform[] Points;
    [SerializeField] private float TimeDelay;
    [SerializeField] private float minTimeDelay;
    [SerializeField] private float Complexity;

    private EcsEntity Entity;
    void Start()
    {
        Entity = EcsStartup.World.NewEntity();
        ref ECS.Components.GeneratorComponent Generator = ref Entity.Get<ECS.Components.GeneratorComponent>();
        Generator.LevelProps = Props;
        Generator.TimeDelay = TimeDelay;
        Generator.Parrent = transform;
        Generator.Points = TransformToVector(Points);
    }

    private Vector2[] TransformToVector(Transform[] t)
    {
        Vector2[] v = new Vector2[t.Length];
        for(int i=0;i<t.Length;i++)
        {
            v[i] = t[i].position;
        }
        return v;
    }
}