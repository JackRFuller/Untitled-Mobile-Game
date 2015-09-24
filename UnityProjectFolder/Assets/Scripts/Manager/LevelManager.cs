using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	[Header("Level Variables")]
	[SerializeField] private string LevelTitleName;
	[SerializeField] private string LevelTagLineText;
    [SerializeField] private string NextLevelID;


	[SerializeField] private int totalTurns;
	public int usedTurns;
	public bool isGameOver;
	public bool isLevelComplete;

	[SerializeField] private int numOfShapes;
	private int shapesHome;

	[Header("UI Objects")]
	[SerializeField] private Animation[] FadeIn;
	[SerializeField] private Text LevelTitle;
	[SerializeField] private Text LevelTagLines;
	[SerializeField] private Text numOfTurns;
	[SerializeField] private Animation GameOverItems;
	[SerializeField] private Animation LevelCompleteItems;


	// Use this for initialization
	void Start () {

		LevelTitle.text = "- " + LevelTitleName + " -";
		LevelTagLines.text = LevelTagLineText;

		numOfTurns.text = totalTurns.ToString();

		StartCoroutine(FadeOutLevelTitle());
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ExitShape(GameObject Shape)
	{

	}

	public void ShapeInHome()
	{
		shapesHome++;
		if(shapesHome == numOfShapes)
		{
			LevelComplete();
		}
	}

	void LevelComplete()
	{
		LevelCompleteItems.Play();
		isLevelComplete = true;
	}

    public void NextLevel()
    {
        Application.LoadLevel(NextLevelID);
    }

	public void Turns()
	{
		usedTurns++;
		int _turnsLeft = totalTurns - usedTurns;
		numOfTurns.text = _turnsLeft.ToString();

		if(usedTurns == totalTurns)
		{
			if(shapesHome != numOfShapes)
			{
				GameOver();
			}
		}
	}

	void GameOver()
	{
		isGameOver = true;
		GameOverItems.Play();
	}

	public void ResetLevel()
	{
		Application.LoadLevel(Application.loadedLevelName);
	}

	IEnumerator FadeOutLevelTitle()
	{
		yield return new WaitForSeconds(5.0F);
		isGameOver = false;
	}
}
