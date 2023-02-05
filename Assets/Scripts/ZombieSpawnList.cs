using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnList : MonoBehaviour
{

    public GameObject Zombie;
    public int MaxZombieNumb;

    public int currentZombieCounter = 0;

    public SpawnPlaces[] spawnPlaces;
    public GameObject[] activationPlaces;

    public void Awake()
    {
        
    }

    public void SpawnZombies(int currentSpawnPlace)
    {
        for (int i = currentZombieCounter; i < MaxZombieNumb; i++)
        {
            var zomb = Instantiate(Zombie, spawnPlaces[currentSpawnPlace].GetRandomTransformPlace(), Quaternion.identity);

            zomb.gameObject.SetActive(true);
            currentZombieCounter++;
        }
    }

    public void ActivateZombieList(int place)
    {
        activationPlaces[place].SetActive(true);
    }

    public void DeactivateZombieList(int place)
    {
        activationPlaces[place].SetActive(false);
    }

}



[Serializable]
public class SpawnPlaces
{
    public Transform[] transformPlaces;
  

    public Vector3 GetRandomTransformPlace()
    {
        var randomPos = UnityEngine.Random.insideUnitCircle * 5f;
        return transformPlaces[UnityEngine.Random.Range(0, transformPlaces.Length)].position + new Vector3(randomPos.x, 0, randomPos.y);
    }
}
