using UnityEngine;
using System.Collections;

public class MousePositionOn2D : MonoBehaviour {
	
	LayerMask mouse2DRaycast;
	Vector3 mousePositionOn2D;
	
	// Use this for initialization
	void Start () {
		mouse2DRaycast = 1 << LayerMask.NameToLayer("Mouse2DRaycast");
		mousePositionOn2D = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public Vector3 GetMousePositionOn2D() {
		Ray ray;
		RaycastHit hit;
		
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray, out hit, 100.0f, mouse2DRaycast) ) {
			mousePositionOn2D = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, hit.distance));
		}
		
		return mousePositionOn2D;
	}
}
