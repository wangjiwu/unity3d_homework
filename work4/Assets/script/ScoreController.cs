using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController{
	int score = 0 ;

	void Start () {
		
	}
	
	void Update () {
		
	}

	public void addScore(int lever ){
		score += lever;
	}

	public int getScore(){
		return score;
	}
  


    public void reset(){
		score = 0;
    }
}
