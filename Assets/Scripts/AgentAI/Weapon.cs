using UnityEngine;
using UnityEngine.Assertions;

public abstract class Weapon : MonoBehaviour {

    public WeaponAI owner;
    public float range = 0f;
    public float attackCooldown = 0f;
    protected float attackCooldownLeft = 0f;

    virtual public void Awake() {
        owner = GetComponent<WeaponAI>();
        Assert.IsNotNull(owner, "Missing owner");
    }

    public void Update() {
        if(attackCooldownLeft > 0f) {
            attackCooldownLeft -= Time.deltaTime;
        }
    }

    public virtual void StartAttack() {
    }

    public virtual void StopAttack() {
    }

    public virtual bool IsTargetInRange(GameObject target) {
        return false;
    }
}
