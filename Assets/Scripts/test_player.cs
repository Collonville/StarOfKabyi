using UnityEngine;
using System.Collections;

public class test_player : MonoBehaviour
{
    public GameObject area;
    void Start()
    {
        var myPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        var rotation = new Vector3(0,0,0);
        var myArea=(GameObject)Instantiate(area,myPosition,Quaternion.Euler(rotation));
        myArea.transform.parent = transform;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal") / 5;
        float y = 0;
        float z = Input.GetAxis("Vertical") / 5;
        if (Input.GetKey(KeyCode.Space))
        {
            z = 0;
            y = Input.GetAxis("Vertical") / 5;
            Vector3 direction = transform.rotation.eulerAngles.normalized;
            transform.position = new Vector3(transform.localPosition.x + x * direction.x, transform.localPosition.y + y * direction.y, transform.localPosition.z + z*direction.z);
        }
        else if (Input.GetKey(KeyCode.R))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x + x*50, transform.rotation.eulerAngles.y + y*50, transform.rotation.eulerAngles.z + z*50);
        }
        else
        {
            transform.position = new Vector3(transform.localPosition.x + x, transform.localPosition.y + y, transform.localPosition.z + z);
        }
    }
}