using UnityEngine;
using System.Collections;

public class BarrierBehaviour : MonoBehaviour {

	public bool isClosing;

	//LerpingVariables
	private float timeStartedLerping;
	private float timeTakenDuringLerp = 75F;

	// Use this for initialization
	void Start () {

		timeStartedLerping = Time.time;
	
	}
	
	// Update is called once per frame
	void Update () {

		if(isClosing)
		{
			float timeSinceStarted = Time.time - timeStartedLerping;
			float percentageComplete = timeSinceStarted / timeTakenDuringLerp;

			transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(transform.localScale.x,0,transform.localScale.z), percentageComplete);

			if(transform.localScale.y < 0.05)
			{
				isClosing = false;
			}
		}
	
	}
}
