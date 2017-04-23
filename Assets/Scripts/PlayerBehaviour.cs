using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR.WSA.Input;

public class PlayerBehaviour : MonoBehaviour {

    [SerializeField]
    private int health = 10;

    public GameObject bullet;

    private GestureRecognizer recognizer;

    public Animation WeapAnim;

    void Start () {
        recognizer = new GestureRecognizer();

        recognizer.HoldStartedEvent += (source, ray) => {
            WeapAnim.gameObject.SetActive(true);
        };

        recognizer.HoldCompletedEvent += (source, ray) => {
            WeapAnim.gameObject.SetActive(false);
        };

        recognizer.TappedEvent += (source, tapCount, ray) => {
            if (bullet != null) {
                Instantiate(bullet, transform.position + transform.forward * 0.25f, transform.rotation);
            }
        };
        recognizer.StartCapturingGestures();
    }

    void Update () {
        //if (!WeapAnim.isPlaying) {
        //    WeapAnim.gameObject.SetActive(false);
        //}

        if (Input.GetMouseButtonDown(0)) {
            WeapAnim.gameObject.SetActive(true);
        }
        if (Input.GetMouseButtonUp(0)) {
            WeapAnim.gameObject.SetActive(false);
        }
    }

    void TakeDamage(int damage) {
        health -= damage;

        if (health <= 0) {
            // END GAME!
        }
    }
}
