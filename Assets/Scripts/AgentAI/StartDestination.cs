using UnityEngine;

public class StartDestination : MonoBehaviour {

	void Start () {
        if(GetComponent<MinionAI>() != null) {
            GetComponent<MinionAI>().SetDestination(LocationsManager.instance.GetPositionOf(LocationsEnum.Camp));
        }
	}
}
