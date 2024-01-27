using PlayerControls.Scripts;
using UnityEngine;

public class Attack_PlayerShot : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _projectile;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject Movement;
    [SerializeField] private IInput input;

    public float force = 1.0f;
    // Update is called once per frame
    void Update()
    {
        if (input.attackInput)
        {
            Rigidbody2D clone;
            clone = Instantiate(_projectile, _player.transform.position, Quaternion.identity);
            bool moveright = GetMoveRight();
            if (moveright)
            {
                clone.AddForce(transform.right * force, ForceMode2D.Impulse);
            }
            else
            {
                clone.AddForce(-transform.right * force, ForceMode2D.Impulse);
            }
        }
    }

    private bool GetMoveRight()
    {
        return Movement.GetComponent<Movement_Horizontal>().moveright;
    }
}
