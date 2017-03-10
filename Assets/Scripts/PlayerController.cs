using UnityEngine;
using System.Collections;

public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}
public class PlayerController : MonoBehaviour {

    //Public fields
    public float speed;

    //Private fields
    private Rigidbody2D rb;

	// Use this for initialization (Runs ONCE, when object is created)
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {

    }
    // Update is called once per frame (USED FOR PHYSICS)
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb.velocity = movement * speed;

        rb.position = new Vector2(Mathf.Clamp(rb.position.x, -10.00f, 10.00f), Mathf.Clamp(rb.position.y, -4f, 4f));
    }
}
