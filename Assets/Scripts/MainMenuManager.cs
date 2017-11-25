using UnityEngine;
using UnityEngine.Assertions;

public class MainMenuManager : MonoBehaviour {

    public GameObject mainMenu;
    public GameObject howToPlayMenu;
    public AudioSource buttonsAudioSource;

    public void Awake() {
        Assert.IsNotNull(mainMenu, "Missing mainMenu in MainMenuManager");
        Assert.IsNotNull(howToPlayMenu, "Missing hotToPlayMenu in MainMenuManager");
        Assert.IsNotNull(buttonsAudioSource, "Missing buttonsAudioSource");
        mainMenu.SetActive(true);
        howToPlayMenu.SetActive(false);
    }

    public void StartButton() {
        Application.LoadLevel("Game");
    }
    
    public void HowToPlayButton() {
        mainMenu.SetActive(false);
        howToPlayMenu.SetActive(true);
    }
    
    public void ExitButton() {
        Application.Quit();
    }

    public void BackButton() {
        mainMenu.SetActive(true);
        howToPlayMenu.SetActive(false);
    }
}
