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
	
	}

    void DetectShape()
    {


        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
        if (hit.collider != null)
        {
            if(hit.collider.tag == "Shape")
            {
                Debug.Log(hit.collider.name);
                MM_Script.activeShape = hit.collider.gameObject;

            }
            
            
        }

    }
}
