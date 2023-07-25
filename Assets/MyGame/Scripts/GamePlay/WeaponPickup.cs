using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public RaycastWeapon weaponPrefab;

    private void OnTriggerEnter(Collider other)
    {
        ActiveWeapon activeWeapon = other.gameObject.GetComponent<ActiveWeapon>();
        if (activeWeapon)
        {
            RaycastWeapon newWeapon = Instantiate(weaponPrefab);
            newWeapon.equipWeaponBy = EquipWeaponBy.Player;
            activeWeapon.Equip(newWeapon);
            Destroy(gameObject);
        }

        AiWeapon aiWeapon = other.gameObject.GetComponent<AiWeapon>();
        if (aiWeapon)
        {
            RaycastWeapon newWeapon = Instantiate(weaponPrefab);
            newWeapon.equipWeaponBy = EquipWeaponBy.AI;
            aiWeapon.EquipWeapon(newWeapon);
            SphereCollider sphereCollider = aiWeapon.gameObject.GetComponent<SphereCollider>();
            Destroy(sphereCollider);
            Destroy(gameObject);
        }
    }
}
