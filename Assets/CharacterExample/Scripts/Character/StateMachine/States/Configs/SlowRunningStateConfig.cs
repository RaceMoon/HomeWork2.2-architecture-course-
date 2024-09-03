using System;
using UnityEngine;

[Serializable]
public class SlowRunningStateConfig
{
    [field: SerializeField, Range(0f, 5f)] public float Speed {  get; private set; }
}
