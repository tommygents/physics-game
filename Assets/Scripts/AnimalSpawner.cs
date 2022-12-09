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
    public float delayTime = .5f;
    public bool animalsSpawning = true;
    
    public int numAnimalsMax = 3;



    //debugging variables
    


    // Start is called before the first frame update
    private void Start()
    {
        thisLayer = this.gameObject.layer;
        //InvokeRepeating("spawnAnimalInvoke", 5, 1);
        Invoke(nameof(StartSpawn), 5f);
    }

   public void StartSpawn()
    {
        StartCoroutine(Spawn());
        Debug.Log("Co-routine started");
    }
    public IEnumerator Spawn()
    {
        Debug.Log("Co-routine looped");
        while (animalsSpawning)
        {
            spawnAnimalCoRoutine();
            yield return new WaitForSeconds(delayTime);
            yield return new WaitUntil(() => gameManager.numAnimals < numAnimalsMax);
        }

        //yield return null;

    }

    public void spawnAnimalCoRoutine()
    {
        GameObject go = animalPrefabs[Random.Range(0, animalPrefabs.Length)];
        GameObject animal = Instantiate(go);
        SetGameLayerRecursive(animal, thisLayer);
        animal.transform.localScale = new Vector3(.5f, .5f, .5f);
        animal.transform.position = this.gameObject.transform.position + new Vector3(Random.Range(-tubSize / 2, tubSize / 2), 0, 0);
        //AnimalControl ac = animal.GetComponent<AnimalControl>();
        //ac.SetGameManager(gameManager);
        SetGameManagerRecursive(animal, gameManager);
        gameManager.numAnimals++;



    }

    //spawns an animal in a repeatable way
    public void spawnAnimalInvoke()
    {
        GameObject go = animalPrefabs[Random.Range(0, animalPrefabs.Length)];
        GameObject animal = Instantiate(go);
        SetGameLayerRecursive(animal, thisLayer);
        animal.transform.localScale = new Vector3(.5f, .5f, .5f);
        animal.transform.position = this.gameObject.transform.position + new Vector3(Random.Range(-tubSize/2, tubSize/2),0,0);
        //AnimalControl ac = animal.GetComponent<AnimalControl>();
        //ac.SetGameManager(gameManager);
        SetGameManagerRecursive(animal, gameManager);
        gameManager.numAnimals++;
        //SetAudioClip(animal);


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
            ac.goalTime = goalTime;

        }
    }

    private void SetAudioClip(GameObject _go)
    {
        GameObject _cgo = _go.GetComponentInChildren<Transform>().gameObject;
        AnimalControl _ac = _cgo.GetComponent<AnimalControl>();
        AudioSource _as = _cgo.GetComponent<AudioSource>();
        _ac.ac = _as;

        
    }

    





}
