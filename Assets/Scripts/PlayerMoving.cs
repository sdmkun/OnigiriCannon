using UnityEngine;
using System.Collections;

public class PlayerMoving : MonoBehaviour {
	public float speed;
	
	//Vector3 StandingPosition = new Vector3(0.0f, 0.0f, 0.0f);
	//Quaternion StandingRotation = Quaternion.Euler(new Vector3(0, 90, 0));
	
	protected bool onSurface;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Mathf.Abs(rigidbody.velocity.x) < speed) {
			//rigidbody.AddForce(60.0f * Input.GetAxis("Horizontal"), 0.0f, 0.0f);
			rigidbody.AddForceAtPosition(new Vector3(60.0f * Input.GetAxis("Horizontal"), 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f));
		}
		if(Mathf.Abs(rigidbody.velocity.z) < speed) {
			rigidbody.AddForce(0.0f, 0.0f, 60.0f * Input.GetAxis("Vertical"));
		}
		
		//StandingPosition.x = transform.position.x;
		//StandingPosition.y = transform.position.y;
		//transform.position = Vector3.Lerp(transform.position, StandingPosition, 10.0f * Time.deltaTime);
		//transform.rotation = Quaternion.Lerp(transform.rotation, StandingRotation, 20.0f * Time.deltaTime);
	}
	
	protected void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "Surface") {
			onSurface = true;
		}
	}
	
	protected void OnCollisionExit(Collision collision) {
		if(collision.gameObject.tag == "Surface") {
			onSurface = false;
		}
	}
	
	void OnGUI() {
		//GUI.Label(new Rect(20, 20, 100, 40), Input.GetAxis("Horizontal").ToString() );
		//GUI.Label(new Rect(20, 40, 100, 40), Input.GetAxis("Vertical").ToString() );
	}
}
