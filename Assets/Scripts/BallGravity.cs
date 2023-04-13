using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallGravity : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public Vector3 movement = new Vector3(0.0f, 1.0f, 0.0f);
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        Vector3 seed = this.transform.position;
        if (seed.y >= 0.9f || seed.y <= -1.7f)
        {
            SceneManager.LoadScene("GameOver");
            Time.timeScale = 1f;
        }
        rb.AddForce(movement * speed);
    }
}