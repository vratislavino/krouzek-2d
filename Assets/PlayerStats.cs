using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public event Action HpChanged;
    public event Action XpChanged;
    public event Action StaminaChanged;
    public event Action PlayerDied;

    private int hp;
    public int Hp => hp;

    private int maxHp = 100;
    public int MaxHp => maxHp;

    private float stamina;
    public float Stamina => stamina;

    private int neededForNextLevel = 15;
    public int NeededForNextLevel => neededForNextLevel;

    private int xp;
    public int Xp => xp;

    private int level = 1;
    public int Level => level;

    public bool IsDead => hp <= 0;

    public int jumpHeightBonus;

    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
        stamina = 100;
    }

    public void AddXp(int amount) {
        xp += amount;
        if(xp >= neededForNextLevel) {
            xp -= neededForNextLevel;
            neededForNextLevel = (int)(neededForNextLevel * 1.2f);
            level++;
        }

        XpChanged?.Invoke();
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
