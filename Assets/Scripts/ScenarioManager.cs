using UnityEngine;
using UnityEngine.Assertions;

public class ScenarioManager : MonoBehaviour {

    public static ScenarioManager instance;
    public GameObject victoryText;
    public GameObject defeatText;
    public GameObject boss;
    private bool gameEnd = false;
    private float countdown = 12.2f;

    public void Awake() {
        Assert.IsNotNull(victoryText, "Missing victoryText");
        Assert.IsNotNull(defeatText, "Missing defeatText");
        Assert.IsNotNull(boss, "Missing boss");
        victoryText.SetActive(false);
        defeatText.SetActive(false);
        instance = this;
    }

	public void Update () {
        if(gameEnd) {
            countdown -= Time.deltaTime;
            if(countdown <= 0.0f) {
                Application.LoadLevel("MainMenu");
            }
        }
        else {
            if(boss == null) {
                gameEnd = true;
                victoryText.SetActive(true);
            }
        }
	}

    public void Defeat() {
        if(!gameEnd) {
            gameEnd = true;
            defeatText.SetActive(true);
        }
    }
}
