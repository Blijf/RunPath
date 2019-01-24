using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTrapActivation : MonoBehaviour
{
    public List<GameObject> tiles;
    public int timeNextSpawn;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            for (int i = 0; i < tiles.Count; i++)
            {
                tiles[i].SetActive(true);
                StartCoroutine(wait());
            }
        }
    }

//Se espera un tiempo al spawn del siguiente elemento de la lista
    IEnumerator wait()
    {
        yield return new WaitForSeconds(timeNextSpawn);
    }
}