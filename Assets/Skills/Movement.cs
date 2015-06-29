using UnityEngine;
using System.Collections;

public class Movement{
	
	private static bool debug = true;
	
	private static float[] Hmove = new float[4]{0f,0f,0f,0f};
	private static float[] Vmove = new float[4]{0f,0f,0f,0f};
	
	private static int[] jumpState = new int[4]{0,0,0,0};
	
	public static void UpdateHorizontal(float value, int player){
		Hmove[player] = Mathf.Clamp(value,-1f,1f);
		if(debug){
			Debug.Log(Hmove[player]);
		}
	}
	
	public static void UpdateVertical(float value, int player){
		Vmove[player] = Mathf.Clamp(value,-1f,1f);
		if(debug){
			Debug.Log(Vmove[player]);
		}
	}
	
	public static float GetHorizontal(int player){
		return Hmove[player];
	}
	public static float GetVertical(int player){
		return Vmove[player];
	}
	
	
	public static void UpdateJump(int state,int player){
		jumpState[player] = Mathf.Clamp(state,0,3);
		if(debug){
			Debug.Log(jumpState[player]);
		}
	}
	
	public static bool GetJump(int player){
		if(jumpState[player] == 2){
			return true;
		}
		else{
			return false;
		}
	}
	public static bool GetJumpDown(int player){
		if(jumpState[player] == 1){
			return true;
		}
		else{
			return false;
		}
	}
	public static bool GetJumpUp(int player){
		if(jumpState[player] == 3){
			return true;
		}
		else{
			return false;
		}
	}
	
	
}
