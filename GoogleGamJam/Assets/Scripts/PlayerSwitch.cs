using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerMovement playerMovement2;

    private bool playerActive = true;

    void Start()
    {
        playerMovement.enabled = playerActive;
        playerMovement2.enabled = !playerActive;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchPlayer();
        }
    }

    public void SwitchPlayer()
    {
        if (playerActive)
        {
            playerMovement.enabled = false;
            StopPlayer(playerMovement.gameObject);

            playerMovement2.enabled = true;
        }
        else
        {
            playerMovement2.enabled = false;
            StopPlayer(playerMovement2.gameObject);

            playerMovement.enabled = true;
        }

        playerActive = !playerActive;
    }

    private void StopPlayer(GameObject player)
    {
        // 2D fizik motoru için Rigidbody2D kullanýlýyor
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }
}
