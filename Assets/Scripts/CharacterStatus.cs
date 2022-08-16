using UnityEngine;

namespace StatusSystem
{
    public class CharacterStatus : MonoBehaviour
    {
        [SerializeField]int life;//-maybe int is an error, float is better...
        [SerializeField]int initialLifeAmount;
        //-----------------------
        Transform initialPosition;
        [SerializeField]Animator characterAnimator;
        //-----------------------
        //hmmm Coffe Break;
        [SerializeField] float movementSpeed;
        [SerializeField] float maxMovementSpeed;

        public float MoveSpeed
        {
            get { return movementSpeed; }
            set
            {
                if (value < maxMovementSpeed)
                {
                    movementSpeed = value;
                }
            }
        }

        public float MaxMoveSpeed
        {
            get { return maxMovementSpeed; }
            set
            { maxMovementSpeed = value;}
        }

        public int Life
        {
            get
            {return life;}
            set
            { life = Mathf.Clamp(value, 0, initialLifeAmount); }
        }
        
        public int InitialLife
        {
            get { return initialLifeAmount; }
            set { initialLifeAmount = value; }
        }

        public Animator Anim
        {
            get { return characterAnimator;} 
            set{ characterAnimator = value; }
        }

        public Transform initPos
        {
            get { return initialPosition; }
            set { initialPosition = value; }
        }

        public virtual void TakeDamage(int value) => Life -= value;
        public virtual void TakeLife(int value) => Life += value;

    }


}
