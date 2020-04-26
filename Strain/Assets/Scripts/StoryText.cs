using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StoryText : MonoBehaviour
{

    public static int health = 100;
    public static int stress = 80;
    //public int health = 100;
    //public int stress = 80;

    int healthDecreaseGaming;
    int healthIncreaseWorkOut;
    int healthDecreaseRead;
    int healthIncreaseConsumable;


    int stressDecreaseGaming;
    int stressDecreaseWorkOut;
    int stressDecreaseRead;
    int stressDecreaseConsumable;


    public Text textComponent;
    public State StartingState;

    public Text stressText;
    public Text healthText;


    State state;
    // Start is called before the first frame update
    public void Start()
    {
        //starts the game with the starting state
        state = StartingState;
        //gets the states and the text
        textComponent.text = state.GetStateStory();
        // these are the stress values and where they get the random variable
        stressDecreaseGaming = UnityEngine.Random.Range(10, 20);
        //Debug.Log(stressDecreaseGaming);
        stressDecreaseWorkOut = UnityEngine.Random.Range(10, 20);
        stressDecreaseRead = UnityEngine.Random.Range(10, 20);
        stressDecreaseConsumable = UnityEngine.Random.Range(10, 20);

        healthDecreaseGaming = UnityEngine.Random.Range(10, 30);
        healthIncreaseWorkOut = UnityEngine.Random.Range(15, 30);
        healthDecreaseRead = UnityEngine.Random.Range(10, 30);
        healthIncreaseConsumable = UnityEngine.Random.Range(10, 20);
    }
  
    // Update is called once per frame
    void Update()
    {
        ManageState();
        
        //makes sure stress doesn't go below 0
        if (stress < 0)
        {
            stress = 0; 
        }
        //makes sure stress doesn't go above 100
        if (stress > 100)
        {
            stress = 100;
        }

        //makes sure health doesn't go below 0
        if (health <= 0)
        {
            health = 0;
        }
        //makes sure stress doesn't go above 150
        if (health > 150)
        {
            health = 150;
        }

        //makes sure that the stress levels dont go below four so that each method still works
        if (stressDecreaseGaming < 4)
        {
            stressDecreaseGaming = stressDecreaseGaming + 1;
        }

        if (stressDecreaseWorkOut < 4)
        {
            stressDecreaseGaming = stressDecreaseGaming + 1;
        }

        if (stressDecreaseRead < 4)
        {
            stressDecreaseGaming = stressDecreaseGaming + 1;
        }

        if (stressDecreaseConsumable < 4)
        {
            stressDecreaseGaming = stressDecreaseGaming + 1;
        }

        // how far it can either decrease or increase health
        if (healthDecreaseGaming > 35)
        {
            healthDecreaseGaming = healthDecreaseGaming - 2;
        }

        if (healthIncreaseWorkOut < 15)
        {
            healthIncreaseWorkOut = healthIncreaseWorkOut + 5;
        }

        if (healthDecreaseRead > 35)
        {
            healthDecreaseRead = healthDecreaseRead - 2;
        }

        if (healthIncreaseConsumable < 10)
        {
            healthIncreaseConsumable = healthIncreaseConsumable + 2;
        }

        CheckGameOver();

    }

    void DisplayScores()
    {
        stressText.text = "Stress:" + StoryText.stress.ToString("000");
        healthText.text = "Health:" + StoryText.health.ToString("000");
    }

    private void ManageState()
    {
        var nextStates = state.GetNextStates();
       
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            state = nextStates[0];
            if (health <= 0)
            {
                health = 0;
            }
            health = health - healthDecreaseGaming;
            healthDecreaseGaming = healthDecreaseGaming + 2;

            stress = stress + 5;
            stress = stress - stressDecreaseGaming;
            stressDecreaseGaming = stressDecreaseGaming - 2;
            Debug.Log("Health:" + health);
            Debug.Log("Stress:" + stress);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            state = nextStates[0];
            health = health + healthIncreaseWorkOut;
            healthIncreaseWorkOut = healthIncreaseWorkOut - 5;

            stress = stress + 5;
            stress = stress - stressDecreaseWorkOut;
            stressDecreaseWorkOut = stressDecreaseWorkOut - 2;
            Debug.Log("Health:" + health);
            Debug.Log("Stress:" + stress);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            state = nextStates[0];
            health = health - healthDecreaseRead;
            healthDecreaseRead = healthDecreaseRead + 5;

            stress = stress + 5;
            stress = stress - stressDecreaseRead;
            stressDecreaseRead = stressDecreaseRead - 2;

            Debug.Log("Health:" + health);
            Debug.Log("Stress:" + stress);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            state = nextStates[0];
            health = health + healthIncreaseConsumable;
            healthIncreaseConsumable = healthIncreaseConsumable - 4;

            stress = stress + 5;
            stress = stress - stressDecreaseConsumable;
            stressDecreaseConsumable = stressDecreaseConsumable - 2;

            Debug.Log("Health:" + health);
            Debug.Log("Stress:" + stress);
        }
        textComponent.text = state.GetStateStory();

        DisplayScores();
    }

    public void CheckGameOver()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(2);
        }
        if (stress <= 0)
        {
            SceneManager.LoadScene(3);
        }
    }
}
