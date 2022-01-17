using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public event Action HpChanged;
    public event Action StaminaChanged;
    public event Action PlayerDied;

    private int hp;
    public int Hp => hp;

    private int maxHp = 100;
    public int MaxHp => maxHp;

    private float stamina;
    public float Stamina => stamina;

    public bool IsDead => hp <= 0;

    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
        stamina = 100;
    }

    public void Heal(int amount) {
        hp += amount;
        if(hp > maxHp)
            hp = maxHp;

        HpChanged?.Invoke();
    }

    public void DealDamage(int amount) {
        hp -= amount;
        if (hp < 0)
            hp = 0;

        HpChanged?.Invoke();

        if (hp <= 0) {
            PlayerDied?.Invoke();
        }
    }

    public void ChangeStamina(float amount) {
        stamina += amount;
        if(stamina > 100) {
            stamina = 100;
        } else if(stamina < 0) {
            stamina = 0;
        }
        StaminaChanged?.Invoke();
    }
}
