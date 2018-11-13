using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Local screen size: y: -10 to 10
//x : from -5 to 5



public class CloudSpawn : MonoBehaviour
{

    public GameObject demo_cloud;
    public float spawnBarrier;
    public float destroyBarrier;
    public int numberOfShapes;

    GameObject newCloud;
    GameObject deadCloud;
    Vector3 initialPosition;
    //List<GameObject> cloud_list;
    Queue<GameObject> cloud_queue;
    
   
    float y_offset = 0;
	// Use this for initialization
	void Start ()
    {
        //Debug.Log("Start called.\n");
		if(demo_cloud != null)
        {
            //Debug.Log("demo cloud x: " + demo_cloud.transform.position.x);
            initialPosition = demo_cloud.transform.position;           
        }
        newCloud = demo_cloud;
        if (cloud_queue == null)
        {
            //Debug.Log("cloud queue null\n");
            cloud_queue = new Queue<GameObject>();
            cloud_queue.Enqueue(newCloud);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log("initial cloud transform position. " + initialPosition);


        //IV) If the newest cloud's x position is beyond the spawn barrier, spawn new cloud.
        if (newCloud != null)
        {
            if (newCloud.transform.position.x > spawnBarrier)
            {
                SpawnCloud();
            }
        }

        //V) If the first cloud in the queue (the oldest one available) is beyond the destroy barrier, dequeue and destroy that cloud.
        if(cloud_queue.Peek().transform.position.x > destroyBarrier)
        {
            RemoveCloud();
        }
        
	}

    void SpawnCloud()
    {
        y_offset = Random.Range(-5.0f, 5.0f);
        

        initialPosition.y = y_offset;
        //Spawn another cloud identical to the demo one
        newCloud = Instantiate(newCloud, initialPosition, Quaternion.identity);
        newCloud.name = (newCloud.GetInstanceID()).ToString();
    
        Debug.Log("SpawnCloud");
        //Try to change a 3D object's Scale when it is not a child of another gameobject.
        GameObject[] testSphere = GameObject.FindGameObjectsWithTag("CloudShape");
        if (testSphere == null)
        {
            Debug.Log("no game objects with the tag 'CloudShape' were found.");
        }
        else
        {
            if (testSphere.Length > numberOfShapes)
            {
                //for the last three elements:
                for (int increment = 1; increment <= numberOfShapes; increment++)
                {
                    GameObject gameO = testSphere[testSphere.Length - increment];
                    if (gameO.GetComponent<ChangeTransform>() != null)
                    {
                        Debug.Log("Change Scale.");
                        float xScale = Random.Range(1.0f, 5.0f);
                        float yScale = Random.Range(1.0f, 2.0f);
                        float zScale = Random.Range(1.0f, 2.0f);

                        //Debug.Log("ChangeTransform component found. Proceed with changing gameobject scale");
                        ChangeTransform t = gameO.GetComponent<ChangeTransform>();
                        t.ChangeScale(new Vector3(xScale, yScale, zScale));
                    }
                
                }
            }

        }

        cloud_queue.Enqueue(newCloud);
        //Debug.Log("Spawned clone!");
    }

    void RemoveCloud()
    {
        //Debug.Log("Remove cloud.");
        deadCloud = cloud_queue.Dequeue();
        Destroy(deadCloud);        
    }
 
}
