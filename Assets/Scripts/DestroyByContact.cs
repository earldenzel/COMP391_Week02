using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion_asteroid;
    public GameObject explosion_player;
    public int scoreValue = 10;


    private GameController gameController; //the other script!
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController"); //references the whole object
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if(gameController == null)
        {
            Debug.Log("No script found");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Boundary")
        {
            return;
        }
        if (other.tag == "Player")
        {
            Instantiate(explosion_player, other.transform.position, other.transform.rotation); //spawn playersplosion
            gameController.AddScore(-scoreValue);
            gameController.GameOver();
        }

        Instantiate(explosion_asteroid, this.transform.position, this.transform.rotation); // spawn explosion at this asteroid

        gameController.AddScore(scoreValue);
        Destroy(other.gameObject); //destroy laser
        Destroy(this.gameObject); //destroy asteroid
    }
}
