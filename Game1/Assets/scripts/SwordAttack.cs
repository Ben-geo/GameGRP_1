using System;
using UnityEngine;
public class Timer
{
    public event Action OnTimerDone;

    private float startTime;
    private float duration;
    private float targetTime;

    private bool isActive;

    public Timer(float duration)
    {
        this.duration = duration;
    }

    public void StartTimer()
    {
        startTime = Time.time;
        targetTime = startTime + duration;
        isActive = true;
    }

    public void StopTimer()
    {
        isActive = false;
    }

    public void Tick()
    {
        if (!isActive) return;

        if (Time.time >= targetTime)
        {
            OnTimerDone?.Invoke();
            StopTimer();
        }
    }
}
public class SwordAttack : MonoBehaviour
    {
        [SerializeField] private int numberOfAttacks;
        [SerializeField] private float attackCounterResetCooldown;

        public int CurrentAttackCounter
        {
            get => currentAttackCounter;
            private set => currentAttackCounter = value >= numberOfAttacks ? 0 : value;
        }

        public event Action OnExit;

        private Animator anim;
        private GameObject baseGameObject;

        private AnimationEventHandler eventHandler;

        private int currentAttackCounter;

        private Timer attackCounterResetTimer;

        public void Enter()
        {
            print($"{transform.name} enter");

            attackCounterResetTimer.StopTimer();

            anim.SetBool("active", true);
            anim.SetInteger("counter", currentAttackCounter);
        }

        private void Exit()
        {
            anim.SetBool("active", false);

            CurrentAttackCounter++;
            attackCounterResetTimer.StartTimer();

            OnExit?.Invoke();
        }

        private void Awake()
        {
            baseGameObject = transform.Find("Base").gameObject;
            anim = baseGameObject.GetComponent<Animator>();

            eventHandler = baseGameObject.GetComponent<AnimationEventHandler>();

            attackCounterResetTimer = new Timer(attackCounterResetCooldown);
        }

        private void Update()
        {
            attackCounterResetTimer.Tick();
        }

        private void ResetAttackCounter()
        {
            print("Reset Attack Counter");
            CurrentAttackCounter = 0;
        }

        private void OnEnable()
        {
            eventHandler.OnFinish += Exit;
            attackCounterResetTimer.OnTimerDone += ResetAttackCounter;
        }

        private void OnDisable()
        {
            eventHandler.OnFinish -= Exit;
            attackCounterResetTimer.OnTimerDone -= ResetAttackCounter;
        }
    }
