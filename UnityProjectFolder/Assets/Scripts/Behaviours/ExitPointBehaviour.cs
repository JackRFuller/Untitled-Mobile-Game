using UnityEngine;
using System.Collections;

public class ExitPointBehaviour : MonoBehaviour {

	private LevelManager LM_Script;

	private enum ExitPointType
	{
		Square,
	}

	[SerializeField] private ExitPointType CurrentEPType;

	// Use this for initialization
	void Start () {

		LM_Script = GameObject.Find("LevelManager").GetComponent<LevelManager>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == CurrentEPType.ToString())
		{
			LM_Script.ShapeInHome();
			LM_Script.ExitShape(other.gameObject);
		}
	}
}
