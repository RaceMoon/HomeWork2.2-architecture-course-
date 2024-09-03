using UnityEngine.InputSystem;

public class RunningState : GroundedState
{
    private RunningStateConfig _config;

    public RunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.RunningStateConfig;

    public override void Enter()
    {
        base.Enter();

        Input.Movement.FastRun.started += OnFastRunKeyPressed;
        Input.Movement.SlowRun.started += OnSlowRunKeyPressed;

        Data.Speed = _config.Speed;

        View.StartRunning();
    }

    public override void Exit()
    {
        base.Exit();

        Input.Movement.FastRun.started -= OnFastRunKeyPressed;
        Input.Movement.SlowRun.started -= OnSlowRunKeyPressed;

        View.StopRunning();
    }

    public override void Update()
    {
        base.Update();

        if (IsHorizontalInputZero())
            StateSwitcher.SwitchState<IdlingState>();
    }

    private void OnFastRunKeyPressed(InputAction.CallbackContext context) => StateSwitcher.SwitchState<FastRunningState>();
    private void OnSlowRunKeyPressed(InputAction.CallbackContext context) => StateSwitcher.SwitchState<SlowRunningState>();
    
}
