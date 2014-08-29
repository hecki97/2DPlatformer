using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {

    public AudioClip[] jumpSounds;
    public AudioClip[] attackSounds;

    void Awake()
    {
        InputEventsHandler.OnInputJump += this.PlayJumpSound;
        InputEventsHandler.OnInputAttack += this.PlayAttackSound;
    }

    void OnDisable()
    {
        InputEventsHandler.OnInputJump -= this.PlayJumpSound;
        InputEventsHandler.OnInputAttack -= this.PlayAttackSound;
    }

    public void PlayJumpSound()
    {
        AudioClip jumpSound = jumpSounds[Random.Range(0, jumpSounds.GetLength(0))];
        AudioSource.PlayClipAtPoint(jumpSound, transform.position, 0.4F);
    }

    public void PlayAttackSound()
    {
        AudioClip attackSound = attackSounds[Random.Range(0, attackSounds.GetLength(0))];
        AudioSource.PlayClipAtPoint(attackSound, transform.position, 0.4F);
    }
}
