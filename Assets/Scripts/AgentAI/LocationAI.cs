using UnityEngine;

public class LocationAI : MonoBehaviour 
{
    public void OnTriggerEnter(Collider other) {
        if(other.gameObject.GetComponent<MinionAI>() != null) {
            Vector3 offset = new Vector3(Random.Range(-3.0f, 3.0f), 0, Random.Range(-3.0f, 3.0f));
            other.gameObject.GetComponent<MinionAI>().SetDestination(LocationsManager.instance.GetPositionOf(LocationsEnum.Camp) + offset);
        }
    }
}
