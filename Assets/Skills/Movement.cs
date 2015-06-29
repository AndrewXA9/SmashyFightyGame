using UnityEngine;
using System.Collections;

public class Movement{

	private static float[] Hmove = new float[4]{0f,0f,0f,0f};
	private static float[] Vmove = new float[4]{0f,0f,0f,0f};
	
	
	public static void UpdateHorizontal(float value, int player){
		Hmove[player] = Mathf.Clamp(value,-1f,1f);
	}
	
	public static void UpdateVertical(float value, int player){
		Vmove[player] = Mathf.Clamp(value,-1f,1f);
	}
	
	public static float GetHorizontal(int player){
		return Hmove[player];
	}
	public static float GetVertical(int player){
		return Vmove[player];
	}
	
}
