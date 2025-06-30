using UnityEngine;

public class PlayerSwitchOnDeath : MonoBehaviour
{
    public GameObject player; // Assign GameObject A (with controller)
    public GameObject oSymbol;
    public GameObject kSymbol; // Assign GameObject B (starts inactive)
    // public int playerHealth = 100;
    // public CameraFollow cameraFollow;
    private Health playerHealth;

    private PlayerMovement controllerA;
    private SimpleMovement controllerB;

    void Start()
    {
        // Get controller components
        controllerA = player.GetComponent<PlayerMovement>();
        controllerB = oSymbol.GetComponent<SimpleMovement>();
        playerHealth = player.GetComponent<Health>();

        // Ensure B is hidden at scene start
        kSymbol.SetActive(false);
        oSymbol.SetActive(false);
        // cameraFollow.SetTarget(player.transform);
    }

    void Update()
    {
        // Example health check (in a real case, reduce health elsewhere)
        if (playerHealth.CurrentHealth == 0 && player!=null)
        {
            Debug.Log("Hit!");
            SwitchPlayer();
        }
    }

    // public void Damageplayer(int damage)
    // {
    //     playerHealth -= damage;
    // }

    private void SwitchPlayer()
    {
        // Disable A
        controllerA.enabled = false;
        player.SetActive(false);

        // Enable B
        kSymbol.SetActive(true);
        oSymbol.SetActive(true);
        controllerB.enabled = true;
        // cameraFollow.SetTarget(oSymbol.transform);
    }
}
