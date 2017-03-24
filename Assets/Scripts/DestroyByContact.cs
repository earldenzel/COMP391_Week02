using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Boundary")
        {
            return;
        }
        Destroy(other.gameObject); //destroy laser
        Destroy(this.gameObject); //destroy asteroid
    }
}
