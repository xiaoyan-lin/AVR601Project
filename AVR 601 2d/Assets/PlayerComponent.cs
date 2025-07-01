using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponent : MonoBehaviour
{

    
    public float speed, jumpSpeed;

   Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxisRaw("Horizontal");
        
        if (Mathf.Abs(input)<0.5f)
            input = 0f;

        transform.Translate(Vector2.right * input * speed * Time.deltaTime);
        Debug.Log("Horizontal Input: " + input);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }



    }
}
