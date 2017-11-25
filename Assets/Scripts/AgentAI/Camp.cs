using UnityEngine;
using UnityEngine.Assertions;

public class Camp : MonoBehaviour {

    public GameObject decardCain;

    public void Awake() {
        Assert.IsNotNull(decardCain, "Missing decardCain");
    }

    public void OnTriggerEnter(Collider other) {
        if(other.gameObject.GetComponent<MinionAI>() != null) {
            other.gameObject.GetComponent<MinionAI>().SetDestination(decardCain.transform.position);
        }
        else {

        }
    }
}
