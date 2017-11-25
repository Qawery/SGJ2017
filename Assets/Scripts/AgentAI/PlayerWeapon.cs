using UnityEngine;

public class PlayerWeapon : Weapon {

    public int damage = 1;

    public override bool IsTargetInRange(GameObject target) {
        if(Vector3.Distance(transform.position, target.transform.position) <= range) {
            return true;
        }
        else {
            return false;
        }
    }
}
