using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*****************************************************************
 * public class DestroyOnCollision
 * 
 * Purpose: Destroy the set tags on collision
 *****************************************************************/
public class DestroyOnCollision : MonoBehaviour
{
    [SerializeField] private List<string> _tagsToDestory;   //List of tags to destroy on contact

    //Destroy objects found in the list of tags to destroy
    void OnCollisionEnter2D(Collision2D other)
    {
        foreach (string tag in _tagsToDestory)
        {
            if (other.gameObject.CompareTag(tag))
            {
                Destroy(other.gameObject);
            }
        }
    }
}
