using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

public class PlayerAI : AgentAI {

    public GameObject sprite;
    public float moveThreshold = 0.05f;
    public float animationCooldown = 0.1f;
    private float originalScaleX;
    private float currentAnimationCooldown = 0.0f;
    private Vector3 previousPosition;
    private Animator animator;
    public AudioClip playerHurt;
    public float staggerLimit;
    private float currentStagger;

    public override void Awake() {
        base.Awake();
        animator = GetComponentInChildren<Animator>();
        Assert.IsNotNull(animator, "Missing animator");
        Assert.IsNotNull(playerHurt, "Missing playerHurt");
        animator.SetInteger("state", 0);
        Assert.IsNotNull(sprite, "Missing sprite");
        originalScaleX = sprite.transform.localScale.x;
    }

    public override void Update() {
        base.Update();
        if(currentStagger > 0f) {
            currentStagger -= Time.deltaTime;
            if(currentStagger <= 0f) {
                navMeshAgent.enabled = true;
                navMeshAgent.destination = currentDestination;
            }
        }
        if(currentAnimationCooldown <= 0.0f) {
            if(Vector3.Distance(transform.position, previousPosition) > moveThreshold) {
                animator.SetInteger("state", 1);
            }
            else {
                animator.SetInteger("state", 0);
            }
            currentAnimationCooldown = animationCooldown;
        }
        else {
            currentAnimationCooldown -= Time.deltaTime;
        }
        if(transform.position.z > previousPosition.z) {
            sprite.transform.localScale = new Vector3(-originalScaleX, sprite.transform.localScale.y, sprite.transform.localScale.z);
        }
        else {
            sprite.transform.localScale = new Vector3(originalScaleX, sprite.transform.localScale.y, sprite.transform.localScale.z);
        }
        previousPosition = transform.position;
    }

    public void SetDestination(Vector3 newDestination) {
        currentDestination = newDestination;
        if(navMeshAgent.enabled) {
            navMeshAgent.destination = currentDestination;
        }
    }

    public void Stop() {
        currentDestination = transform.position;
        if(navMeshAgent.enabled) {
            navMeshAgent.destination = currentDestination;
        }
    }

    public void ApplyStagger(float staggerForce) {
        currentStagger += staggerForce;
        if(currentStagger > staggerLimit) {
            currentStagger = staggerLimit;
        }
        navMeshAgent.enabled = false;
        audioSource.PlayOneShot(playerHurt);
        if(animator.GetInteger("state") != 2) {
            animator.SetInteger("state", 2);
            currentAnimationCooldown = animationCooldown;
        }
    }

    public bool CanPlayerAct() {
        if(currentStagger <= 0f) {
            return true;
        }
        else {
            return false;
        }
    }
}