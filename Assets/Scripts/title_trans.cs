using UnityEngine;
using System.Collections;

public class title_trans : MonoBehaviour {
    private GameObject camera;
    private GameObject titleCanvas;
    private GameObject menuCanvas;
    private GameObject spareTitleCanvas;
    private GameObject spareMenuCanvas;
    private State nowState = State.title;
    enum State
    {
        title,
        menu
    };
	// Use this for initialization
	void Start () {
        camera =GameObject.Find("Camera");
        titleCanvas = GameObject.Find("Title");
        menuCanvas = GameObject.Find("Menu");
        menuCanvas.SetActive(false);
	}
	public void TransTitle()
    {
        camera.transform.Rotate(new Vector3(35, 0, 0));
        spareMenuCanvas = Instantiate(menuCanvas);
        spareMenuCanvas.SetActive(false);
        Destroy(menuCanvas);
        menuCanvas = spareMenuCanvas;
        nowState = State.title;
        titleCanvas.SetActive(true);
        menuCanvas.SetActive(false);
    }
    public void TransMenu()
    {
        camera.transform.Rotate(new Vector3(-35, 0, 0));
        spareTitleCanvas = Instantiate(titleCanvas);
        spareTitleCanvas.SetActive(false);
        menuCanvas.SetActive(true);
        Destroy(titleCanvas);
        titleCanvas = spareTitleCanvas;
        nowState = State.menu;
    }
    public void TransToGame()
    {
        Application.LoadLevel("Game");
    }
	// Update is called once per frame
	void Update () {
        float leftRotation = 40;
        if (Input.GetKeyDown(KeyCode.Return)&&nowState==State.title)
        {
            TransMenu();
        }
    }
}
