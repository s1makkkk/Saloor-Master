using UnityEngine;

namespace ECS.Components
{
    struct GeneratorComponent
    {
        public GameObject[] LevelProps;
        public float TimeDelay;
        public float MinTime;
        public float Complexity;
        public Transform Parrent;
        public Vector2[] Points;

    }
}