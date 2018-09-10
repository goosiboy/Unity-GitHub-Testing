using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public static bool isActive;
    public static enumPosition position;

    private float _speed = -1f;
    private float objectSpeed;

    private float timer = 0f;
    private float time = 1f;

    public GameObject mainBG;

	// Use this for initialization
	void Start () {

        objectSpeed = _speed * Time.deltaTime;
        isActive = false;
        position = enumPosition.center;

        mainBG = GameObject.Find("MainBG");

        print("Im not active!");
	}
	
	// Update is called once per frame
	void Update () {}

    private IEnumerator MoveBackground() {

        isActive = true;
        print("Im active!");

        while (timer < time) {
            timer += Time.deltaTime;
            mainBG.transform.Translate(0, objectSpeed, 0);
            yield return null;
        }

        isActive = false;
        timer = 0;

        print("Im not active again!");
    }

    private void OnMouseDown() {
        print("My position: " + position);

        if (mainBG != null) {
            if (!isActive) {
                StartCoroutine(MoveBackground());
            } else if (isActive) {
                print("Cant move! Im already active!");
            }

        }

    }
}


