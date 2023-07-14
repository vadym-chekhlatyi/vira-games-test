using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    private const float PLAYER_Y_POSITION = 0.75f;
    private const string DIAMOND_TAG = "Diamond";

    public GameConfig Config;
    private PlayerStats stats;

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
        stats = GetComponent<PlayerStats>();
        stats.LoadStats();
        InputHandler.Instance.SignalOnClick = OnClick;
    }

    private void OnClick()
    {
        Direction = !Direction;
    }

    private void FixedUpdate()
    {
        if (!IsPaused && GameController.Instance.isGameStarted)
        {
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        float movementSpeed = Config.PlayerMovementSpeed * Time.deltaTime;
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

        if (collisionObject.GetComponent<MapBlock>() != null && transform.position.y < PLAYER_Y_POSITION){
            IsPaused = true;
            PopUpManager.OpenPopup(PopUpManager.Popups.GameOverPopup);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        GameObject collisionObject = collision.gameObject;

        if(collisionObject.CompareTag(DIAMOND_TAG)){
            PickDiamond(collisionObject);
        }
    }

    private void PickDiamond(GameObject diamond)
    {
        stats.Crystals++;
        diamond.SetActive(false);
    }
}