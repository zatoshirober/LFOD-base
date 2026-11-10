using UnityEngine;
using UnityEngine.InputSystem.XR;

public class State_Bat_Follow : StateMachineBehaviour
{
    BatController controller;
    [SerializeField] float movementVelocity;
    [SerializeField] float tiempoFollowBase;
    [SerializeField] float tiempoFollow;
    [SerializeField] Transform positionPlayer;
    [SerializeField] Murcielago murcielago;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tiempoFollow = tiempoFollowBase;
        positionPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        murcielago = animator.gameObject.GetComponent<Murcielago>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        animator.transform.position = Vector2.MoveTowards(animator.transform.position,positionPlayer.position,movementVelocity * Time.deltaTime);
        tiempoFollow -= Time.deltaTime;
        if (tiempoFollow <= 0)
        {
            animator.SetTrigger("Volver");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
