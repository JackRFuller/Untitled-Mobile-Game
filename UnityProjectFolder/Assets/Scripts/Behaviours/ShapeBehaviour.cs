using UnityEngine;
using System.Collections;

public class ShapeBehaviour : MonoBehaviour {

	private LevelManager LM_Script;

	[SerializeField] private Transform startingPos;
	public TravelPointBehaviour TBP_Script;
	[SerializeField] private SpriteRenderer activeIndicator;
	private ParticleSystem shape_PS;

	public bool Home;

	// Use this for initialization
	void Start () {

		LM_Script = GameObject.Find("LevelManager").GetComponent<LevelManager>();

		transform.position = startingPos.position;

		TBP_Script = startingPos.GetComponent<TravelPointBehaviour>();
		shape_PS = GetComponent<ParticleSystem>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public TravelPointBehaviour GetTBD_Script()
	{
		return TBP_Script;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "TravelPoint")
		{
			TBP_Script = other.GetComponent<TravelPointBehaviour>();
		}
	}

	public void TurnOffShape()
	{
		activeIndicator.enabled = false;
	}

	public void TurnOnShape()
	{
		activeIndicator.enabled = true;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.collider.tag == "Shape" || other.collider.tag == "Barrier")
		{
			Death();
		}
	}

	void Death()
	{
		GetComponent<SpriteRenderer>().enabled = false;
		activeIndicator.enabled = false;
		shape_PS.Play();
		shape_PS.enableEmission = true;

		LM_Script.GameOver();
	}
}
