using UnityEngine;
using System.Collections;

public class MovementManager : MonoBehaviour {

	private LevelManager LM_Script;

	[Header("Shape Variables")]
	public GameObject activeShape;
	[SerializeField] private float shapeSpeed;
	public bool isMoving = false;
	private bool isLerping = false;
	public bool hasMoved = false;

	//LerpingVariables
	private float timeStartedLerping;
	private float timeTakenDuringLerp = 0.5F;
	private GameObject TravelPoint;

	[Header("TravelPoint Variables")]
	public TravelPointBehaviour TPB_Script;

	// Use this for initialization
	void Start () {

		LM_Script = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		activeShape.GetComponent<ShapeBehaviour>().TurnOnShape();

		StartCoroutine(WaitToChangeShape());
	}

	IEnumerator WaitToChangeShape()
	{
		yield return new WaitForSeconds(0.2F);
		ChangeShape();
	}

	public void ChangeShape()
	{
		TPB_Script = activeShape.GetComponent<ShapeBehaviour>().GetTBD_Script();
		activeShape.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
	}

	void FixedUpdate()
	{
		if(isLerping)
		{
			float timeSinceStarted = Time.time - timeStartedLerping;
			float percentageComplete = timeSinceStarted / timeTakenDuringLerp;
			
			activeShape.transform.position = Vector2.Lerp(activeShape.transform.position, TravelPoint.transform.position,percentageComplete);

		

			if(percentageComplete >= 1.0F)
			{
				isLerping = false;
				isMoving = false;

				LM_Script.Turns();
			}
		}
	}

	public void DetermineMovementDirection(string direction)
	{
		if (!LM_Script.isGameOver || !LM_Script.isLevelComplete)
		{
			if(!isMoving)
			{
				Vector2 movementDirection = Vector2.zero;
				
				switch(direction)
				{
				case("Up"):
					if(TPB_Script.AvailableMovements.Up == true)
					{
						movementDirection = Vector2.up;
						hasMoved = true;
					}
					break;
				case("Left"):
					if(TPB_Script.AvailableMovements.Left == true)
					{
						movementDirection = Vector2.left;
						hasMoved = true;
					}
					break;
				case("Right"):
					if(TPB_Script.AvailableMovements.Right == true)
					{
						movementDirection = Vector2.right;
						hasMoved = true;
					}
					break;
				case("Down"):
					if(TPB_Script.AvailableMovements.Down == true)
					{
						movementDirection = Vector2.down;
						hasMoved = true;
					}
					break;
				}
				
				MoveShape(movementDirection);
			}
		}
	}

	void MoveShape(Vector2 movingDirection)
	{
		float speed = shapeSpeed * Time.deltaTime;
		activeShape.GetComponent<Rigidbody2D>().velocity = movingDirection * speed;
		isMoving = true;


	}

	public void NewTravelPoint(GameObject HitTravelPoint)
	{
		activeShape.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
		SnapToTravelPoint(HitTravelPoint);
		TPB_Script = HitTravelPoint.GetComponent<TravelPointBehaviour>();

	}

	void SnapToTravelPoint(GameObject NewTravelPoint)
	{
		timeStartedLerping = Time.time;
		TravelPoint = NewTravelPoint;
		isLerping = true;
	}
}
