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

	[SerializeField] private List<Transform> m_players;		// Grab the transforms of all the players from inspector
	[SerializeField] private Vector3 m_cameraBuffer;		// Alter the home position of the camera
	[SerializeField] private Vector2 m_minCameraPos;		// Minimum camera x and y position
	[SerializeField] private Vector2 m_maxCameraPos;		// Maximum camera x and y postion
	[SerializeField] private float m_cameraZoomScale;		// How fast the camera zooms in and out

	private List<float> m_xPositions = new List<float>();
	private List<float> m_yPositions = new List<float>();
	private float m_maxX;
	private float m_maxY;
	private float m_minX;
	private float m_minY;
	private Vector3 m_maxPosition;
	private Vector3 m_minPosition;
	private Vector3 m_centerPosition;
	private Vector3 m_zoomValue;
	private Vector3 m_cameraPosition;



	// Update is called once per frame
	void Update () 
	{
		positionCamera();
	}

	void positionCamera()
	{
		foreach(Transform player in m_players)
		{
			m_xPositions.Add(player.transform.position.x);
			m_yPositions.Add(player.transform.position.y);
		}
		
		//setting the min and max player positions, check if the positions pass the min and max vectors
		m_maxX = (Mathf.Max(m_xPositions.ToArray()) > m_maxCameraPos.x) ? m_maxCameraPos.x : Mathf.Max(m_xPositions.ToArray());
		m_maxY = (Mathf.Max(m_yPositions.ToArray()) > m_maxCameraPos.y) ? m_maxCameraPos.y : Mathf.Max(m_yPositions.ToArray());
		m_minX = (Mathf.Min(m_xPositions.ToArray()) < m_minCameraPos.x) ? m_minCameraPos.x : Mathf.Min(m_xPositions.ToArray());
		m_minY = (Mathf.Min(m_yPositions.ToArray()) < m_minCameraPos.y) ? m_minCameraPos.y : Mathf.Min(m_yPositions.ToArray());
		
		//clear lists for next update
		m_xPositions.Clear();
		m_yPositions.Clear();
		
		//finding the center follow position for the camera
		m_maxPosition = new Vector3(m_maxX,m_maxY,0);
		m_minPosition = new Vector3(m_minX,m_minY,0);
		
		m_centerPosition = (m_maxPosition + m_minPosition) * 0.5f;
		
		//cross product to get the z value to scale back and forth when the players move away from eachother
		m_zoomValue = Vector3.Cross(m_minPosition,m_maxPosition);
		
		
		//make sure to always zoom out when players move away from eachother
		if(m_zoomValue.z >= 0.0f)
		{
			m_cameraPosition = m_centerPosition - m_zoomValue;
		}
		else if(m_zoomValue.z < 0.0f)
		{
			m_cameraPosition = m_centerPosition + m_zoomValue;
		}
		
		
		//Final Camera Position with Buffer for start position
//		transform.position = m_cameraPosition + m_cameraBuffer;
		transform.position = Vector3.Lerp(transform.position, (m_cameraPosition + m_cameraBuffer),Time.deltaTime * m_cameraZoomScale);
	}
}
