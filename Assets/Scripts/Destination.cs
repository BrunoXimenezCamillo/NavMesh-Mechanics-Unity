using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    GameObject player;
    [SerializeField] GameObject model;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    IEnumerator Routine(Vector3 position)
    {
        transform.position = position;
        model.SetActive(true);
        float distance() => Vector3.Distance(transform.position, player.transform.position);
        yield return new WaitWhile(() => distance() > 1);
        model.SetActive(false);
    }

    public void Appear(Vector3 position)
    {
        StartCoroutine(Routine(position));
    }
}
