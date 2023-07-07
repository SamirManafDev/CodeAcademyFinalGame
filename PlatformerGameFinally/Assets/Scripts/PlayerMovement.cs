using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public Animator animator;
    [SerializeField] LayerMask layer;
    [SerializeField] float jumpForce;
    [SerializeField] float _speed;
    [SerializeField] GameObject _pauseMenu;
    [SerializeField] private AudioSource AudioVolume;
    [SerializeField] private UnityEngine.UI.Slider VolumeSlider;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip health;
    [SerializeField] AudioClip thron;
    [SerializeField] GameObject heartOne;
    [SerializeField] GameObject heartTwo;
    [SerializeField] GameObject heartThree;
    private Vector3 _direction;
    private float _currentTurnAngle;
    public float _health=90f;

    Rigidbody rb;
    private void Start()
    {
        VolumeSlider.value = 1f;
        rb = GetComponent<Rigidbody>();
    }
    private void Awake()
    {
        UnityEngine.Cursor.visible= false;
    }
    private void Update()
    {
        PlayerMove();
        PlayerJump();
        PauseMenu();
        CheckHealth();
    }
    private void PlayerMove()
    {
        _direction = CalculateMovement();
        
        if (_direction.magnitude > 0.01f)
        {
            float targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,
            targetAngle, ref _currentTurnAngle, 0.3f);

            transform.rotation = Quaternion.Euler(0, angle, 0);

            rb.MovePosition(transform.position +
            (_direction.normalized * (_speed * Time.deltaTime)));
            animator.SetBool("Runing", true);

        }
        else
        {
            animator.SetBool("Runing", false);
        }
    }
    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Physics.Raycast(transform.position, Vector3.down, 1f, layer))
        {
            animator.SetBool("Jump", true);
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            GameObject.Find("Jump Sound").GetComponent<AudioSource>().Play();
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Thron")
        {
            GameObject.Find("Thorn Sound").GetComponent<AudioSource>().Play();
            _health -= 30f;
        }
        if (collision.gameObject.tag == "Heart")
        {
            GameObject.Find("Health Sound").GetComponent<AudioSource>().Play();
            _health += 30;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Tom")
        {
            StartCoroutine(TomHunt());
            _speed = 0;
            VolumeSlider.value = 0f;
        }

    }
    IEnumerator TomHunt()
    {
        yield return new WaitForSeconds(4f);
        UIManager.Instance.GameOverOpen();
        Time.timeScale = 0f;
    }
    private void CheckHealth()
    {
        switch (_health)
        {
            case 0:
                heartOne.SetActive(false);
                heartTwo.SetActive(false);
                heartThree.SetActive(false);
                UIManager.Instance.GameOverOpen();
                Time.timeScale = 0f;
                break;
            case 30:
                heartOne.SetActive(true);
                heartTwo.SetActive(false);
                heartThree.SetActive(false);
                break;
            case 60:
                heartOne.SetActive(true);
                heartTwo.SetActive(true);
                heartThree.SetActive(false);
                break;
            case 90:
                heartOne.SetActive(true);
                heartTwo.SetActive(true);
                heartThree.SetActive(true);
                break;
        }
    }
    private void PauseMenu()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            _pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            VolumeSlider.value = 0f;

        }

    }
    public void Resume()
    {
        _pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        VolumeSlider.value = 1f;
        UnityEngine.Cursor.visible = false;
    }
    public void Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
    public void ChangeVolume()
    {
        AudioVolume.volume = VolumeSlider.value;
    }

    protected Vector3 CalculateMovement()
    {
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        return forward * Input.GetAxis("Vertical") +
               right * Input.GetAxis("Horizontal");
    }
}
