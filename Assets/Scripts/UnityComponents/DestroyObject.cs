using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] private  float TimeDelay;

    void Start()
    {
        Destroy(gameObject, TimeDelay);
    }
}
