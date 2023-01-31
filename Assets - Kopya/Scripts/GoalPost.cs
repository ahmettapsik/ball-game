using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPost : MonoBehaviour
{
    public bool isGoalPostOfPlayerOne;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("MainBall"))
            GameManager.instance.Goal(!isGoalPostOfPlayerOne);
    }
}
