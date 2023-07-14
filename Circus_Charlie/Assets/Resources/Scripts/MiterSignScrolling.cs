using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiterSignScrolling : MonoBehaviour
{
    private float speed = 3f;

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.isDead == false)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }
}
