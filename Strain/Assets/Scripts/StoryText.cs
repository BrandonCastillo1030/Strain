using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryText : MonoBehaviour
{
    public int health = 100;
    public int stress = 50;

    public Text textComponent;
    public State StartingState;

    State state;
    // Start is called before the first frame update
    void Start()
    {
        state = StartingState;
        textComponent.text = state.GetStateStory();
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
            stress = stress - 10;
            Debug.Log("Health:" + health);
            Debug.Log("Stress:" + stress);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            state = nextStates[1];
        }
        textComponent.text = state.GetStateStory();
    }
}
