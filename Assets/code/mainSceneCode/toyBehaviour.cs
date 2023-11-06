using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toyBehaviour : MonoBehaviour
{
    private Vector3 offset;
    [SerializeField] private Sprite teddyNormal;
    [SerializeField] private Sprite teddyHover;

    void Update()
    {
        if (GameManager.Instance.dragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }
    void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameManager.Instance.dragging = true;
    }
    void OnMouseUp()
    {
        GameManager.Instance.dragging = false;
    }
    void OnMouseOver()
    {
        GetComponent<SpriteRenderer>().sprite = teddyHover;
    }

    void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().sprite = teddyNormal;
    }
}
