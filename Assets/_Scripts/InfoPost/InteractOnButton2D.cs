using UnityEngine;
using UnityEngine.Events;

    public class InteractOnButton2D : InteractOnTrigger2D
    {
        public UnityEvent OnButtonPress;

        bool m_CanExecuteButtons;

        protected override void ExecuteOnEnter(Collider2D other)
        {
            base.ExecuteOnEnter(other);
            m_CanExecuteButtons = true;
            
        }

        protected override void ExecuteOnExit(Collider2D other)
        {
            base.ExecuteOnExit(other);
            m_CanExecuteButtons = false;

        }

        void Update()
        {
            if (m_CanExecuteButtons)
            {
                if (OnButtonPress.GetPersistentEventCount() > 0 )
                    OnButtonPress.Invoke();
            }
        }
    }
