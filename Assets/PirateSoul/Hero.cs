using PirateSoul.Components;
using PirateSoul.UI.Hud;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace PirateSoul
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private float _speed; // ����� � ����� ��� ��������
        [SerializeField] private float _jumpSpeed; // � ����� ��������� ������� ������
        [SerializeField] private float _damageJumpSpeed;
        [SerializeField] private LayerMask _groundLayer; // ���� �����

        [SerializeField] private float _groundCheckRadius;
        [SerializeField] private Vector3 _groundCheckPositionDelta; // ��� ��������� ����� ��� ����������

        [SerializeField] private float _interactionRadius;
        [SerializeField] private LayerMask _interactionLayer;
        [SerializeField] public Text coinsText;
        [SerializeField] public Text multyTimerText;
        [SerializeField] public Text finalScoreText;
        [SerializeField] public GameObject multyTimerPanel;
        [SerializeField] private GameObject _activateButton;

        [SerializeField] private UnityEvent _onDie;


        private Vector2 _direction;
        private Collider2D[] _interactionResult = new Collider2D[1];
        private Rigidbody2D _rigidbody;
        private Animator _animator;
        private SpriteRenderer _sprite;
        public int coinsCount;
        public float multiplyTime = 0;
        private bool _isGounded;
        private bool _allowDoubleJump;
        private bool _isDie = false;


        private static readonly int IsGroundKey = Animator.StringToHash("is-ground"); // ��� �� �� ���������� ������ ������ ���
        private static readonly int VerticalVelocityKey = Animator.StringToHash("vertical-velocity");
        private static readonly int IsRunningKey = Animator.StringToHash("is-running");
        private static readonly int IsHittingKey = Animator.StringToHash("hit");
        private static readonly int IsDieKey = Animator.StringToHash("die");


        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _sprite = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            coinsText.text = coinsCount.ToString();
            multyTimerText.text = Mathf.Round(multiplyTime).ToString();
        }

         public void SetDirection(Vector2 dir)
        {
            if (!_isDie) _direction = dir;
        }

        private void FixedUpdate() // ������ �������������� ��� � FixedUpdate
        {
            var xVelocity = _direction.x * _speed;
            var yVelocity = CalculateYVelocity();
            _rigidbody.velocity = new Vector2(xVelocity, yVelocity);
            

            if (!_isDie)
            {
                _animator.SetBool(IsGroundKey, _isGounded); // ����� ��������
                _animator.SetFloat(VerticalVelocityKey, _rigidbody.velocity.y);
                _animator.SetBool(IsRunningKey, _direction.x != 0);
                
            }

            UpdateSpriteDirection();


        }

        private void Update()
        {
            if (multiplyTime > 0) 
            { 
                multiplyTime -= Time.deltaTime;
                multyTimerText.text = Mathf.Round(multiplyTime).ToString();
            }
            else
            {
                if(multyTimerPanel.active) multyTimerPanel.active = false;
            }
            _isGounded = IsGrounded();
            
        }

        private void UpdateSpriteDirection()
        {
            if(_direction.x > 0)
            {
                _sprite.flipX = false;
            }
            else if(_direction.x< 0)
            {
                _sprite.flipX = true;
            }
        }

        
        public void ActivateMultiplyCoins()
        {
            multiplyTime += 10f;
        }
        public void GetCoins(int count)
        {
            if (multiplyTime > 0)
            {
                count *= 2;
                
            }
            coinsCount+= count;
            //Debug.Log(coinsCount);
            coinsText.text = coinsCount.ToString();

        }

        public void TakeDamage()
        {
            if (!_isDie) 
            {
                _animator.SetTrigger(IsHittingKey);
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _damageJumpSpeed);
            }
            
        }

        public void OnDie()
        {
            _isDie = true;
            //_animator.SetTrigger(IsHittingKey);
            _animator.SetTrigger(IsDieKey);
        }

        public void AfterDeathEvents()
        {
            if (_isDie)
            {
                Time.timeScale = 0f;
                finalScoreText.text = coinsCount.ToString();
                //Debug.Log("GAME OVER");
                _onDie?.Invoke();
            }
        }
        

        private float CalculateYVelocity()
        {
            var yVelocity = _rigidbody.velocity.y;
            var isJumpPressing = _direction.y > 0;
            if (_isGounded) _allowDoubleJump = true; // 2 ������ ����� �������� ������ ����� �����������

            if (isJumpPressing)
            {
                yVelocity = CalculateJumpVelocity(yVelocity);
            }
            else if (_rigidbody.velocity.y > 0) // ���� �������� ������ ������ �� �����������
            {
                yVelocity *= 0.5f;
            }
            return yVelocity;
        }

        private float CalculateJumpVelocity(float yVelocity)
        {
            var isFalling = _rigidbody.velocity.y <= 0.001f;
            if (!isFalling) return yVelocity;

            // ������ 2�� ������
            if (_isGounded)
            {
                yVelocity += _jumpSpeed;
            }
            else if(_allowDoubleJump)
            {
                yVelocity = _jumpSpeed;
                _allowDoubleJump = false;
            }
            return yVelocity;
        }

        private bool IsGrounded() // ������������ �� ��� ������ � ������
        {
            //var hitGround = Physics2D.Raycast(transform.position, Vector2.down, 1, _groundLayer); //  Raycast - ����������� ��� � ���������� � ��� ��� ���������
            var hitGround = Physics2D.CircleCast(transform.position + _groundCheckPositionDelta, _groundCheckRadius, Vector2.down, 0, _groundLayer);
            // ������� ����� ��� ����������� ����� �� ���� �� �����
            return hitGround.collider != null;

        }

        private void OnDrawGizmos()
        {
            //Debug.DrawRay(transform.position, Vector3.down, IsGrounded() ? Color.green : Color.red); //�������� �������� �� ��� �����
            Gizmos.color = IsGrounded() ? Color.green : Color.red;
            Gizmos.DrawSphere(transform.position + _groundCheckPositionDelta, _groundCheckRadius);
            // ������ ����� ��� �����������

        }

        public void SaySomething()
        {
            //Debug.Log("Pew-Pew");
        }

        public void Interact()
        {
            var size = Physics2D.OverlapCircleNonAlloc(transform.position, _interactionRadius,
                _interactionResult, _interactionLayer); // �������� ��� �������������� �������
            // ������� ����� � ��� ��� � ��� ������� ������� � _interactionResult

            for (int i = 0; i < size; i++)
            {
                var interactable = _interactionResult[i].GetComponent<InteractableComponent>(); 
                if(interactable != null) // ���� �������
                {
                    interactable.Interact(); // ��������� ������������� �������� ����� �������
                }
            }


        }
    }
}
