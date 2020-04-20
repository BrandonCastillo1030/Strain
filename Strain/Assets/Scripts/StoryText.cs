using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StoryText : MonoBehaviour
{
    public int health = 100;
    public int stress = 50;

    int stressDecreaseGaming;
    int stressDecreaseWorkOut;
    int stressDecreaseRead;
    int stressDecreaseConsumable;


    public Text textComponent;
    public State StartingState;

    State state;
    // Start is called before the first frame update
    public void Start()
    {
        state = StartingState;
        textComponent.text = state.GetStateStory();
        stressDecreaseGaming = UnityEngine.Random.Range(2, 20);
        stressDecreaseWorkOut = UnityEngine.Random.Range(2, 20);
        stressDecreaseRead = UnityEngine.Random.Range(2, 20);
        stressDecreaseConsumable = UnityEngine.Random.Range(2, 20);
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        var nextStates = state.GetNextStates();
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            state = nextStates[0];
            health = health + 10;
            stress = stress - stressDecreaseGaming;
            Debug.Log("Health:" + health);
            Debug.Log("Stress:" + stress);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            state = nextStates[0];
            health = health + 15;
            stress = stress - stressDecreaseWorkOut;
            Debug.Log("Health:" + health);
            Debug.Log("Stress:" + stress);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            state = nextStates[0];
            health = health + 15;
            stress = stress - stressDecreaseRead;
            Debug.Log("Health:" + health);
            Debug.Log("Stress:" + stress);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            state = nextStates[0];
            health = health + 15;
            stress = stress - stressDecreaseConsumable;
            Debug.Log("Health:" + health);
            Debug.Log("Stress:" + stress);
        }
        textComponent.text = state.GetStateStory();
    }
}
