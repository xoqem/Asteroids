using UnityEngine;
using System.Collections;

public class HudScript : MonoBehaviour {

	public ShipControllerScript ship;
	public Color speedBarBackgroundColor;
	public Color speedBarColor;
	public Color targetSpeedColor;

	private Texture2D speedBarBackgroundTexture;
	private Texture2D speedBarTexture;
	private Texture2D targetSpeedTexture;

	private Rect speedBarBackgroundRect = new Rect (5, 5, 100, 10);
	private Rect speedBarRect = new Rect(5, 5, 0, 10);
	private Rect targetSpeedRect = new Rect(5, 4, 2, 12);
	private Texture2D speedBarBackground;
	private Texture2D speedBarCurrent;

	void Start() {
		speedBarBackgroundTexture = this.createTexture(speedBarBackgroundColor);
		speedBarTexture = this.createTexture(speedBarColor);
		targetSpeedTexture = this.createTexture(targetSpeedColor);
	}
	
	void OnGUI() {
		GUI.DrawTexture (speedBarBackgroundRect, speedBarBackgroundTexture);
		GUI.DrawTexture (speedBarRect, speedBarTexture);
		GUI.DrawTexture (targetSpeedRect, targetSpeedTexture);
	}
	
	// Update is called once per frame
	void Update () {
		float ratio = speedBarBackgroundRect.width / (ship.maxSpeed - ship.minSpeed);
		speedBarRect.x = ratio * -ship.minSpeed + speedBarBackgroundRect.x;
		speedBarRect.width = ratio * (ship.speed);
		targetSpeedRect.x = ratio * (ship.targetSpeed - ship.minSpeed) + speedBarBackgroundRect.x;
	}

	private Texture2D createTexture(Color color) {
		Texture2D texture = new Texture2D (1, 1);
		texture.SetPixel (0, 0, color);
		texture.Apply ();
		return texture;
	}
}