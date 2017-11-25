using UnityEngine;
using UnityEngine.Assertions;

public class DecardAI : AgentAI {

    public float staggerLimit;
    public float currentStagger;
    public AudioClip hello;
    public AudioClip incoming;
    public AudioClip newItem;

    public new void Awake() {
        audioSource = GetComponent<AudioSource>();
        Assert.IsNotNull(audioSource, "Missing audioSource");
        Assert.IsNotNull(hello, "Missing hello");
        Assert.IsNotNull(incoming, "Missing incoming");
        Assert.IsNotNull(newItem, "Missing newItem");
    }

    public new void Update() {
    }

    public void ApplyStagger(float staggerForce) {
        currentStagger += staggerForce;
        if(currentStagger > staggerLimit) {
            ScenarioManager.instance.Defeat();
        }
    }

    public void PlayHello() {
        audioSource.PlayOneShot(hello);
    }

    public void PlayIncoming() {
        audioSource.PlayOneShot(incoming);
    }

    public void PlayNewItem() {
        audioSource.PlayOneShot(newItem);
    }
}
