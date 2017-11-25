using UnityEngine;

public class MinionWeapon : Weapon {

    public float staggerForce = 0.1f;

    public override bool IsTargetInRange(GameObject target) {
        if(target != null && target.activeInHierarchy && Vector3.Distance(transform.position, target.transform.position) <= range + 2f) {
            return true;
        }
        else {
            return false;
        }
    }
}
