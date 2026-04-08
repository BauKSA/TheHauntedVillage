using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhantomMovementController : MonoBehaviour
{
    private readonly float MinX = -88f;
    private readonly float MaxX = -1f;

    private readonly float MinY = -62f;
    private readonly float MaxY = 17f;

    private float bulletSpeed = 25f;

    private PositionController position;
    private AnimationController animationController;
    private SpriteRenderer sprRenderer;

    private bool Hidden = false;
    private bool IsAttacking = false;
    private bool IsDamaged = false;

    private float Timer = 0f;
    [SerializeField]
    private float HiddenTime = 10f;
    [SerializeField]
    private float AttackingTime = 7f;

    [SerializeField]
    private GameObject Bullet;

    [SerializeField]
    private GameObject hearthController;

    [SerializeField]
    private GameObject player;

    private void Awake()
    {
        position = GetComponent<PositionController>();
        if (!position) Destroy(this);

        animationController = GetComponent<AnimationController>();
        if (!animationController) Destroy(this);

        sprRenderer = GetComponent<SpriteRenderer>();
        if (!sprRenderer) Destroy(this);
    }

    private void Start()
    {
        animationController.StartAnimation("Phantom_idle");
    }

    private void Update()
    {
        if (IsDamaged) return;
        if (IsAttacking) return;
        Timer += Time.deltaTime;

        if (Timer >= HiddenTime)
        {
            if (Hidden) Show();
            else Hide();

            Timer = 0f;
        }
    }

    private void Show()
    {
        Hidden = false;
        sprRenderer.enabled = true;
        animationController.StartAnimation("Phantom_show", true, CheckAttack);
    }

    private void Hide()
    {
        Hidden = true;
        sprRenderer.enabled = false;
        Move();
    }

    public void Move()
    {
        float x = UnityEngine.Random.Range(MinX, MaxX);
        float y = UnityEngine.Random.Range(MinY, MaxY);
        position.SetPosition(x, y);
    }

    private void CheckAttack()
    {
        if (!player)
        {
            Debug.LogError("PLAYER IS NULL");
            return;
        }

        Debug.Log("Player OK");

        float distance = Vector3.Distance(
            transform.position,
            player.transform.position
        );

        Debug.Log("Distance OK: " + distance);

        if (distance <= 25f) return;

        bool CanAttack = UnityEngine.Random.value > 0.1f;
        Debug.Log("CanAttack: " + CanAttack);

        if (!CanAttack) return;

        StartCoroutine(AttackAfterFrames(2));
    }

    private IEnumerator AttackAfterFrames(int frames)
    {
        for (int i = 0; i < frames; i++)
            yield return null;

        Attack();
    }

    private void Attack()
    {
        Debug.Log("Attacking");
        IsAttacking = true;
        animationController.StartAnimationWithDelay("Phantom_attacking", StopAttack, AttackingTime);
        Spawn();
    }

    private void StopAttack()
    {
        IsAttacking = false;
    }

    private void Spawn()
    {
        if (!Bullet) return;

        int bulletCount = 4;
        float angleStep = 360f / bulletCount;
        float angle = 0f;

        PhantomState state = GetComponent<PhantomState>();
        if (!state) return;

        state.IsVulnerable = false;

        for (int i = 0; i < bulletCount; i++)
        {
            Quaternion rotation = Quaternion.Euler(0f, 0f, angle);
            angle += angleStep;

            GameObject bullet = Instantiate(Bullet, transform.position, rotation);
            PhantomBulletBeingAlive controller = bullet.GetComponent<PhantomBulletBeingAlive>();
            if (!controller) continue;

            MovementController movement = bullet.GetComponent<MovementController>();
            if (!movement) continue;

            movement.SetSpeed(bulletSpeed);

            controller.Move((BulletDirection)i);
        }
    }

    public void Damage()
    {
        IsDamaged = true;

        animationController.StartAnimation("Phantom_show", true, RestartFromDamage, "Phantom_idle");

        EnemyHearthController controller = hearthController.GetComponent<EnemyHearthController>();
        if (!controller)
        {
            Debug.Log("No hearth controller found");
            return;
        }

        controller.DestroyOneHearth();
        bulletSpeed += 5f;

        if(controller.GetEnemyHearthCount() <= 0)
        {
            Defeated();
        }
    }

    private void RestartFromDamage()
    {
        IsAttacking = false;
        IsDamaged = false;
        Timer = 0f;

        animationController.StartAnimation("Phantom_idle");

        Hide();
    }

    private void Defeated()
    {
        IsDamaged = true;
        Hidden = false;
        sprRenderer.enabled = true;

        animationController.StartAnimationWithDelay("Phantom_death", EndRoom, 2f, "Phantom_death");
    }

    private void EndRoom()
    {
        GameObject SpawnController = GameObject.FindGameObjectWithTag("SpawnController");
        if (!SpawnController) return;

        WorldSpawnPositionController spawnPosition = SpawnController.GetComponent<WorldSpawnPositionController>();
        if (!spawnPosition) return;

        spawnPosition.SpawnPositionX = -36;
        spawnPosition.SpawnPositionY = -54;

        Inventory inventory = Inventory.Instance;
        inventory.ActivateAxe();

        SceneManager.LoadScene("World");
    }

}
