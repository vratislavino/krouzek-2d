using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    List<Weapon> weapons;

    private Weapon currentWeapon;

    private void Awake() {
        weapons = transform.GetComponentsInChildren<Weapon>().ToList();
        currentWeapon = weapons.Last();
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
    }
}
