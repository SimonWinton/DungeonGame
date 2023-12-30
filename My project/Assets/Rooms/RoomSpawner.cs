using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    // 1 --> need bottom door
    // 2 --> need top door
    // 3 --> need left door
    // 4 --> need right door

    private RoomTemplates templates;
    private int rand;
    public bool spawned = false;

    // Start is called before the first frame update
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.3f);
    }

    void Spawn()
    {
        if (spawned == false)
        {
            spawned = true;
            if (openingDirection == 1)
            {
                // Need to spawn a room with a BOTTOM door
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                // Need to spawn a room with a TOP door.
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                // Need to spawn a room with a LEFT door.
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                // Need to spawn a room with a RIGHT door.
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }
        }

    }

    //Upon collision with another GameObject
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("SpawnPoint"))
        {
            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                print("spawning Corner" + other.GetComponent<RoomSpawner>().openingDirection + "," + openingDirection);
                if ((other.GetComponent<RoomSpawner>().openingDirection == 1 && openingDirection == 2) || (other.GetComponent<RoomSpawner>().openingDirection == 2 && openingDirection == 1))
                {
                    print("spawning Vertical Line");
                    Instantiate(templates.verLineRoom, transform.position, templates.verLineRoom.transform.rotation);
                }

                if ((other.GetComponent<RoomSpawner>().openingDirection == 3 && openingDirection == 4) || (other.GetComponent<RoomSpawner>().openingDirection == 4 && openingDirection == 3))
                {
                    Instantiate(templates.horLineRoom, transform.position, templates.horLineRoom.transform.rotation);
                    print("spawning Hor Line");
                }

                if ((other.GetComponent<RoomSpawner>().openingDirection == 1 && openingDirection == 3) || (other.GetComponent<RoomSpawner>().openingDirection == 3 && openingDirection == 1))
                {
                    Instantiate(templates.topLeftRoom, transform.position, templates.topLeftRoom.transform.rotation);
                    print("spawning top left");
                }

                if ((other.GetComponent<RoomSpawner>().openingDirection == 1 && openingDirection == 4) || (other.GetComponent<RoomSpawner>().openingDirection == 4 && openingDirection == 1))
                {
                    Instantiate(templates.topRightRoom, transform.position, templates.topRightRoom.transform.rotation);
                    print("spawning top right");
                }

                if ((other.GetComponent<RoomSpawner>().openingDirection == 2 && openingDirection == 4) || (other.GetComponent<RoomSpawner>().openingDirection == 4 && openingDirection == 2))
                {
                    Instantiate(templates.bottomRightRoom, transform.position, templates.bottomRightRoom.transform.rotation);
                    print("spawning bottom right");
                }

                if ((other.GetComponent<RoomSpawner>().openingDirection == 2 && openingDirection == 3) || (other.GetComponent<RoomSpawner>().openingDirection == 3 && openingDirection == 2))
                {
                    Instantiate(templates.bottomLeftRoom, transform.position, templates.bottomLeftRoom.transform.rotation);
                    print("spawning bottom left");
                }

                
            }
            Destroy(other.gameObject);

        }
        spawned = true;
        Destroy(gameObject);
        
    }





        //            if (other.CompareTag("SpawnPoint") && other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
        //{
        //    spawned = true;
        //    if (other.GetComponent<RoomSpawner>().openingDirection == 1 && openingDirection == 2)
        //    {
        //        print("spawning Vertical Line");
        //        Instantiate(templates.verLineRoom, transform.position, templates.verLineRoom.transform.rotation);
        //    }

        //    if (other.GetComponent<RoomSpawner>().openingDirection == 1 && openingDirection == 3)
        //    {
        //        Instantiate(templates.topLeftRoom, transform.position, templates.topLeftRoom.transform.rotation);
        //        print("spawning top left");
        //    }
        //        print("Other spawn point");
            //if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            //{
            //    spawned = true;
            //    other.GetComponent<RoomSpawner>().spawned = true;
            //    Instantiate(templates.topRightRoom, transform.position, templates.topRightRoom.transform.rotation);
            //}
        //}
        //        spawned = true;
        //if ((other.GetComponent<RoomSpawner>().openingDirection == 1 && openingDirection == 2) || (other.GetComponent<RoomSpawner>().openingDirection == 2 && openingDirection == 1))
        //{
        //    print("spawning Vertical Line");
        //    Instantiate(templates.verLineRoom, transform.position, templates.verLineRoom.transform.rotation);
        //}
        //else if ((other.GetComponent<RoomSpawner>().openingDirection == 3 && openingDirection == 4) || (other.GetComponent<RoomSpawner>().openingDirection == 4 && openingDirection == 3))
        //{
        //    Instantiate(templates.horLineRoom, transform.position, templates.horLineRoom.transform.rotation);
        //    print("spawning Hor Line");
        //}
        //else if ((other.GetComponent<RoomSpawner>().openingDirection == 1 && openingDirection == 3) || (other.GetComponent<RoomSpawner>().openingDirection == 3 && openingDirection == 1))
        //{
        //    Instantiate(templates.topLeftRoom, transform.position, templates.topLeftRoom.transform.rotation);
        //    print("spawning top left");
        //}
        //else if ((other.GetComponent<RoomSpawner>().openingDirection == 1 && openingDirection == 4) || (other.GetComponent<RoomSpawner>().openingDirection == 4 && openingDirection == 1))
        //{
        //    Instantiate(templates.topRightRoom, transform.position, templates.topRightRoom.transform.rotation);
        //    print("spawning top right");
        //}
        //else if ((other.GetComponent<RoomSpawner>().openingDirection == 2 && openingDirection == 4) || (other.GetComponent<RoomSpawner>().openingDirection == 4 && openingDirection == 2))
        //{
        //    Instantiate(templates.bottomRightRoom, transform.position, templates.bottomRightRoom.transform.rotation);
        //    print("spawning bottom right");
        //}
        //else if ((other.GetComponent<RoomSpawner>().openingDirection == 2 && openingDirection == 3) || (other.GetComponent<RoomSpawner>().openingDirection == 3 && openingDirection == 2))
        //{
        //    Instantiate(templates.bottomLeftRoom, transform.position, templates.bottomLeftRoom.transform.rotation);
        //    print("spawning bottom left");
        //}
        //print(other.GetComponent<RoomSpawner>().openingDirection);
        //print(openingDirection);
        // print("Equal" + openingDirection == other.GetComponent<RoomSpawner>().openingDirection);
        //Destroy(gameObject);
        //    }

        //}
        //Destroy(gameObject);
    //}

    //void OnCollisionEnter(Collision collision)
    //{
    //    print("OnCollisionEnter");
    //    Destroy(gameObject);
    //}
}