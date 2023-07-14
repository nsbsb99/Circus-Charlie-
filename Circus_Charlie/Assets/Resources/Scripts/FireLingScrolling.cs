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
    public void Update()
    {
        if (PlayerController.isDead == false && GameManager.clickRight == false)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if (PlayerController.isDead == false && GameManager.clickRight == true)
        {
            transform.Translate(Vector2.right * (speed / 2) * Time.deltaTime);
        }
    }
}
