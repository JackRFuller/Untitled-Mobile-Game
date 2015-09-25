using UnityEngine;
using System.Collections;

public class ActiveShapeManager : MonoBehaviour {

    private Camera MainCamera;
    [SerializeField] private MovementManager MM_Script;
  

	// Use this for initialization
	void Start () {

        MainCamera = Camera.main;
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButton(0))
        {
            DetectShape();
        }

		if(Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			DetectShapeTouch(touch);
		}
	
	}

	void DetectShapeTouch(Touch touchpoint)
	{
		Vector2 worldPoint = Camera.main.ScreenToWorldPoint(touchpoint.position);
		RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
		if (hit.collider != null)
		{
			if(hit.collider.tag == "Shape")
			{
				if(!MM_Script.isMoving)
				{
					ChangeActiveShape(hit.collider.gameObject);           
				}
				
			}  
		}
	}

    void DetectShape()
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
        if (hit.collider != null)
        {
            if(hit.collider.tag == "Shape")
            {
				if(!MM_Script.isMoving)
				{
					ChangeActiveShape(hit.collider.gameObject);           
				}
				  
            }  
        }

    }

	void ChangeActiveShape(GameObject hit)
	{
		MM_Script.activeShape.GetComponent<ShapeBehaviour>().TurnOffShape();
		MM_Script.activeShape = hit.GetComponent<Collider2D>().gameObject;

		MM_Script.activeShape.GetComponent<ShapeBehaviour>().TurnOnShape();
		MM_Script.ChangeShape();
	}
}
