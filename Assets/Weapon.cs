using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public ContactFilter2D contactFilter;

    [SerializeField]
    protected float damage;
    public float Damage => damage;
    [SerializeField]
    protected float cooldown;
    public float Cooldown => cooldown;

    protected float currentCooldown;

    public abstract void Attack();
}
