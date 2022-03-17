using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float _movespeed = 5f;
    public float _mousespeed = 10f;

    private float _horizontal;
    private float _vertical;
    private float mouseX = 0;
    private Vector3 move;

    private bool _key = false;
    private bool _End = false;
    private bool _Eat = false;
    private float buffTime = 5;
    private float carrotCnt = 0;

    CharacterController character;
    Animator animator;

    private void Awake()
    {
        character = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // 키보드
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
        move = new Vector3(_horizontal, 0, _vertical);

        // 마우스
        mouseX += Input.GetAxis("Mouse X") * _mousespeed;

        // 애니메이터
        Move();
        onAnimate();
        Item();
    }
    private void Move()
    {
        character.Move(transform.TransformDirection(move).normalized * Time.deltaTime * _movespeed);
        transform.eulerAngles = new Vector3(0, mouseX, 0);
    }

    private void Item()
    {
        if (_Eat) _movespeed = 30f;
        carrotCnt += Time.deltaTime;
        if (carrotCnt >= buffTime) {
            _Eat = false;
            _movespeed = 5f;
            carrotCnt = 0;
        }
    }

    void onAnimate()
    {
        if (_horizontal == 0 && _vertical == 0)
        {
            animator.SetBool("runChk", false);
        }

        else 
        {
            animator.SetBool("runChk", true);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("_Key"))
        {
            _key = true;
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("_Carrot"))
        {
            _Eat = true;
            Destroy(col.gameObject);            
        }
        if (col.gameObject.CompareTag("_Door") && _key)
        {
            col.gameObject.GetComponent<Animator>().SetBool("open", true);
            _movespeed = 0.000000001f;
            _mousespeed = 0.000000001f;

            GameManager.instance._receive_victory = true;
            GameManager.instance.Result();
        }

        if (col.gameObject.CompareTag("_Enemy"))
        {
            Time.timeScale = 0;
            _mousespeed = 0f;

            GameManager.instance._receive_victory = false;
            GameManager.instance.Result();
        }

        
    }
}
