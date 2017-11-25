using UnityEngine;
using UnityEngine.Assertions;

public enum SelectedMarker {
    One, Two, Three
}

public class CollectiveInputManager : MonoBehaviour {

    public static CollectiveInputManager instance;
    public bool isMouseInputEnabled = true;
    public Camera mainCamera;
    public PlayerAI player1;
    public PlayerAI player2;
    public PlayerAI player3;
    private SelectedMarker currentMarkerNumber = SelectedMarker.One;
    public GameObject questMarker1;
    public GameObject questMarker2;
    public GameObject questMarker3;
    public GameObject exclamationMark1;
    public GameObject exclamationMark2;
    public GameObject exclamationMark3;

    public void Awake() {
        instance = this;
        Assert.IsNotNull(mainCamera, "Missing mainCamera in InputManager");
        Assert.IsNotNull(questMarker1, "Missing questMarker1 in InputManager");
        Assert.IsNotNull(questMarker2, "Missing questMarker2 in InputManager");
        Assert.IsNotNull(questMarker3, "Missing questMarker3 in InputManager");
        Assert.IsNotNull(player1, "Missing player1 in InputManager");
        Assert.IsNotNull(player2, "Missing player2 in InputManager");
        Assert.IsNotNull(player3, "Missing player3 in InputManager");
        Assert.IsNotNull(exclamationMark1, "Missing exclamationMark1 in InputManager");
        Assert.IsNotNull(exclamationMark2, "Missing exclamationMark2 in InputManager");
        Assert.IsNotNull(exclamationMark3, "Missing exclamationMark3 in InputManager");
    }

    public void Start() {
        exclamationMark1.SetActive(true);
        exclamationMark2.SetActive(false);
        exclamationMark3.SetActive(false);
    }

    public void Update() {
        if(isMouseInputEnabled) {
            DecardInput();
        }
        HeroesInput();
    }

    private void DecardInput() {
        if(Input.GetButton("Exit")) {
            Application.LoadLevel("MainMenu");
        }
        if(Input.GetKeyDown("1")) {
            currentMarkerNumber = SelectedMarker.One;
            exclamationMark1.SetActive(true);
            exclamationMark2.SetActive(false);
            exclamationMark3.SetActive(false);
        }
        else if(Input.GetKeyDown("2")) {
            currentMarkerNumber = SelectedMarker.Two;
            exclamationMark1.SetActive(false);
            exclamationMark2.SetActive(true);
            exclamationMark3.SetActive(false);
        }
        else if(Input.GetKeyDown("3")) {
            currentMarkerNumber = SelectedMarker.Three;
            exclamationMark1.SetActive(false);
            exclamationMark2.SetActive(false);
            exclamationMark3.SetActive(true);
        }

        if(Input.GetButton("Fire1")) {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);
            switch(currentMarkerNumber) {
                case SelectedMarker.One:
                    questMarker1.transform.position = hit.point;
                    break;

                case SelectedMarker.Two:
                    questMarker2.transform.position = hit.point;
                    break;

                case SelectedMarker.Three:
                    questMarker3.transform.position = hit.point;
                    break;
            }
        }
    }

    private void HeroesInput() {
        if(Input.GetButton("Quest1")) {
            player1.SetDestination(questMarker1.transform.position);
        }
        else {
            player1.SetDestination(LocationsManager.instance.GetPositionOf(LocationsEnum.Camp));
        }

        if(Input.GetButton("Quest2")) {
            player2.SetDestination(questMarker2.transform.position);
        }
        else {
            player2.SetDestination(LocationsManager.instance.GetPositionOf(LocationsEnum.Camp));
        }

        if(Input.GetButton("Quest3")) {
            player3.SetDestination(questMarker3.transform.position);
        }
        else {
            player3.SetDestination(LocationsManager.instance.GetPositionOf(LocationsEnum.Camp));
        }
    }
}
