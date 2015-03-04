using UnityEngine;
using System.Collections;
	
	
	//TEMPLATE FOR SKILLS
public class Skill : MonoBehaviour {
	
	
	private bool interrupt = false;
	
	void Interrupt(){
		interrupt = true;
	}
	
	void OnEnable(){
		StartCoroutine(Begin());
	}
	
	IEnumerator Begin(){
		float exit = 1;
		this.renderer.material.color = Color.red;
		
		while(exit > 0){
			exit -= Time.deltaTime;
			
			
			
			yield return null;
		}
		
		StartCoroutine(Loop1());
	}
	
	IEnumerator Loop1(){
		float exit = 2;
		this.renderer.material.color = Color.yellow;
		
		while(exit > 0){
			exit -= Time.deltaTime;
			
			//Content
			
			if(interrupt){
				yield break;
				this.enabled = false;
			}
			yield return null;
		}
		
		StartCoroutine(End());		
	}
	
	IEnumerator End(){
		float exit = 1;
		this.renderer.material.color = Color.green;
		
		while(exit > 0){
			exit -= Time.deltaTime;
			
			//Content
			
			yield return null;
		}
		
		this.enabled = false;
	}
		
}
