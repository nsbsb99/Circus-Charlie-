using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLingScrolling : MonoBehaviour
{
    private float speed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameOver == false)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }
}
