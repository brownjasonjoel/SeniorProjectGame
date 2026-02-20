using UnityEngine;

public class PlayerSlideState : PlayerState
{
    private float slideStopTimer;
    private float slideTimer;

    public PlayerSlideState(Player player) : base(player) { }


    public override void Enter()
    {
        base.Enter();

        slideTimer = player.slideDuration;
        slideStopTimer = 0;

        player.SetColliderSlide();
        anim.SetBool("isSliding", true);
    }

    public override void Update()
    {
        base.Update();

        if (slideTimer > 0)
        {
            slideTimer -= Time.deltaTime;
        }
        else if (slideStopTimer <= 0)
        {
            slideStopTimer = player.slideStopDuration;
        }
        else
        {
            slideStopTimer -= Time.deltaTime;

            if (slideStopTimer <= 0)
            {
                if (player.CheckForCieling() || MoveInput.y <= -0.1f)
                {
                    player.ChangeState(player.crouchState);
                }
                else
                { 
                player.ChangeState(player.idleState);
                }
            }
        }
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        if (slideTimer > 0)
        {
            player.rb.linearVelocity = new Vector2(player.slideSpeed * player.facingDirection, player.rb.linearVelocity.y);
        }
        else
        {
            player.rb.linearVelocity = new Vector2(0, player.rb.linearVelocity.y) ;
        }
    }


    public override void Exit()
    {
        base.Exit();

        player.SetColliderNormal();
        anim.SetBool("isSliding", false);
    }


}
