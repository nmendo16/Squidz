using System.Collections;
using UnityEngine;

public class InkyAnimationController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayIdle()
    {
        animator.SetTrigger("TriggerIdle_inky");
    }

    public void PlayWinning()
    {
        animator.SetTrigger("TriggerWinning_inky");
    }

    public void PlayDamage()
    {
        animator.SetTrigger("TriggerDamage_inky");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Get the shooter from the bullet
            GameObject shooter = collision.gameObject.GetComponent<TESTBullet>().shooter;

            // Trigger the winning animation for the shooter
            shooter.GetComponent<InkyAnimationController>().PlayWinning();

            // Trigger the damage animation for the hit player
            PlayDamage();

            // Start the coroutine to return to idle after 3 seconds
            StartCoroutine(ReturnToIdle());
        }
    }

    private IEnumerator ReturnToIdle()
    {
        yield return new WaitForSeconds(3);
        PlayIdle();
    }
}

