using UnityEngine;

public class TeleHit : PlayerWeapon {

    public override void StartAttack() {
        if(attackCooldownLeft <= 0.0f && owner.owner.sensesAI.GetVisibleTargets() != null && owner.owner.sensesAI.GetVisibleTargets().Count > 0) {
            GameObject bestTarget = owner.owner.sensesAI.GetVisibleTargets()[0];
            foreach(GameObject target in owner.owner.sensesAI.GetVisibleTargets()){
                if(Vector3.Distance(bestTarget.transform.position, transform.position) > Vector3.Distance(target.transform.position, transform.position)) {
                    bestTarget = target;
                }
            }
            if(IsTargetInRange(bestTarget)) {
                MinionAI targetAI = bestTarget.GetComponent<MinionAI>();
                if(targetAI != null) {
                    targetAI.ApplyDamage(damage);
                    attackCooldownLeft = attackCooldown;
                }
            }
        }
    }
}
