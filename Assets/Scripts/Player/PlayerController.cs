using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    private const float PLAYER_Y_POSITION = 0.75f;

    public PlayerConfig Config;

    private bool Direction;

    [HideInInspector] public bool IsPaused;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        InputHandler.Instance.SignalOnClick = OnClick;
    }

    private void OnClick()
    {
        Direction = !Direction;
    }

    private void FixedUpdate()
    {
        if (!IsPaused)
        {
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        float movementSpeed = Config.movementSpeed * Time.deltaTime;
        if (Direction)
        {
            transform.Translate(new Vector3(-movementSpeed, 0, 0));
        }
        else
        {
            transform.Translate(new Vector3(0, 0, movementSpeed));
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        GameObject collisionObject = collision.gameObject;

        if (collisionObject.GetComponent<MapComponent>() != null && transform.position.y < PLAYER_Y_POSITION){
            Debug.Log("Pause");
            IsPaused = true;
        }
    }
}