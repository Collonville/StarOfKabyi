using UnityEngine;
using System.Collections;

public class star_rotate : MonoBehaviour {
    /// <summary>
    /// Starsに取りつけ、夜になったら星を出して朝になったら星を消す。
    /// </summary>
    bool isStarEnable=true;

    public void switchStar(bool newState)
    {
        /*
        skydomeから呼び出される。
        */
        isStarEnable = newState;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Renderer>().enabled = isStarEnable;
    }
}
