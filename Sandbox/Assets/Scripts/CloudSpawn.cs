using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Local screen size: y: -10 to 10
//x : from -5 to 5

struct Cube
{

}
struct Sphere
{

}
struct Cloud
{
    //1 cube and 3 spheres
    Cube cloud_block;
    //Sphere[] cloud_circles = new Sphere[3]();
}

public class CloudSpawn : MonoBehaviour
{

    public GameObject demo_cloud;

    GameObject oldCloud;
    Vector3 initialPosition;
    //List<GameObject> cloud_list;
    Queue<GameObject> cloud_queue;
    bool test;
    float y_offset = 0;
	// Use this for initialization
	void Start ()
    {
		if(demo_cloud != null)
        {
            Debug.Log("demo cloud x: " + demo_cloud.transform.position.x);
            initialPosition = demo_cloud.transform.position;
            test = false;
        }
        oldCloud = demo_cloud;
        if (cloud_queue == null)
        {
            cloud_queue = new Queue<GameObject>();
            cloud_queue.Enqueue(oldCloud);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log("initial cloud transform position. " + initialPosition);


        //demo_cloud.CompareTag()
        if (oldCloud != null)
        {
            if (oldCloud.transform.position.x > -2.5f)
            {
                SpawnCloud();
            }
        }
            foreach (GameObject a_cloud in cloud_queue)
            {
                if (a_cloud.transform.position.x > 8.0f)
                {
                    //TODO: Remove clouds that are beyond the right side of the screen.
                    //RemoveCloud();

                    
                   oldCloud = cloud_queue.Dequeue();
                   Destroy(a_cloud);
                //cloud_list.Remove(a_cloud);
                }
            }
        
	}

    void SpawnCloud()
    {
        y_offset = Random.Range(-5.0f, 5.0f);
        initialPosition.y = y_offset;
        //Spawn another cloud identical to the demo one
        oldCloud = Instantiate(demo_cloud, initialPosition, Quaternion.identity);
        cloud_queue.Enqueue(oldCloud);
        Debug.Log("Spawned clone!");
    }

    void RemoveCloud()
    {
        Debug.Log("Remove cloud.");
        cloud_queue.Dequeue();
    }
   // MeshFilter Spheremesh = new MeshFilter();
    
    //Mesh Spawn()
    //{
    //    Mesh mesh = new Mesh();
    //    Sphere
    //}
}
