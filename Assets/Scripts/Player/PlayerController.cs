using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    private const float PLAYER_Y_POSITION = 0.75f;
    private const string Crystal_TAG = "Crystal";

    public GameConfig Config;
    [HideInInspector] public PlayerStats Stats;
    [HideInInspector] public bool IsPaused;

    private bool Direction;

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

    public void Init()
    {
        Stats = new PlayerStats();
        Stats.Init();
        InputHandler.Instance.SignalOnClick = OnClick;
    }

    private void OnClick()
    {
        SoundManager.Instance.PlaySound(SoundManager.AudioClips.Click);
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
            int score = ScoresController.Instance.Scores;
            if(score > Stats.HighestScore){
                Stats.HighestScore = score;
            }
            PopUpManager.OpenPopup(PopUpManager.Popups.GameOverPopup);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        GameObject collisionObject = collision.gameObject;

        if(collisionObject.CompareTag(Crystal_TAG)){
            PickCrystal(collisionObject);
        }
    }

    private void PickCrystal(GameObject Crystal)
    {
        Stats.Crystals++;
        SoundManager.Instance.PlaySound(SoundManager.AudioClips.CrystalPickUp);
        Crystal.SetActive(false);
    }
}