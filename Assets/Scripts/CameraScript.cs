using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    public GameObject player;
    void Start() {
    }
    void Update() {
        // if (Input.GetKey(KeyCode.A)) {
        //     transform.RotateAround(player.transform.position, Vector3.up, -10f * Time.deltaTime);
        // }
        // if (Input.GetKey(KeyCode.D)) {
        //     transform.RotateAround(player.transform.position, Vector3.up, 10f * Time.deltaTime);
        // }
        // if (Input.GetKey(KeyCode.Space) && transform.position.y <= 27f) {
        //     // transform.Translate(new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z) * Time.deltaTime);
        //     transform.Translate(Vector3.up * Time.deltaTime);
        // }
    }
}