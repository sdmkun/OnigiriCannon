using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {
	
	public GameObject explosion;
	public GameObject food;
	public Vector3 direction;
	public float power;
	public float dispersion;	//ばらつき
	
	GUIStyle style = new GUIStyle();
	
	MousePositionOn2D mousePositionOn2D;
	
	// Use this for initialization
	void Start () {
		mousePositionOn2D = (MousePositionOn2D)transform.parent.gameObject.GetComponent(typeof(MousePositionOn2D));
		style.normal.textColor = Color.black;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			GameObject onigiri = (GameObject)Instantiate(explosion, transform.position + new Vector3(1.2f, 0.7f, 0.0f), Quaternion.identity);
			onigiri.transform.parent = transform.parent;
			onigiri.name = "OnigiriExplosive";
			direction = (mousePositionOn2D.GetMousePositionOn2D() - transform.position) * power;
			direction.z = Random.Range(-dispersion, dispersion);
			onigiri.rigidbody.AddForce(direction);
		}
		if (Input.GetButtonDown("Fire2")) {
			GameObject onigiri = (GameObject)Instantiate(food, transform.position + new Vector3(-1.0f, 0.5f, 0.0f), Quaternion.identity);
			onigiri.transform.parent = transform.parent;
			onigiri.name = "Onigiri";
		}
	}
	
	void OnGUI() {
		/*
		GUI.Label(new Rect(10, 10, 100, 40), direction.x.ToString(), style );
		GUI.Label(new Rect(10, 22, 100, 40), direction.y.ToString(), style );
		GUI.Label(new Rect(10, 34, 100, 40), direction.z.ToString(), style );
		GUI.Label(new Rect(100, 10, 100, 40), mousePositionOn2D.GetMousePositionOn2D().x.ToString(), style );
		GUI.Label(new Rect(100, 22, 100, 40), mousePositionOn2D.GetMousePositionOn2D().y.ToString(), style );
		GUI.Label(new Rect(100, 34, 100, 40), mousePositionOn2D.GetMousePositionOn2D().z.ToString(), style );
		*/
	}
}
