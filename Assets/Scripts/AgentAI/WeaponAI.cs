using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;

public class WeaponAI : MonoBehaviour {

    private GameObject currentTarget = null;
    public AgentAI owner;
    public Weapon weapon;

    public void Awake() {
        owner = GetComponent<AgentAI>();
        Assert.IsNotNull(owner, "Missing owner");
        Assert.IsNotNull(weapon, "Missing weapon");
    }

    public void ManualWeaponUpdate() {
        ChooseAndEngageTarget(owner.sensesAI.GetVisibleTargets());
    }
    
    public void ChooseAndEngageTarget(List<GameObject> visibleTargets) {
        if(visibleTargets == null || visibleTargets.Count <= 0) {
            currentTarget = null;
            weapon.StopAttack();
        }
        else {
            if(visibleTargets.Contains(currentTarget)) {
            }
            else {
                currentTarget = visibleTargets[0];
                foreach(GameObject target in visibleTargets) {
                    if(Vector3.Distance(transform.position, target.transform.position) < Vector3.Distance(transform.position, currentTarget.transform.position)) {
                        currentTarget = target;    
                    }
                }
            }
            weapon.StartAttack();
        }
    }

    public GameObject GetCurrentTarget() {
        return currentTarget;
    }
}
