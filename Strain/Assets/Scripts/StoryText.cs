using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StoryText : MonoBehaviour
{

    public static int health = 100;
    public static int acuteStress = 80;
    //public int health = 100;
    //public int stress = 80;

    int healthDecreaseGaming;
    int healthIncreaseWorkOut;
    int healthDecreaseRead;
    int healthIncreaseConsumable;


    int acutestressDecreaseGaming;
    int acutestressDecreaseWorkOut;
    int acutestressDecreaseRead;
    int acutestressDecreaseConsumable;


    public Text textComponent;
    public State StartingState;
    public State Situation1;
    public State Situation2;
    public State Situation3;
    public State Situation4;
    public State Situation5;
    public State Situation6;
    public State Situation7;

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
        acutestressDecreaseGaming = UnityEngine.Random.Range(10, 20);
        //Debug.Log(stressDecreaseGaming);
        acutestressDecreaseWorkOut = UnityEngine.Random.Range(10, 20);
        acutestressDecreaseRead = UnityEngine.Random.Range(10, 20);
        acutestressDecreaseConsumable = UnityEngine.Random.Range(10, 20);

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
        if (acuteStress < 0)
        {
            acuteStress = 0; 
        }
        //makes sure stress doesn't go above 100
        if (acuteStress > 100)
        {
            acuteStress = 100;
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
        if (acutestressDecreaseGaming < 4)
        {
            acutestressDecreaseGaming = acutestressDecreaseGaming + 1;
        }

        if (acutestressDecreaseWorkOut < 4)
        {
            acutestressDecreaseGaming = acutestressDecreaseGaming + 1;
        }

        if (acutestressDecreaseRead < 4)
        {
            acutestressDecreaseGaming = acutestressDecreaseGaming + 1;
        }

        if (acutestressDecreaseConsumable < 4)
        {
            acutestressDecreaseGaming = acutestressDecreaseGaming + 1;
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
        stressText.text = "Stress:" + StoryText.acuteStress.ToString("000");
        healthText.text = "Health:" + StoryText.health.ToString("000");
    }

    private void ManageState()
    {
        var nextStates = state.GetNextStates();
        if (state == StartingState)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                state = Situation1;
                if (health <= 0)
                {
                    health = 0;
                }
                health = health - healthDecreaseGaming;
                healthDecreaseGaming = healthDecreaseGaming + 2;

                acuteStress = acuteStress + 5;
                acuteStress = acuteStress - acutestressDecreaseGaming;
                acutestressDecreaseGaming = acutestressDecreaseGaming - 2;
                Debug.Log("Health:" + health);
                Debug.Log("Stress:" + acuteStress);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                state = Situation1;
                health = health + healthIncreaseWorkOut;
                healthIncreaseWorkOut = healthIncreaseWorkOut - 5;

                acuteStress = acuteStress + 5;
                acuteStress = acuteStress - acutestressDecreaseWorkOut;
                acutestressDecreaseWorkOut = acutestressDecreaseWorkOut - 2;
                Debug.Log("Health:" + health);
                Debug.Log("Stress:" + acuteStress);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                state = Situation1;
                health = health - healthDecreaseRead;
                healthDecreaseRead = healthDecreaseRead + 5;

                acuteStress = acuteStress + 5;
                acuteStress = acuteStress - acutestressDecreaseRead;
                acutestressDecreaseRead = acutestressDecreaseRead - 2;

                Debug.Log("Health:" + health);
                Debug.Log("Stress:" + acuteStress);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                state = Situation1;
                health = health + healthIncreaseConsumable;
                healthIncreaseConsumable = healthIncreaseConsumable - 4;

                acuteStress = acuteStress + 5;
                acuteStress = acuteStress - acutestressDecreaseConsumable;
                acutestressDecreaseConsumable = acutestressDecreaseConsumable - 2;

                Debug.Log("Health:" + health);
                Debug.Log("Stress:" + acuteStress);
            }
        }
        else if (state == Situation1)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                state = Situation2;
                if (health <= 0)
                {
                    health = 0;
                }
                health = health - healthDecreaseGaming;
                healthDecreaseGaming = healthDecreaseGaming + 2;

                acuteStress = acuteStress + 5;
                acuteStress = acuteStress - acutestressDecreaseGaming;
                acutestressDecreaseGaming = acutestressDecreaseGaming - 2;
                Debug.Log("Health:" + health);
                Debug.Log("Stress:" + acuteStress);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                state = Situation2;
                health = health + healthIncreaseWorkOut;
                healthIncreaseWorkOut = healthIncreaseWorkOut - 5;

                acuteStress = acuteStress + 5;
                acuteStress = acuteStress - acutestressDecreaseWorkOut;
                acutestressDecreaseWorkOut = acutestressDecreaseWorkOut - 2;
                Debug.Log("Health:" + health);
                Debug.Log("Stress:" + acuteStress);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                state = Situation2;
                health = health - healthDecreaseRead;
                healthDecreaseRead = healthDecreaseRead + 5;

                acuteStress = acuteStress + 5;
                acuteStress = acuteStress - acutestressDecreaseRead;
                acutestressDecreaseRead = acutestressDecreaseRead - 2;

                Debug.Log("Health:" + health);
                Debug.Log("Stress:" + acuteStress);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                state = Situation2;
                health = health + healthIncreaseConsumable;
                healthIncreaseConsumable = healthIncreaseConsumable - 4;

                acuteStress = acuteStress + 5;
                acuteStress = acuteStress - acutestressDecreaseConsumable;
                acutestressDecreaseConsumable = acutestressDecreaseConsumable - 2;

                Debug.Log("Health:" + health);
                Debug.Log("Stress:" + acuteStress);
            }
        }
        else if (state == Situation2)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                state = Situation3;
                if (health <= 0)
                {
                    health = 0;
                }
                health = health - healthDecreaseGaming;
                healthDecreaseGaming = healthDecreaseGaming + 2;

                acuteStress = acuteStress + 5;
                acuteStress = acuteStress - acutestressDecreaseGaming;
                acutestressDecreaseGaming = acutestressDecreaseGaming - 2;
                Debug.Log("Health:" + health);
                Debug.Log("Stress:" + acuteStress);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                state = Situation3;
                health = health + healthIncreaseWorkOut;
                healthIncreaseWorkOut = healthIncreaseWorkOut - 5;

                acuteStress = acuteStress + 5;
                acuteStress = acuteStress - acutestressDecreaseWorkOut;
                acutestressDecreaseWorkOut = acutestressDecreaseWorkOut - 2;
                Debug.Log("Health:" + health);
                Debug.Log("Stress:" + acuteStress);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                state = Situation3;
                health = health - healthDecreaseRead;
                healthDecreaseRead = healthDecreaseRead + 5;

                acuteStress = acuteStress + 5;
                acuteStress = acuteStress - acutestressDecreaseRead;
                acutestressDecreaseRead = acutestressDecreaseRead - 2;

                Debug.Log("Health:" + health);
                Debug.Log("Stress:" + acuteStress);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                state = Situation3;
                health = health + healthIncreaseConsumable;
                healthIncreaseConsumable = healthIncreaseConsumable - 4;

                acuteStress = acuteStress + 5;
                acuteStress = acuteStress - acutestressDecreaseConsumable;
                acutestressDecreaseConsumable = acutestressDecreaseConsumable - 2;

                Debug.Log("Health:" + health);
                Debug.Log("Stress:" + acuteStress);
            }
        }
        else if (state == Situation3)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                state = Situation4;
                if (health <= 0)
                {
                    health = 0;
                }
                health = health - healthDecreaseGaming;
                healthDecreaseGaming = healthDecreaseGaming + 2;

                acuteStress = acuteStress + 5;
                acuteStress = acuteStress - acutestressDecreaseGaming;
                acutestressDecreaseGaming = acutestressDecreaseGaming - 2;
                Debug.Log("Health:" + health);
                Debug.Log("Stress:" + acuteStress);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                state = Situation4;
                health = health + healthIncreaseWorkOut;
                healthIncreaseWorkOut = healthIncreaseWorkOut - 5;

                acuteStress = acuteStress + 4;
                acuteStress = acuteStress - acutestressDecreaseWorkOut;
                acutestressDecreaseWorkOut = acutestressDecreaseWorkOut - 2;
                Debug.Log("Health:" + health);
                Debug.Log("Stress:" + acuteStress);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                state = Situation4;
                health = health - healthDecreaseRead;
                healthDecreaseRead = healthDecreaseRead + 5;

                acuteStress = acuteStress + 5;
                acuteStress = acuteStress - acutestressDecreaseRead;
                acutestressDecreaseRead = acutestressDecreaseRead - 2;

                Debug.Log("Health:" + health);
                Debug.Log("Stress:" + acuteStress);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                state = Situation4;
                health = health + healthIncreaseConsumable;
                healthIncreaseConsumable = healthIncreaseConsumable - 4;

                acuteStress = acuteStress + 5;
                acuteStress = acuteStress - acutestressDecreaseConsumable;
                acutestressDecreaseConsumable = acutestressDecreaseConsumable - 2;

                Debug.Log("Health:" + health);
                Debug.Log("Stress:" + acuteStress);
            }
        }
        else if (state == Situation4)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                state = Situation5;
                if (health <= 0)
                {
                    health = 0;
                }
                health = health - healthDecreaseGaming;
                healthDecreaseGaming = healthDecreaseGaming + 2;

                acuteStress = acuteStress + 5;
                acuteStress = acuteStress - acutestressDecreaseGaming;
                acutestressDecreaseGaming = acutestressDecreaseGaming - 2;
                Debug.Log("Health:" + health);
                Debug.Log("Stress:" + acuteStress);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                state = Situation5;
                health = health + healthIncreaseWorkOut;
                healthIncreaseWorkOut = healthIncreaseWorkOut - 5;

                acuteStress = acuteStress + 4;
                acuteStress = acuteStress - acutestressDecreaseWorkOut;
                acutestressDecreaseWorkOut = acutestressDecreaseWorkOut - 2;
                Debug.Log("Health:" + health);
                Debug.Log("Stress:" + acuteStress);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                state = Situation5;
                health = health - healthDecreaseRead;
                healthDecreaseRead = healthDecreaseRead + 5;

                acuteStress = acuteStress + 5;
                acuteStress = acuteStress - acutestressDecreaseRead;
                acutestressDecreaseRead = acutestressDecreaseRead - 2;

                Debug.Log("Health:" + health);
                Debug.Log("Stress:" + acuteStress);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                state = Situation5;
                health = health + healthIncreaseConsumable;
                healthIncreaseConsumable = healthIncreaseConsumable - 4;

                acuteStress = acuteStress + 5;
                acuteStress = acuteStress - acutestressDecreaseConsumable;
                acutestressDecreaseConsumable = acutestressDecreaseConsumable - 2;

                Debug.Log("Health:" + health);
                Debug.Log("Stress:" + acuteStress);
            }
        }
        else if (state == Situation5)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                state = Situation6;
                if (health <= 0)
                {
                    health = 0;
                }
                health = health - healthDecreaseGaming;
                healthDecreaseGaming = healthDecreaseGaming + 2;

                acuteStress = acuteStress + 5;
                acuteStress = acuteStress - acutestressDecreaseGaming;
                acutestressDecreaseGaming = acutestressDecreaseGaming - 2;
                Debug.Log("Health:" + health);
                Debug.Log("Stress:" + acuteStress);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                state = Situation6;
                health = health + healthIncreaseWorkOut;
                healthIncreaseWorkOut = healthIncreaseWorkOut - 5;

                acuteStress = acuteStress + 4;
                acuteStress = acuteStress - acutestressDecreaseWorkOut;
                acutestressDecreaseWorkOut = acutestressDecreaseWorkOut - 2;
                Debug.Log("Health:" + health);
                Debug.Log("Stress:" + acuteStress);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                state = Situation6;
                health = health - healthDecreaseRead;
                healthDecreaseRead = healthDecreaseRead + 5;

                acuteStress = acuteStress + 5;
                acuteStress = acuteStress - acutestressDecreaseRead;
                acutestressDecreaseRead = acutestressDecreaseRead - 2;

                Debug.Log("Health:" + health);
                Debug.Log("Stress:" + acuteStress);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                state = Situation6;
                health = health + healthIncreaseConsumable;
                healthIncreaseConsumable = healthIncreaseConsumable - 4;

                acuteStress = acuteStress + 5;
                acuteStress = acuteStress - acutestressDecreaseConsumable;
                acutestressDecreaseConsumable = acutestressDecreaseConsumable - 2;

                Debug.Log("Health:" + health);
                Debug.Log("Stress:" + acuteStress);
            }
        }
        else if (state == Situation6)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                state = Situation7;
                if (health <= 0)
                {
                    health = 0;
                }
                health = health - healthDecreaseGaming;
                healthDecreaseGaming = healthDecreaseGaming + 2;

                acuteStress = acuteStress + 5;
                acuteStress = acuteStress - acutestressDecreaseGaming;
                acutestressDecreaseGaming = acutestressDecreaseGaming - 2;
                Debug.Log("Health:" + health);
                Debug.Log("Stress:" + acuteStress);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                state = Situation7;
                health = health + healthIncreaseWorkOut;
                healthIncreaseWorkOut = healthIncreaseWorkOut - 5;

                acuteStress = acuteStress + 4;
                acuteStress = acuteStress - acutestressDecreaseWorkOut;
                acutestressDecreaseWorkOut = acutestressDecreaseWorkOut - 2;
                Debug.Log("Health:" + health);
                Debug.Log("Stress:" + acuteStress);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                state = Situation7;
                health = health - healthDecreaseRead;
                healthDecreaseRead = healthDecreaseRead + 5;

                acuteStress = acuteStress + 5;
                acuteStress = acuteStress - acutestressDecreaseRead;
                acutestressDecreaseRead = acutestressDecreaseRead - 2;

                Debug.Log("Health:" + health);
                Debug.Log("Stress:" + acuteStress);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                state = Situation7;
                health = health + healthIncreaseConsumable;
                healthIncreaseConsumable = healthIncreaseConsumable - 4;

                acuteStress = acuteStress + 5;
                acuteStress = acuteStress - acutestressDecreaseConsumable;
                acutestressDecreaseConsumable = acutestressDecreaseConsumable - 2;

                Debug.Log("Health:" + health);
                Debug.Log("Stress:" + acuteStress);
            }
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
        if (acuteStress <= 0)
        {
            SceneManager.LoadScene(3);
        }
    }
}
