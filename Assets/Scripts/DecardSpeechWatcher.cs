using UnityEngine;
using UnityEngine.Assertions;
using Assets.Scripts;

public class DecardSpeechWatcher : MonoBehaviour {

    public DecardAI decardAI;
    private bool wasHello = false;
    private bool wasIncoming = false;
    private float cooldown = 5f;

    public void Awake() {
        Assert.IsNotNull(decardAI, "Missing decardAI");
    }

    public void Start() {
        decardAI.PlayHello();
        wasHello = true;
    }

    public void Update() {
        if(cooldown > 0.0f){
            cooldown -= Time.deltaTime;
        }
        if(wasHello && wasIncoming) {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider other) {
        if(!wasIncoming && other.gameObject.GetComponent<MinionAI>() != null) {
            decardAI.PlayIncoming();
            wasIncoming = true;
        }
    }
}
