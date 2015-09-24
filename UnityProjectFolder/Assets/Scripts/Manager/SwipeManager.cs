using UnityEngine;
using System.Collections;

public class SwipeManager : MonoBehaviour {

	[SerializeField] private MovementManager MM_Script;

	private enum SwipeMode
	{
		Mobile,
		GameEngine,
	}

	[SerializeField]private SwipeMode CurrentSwipeMode;

	[SerializeField] private float minSwipeLength = 200F;

	private Vector2 firstPressPos;
	private Vector2 secondPressPos;
	private Vector2 currentSwipe;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(CurrentSwipeMode == SwipeMode.GameEngine)
		{
			DetectEditorSwipe();
		}
		else
		{
			DetectMobileSwipe();
		}


	
	}

	void DetectMobileSwipe()
	{
		Touch t = Input.GetTouch(0);
		if(t.phase == TouchPhase.Began)
		{
			//save began touch 2d point
			firstPressPos = new Vector2(t.position.x,t.position.y);
		}
		if(t.phase == TouchPhase.Ended)
		{
			//save ended touch 2d point
			secondPressPos = new Vector2(t.position.x,t.position.y);
			
			//create vector from the two points
			currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

			if(currentSwipe.magnitude < minSwipeLength)
			{
				return;
			}
			
			//normalize the 2d vector
			currentSwipe.Normalize();

			DetermineDirection();
		}
	}

	void DetectEditorSwipe()
	{
		if(Input.GetMouseButtonDown(0))
		{
			//Save First Touch Position
			firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		}

		if(Input.GetMouseButtonUp(0))
		{
			//Save Second Touch Position
			secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

			//Create Vector from Two Points
			currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

			if(currentSwipe.magnitude < minSwipeLength)
			{
				return;
			}

			currentSwipe.Normalize();

			DetermineDirection();
		}
	}

	void DetermineDirection()
	{
		string movementDirection = "null";

		//swipe upwards
		if(currentSwipe.y > 0 &&  currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
		{
			Debug.Log("up swipe");
			movementDirection = "Up";
		}
		//swipe down
		if(currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
		{
			Debug.Log("down swipe");
			movementDirection = "Down";
		}
		//swipe left
		if(currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
		{
			Debug.Log("left swipe");
			movementDirection = "Left";
		}
		//swipe right
		if(currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
		{
			Debug.Log("right swipe");
			movementDirection = "Right";
		}

		MM_Script.DetermineMovementDirection(movementDirection);
	}
}
