using UnityEngine;

public class Billboard : MonoBehaviour {
    public void Update() {
        transform.LookAt(transform.position + LocationsManager.instance.camera.transform.rotation * Vector3.forward, LocationsManager.instance.camera.transform.rotation * Vector3.up);
    }    
}
