using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour {

    public Text scoreText;
    public Image backgroundImg;

    private bool isShown = false;

    private float transition = 0.0f;
	// Use this for initialization
	void Start () //hides the death menu
    {
        gameObject.SetActive(false); 
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!isShown)
            return;

        transition += Time.deltaTime;
        backgroundImg.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);
	}
    public void ToggleEnd(float score) //shows the final score
    {
        gameObject.SetActive(true);
        scoreText.text = ((int)score).ToString();
        isShown = true;
    }

    public void Restart() //loads the scene again
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnMenu() //returns to the main menu
    {
        SceneManager.LoadScene("Menu");
    }
}
