using UnityEngine;
using System.Collections;

public class cloud_gen_era : MonoBehaviour {
    void OnTriggerExit(Collider collider)
    {
        Debug.Log("nasu");
        Instantiate(collider.gameObject, new Vector3(collider.gameObject.transform.position.x, collider.gameObject.transform.position.y, -350), collider.gameObject.transform.rotation);
        Destroy(collider.gameObject);
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
