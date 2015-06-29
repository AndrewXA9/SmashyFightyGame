using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputListener : MonoBehaviour {
	
	public int playerIndex = 1;
	
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
	
	private Dictionary<int,MonoBehaviour> moveMap = new Dictionary<int, MonoBehaviour>(){};
	
	public enum directions {Neutral=100, Side = 200, Up = 300, Down = 400};
	public enum Position {Ground = 10, Air = 20};
	public enum Button {None = 1, Basic = 2, Special = 3, Shield = 4};
	
	private int button = 0;
	private int position = 00;
	private int dir = 000;
	
	private int move = 000;
	
	void Awake(){
		moveMap.Add(112,  basicNeutral);
		moveMap.Add(212,  basicSide);
		moveMap.Add(312,  basicUp);
		moveMap.Add(412,  basicDown);
		
		moveMap.Add(122,  airNeutral);
		moveMap.Add(222,  airSide);
		moveMap.Add(322,  airUp);
		moveMap.Add(422,  airDown);
		
		moveMap.Add(113,  specialNeutral);
		moveMap.Add(213,  specialSide);
		moveMap.Add(313,  specialUp);
		moveMap.Add(413,  specialDown);
		
		moveMap.Add(123,  specialNeutral);
		moveMap.Add(223,  specialSide);
		moveMap.Add(323,  specialUp);
		moveMap.Add(423,  specialDown);
		
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
		
		MonoBehaviour output;
		if(moveMap.TryGetValue(move, out output)){
			output.enabled = true;
		}
		else{
			if(Input.GetKey(KeyCode.LeftArrow)){
				Movement.UpdateHorizontal(-1f,playerIndex);
			}
			if(Input.GetKey(KeyCode.RightArrow)){
				Movement.UpdateHorizontal(1f,playerIndex);
			}
			if(Input.GetKey(KeyCode.UpArrow)){
				Movement.UpdateVertical(1f,playerIndex);
			}
			if(Input.GetKey(KeyCode.DownArrow)){
				Movement.UpdateVertical(-1f,playerIndex);
			}
		}
		
		
		if(Input.GetKey(KeyCode.Space)){
			Movement.UpdateJump(2,playerIndex);
		}
		if(Input.GetKeyDown(KeyCode.Space)){
			Movement.UpdateJump(1,playerIndex);
		}
		if(Input.GetKeyUp(KeyCode.Space)){
			Movement.UpdateJump(3,playerIndex);
		}
		
		
//		if(Input.GetMouseButtonDown(0)){
//			AS.enabled = true;
//		}
		
//		if(Input.GetMouseButtonDown(1)){
//			this.gameObject.SendMessage("Interrupt");
//		}
		
		
	}
}
