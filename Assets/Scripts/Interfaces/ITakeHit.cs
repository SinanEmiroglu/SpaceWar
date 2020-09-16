using System;
using UnityEngine;

public interface ITakeHit
{
    event Action OnHit;
    bool Alive { get; }
    Transform transform { get; }
    void TakeHit(IDamage hitBy);
}