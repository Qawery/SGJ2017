using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;

public class SensesAI : MonoBehaviour {

    public float sightRange = 10f;
    private AgentAI owner;
    private List<GameObject> visibleTargets;

    public void Awake() {
        owner = GetComponent<AgentAI>();
        Assert.IsNotNull(owner, "Missing owner AgentAI");
        Assert.IsTrue(sightRange > 0f, "Too small sightRange");
        visibleTargets = new List<GameObject>();
    }
    
    public void DetectTargets() {
        visibleTargets.Clear();
        Collider[] collidersInRange = Physics.OverlapSphere(transform.position, sightRange);
        foreach(Collider collider in collidersInRange) {
            AgentAI agent = collider.GetComponent<AgentAI>();
            if(agent != null && agent != owner && agent.team != owner.team) {
                visibleTargets.Add(agent.gameObject);
            }
        }
    }

    public List<GameObject> GetVisibleTargets() {
        return visibleTargets;
    }
}
