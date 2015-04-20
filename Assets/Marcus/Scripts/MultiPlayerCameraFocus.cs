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

	[SerializeField] private List<Transform> players;		// Grab the transforms of all the players from inspector
	[SerializeField] private Vector3 cameraBuffer;		// Alter the home position of the camera
	[SerializeField] private Vector2 minCameraPos;		// Minimum camera x and y position
	[SerializeField] private Vector2 maxCameraPos;		// Maximum camera x and y postion
	[SerializeField] private float cameraZoomScale;		// How fast the camera zooms in and out

	private List<float> m_xPositions = new List<float>();
	private List<float> m_yPositions = new List<float>();
	private float maxX;
	private float maxY;
	private float minX;
	private float minY;
	private Vector3 maxPosition;
	private Vector3 minPosition;
	private Vector3 centerPosition;
	private Vector3 zoomValue;
	private Vector3 cameraPosition;



	// Update is called once per frame
	void Update () 
	{
		positionCamera();
	}

	void positionCamera()
	{
		foreach(Transform player in players)
		{
			m_xPositions.Add(player.transform.position.x);
			m_yPositions.Add(player.transform.position.y);
		}
		
		//setting the min and max player positions, check if the positions pass the min and max vectors
		maxX = (Mathf.Max(m_xPositions.ToArray()) > maxCameraPos.x) ? maxCameraPos.x : Mathf.Max(m_xPositions.ToArray());
		maxY = (Mathf.Max(m_yPositions.ToArray()) > maxCameraPos.y) ? maxCameraPos.y : Mathf.Max(m_yPositions.ToArray());
		minX = (Mathf.Min(m_xPositions.ToArray()) < minCameraPos.x) ? minCameraPos.x : Mathf.Min(m_xPositions.ToArray());
		minY = (Mathf.Min(m_yPositions.ToArray()) < minCameraPos.y) ? minCameraPos.y : Mathf.Min(m_yPositions.ToArray());
		
		//clear lists for next update
		m_xPositions.Clear();
		m_yPositions.Clear();
		
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
//		transform.position = cameraPosition + cameraBuffer;
		transform.position = Vector3.Lerp(transform.position, (cameraPosition + cameraBuffer),Time.deltaTime * cameraZoomScale);
	}
}
