using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] private  float TimeDelay;
    bool isEntity = false;
    void Start()
    {
        Destroy(gameObject, TimeDelay);
    }
}
