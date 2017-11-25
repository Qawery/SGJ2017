using UnityEngine;

public class TeleStagger : MinionWeapon {

    public AudioClip attack1;
    public AudioClip attack2;

    public override void StartAttack() {
        if(attackCooldownLeft <= 0.0f && owner.owner.sensesAI.GetVisibleTargets() != null && owner.owner.sensesAI.GetVisibleTargets().Count > 0) {
            GameObject bestTarget = owner.owner.sensesAI.GetVisibleTargets()[0];
            foreach(GameObject target in owner.owner.sensesAI.GetVisibleTargets()){
                if(Vector3.Distance(bestTarget.transform.position, transform.position) > Vector3.Distance(target.transform.position, transform.position)) {
                    bestTarget = target;
                }
            }
            if(IsTargetInRange(bestTarget)) {
                if(bestTarget.GetComponent<PlayerAI>() != null) {
                    bestTarget.GetComponent<PlayerAI>().ApplyStagger(staggerForce);
                    float soundRoll = Random.Range(0.0f, 1.0f);
                    if(soundRoll <= 0.5f) {
                        owner.owner.audioSource.PlayOneShot(attack1);
                    }
                    else {
                        owner.owner.audioSource.PlayOneShot(attack2);
                    }
                    attackCooldownLeft = attackCooldown;
                }
                else if(bestTarget.GetComponent<DecardAI>() != null) {
                    bestTarget.GetComponent<DecardAI>().ApplyStagger(staggerForce);
                    float soundRoll = Random.Range(0.0f, 1.0f);
                    if(soundRoll <= 0.5f) {
                        owner.owner.audioSource.PlayOneShot(attack1);
                    }
                    else {
                        owner.owner.audioSource.PlayOneShot(attack2);
                    }
                    attackCooldownLeft = attackCooldown;
                }
            }
        }
    }
}
