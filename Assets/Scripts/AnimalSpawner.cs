using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour

    
{
    //the animal prefabs
    public GameObject[] animalPrefabs;



    // Start is called before the first frame update
    void Start()
    {
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
        animal.transform.localScale= new Vector3(.2f, .2f, .2f);
        animal.transform.position = this.gameObject.transform.position;

    }

    //Step one is to create a spawner that spawns animals at random intervals. Then I can think about object pooling.
    //the goal for this script is to use object-pooling to manage the animals that are getting spawned into the game.
    //that means I need to create a certain number of the animals, instantiate them, and 


    public class Animal
    {
        public string name;
        public enum Type
        {

        }
        public Type type;

        public Animal(Type type)
        {
            this.type = type;
        }
    }


}
