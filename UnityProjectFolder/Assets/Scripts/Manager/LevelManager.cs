using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	private MovementManager MM_Script;

	[Header("Level Variables")]
	[SerializeField] private string LevelTitleName;
	[SerializeField] private string LevelTagLineText;
    [SerializeField] private string NextLevelID;


	[SerializeField] private int totalTurns;
	public int usedTurns;
	public bool isGameOver;
	public bool isLevelComplete;

	[SerializeField] private int numOfShapes;
	private GameObject[] shapes;
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

		MM_Script = GameObject.Find("MovementManager").GetComponent<MovementManager>();

		LevelTitle.text = "- " + LevelTitleName + " -";
		LevelTagLines.text = LevelTagLineText;

		numOfTurns.text = totalTurns.ToString();

		if(numOfShapes > 1)
		{
			CollectShapes();
		}

		StartCoroutine(FadeOutLevelTitle());
	
	}

	void CollectShapes()
	{
		shapes = GameObject.FindGameObjectsWithTag("Shape");
	}

	public void ShapeInHome()
	{
		shapesHome++;
		if(shapesHome == numOfShapes)
		{
			LevelComplete();
		}
		else
		{
			StartCoroutine(SetToNewShape());
		}
	}

	IEnumerator SetToNewShape()
	{
		yield return new WaitForSeconds(0.75F);
		foreach(GameObject shape in shapes)
		{
			ShapeBehaviour SP_Script = shape.GetComponent<ShapeBehaviour>();
			if(!SP_Script.Home)
			{
				MM_Script.activeShape = shape;
				SetNewShapeActive();
			}
		}
	}

	void SetNewShapeActive()
	{
		MM_Script.activeShape.GetComponent<ShapeBehaviour>().TurnOnShape();
		MM_Script.ChangeShape();
	}

	void LevelComplete()
	{
		LevelCompleteItems.Play();
		isLevelComplete = true;
	}

    public void ResetLevel()
    {
        Application.LoadLevel(Application.loadedLevelName);
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

	public void GameOver()
	{
		isGameOver = true;
		GameOverItems.Play();
	}

	IEnumerator FadeOutLevelTitle()
	{
		yield return new WaitForSeconds(5.0F);
		isGameOver = false;
	}
}
