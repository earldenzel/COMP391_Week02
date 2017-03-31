using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion_asteroid;
    public GameObject explosion_player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Boundary")
        {
            return;
        }
        if (other.tag == "Player")
        {
            Instantiate(explosion_player, other.transform.position, other.transform.rotation); //spawn playersplosion
        }

        Instantiate(explosion_asteroid, this.transform.position, this.transform.rotation); // spawn explosion at this asteroid

        Destroy(other.gameObject); //destroy laser
        Destroy(this.gameObject); //destroy asteroid
    }
}
