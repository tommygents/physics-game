using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalControl : MonoBehaviour
{

    // public int framesInCircle = 0;
    // public int framesPerSecond = 60;
    
    //Time variables
    public float goalTime = .3f;
    public bool inBoat = false;
    [SerializeField] private float timeInBoat = 0;

    //Utility variables
    public GameManager gameManager;
    public bool debugGameManagerSet = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Boat"))
        {
            inBoat = true;
        }
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("Piston"))
        {

            Destroy(this.transform.parent.gameObject);
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


   // public void OnTriggerExit2D(Collider2D other)
    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Boat"))
        {
            inBoat = false;
            timeInBoat = 0;  
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
        this.gameManager.IncrementScore();
        ac.Play();
    }
}
