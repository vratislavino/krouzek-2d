using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public event Action<Weapon> WeaponChanged;

    List<Weapon> weapons;

    int currentWeaponIndex;

    private Weapon currentWeapon;
    public Weapon CurrentWeapon {
        get { return currentWeapon; }
        set {
            currentWeapon = value;
            WeaponChanged?.Invoke(currentWeapon);
        }
    }

    private void Awake() {
        weapons = transform.GetComponentsInChildren<Weapon>().ToList();
        Debug.Log(weapons.Count);
        CurrentWeapon = weapons.Last();
    }

    public void AddWeapon(string weapon) {
        var allWeapons = transform.GetComponentsInChildren<Weapon>(true).ToList();
        for(int i = 0; i < allWeapons.Count; i++) {
            if(allWeapons[i].gameObject.name == weapon) {
                allWeapons[i].gameObject.SetActive(true);
                weapons = transform.GetComponentsInChildren<Weapon>().ToList();
                break;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) {
            currentWeapon.Attack();
        }

        if(Input.GetKeyDown(KeyCode.UpArrow)) {
            currentWeaponIndex -= 1;
            if (currentWeaponIndex < 0)
                currentWeaponIndex = weapons.Count - 1;
            CurrentWeapon = weapons[currentWeaponIndex];
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            currentWeaponIndex += 1;
            if (currentWeaponIndex >= weapons.Count)
                currentWeaponIndex = 0;
            CurrentWeapon = weapons[currentWeaponIndex];
        }


    }
}
