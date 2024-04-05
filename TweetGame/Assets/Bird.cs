using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] float _launchForce = 800;
     [SerializeField] float _maxDragDist = 5;

    Rigidbody2D _rigidbody2D;
    Vector2 _startPosition;
    SpriteRenderer _spriterenderer;
    bool _resetting;
    public bool IsDragging { get; private set; }
    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriterenderer = GetComponent<SpriteRenderer>();

    }
   
    void Start()
    {
        _startPosition = _rigidbody2D.position;
        _rigidbody2D.isKinematic = true;
    }

    void OnMouseDown()
    {
        _spriterenderer.color = Color.magenta;
        IsDragging = true;
    
    }
    void OnMouseUp()
    {
        Vector2 currentPosition = GetComponent<Rigidbody2D>().position;
        Vector2 direction = _startPosition - currentPosition;
        direction.Normalize();

        _rigidbody2D.isKinematic = false;
        _rigidbody2D.AddForce(direction * _launchForce);
        _spriterenderer.color = Color.white;
        IsDragging = false;
    }
    void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        Vector2 desiredPosition = mousePosition;
        

            float distance = Vector2.Distance(desiredPosition, _startPosition);
            if (distance > _maxDragDist)
            {
                Vector2 direction = desiredPosition - _startPosition;
                direction.Normalize();
                desiredPosition = _startPosition + (direction * _maxDragDist);
            }
            
            if (desiredPosition.x > _startPosition.x)
            desiredPosition.x = _startPosition.x;


       _rigidbody2D.position = desiredPosition;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisiionEnter2D(Collision2D collision)
    {
        StartCoroutine(ResetDelay());
        
    }
    IEnumerator ResetDelay()
    {
        yield return new WaitForSeconds(3);
        _rigidbody2D.position = _startPosition;
        _rigidbody2D.isKinematic = true;
        _rigidbody2D.velocity = Vector2.zero;
    }
}
