/*
 * Camera control class for a battle arena type game. 
 * Takes the average transform of the two furthest players and centers the camera.
 * uses the x and y values
 * 
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MultiPlayerCameraFocus : MonoBehaviour
{
	//grab the transforms of all the players from inspector
	public List<Transform> Players;
	public Vector3 CameraBuffer;
	public Vector2 minCameraPos;
	public Vector2 maxCameraPos;

	private List<float> xPositions = new List<float>();
	private List<float> yPositions = new List<float>();
	private float maxX;
	private float maxY;
	private float minX;
	private float minY;
	private Vector3 maxPosition;
	private Vector3 minPosition;
	private Vector3 centerPosition;
	private Vector3 zoomValue;
	private Vector3 cameraPosition;

	


	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		foreach(Transform player in Players)
		{
			xPositions.Add(player.transform.position.x);
			yPositions.Add(player.transform.position.y);
		}

		//setting the min and max player positions, check if the positions pass the min and max vectors
		maxX = (Mathf.Max(xPositions.ToArray()) > maxCameraPos.x) ? maxCameraPos.x : Mathf.Max(xPositions.ToArray());
		maxY = (Mathf.Max(yPositions.ToArray()) > maxCameraPos.y) ? maxCameraPos.y : Mathf.Max(yPositions.ToArray());
		minX = (Mathf.Min(xPositions.ToArray()) < minCameraPos.x) ? minCameraPos.x : Mathf.Min(xPositions.ToArray());
		minY = (Mathf.Min(yPositions.ToArray()) < minCameraPos.y) ? minCameraPos.y : Mathf.Min(yPositions.ToArray());

		//clear lists for next update
		xPositions.Clear();
		yPositions.Clear();

		//finding the center follow position for the camera
		maxPosition = new Vector3(maxX,maxY,0);
		minPosition = new Vector3(minX,minY,0);

		centerPosition = (maxPosition + minPosition) * 0.5f;

		//cross product to get the z value to scale back and forth when the players move away from eachother
		zoomValue = Vector3.Cross(minPosition,maxPosition);


		//make sure to always zoom out when players move away from eachother
		if(zoomValue.z >= 0.0f)
		{
			cameraPosition = centerPosition - zoomValue;
		}
		else if(zoomValue.z < 0.0f)
		{
			cameraPosition = centerPosition + zoomValue;
		}


		//Final Camera Position with Buffer for start position
		transform.position = cameraPosition + CameraBuffer;


	}
}
