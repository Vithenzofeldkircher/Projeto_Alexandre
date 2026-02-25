using UnityEngine;
using UnityEngine.Events;

public class Pressure_Plate : MonoBehaviour
{

    [SerializeField] private bool _Once_Place;

    public UnityEvent On_Active;

    public UnityEvent On_Desactive;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        On_Active.Invoke();
        if (_Once_Place)
            Destroy(this);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        On_Desactive.Invoke();
    }

}
