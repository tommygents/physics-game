using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalControl : MonoBehaviour
{

    // public int framesInCircle = 0;
    // public int framesPerSecond = 60;
    
    //Time variables
    public float goalTime = .3f;
    [SerializeField] private float timeInBoat = 0;

    //Utility variables
    public GameManager gameManager;
    public bool debugGameManagerSet = false;

    // Timer for when to delete animal and add score; flag to check if animal is in boat
    private float scoreTimer;
    private bool inBoat;

    private void Start() {
        scoreTimer = 0.5f;
        inBoat = false;
    }

    private void Update() {
        if (inBoat) {
            scoreTimer -= Time.deltaTime;
            if (scoreTimer <= 0f) {
                DestroyAnimal();
                this.gameManager.IncrementScore();
                scoreTimer = 0.5f;
                inBoat = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Boat"))
        {
            inBoat = true;
        }
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("Piston"))
        {

            DestroyAnimal();
        }
    }


   /* public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Boat"))
        {
            inBoat = true;
        }
    } */
    
    //Acts as a timer to score and delete animals who are in the boat
    //public void OnTriggerStay2D(Collider2D other)
    /*
    public void OnCollisionStay2D(Collision2D other)   
    {
        
        if (other.gameObject.CompareTag("Boat"))
        {
            timeInBoat += Time.deltaTime;
            if (timeInBoat >= goalTime)
            {
                Destroy(transform.parent.gameObject);
                Destroy(gameObject);
            }
        }

    }
    */


   // public void OnTriggerExit2D(Collider2D other)
    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Boat"))
        {
            inBoat = false;
            scoreTimer = 0.5f;
            //timeInBoat = 0;  
        }
        
    }

  

    public void SetGameManager(GameManager gm)
    {
        this.gameManager = gm;
        debugGameManagerSet = true;
    }


    public void DestroyAnimal()
    {
        if (transform.parent.gameObject != null)
        {
            Destroy(this.transform.parent.gameObject);

        }
        else
        {
            Destroy(this.gameObject); 
        }
    }

    public void OnDestroy()
    {
        AudioSource ac = GetComponent<AudioSource>();
        //this.gameManager.IncrementScore();
        ac.Play();
    }
}
