using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR.WSA.Input;

public class PlayerBehaviour : MonoBehaviour {

    [SerializeField]
    private int health = 10;

    public GameObject bullet;

    private GestureRecognizer recognizer;

    void Start () {
        recognizer = new GestureRecognizer();

        recognizer.TappedEvent += (source, tapCount, ray) => {
            if (bullet != null) {
                Instantiate(bullet, transform.position + transform.forward * 0.25f, transform.rotation);
            }
        };
        recognizer.StartCapturingGestures();
    }

    private void Recognizer_TappedEvent(InteractionSourceKind source, int tapCount, Ray headRay)
    {
        throw new System.NotImplementedException();
    }

    void Update () {}

    void TakeDamage(int damage) {
        health -= damage;

        if (health <= 0) {
            // END GAME!
        }
    }
}
