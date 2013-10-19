using UnityEngine;
using System.Collections;

public class ShowStatus : MonoBehaviour {

	GameObject healthEmpty;
	GameObject healthFill;
	public Texture2D healthEmptyTexture;
	public Texture2D healthFillTexture;
	
	float healthRate;
	int healthBarWidth = 50;
	int healthBarHeight = 6;
	
	// Use this for initialization
	void Start () {
		healthEmpty = new GameObject();
		healthEmpty.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
		healthEmpty.transform.rotation = Quaternion.identity;
		healthEmpty.transform.localScale = new Vector3(0.0f, 0.0f, 1.0f);
		healthEmpty.transform.parent = transform.parent;
		healthEmpty.name = "healthEmpty";
		healthEmpty.AddComponent("GUITexture");
		healthEmpty.layer = 9; //GUI
		healthEmpty.guiTexture.texture = healthEmptyTexture;
		healthEmpty.guiTexture.color = Color.red;
		healthEmpty.guiTexture.pixelInset = new Rect(-100, -100, healthBarWidth, healthBarHeight);
		healthEmpty.guiTexture.border = new RectOffset(3, 3, 0, 0);
		healthFill = new GameObject();
		healthFill.transform.position = new Vector3(0.0f, 0.0f, 5.0f);
		healthFill.transform.rotation = Quaternion.identity;
		healthFill.transform.localScale = new Vector3(0.0f, 0.0f, 1.0f);
		healthFill.transform.parent = transform.parent;
		healthFill.name = "healthFill";
		healthFill.AddComponent("GUITexture");
		healthEmpty.layer = 9; //GUI
		healthFill.guiTexture.texture = healthFillTexture;
		healthFill.guiTexture.color = Color.green;
		healthFill.guiTexture.border = new RectOffset(3, 3, 0, 0);
		healthFill.guiTexture.pixelInset = new Rect(-100, -100, healthBarWidth, healthBarHeight);
	}
	
	// Update is called once per frame
	void Update () {
		healthEmpty.guiTexture.pixelInset = new Rect(Camera.main.WorldToScreenPoint(transform.position).x - 24, Camera.main.WorldToScreenPoint(transform.position).y - 18,
													healthBarWidth, healthBarHeight);
		healthFill.guiTexture.pixelInset = new Rect(Camera.main.WorldToScreenPoint(transform.position).x - 24, Camera.main.WorldToScreenPoint(transform.position).y - 18,
													healthRate * healthBarWidth, healthBarHeight);
	}
	
	void OnDestroy() {
		Die();
	}
	
	void SetHealthRate(float argHealthRate) {
		healthRate = argHealthRate;
	}
	
	void Die() {
		Destroy(healthEmpty);
		Destroy(healthFill);
		Destroy(this);
	}
	
}
