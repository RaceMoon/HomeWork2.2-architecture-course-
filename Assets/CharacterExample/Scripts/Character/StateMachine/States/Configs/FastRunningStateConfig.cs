using System;
using UnityEngine;

[Serializable]
public class FastRunningStateConfig
{
    [field: SerializeField, Range(5, 20)] public float Speed {  get; private set; }
    
}
