using UnityEngine;

public class Player : Fighter
{
    private Animator _animator;
    private bool _insidePushObject;
    public bool StopPlayer = false;
    private Vector3 _spawn;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        //DontDestroyOnLoad(gameObject);
    }

    public override void Start()
    {
        base.Start();
        _spawn = transform.position;
    }

    public void FixedUpdate()
    {
        if (StopPlayer)
        {
            UpdateMotor(0f,0f);
            return;
        }

        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        UpdateMotor(x,y);

        if (Input.GetKey(KeyCode.R))
        {
            transform.position = _spawn;
        }
    }
    
    protected override void StartWalkAnimation()
    {
        _animator.SetBool("walking",true);
    }

    protected override void StopWalkAnimation()
    {
        _animator.SetBool("walking",false);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        _insidePushObject = collision.transform.CompareTag("Pushable");
    }

    public void GiveSword()
    {
        GameManager.Instance.floatingTextManager.Show("Recebeu a espada" ,
            30,
            Color.yellow,
            transform.position,
            Vector3.up * 2f,
            1f);
        transform.GetChild(1).gameObject.SetActive(true);
    }
    protected override void Death()
    {
        HitPoint = 5;
        transform.position = _spawn;
        GameManager.Instance.floatingTextManager.Show("Morri :(",
            20,
            Color.cyan,
            transform.position,
            Vector3.up * 0.4f,
            0.3f);
    }
    
}
