using System;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

public class MinionAI : AgentAI {

    public AudioClip hurt1;
    public AudioClip hurt2;
    private bool hasDestination = false;
    public int health = 1;
    public Loot Loot;
    public float LootChance = 0.05f;
    public AudioSource DeathSoundBomb;

    public override void Awake() {
        base.Awake();
        Assert.IsNotNull(hurt1, "Missing hurt1");
        Assert.IsNotNull(hurt2, "Missing hurt2");
        Stop();
    }

    public override void Update() {
        base.Update();
        if(weaponAI.GetCurrentTarget() != null && !weaponAI.weapon.IsTargetInRange(weaponAI.GetCurrentTarget())) {
            navMeshAgent.enabled = true;
            navMeshAgent.destination = weaponAI.GetCurrentTarget().transform.position;
        }
        else if(weaponAI.GetCurrentTarget() != null && weaponAI.weapon.IsTargetInRange(weaponAI.GetCurrentTarget())) {
            navMeshAgent.enabled = true;
            navMeshAgent.destination = transform.position;
        }
        else {
            if(hasDestination) {
                navMeshAgent.enabled = true;
                navMeshAgent.destination = currentDestination;
            }
            else {
                navMeshAgent.enabled = false;
            }
        }
    }


    public void ApplyDamage(int damage) {
        health -= damage;
        float soundRoll = UnityEngine.Random.Range(0.0f, 1.0f);
        if(soundRoll <= 0.5f) {
            audioSource.PlayOneShot(hurt1);
        }
        else {
            audioSource.PlayOneShot(hurt2);
        }
        if(health <= 0) {
            if (UnityEngine.Random.Range(0f,1f) < LootChance) Instantiate(Loot, transform.position, Quaternion.identity);
            if (DeathSoundBomb != null) Instantiate(DeathSoundBomb, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void SetDestination(Vector3 newDestination) {
        hasDestination = true;
        currentDestination = newDestination;
    }

    public void Stop() {
        hasDestination = false;
    }
}
