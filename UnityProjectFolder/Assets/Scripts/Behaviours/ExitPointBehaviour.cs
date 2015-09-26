using UnityEngine;
using System.Collections;

public class ExitPointBehaviour : MonoBehaviour {

	private LevelManager LM_Script;

	private enum ExitPointType
	{
		Square,
        Circle,
	}

	[SerializeField] private ExitPointType CurrentEPType;
    [SerializeField] private Animation Idle;
    [SerializeField] private Animation Home;

	private string ExitType;

	// Use this for initialization
	void Start () {

		LM_Script = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		ExitType = CurrentEPType.ToString();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name.Contains(ExitType))
		{
			LM_Script.ShapeInHome();
			other.GetComponent<ShapeBehaviour>().Home = true;
			other.GetComponent<ShapeBehaviour>().TurnOffShape();


            Idle.Stop();
            StartCoroutine(PlayAnimation());
		}
	}

    IEnumerator PlayAnimation()
    {
        yield return new WaitForSeconds(0.15F);
        Home.Play();
    }
}
