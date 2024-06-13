using System.Threading;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStateController : MonoBehaviour {

    // Creem una variable pública de tipus Bool
    public static bool canMove;

    // Start is called before the first frame update
    void Start() {

        // Reiniciem les estadístiques
        if (SceneManager.GetActiveScene().name == "Lvl1") {
            ScoreManager.Instance.Reset();
            PlayerManager.bossHP = 2.0f;
            PlayerManager.playerHP = 50.0f;
            PlayerManager.speed = 5.0f;
            PlayerManager.shot = 0.0f;
        }
        
        // Permetem que el jugador es pugui moure
        canMove = true;
    }

    // Update is called once per frame
    void Update() {
        
        // Agafem el valor en moure l'AXIS Horitzontal
        float horizontalInput = Input.GetAxis("Horizontal");

        // Creem una estructura tipus Vector
        Vector3 direction = new Vector3(horizontalInput, 0f, 0f);

        // Movem el personatge quan es prem la tecla dreta o l'esquerra
        if (canMove) {
            transform.Translate(direction * PlayerManager.speed * Time.deltaTime);
        }
    }
}
