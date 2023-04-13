using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 


public class MouseClick : MonoBehaviour
{
    public GameObject obj;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            BallGravity ball = obj.GetComponent<BallGravity>();
            //Debug.Log(ball.movement.y);
            ball.movement.y = -ball.movement.y;
        }
    }
}