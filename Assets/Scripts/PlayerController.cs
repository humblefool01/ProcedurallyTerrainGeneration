using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Rigidbody rb, rbc;
    Vector3 forwardDirection, sideDirection, cameraForward;
    public float thrust, turnSpeed, moveSpeed, speedLimit, resistance;
    bool goForward, takeTurn;
    Camera camera;
    public GameObject cameraParent;
    void Start() {
        goForward = false;
        takeTurn = false;        
        camera = FindObjectOfType<Camera>();
        print(camera.name);
        rb = gameObject.GetComponent<Rigidbody>();
        rbc = camera.gameObject.GetComponent<Rigidbody>();
    }
    void Update() {
        NoPhysics();
        // cameraParent.transform.position = transform.position;
        // Physics();        
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }
    void Physics() {
        if (rb.transform.position.y <= 5f) {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            // rbc.velocity = new Vector3(rbc.velocity.x, 0f, rbc.velocity.z);
        }
        if (Input.GetKey(KeyCode.Space) && transform.position.y <= 12f) {
            rb.AddForce(Vector3.up * thrust);
            // rbc.AddForce(Vector3.up * thrust);
        }
        if (Input.GetKey(KeyCode.LeftShift) && transform.position.y >= 10f) {
            rb.AddForce(Vector3.up * -thrust);
            // rbc.AddForce(Vector3.up * -thrust);
        }
        if (Input.GetKey(KeyCode.W) && rb.velocity.magnitude <= speedLimit && !takeTurn) {
            goForward = true;
            rb.AddForce(transform.forward * moveSpeed * Time.deltaTime);
            // rbc.AddForce(transform.forward * moveSpeed * Time.deltaTime);            
        }
        if (Input.GetKey(KeyCode.S) && rb.velocity.magnitude <= speedLimit && !takeTurn) {
            goForward = true;
            rb.AddForce(transform.forward * -moveSpeed * Time.deltaTime);
            // rbc.AddForce(transform.forward * -moveSpeed * Time.deltaTime);            
        }
        // Turn
        if (Input.GetKey(KeyCode.A) && !goForward) {
            takeTurn = true;
            transform.Rotate(0f, -turnSpeed * Time.deltaTime, 0f);
            cameraParent.transform.RotateAround(transform.position, Vector3.up, -turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) && !goForward) {
            takeTurn = true;
            transform.Rotate(0f, turnSpeed * Time.deltaTime, 0f);
            cameraParent.transform.RotateAround(transform.position, Vector3.up, turnSpeed * Time.deltaTime);        
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) {
            takeTurn = false;
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S)) {
            goForward = false;
        }
        Resistance();
    }
    void Resistance() {
        Vector3 velocity = rb.velocity;
        rb.AddForce(new Vector3(-velocity.x, -velocity.y, -velocity.z) * resistance);
        velocity = rbc.velocity;
        rbc.AddForce(new Vector3(-velocity.x, -velocity.y, -velocity.z) * resistance);
    }
    void NoPhysics() {
        // Up-Down
        if (Input.GetKey(KeyCode.Space) && transform.position.y <= 25f) {
            transform.Translate(Vector3.up * thrust * Time.deltaTime);
            camera.transform.Translate(Vector3.up * thrust * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftShift) && transform.position.y >= 5f) {
            transform.Translate(Vector3.up * -thrust * Time.deltaTime);
            camera.transform.Translate(Vector3.up * -thrust * Time.deltaTime);
        }
        // Forward
        if (Input.GetKeyDown(KeyCode.W)) {
            sideDirection = transform.InverseTransformDirection(transform.right);
            forwardDirection = transform.forward;
            cameraForward = camera.transform.forward;
        }
        if (Input.GetKey(KeyCode.W)) {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            camera.transform.position += camera.transform.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            sideDirection = transform.InverseTransformDirection(transform.right);
            forwardDirection = transform.forward;
        }
        if (Input.GetKey(KeyCode.S)) {
            transform.position -= transform.forward * moveSpeed * Time.deltaTime;
            camera.transform.position -= camera.transform.forward * moveSpeed * Time.deltaTime;
        }
        // Turn
        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(0f, -turnSpeed * Time.deltaTime, 0f);
            camera.transform.RotateAround(transform.position, Vector3.up, -turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(0f, turnSpeed * Time.deltaTime, 0f);
            camera.transform.RotateAround(transform.position, Vector3.up, turnSpeed * Time.deltaTime);
        }
    }
}
