using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;

    public int openingDirection;
    //1 --> need bot door
    //2 --> need top door
    //3 --> need left door
    //4 --> need right door

    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    private void Spawn()
    {
        if (!spawned)
        {
            if (openingDirection == 1)
            {
                //Need to spawn a room with a BOT door
                rand = Random.Range(0, templates.botRooms.Length);
                Instantiate(templates.botRooms[rand], transform.position, templates.botRooms[rand].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                //Need to spawn a room with a TOP door
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                //Need to spawn a room with a LEFT door
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                //Need to spawn a room with a RIGHT door
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }
            spawned = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            if (!other.GetComponent<RoomSpawner>().spawned && !spawned)
            {
                templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
            }
            spawned = true;
        }
    }
}
