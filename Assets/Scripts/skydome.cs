using UnityEngine;
using System.Collections;

public class skydome : MonoBehaviour {
    /// <summary>
    /// skydomeに取りつけ、空の色を切り替え、朝と夜を表現している。
    /// </summary>
    GameObject star;
    star_rotate starClass;
	// Use this for initialization

	void Start () {
        Vector2 offset = GetComponent<Renderer>().sharedMaterial.mainTextureOffset;
        offset.x = 0;
        offset.y = 0;
        GetComponent<Renderer>().sharedMaterial.mainTextureOffset = offset;
        star = gameObject.transform.FindChild("Stars").gameObject;
        starClass = star.GetComponent<star_rotate>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 offset = GetComponent<Renderer>().sharedMaterial.mainTextureOffset;
        offset.x = Mathf.Repeat(offset.x + 0.0003f, 1.0f);
        if (offset.x>0.35&&offset.x<0.7)
        {
            starClass.switchStar(true);
        }
        else
        {
            starClass.switchStar(false);
        }
        offset.y = 0;
        GetComponent<Renderer>().sharedMaterial.mainTextureOffset = offset;
    }
}
