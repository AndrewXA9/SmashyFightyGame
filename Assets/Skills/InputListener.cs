using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputListener : MonoBehaviour {
	
	public MonoBehaviour basicNeutral;
	public MonoBehaviour basicSide;
	public MonoBehaviour basicUp;
	public MonoBehaviour basicDown;
	
	public MonoBehaviour airNeutral;
	public MonoBehaviour airSide;
	public MonoBehaviour airUp;
	public MonoBehaviour airDown;
	
	public MonoBehaviour specialNeutral;
	public MonoBehaviour specialSide;
	public MonoBehaviour specialUp;
	public MonoBehaviour specialDown;
	
	private Dictionary<int,MonoBehaviour> moveMap = new Dictionary<int, MonoBehaviour>();
	
	public enum directions {Neutral=100, Side = 200, Up = 300, Down = 400};
	public enum Position {Ground = 10, Air = 20};
	public enum Button {None = 1, Basic = 2, Special = 3, Shield = 4};
	
	private int button = 0;
	private int position = 00;
	private int dir = 000;
	
	private int move = 000;
	
	void Awake(){
		moveMap.Add(000,  basicNeutral);
		moveMap.Add(000,  basicSide);
		moveMap.Add(000,  basicUp);
		moveMap.Add(000,  basicDown);
		
		moveMap.Add(000,  airNeutral);
		moveMap.Add(000,  airSide);
		moveMap.Add(000,  airUp);
		moveMap.Add(000,  airDown);
		
		moveMap.Add(000,  specialNeutral);
		moveMap.Add(000,  specialSide);
		moveMap.Add(000,  specialUp);
		moveMap.Add(000,  specialDown);
	}
	
	void Update () {
		
		move = 000;
		
		dir = 100;
		if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)){
			dir = 200;
		}
		if(Input.GetKey(KeyCode.UpArrow)){
			dir = 300;
		}
		if(Input.GetKey(KeyCode.DownArrow)){
			dir = 400;
		}
		
		button = 0;
		if(Input.GetKey(KeyCode.Z)){
			button = 1;
		}
		if(Input.GetKey(KeyCode.X)){
			button = 2;
		}
		
		move = dir+position+button;
		/*if(Input.GetMouseButtonDown(0)){
			AS.enabled = true;
		}*/
		
		if(Input.GetMouseButtonDown(1)){
			this.gameObject.SendMessage("Interrupt");
		}
	}
}
