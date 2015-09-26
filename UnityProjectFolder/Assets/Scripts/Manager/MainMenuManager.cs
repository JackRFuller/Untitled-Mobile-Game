using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

    [SerializeField] private GameObject SplashScreenItem;

    [SerializeField] private Animation TitleScreen;
    [SerializeField] private Animation LevelSelect;

    void Awake()
    {
        StartCoroutine(SplashScreen());
    }

    IEnumerator SplashScreen()
    {
        yield return new WaitForSeconds(3.0F);
        SplashScreenItem.SetActive(false);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadInLevelSelect()
    {
        TitleScreen.Play("TitleScreenOut");
        LevelSelect.Play("LevelSelectIn");
    }

    
}
