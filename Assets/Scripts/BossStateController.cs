using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossStateController : MonoBehaviour {

    // Creem un nombre decimal a mode de límit esquerre
    float leftBound;

    // Creem un nombre decimal a mode de límit dret
    float rightBound;

    // Creem una variable tipus Bool per regular el moviment de l'enemic
    bool movingRight = true;

    // Start is called before the first frame update
    void Start() {
        // Establim els valors dels límits dret i esquerre en funció de la posició d'inici
        leftBound = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + 1.0f;
        rightBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - 1.0f;
    }

    // Update is called once per frame
    void Update() {

        if (EnemyCounter.Instance.enemyCount == 0 && SceneManager.GetActiveScene().name == "BossScene") {

            if (movingRight) {

                // Desplaçem l'enemic cap a l'equerra
                transform.Translate(Vector2.right * 2.5f * Time.deltaTime);

                // Si l'enemic arriba fins el límit dret, canvia de direcció
                if (transform.position.x >= rightBound) {
                    movingRight = false;
                }

            } else {

                // Desplaçem l'enemic cap a la dreta
                transform.Translate(Vector2.left * 2.5f * Time.deltaTime);

                // Si l'enemic arriba fins el límit esquerre, canvia de direcció
                if (transform.position.x <= leftBound) {
                    movingRight = true;
                }
            }
        }
    }
}
