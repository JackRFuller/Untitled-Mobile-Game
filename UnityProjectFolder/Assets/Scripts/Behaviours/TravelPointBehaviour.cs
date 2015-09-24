using UnityEngine;
using System.Collections;

public class TravelPointBehaviour : MonoBehaviour {

	private MovementManager MM_Script;

	[System.Serializable]
	public class MovementDirections
	{
		public bool Up;
		public bool Left;
		public bool Right;
		public bool Down;
	}

	public MovementDirections AvailableMovements;

	// Use this for initialization
	void Start () {

		MM_Script = GameObject.Find("MovementManager").GetComponent<MovementManager>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Shape")
		{
			MM_Script.NewTravelPoint(gameObject);
		}
	}
}
