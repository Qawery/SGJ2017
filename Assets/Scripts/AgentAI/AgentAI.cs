using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.AI;

public abstract class AgentAI : MonoBehaviour {

    public TeamEnum team;
    public SensesAI sensesAI;
    public WeaponAI weaponAI;
    protected NavMeshAgent navMeshAgent;
    protected Vector3 currentDestination;
    public AudioSource audioSource;

    public virtual void Awake() {
        sensesAI = GetComponent<SensesAI>();
        Assert.IsNotNull(sensesAI, "Missing sensesAI");
        weaponAI = GetComponent<WeaponAI>();
        Assert.IsNotNull(weaponAI, "Missing weaponAI");
        navMeshAgent = GetComponent<NavMeshAgent>();
        Assert.IsNotNull(navMeshAgent, "Missing navMeshAgent");
        audioSource = GetComponent<AudioSource>();
        Assert.IsNotNull(audioSource, "Missing audioSource");
    }

    public virtual void Update() {
        sensesAI.DetectTargets();
        weaponAI.ManualWeaponUpdate();
    }
}