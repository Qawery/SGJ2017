using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using Assets.Scripts.AgentAI;
using Assets.Scripts.IdentificationLottery;
using UnityEngine;
using UnityEngine.UI;

public class IdentificationLottery : MonoBehaviour {
    public List<Prefix> prefixes;
    public List<Sufix> sufixes;

    public List<Prefix> rolledPrefixes = new List<Prefix>();
    public List<Sufix> rolledSufixes = new List<Sufix>();

    internal void SetWeaponCore(WeaponCore carriedWeapon, GameObject carrier)
    {
        Roll3();
        gameObject.SetActive(true);
        Time.timeScale = 0.01f;
        CollectiveInputManager.instance.isMouseInputEnabled = false;
        adventurer = carrier;
        selectedCore = carriedWeapon;
        WeaponCoreImage.sprite = carriedWeapon.Sprite;
        WeaponCoreText.text = carriedWeapon.Name;
    }

    public List<Button> prefixButtons, sufixButtons;
    public Image WeaponCoreImage;
    public Text WeaponCoreText;

    public Prefix selectedPrefix;
    public Sufix selectedSufix;
    public WeaponCore selectedCore;

    public GameObject adventurer;

	// Use this for initialization
	void Start () {
        Roll3();
	}
	
    public void SetPrefix(int i)
    {
        for (int b =0; b < prefixButtons.Count; b++)
        {
            if (b != i) prefixButtons[b].gameObject.SetActive(false);
        }
        selectedPrefix = rolledPrefixes[i];
        CheckForCompletion();
    }

    public void SetSuffix(int i)
    {
        for (int b = 0; b < sufixButtons.Count; b++)
        {
            if (b != i) sufixButtons[b].gameObject.SetActive(false);
        }
        selectedSufix = rolledSufixes[i];
        CheckForCompletion();
    }

	// Update is called once per frame
	void Update () {
		
	}

    public void Roll3()
    {
        const int numberOfRolls = 3;

        rolledPrefixes = prefixes.Shuffle().Take(numberOfRolls).ToList();
        rolledSufixes = sufixes.Shuffle().Take(numberOfRolls).ToList();

        for (int i=0; i< numberOfRolls; i++)
        {
            prefixButtons[i].GetComponentInChildren<Text>().text = rolledPrefixes[i].prefixName;
            sufixButtons[i].GetComponentInChildren<Text>().text = rolledSufixes[i].sufixName;
        }
    }

    public void BuildWeapon()
    {
        var weapon = Instantiate(selectedPrefix.AttackType, adventurer.transform).gameObject;
        var weaponAi = adventurer.GetComponent<WeaponAI>();
        Destroy(weaponAi.weapon.gameObject);
        var customWeapon = weapon.GetComponent<CustomWeapon>();
        customWeapon.SetOwner(adventurer);
        customWeapon.SetWeaponCore(selectedCore);
    }

    private void CheckForCompletion()
    {
        if (selectedCore == null || selectedPrefix == null || selectedSufix == null) return;
        BuildWeapon();
        selectedCore = null;
        selectedPrefix = null;
        selectedSufix = null;
        adventurer = null;
        foreach (var button in prefixButtons) button.gameObject.SetActive(true);
        foreach (var button in sufixButtons) button.gameObject.SetActive(true);
        Time.timeScale = 1;
        CollectiveInputManager.instance.isMouseInputEnabled = true;
        gameObject.SetActive(false);
    }

}
