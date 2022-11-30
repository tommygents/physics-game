using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour

    
{
    
    public GameObject[] animalPrefabs;
    public float tubSize = 10f;
    public float animalScale = .5f;
    private int thisLayer;
    public GameManager gameManager;
    public float goalTime = .3f;



    //debugging variables
    


    // Start is called before the first frame update
    void Start()
    {
        thisLayer = this.gameObject.layer;  
        InvokeRepeating("spawnAnimalInvoke", 5, 1);
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    //spawns an animal
    public void spawnAnimal(GameObject animalgo)
    {
        GameObject animal = Instantiate(animalgo);

    }

    //spawns an animal in a repeatable way
    public void spawnAnimalInvoke()
    {
        GameObject go = animalPrefabs[Random.Range(0, animalPrefabs.Length)];
        GameObject animal = Instantiate(go);
        SetGameLayerRecursive(animal, thisLayer);
        animal.transform.localScale = new Vector3(.2f, .2f, .2f);
        animal.transform.position = this.gameObject.transform.position + new Vector3(Random.Range(-tubSize/2, tubSize/2),0,0);
        AnimalControl ac = animal.GetComponent<AnimalControl>();
        //ac.SetGameManager(gameManager);
        SetGameManagerRecursive(animal, gameManager);
        ac.goalTime = goalTime;


    }

    //updates the layer on each animal
    private void SetGameLayerRecursive(GameObject _go, int _layer)
    {
        _go.layer = _layer;
        foreach (Transform child in _go.transform)
        {
            child.gameObject.layer = _layer;

            Transform _HasChildren = child.GetComponentInChildren<Transform>();
            if (_HasChildren != null)
                SetGameLayerRecursive(child.gameObject, _layer);

        }
    }

    private void SetGameManagerRecursive(GameObject _go, GameManager _gm)
    {
        AnimalControl[] _ac = _go.GetComponentsInChildren<AnimalControl>();
        foreach (AnimalControl ac in _ac)
        {
            ac.SetGameManager(_gm);

        }
    }


    //Step one is to create a spawner that spawns animals at random intervals. Then I can think about object pooling.
    //the goal for this script is to use object-pooling to manage the animals that are getting spawned into the game.
    //that means I need to create a certain number of the animals, instantiate them, and 





}
