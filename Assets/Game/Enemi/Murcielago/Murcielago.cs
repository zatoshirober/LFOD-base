using Unity.VisualScripting;
using UnityEngine;

public class Murcielago : MonoBehaviour
{
    [SerializeField] Transform positionPlayer;
    [SerializeField] float distancePlayer;
    [SerializeField] Vector3 puntoInicial;
    [SerializeField] SpriteRenderer spriteRender;
    [SerializeField] Animator anim;


    private void Start()
    {
        puntoInicial = transform.position;
        spriteRender = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        distancePlayer = Vector2.Distance(transform.position,positionPlayer.position);
        anim.SetFloat("Distancia", distancePlayer);
    }




}
