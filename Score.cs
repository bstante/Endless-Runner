using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private float score = 0.0f;

    private int diffRange = 1;
    private int maxDifficulty = 20;
    private int difficultyLevel = 10;

    private bool isDead = false;

    public Text scoreText;
    public Death deathMenu;
	
	
	
	void Update () {
        if (isDead)
            return;

        if (score >= difficultyLevel)
            Level();
        score += Time.deltaTime *diffRange; //every second passes adds 1 score
        scoreText.text = ((int)score).ToString(); //inputs the score onto the text image
	}

    void Level() //adds difficulty to the game when the player reaches a certain score
    {
        if (diffRange == maxDifficulty)
            return;
        difficultyLevel *= 2;
        diffRange++;

        GetComponent<PlayerMotor>().Speed(diffRange); //took the component Speed from playermotor script
        Debug.Log(diffRange);
    }

    public void OnDeath()
    {
        isDead = true;
        deathMenu.ToggleEnd (score);
    }
}
