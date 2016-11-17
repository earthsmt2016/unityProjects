using System;
using UnityEngine;
using System.Collections;

public class setPebbles : MonoBehaviour {
	
	/**
	 * Set the number of peebles to use in the Unity scene.
	 */
	private const int maxPebbleCount = 12;
	
	/**
	 * Current pebbles which are already displayed in a given scene.
	 */
	private static int currentPebbleCount = 0;
	
	/**
	 * Current scale factor for the current pebble.
	 */
	private static float scaleFactor = 100;
	
	/**
	 * Rate of decrease in scaling.
	 */
	private const float rateOfScale = 1.05f;
	
	/**
	 * Angle for the current pebble - this is used to calculate the position ofthe current pebble.
	 */
	private static double angleChange = 10.0f;
	
	/**
	 * Shift the angle used in calculating the position of the pebbles.
	 */
	public const double defaultAngle = 0.0f;
	
	/**
	 * Minimum distance between each of the pebbles.
	 * -- This should be constrained against the minimum distance.
	 */
	private static float constDistance = 1.19f;
	
	/**
	 * Decide on orientation of the pebbles.
	 */
	private bool reflectTrue = false;
	
	private float controlHeight = 0.1f;
	private static float lastX;
	private static float lastY;
	private static float lastZ;
	/**
	 * Used to set up properties directly relating to the asset assigned.
	 */
	void Start () {
		float[] positionData = new float[3];
		
		{
				if(currentPebbleCount >= maxPebbleCount)
				{
					print("There are "+Convert.ToString(maxPebbleCount)+" pebbles created");
					creatingScreenGate(lastX, lastY, lastZ);
				}
				else{
					positionData = reflectPositionOfPebblesX();
					creatingCloneAsset(positionData[0], positionData[1], positionData[2]);
					lastX = positionData[0];
					lastY = positionData[1];
					lastZ = positionData[2];
				}				
				currentPebbleCount = currentPebbleCount +1;
				angleChange = angleChange + 10.0f;
		}
	}
	
	/**
	 * Reflect the position of the pebbles in the x-direction.
	 * @return returnInfo: position information of the assets which are repeated/cloned.
	 */
	 private float[] reflectPositionOfPebblesX()
	 {
		 float[] returnInfo = new float[3];
		 if(reflectTrue)
		 {
			 returnInfo[2] = (Convert.ToSingle(this.transform.position.z - constDistance*Math.Cos(convertToRadians(angleChange))));	 
		 }
		 else
		 {
			 returnInfo[2] = (Convert.ToSingle(this.transform.position.z + constDistance*Math.Cos(convertToRadians(angleChange))));			 
		 }
		returnInfo[1] = Convert.ToSingle(this.transform.position.y + constDistance*Math.Sin(convertToRadians(angleChange)));	 
		returnInfo[0] = Convert.ToSingle(this.transform.position.x +controlHeight*convertToRadians(angleChange));
		return returnInfo;
	 }
	
    /**
	 * Used to set up properties directly relating to the asset assigned.
	 * @param positionX: x-position of the clone asset.
	 * @param positionY: y-position of the clone asset.
	 * @param positionZ: z-direction of the clone asset.
	 */
	 private void creatingCloneAsset(float positionX, float positionY, float positionZ)
	 {
		GameObject copy = (GameObject) Instantiate(GameObject.Find("jesusRock"), new Vector3(positionX, positionY, positionZ), Quaternion.identity);
		copy.name = "cloneStone"+Convert.ToString(currentPebbleCount);
		scaleFactor = scaleFactor/rateOfScale;
		copy.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
		copy.transform.Rotate(0, 90, 0);	
	 }
	 
	 private void creatingScreenGate(float posX, float posY, float posZ)
	 {
	 }
	
	/**
	 * Convert the angle which is degrees into radians.
	 */
	
	private double convertToRadians(double degree)
	{
		return 0.0174533f*(degree + defaultAngle);
	}
	
	/**
	 * Update is called once per frame.
	 */
	 
	void Update () {
	
	}
}