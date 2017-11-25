using UnityEngine;
using UnityEngine.Assertions;

public class LocationsManager : MonoBehaviour {

    public static LocationsManager instance;
    public Transform camp;
    public Transform frozenThrone;
    public Transform catacombs;
    public Transform hell;
    public new Camera camera;

    public void Awake() {
        Assert.IsNotNull(camp, "Missing camp");
        Assert.IsNotNull(frozenThrone, "Missing frozenThrone");
        Assert.IsNotNull(catacombs, "Missing catacombs");
        Assert.IsNotNull(hell, "Missing hell");
        Assert.IsNotNull(camera, "Missing camera");
        instance = this;
    }

    public Vector3 GetPositionOf(LocationsEnum location) {
        switch(location) {
            case LocationsEnum.Camp:
                return camp.position;
            case LocationsEnum.Catacombs:
                return catacombs.position;
            case LocationsEnum.FrozenThrone:
                return frozenThrone.position;
            case LocationsEnum.Hell:
                return hell.position;
            default:
                return new Vector3(0, 0, 0);
        }
    }
}