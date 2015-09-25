using UnityEngine;
using System.Collections;

public class KeyBehaviour : MonoBehaviour {

	[SerializeField] private BarrierBehaviour[] BB_Scripts;
	[SerializeField] private Sprite secondarySprite;
	private bool isActivated;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Shape")
		{
			if(!isActivated)
			{
				ActivateBarriers();
			}
		}
	}

	void ActivateBarriers()
	{
		foreach(BarrierBehaviour BB_Script in BB_Scripts)
		{
			BB_Script.isClosing = true;
		}

		isActivated = true;

		RemoveKey();
	}

	void RemoveKey()
	{
		GetComponent<SpriteRenderer>().sprite = secondarySprite;
		transform.localScale = new Vector3(0.75F,0.75F,1F);
	}


}
