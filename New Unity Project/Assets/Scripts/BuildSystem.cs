using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : MonoBehaviour
{

    public Transform cam;

    public Transform floor;
    public Transform wall;
    public Transform ramp;

    public Transform floorPrefab;
    public Transform wallPrefab;
    public Transform rampPrefab;

    private RaycastHit hit;

    private int buildIndex = 1;

    void Start()
    {
        
    }

    void Update()
    {
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
            buildIndex += 1;
		}

        if (buildIndex == 3)
		{
            buildIndex = 1;
		}
        
        if (Physics.Raycast(cam.position, cam.forward, out hit, 6f))
		{
            if (buildIndex == 1)
            {
                floor.position = new Vector3(Mathf.RoundToInt(hit.point.x) != 0 ? Mathf.RoundToInt(hit.point.x / 3) * 3 : 3,
                Mathf.RoundToInt(hit.point.y) != 0 ? Mathf.RoundToInt(hit.point.y / 3) * 3 : 0 + floor.localScale.y,
                Mathf.RoundToInt(hit.point.z) != 0 ? Mathf.RoundToInt(hit.point.z / 3) * 3 : 3);

                if (Input.GetMouseButtonDown(0))
                {
                    Instantiate(floorPrefab, floor.position, floor.rotation);
                }
            }
            if (buildIndex == 2)
            {
                ramp.position = new Vector3(Mathf.RoundToInt(hit.point.x) != 0 ? Mathf.RoundToInt(hit.point.x / 3) * 3 : 3,
                0.9f, Mathf.RoundToInt(hit.point.z) != 0 ? Mathf.RoundToInt(hit.point.z / 3) * 3 : 3);

                ramp.eulerAngles = new Vector3(35, Mathf.RoundToInt(transform.eulerAngles.y) != 0 ? Mathf.RoundToInt(transform.eulerAngles.y / 90.0f) * 90.0f: 0, 0);
                transform.rotation.y *= -1.0f;

                if (Input.GetMouseButtonDown(0))
                {
                    Instantiate(rampPrefab, ramp.position, ramp.rotation);
                }
            }

        }

        if (buildIndex == 1)
        {
            floor.gameObject.SetActive(true);
            ramp.gameObject.SetActive(false);
        }
        if (buildIndex == 2)
        {
            floor.gameObject.SetActive(false);
            ramp.gameObject.SetActive(true);
        }
    }
}
