using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalControl : MonoBehaviour
{

    // public int framesInCircle = 0;
    // public int framesPerSecond = 60;
    
    //Time variables
    public float goalTime = .3f;
    public AudioSource ac;
    [SerializeField] private float timeInBoat = 0;

    //Utility variables to talk to other programs
    public GameManager gameManager;
    public bool debugGameManagerSet = false;

    // Timer for when to delete animal and add score; flag to check if animal is in boat
    private float scoreTimer;
    private bool inBoat;


    // position variables to check to make sure we're within the tub
    public float tubXBound = 9.5f;
    public Transform locationTransform;

    private void Start() {
        scoreTimer = 0.5f;
        inBoat = false;
        ac = GetComponent<AudioSource>();
    }

    private void Update() {
        //first check to see if the animal has been in the boat long enough to score
        if (inBoat)
        {
            scoreTimer -= Time.deltaTime;
            if (scoreTimer <= 0f)
            {


                Debug.Log("Audio Played because animal scored");
                this.gameManager.IncrementScore();
                scoreTimer = 0.5f;
                inBoat = false;
                ac.Play();

                DestroyThisAnimal(ac.clip.length);

            }
        }
            // then see if the animal is out of bounds
            if (transform.position.x < -tubXBound || transform.position.x > tubXBound || transform.position.y < -100)
            {
                Debug.Log("Out of Bounds");
                DestroyThisAnimal();
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

            DestroyThisAnimal();
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

 

    public void DestroyThisAnimal()
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

    public void DestroyThisAnimal(float f)
    {

        if (transform.parent.gameObject != null)
        {
            Destroy(this.transform.parent.gameObject, f);

        }
        else
        {
            Destroy(this.gameObject, f);
        }
    }

    public void OnDestroy()
    {
        //AudioSource ac = GetComponent<AudioSource>();
        //this.gameManager.IncrementScore();
        //ac.Play();
        gameManager.numAnimals--;
    }
}
