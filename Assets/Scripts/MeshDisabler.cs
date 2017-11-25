using UnityEngine;

public class MeshDisabler : MonoBehaviour {
    public void Awake() {
        MeshRenderer[] meshRenderers = GetComponents<MeshRenderer>();
        foreach(MeshRenderer renderer in meshRenderers) {
            renderer.enabled = false;
        }
        
        SpriteRenderer[] spriteRenderers = GetComponents<SpriteRenderer>();
        foreach(SpriteRenderer renderer in spriteRenderers) {
            renderer.enabled = false;
        }
    }
}