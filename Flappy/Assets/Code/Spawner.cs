using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*********************************************************************************
 * public class Spawner
 * 
 * Function: Easily spawn objects common among multiple scripts
 *********************************************************************************/
public class Spawner : MonoBehaviour
{
    public static Spawner i; //Static reference

    public GameObject[] prefabs; //List of all prefabs that may be instantiated

    void Awake()
    {
        i = this;
    }

    public void SpawnObject(Prefab obj)
    {
        SpawnObject((int) obj);
    }

    public void SpawnObject(int index)
    {
        SpawnObject(index, Vector3.zero);
    }

    //Instantiate an object at the specified location and add it to the list of active objects
    public void SpawnObject(int index, Vector3 location)
    {
        Instantiate(prefabs[index], location, Quaternion.identity);
    }

    //Convert enum to index and call SPawnObject
    public void SpawnObject(Prefab obj, Vector3 location)
    {
        SpawnObject((int) obj, location);
    }

    public void SpawnObjectWithRotation(Prefab obj, Vector3 location, Vector3 rotation)
    {
        SpawnObjectWithRotation((int)obj, location, rotation);
    }

    public void SpawnObjectWithRotation(int index, Vector3 location, Vector3 rotation)
    {
        GameObject spawned = Instantiate(prefabs[index], location, Quaternion.identity) as GameObject;
        spawned.transform.Rotate(rotation);
    }
}

//Enum to easily convert prefab names to the appropriate index
public enum Prefab
{
    PauseMenu = 0,
    GameOverMenu = 1
};