using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    private List<GameObject> cubes;
    private GameObject currentCube;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        cubes = GameObject.FindGameObjectsWithTag("ColorCube").ToList();
        currentCube = cubes[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(currentCube != null && currentCube.transform.position.y < 0)
        {
            currentCube.transform.SetParent(gameObject.transform);
      
            currentCube.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1, gameObject.transform.position.z + 3);
        }

        if(Input.GetMouseButtonDown(0))
        {
            if(currentCube != null)
            {
                currentCube.AddComponent<Rigidbody>();
                currentCube.GetComponent<Rigidbody>().mass = 1000;
                currentCube.transform.parent = null;
                cubes.Remove(currentCube);
                if(cubes.Count > 0)
                {
                    currentCube = cubes[0];
                }
                
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (cubes.Count > 1)
            {
                if(cubes.IndexOf(currentCube) == cubes.Count-1) 
                {
                    currentCube.transform.position = new Vector3(5, -6, 5);
                    currentCube = cubes[0];
                }
                else
                {
                    currentCube.transform.position = new Vector3(5, -6, 5);
                    currentCube = cubes[cubes.IndexOf(currentCube)+1];
                }
            }
        }
        if(Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * 5, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Rotate(new Vector3(0, -.5f, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Rotate(new Vector3(0, .5f, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.back * 5, ForceMode.Force);
        }
    }
}
