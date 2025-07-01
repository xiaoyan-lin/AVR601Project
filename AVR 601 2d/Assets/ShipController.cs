using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed, turnSpeed, boundaryWidth, boundaryLength;

    Vector2 input;
    Vector2 topRight, topLeft, bottomRight, bottomLeft;
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        topRight = new Vector2(boundaryLength/2f, boundaryWidth/2f);
        topLeft = new Vector2(-boundaryLength/2f, boundaryWidth/2f);
        bottomRight = new Vector2(boundaryLength/2f, -boundaryWidth/2f);
        bottomLeft = new Vector2(-boundaryLength/2f, -boundaryWidth/2f);

        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        transform.Translate(Vector2.up * input.y * moveSpeed * Time.deltaTime);

        transform.Rotate(new Vector3(0f,0f, -input.x * turnSpeed * Time.deltaTime));


        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -boundaryLength/2f, boundaryLength/2f),Mathf.Clamp(transform.position.y, -boundaryWidth/2f, boundaryWidth/2f));
        /*

        if (transform.position.x > boundaryLength/2f)
            transform.position = new Vector2 (boundaryLength/2f, transform.position.y);
        if (transform.position.x < -boundaryLength/2f)
            transform.position = new Vector2 (-boundaryLength/2f,transform.position.y);
        if (transform.position.y > boundaryWidth/2f)
            transform.position = new Vector2 (transform.position.x,boundaryWidth/2f);
        if (transform.position.y < -boundaryWidth/2f)
            transform.position = new Vector2 (transform.position.x,-boundaryWidth/2f);
*/
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
        Gizmos.DrawLine(topRight,topLeft);
        Gizmos.DrawLine(bottomRight,bottomLeft);
        Gizmos.DrawLine(topRight,bottomRight);
        Gizmos.DrawLine(bottomLeft,topLeft);
    }
}
