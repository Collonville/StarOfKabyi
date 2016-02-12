using UnityEngine;
using System.Collections;

public class title_canvas : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Return))
        {
            Destroy(gameObject);
        }
    }
}
