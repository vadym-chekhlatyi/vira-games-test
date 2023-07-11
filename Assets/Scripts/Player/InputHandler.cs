using UnityEngine;
using UnityEngine.Events;

public class InputHandler : MonoBehaviour
{
    public static InputHandler Instance { get; private set; }

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

    public UnityAction SignalOnClick = null;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            SignalOnClick?.Invoke();
        }
    }
}
