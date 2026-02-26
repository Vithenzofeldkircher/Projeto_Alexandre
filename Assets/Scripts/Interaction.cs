using UnityEngine;

public class Interaction : MonoBehaviour
{
    private IInteractable _Target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(_Target);
        if (_Target == null)
            return;
        if (Input.GetButtonDown("Fire1"))
        {
            _Target.Active();
            Debug.Log("ESTÁ CLICANDO");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out _Target))
        {

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.TryGetComponent(out _Target))
        {
            _Target = null;
        }
    }
}


