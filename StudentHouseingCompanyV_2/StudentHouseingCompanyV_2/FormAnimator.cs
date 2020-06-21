using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace StudentHouseingCompanyV_2
{
    public sealed class FormAnimator
    {
      
        public enum AnimationMethod
        {
            Roll = 0x0,
            
            Center = 0x10,
            
            Slide = 0x40000,
            
            Fade = 0x80000
        }

        [Flags]
        public enum AnimationDirection
        {
            Right = 0x1,

            Left = 0x2,
            
            Down = 0x4,
           
            Up = 0x8
        }


 

        private const int AwHide = 0x10000;

        private const int AwActivate = 0x20000;
  
        private const int DefaultDuration = 250;


        private readonly Form _form;
        
        private AnimationMethod _method;

        private AnimationDirection _direction;
       
        private int _duration;


       
        public AnimationMethod Method
        {
            get
            {
                return _method;
            }
            set
            {
                _method = value;
            }
        }

        public AnimationDirection Direction
        {
            get
            {
                return _direction;
            }
            set
            {
                _direction = value;
            }
        }

        public int Duration
        {
            get
            {
                return _duration;
            }
            set
            {
                _duration = value;
            }
        }

        public Form Form
        {
            get
            {
                return _form;
            }
        }

        
        public FormAnimator(Form form)
        {
            _form = form;

            _form.Load += Form_Load;
            _form.VisibleChanged += Form_VisibleChanged;
            _form.Closing += Form_Closing;

            _duration = DefaultDuration;
        }

        public FormAnimator(Form form, AnimationMethod method, int duration) : this(form)
        {
            _method = method;
            _duration = duration;
        }

      
        public FormAnimator(Form form, AnimationMethod method, AnimationDirection direction, int duration) : this(form, method, duration)
        {
            _direction = direction;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            if (_form.MdiParent == null || _method != AnimationMethod.Fade)
            {
                NativeMethods.AnimateWindow(_form.Handle, _duration, AwActivate | (int)_method | (int)_direction);
            }
        }

        private void Form_VisibleChanged(object sender, EventArgs e)
        {
            if (_form.MdiParent == null)
            {
                int flags = (int)_method | (int)_direction;

                if (_form.Visible)
                {
                    flags = flags | AwActivate;
                }
                else
                {
                    flags = flags | AwHide;
                }

                NativeMethods.AnimateWindow(_form.Handle, _duration, flags);
            }
        }

        private void Form_Closing(object sender, CancelEventArgs e)
        {
            if (!e.Cancel)
            {
                if (_form.MdiParent == null || _method != AnimationMethod.Fade)
                {
                    NativeMethods.AnimateWindow(_form.Handle, _duration, AwHide | (int)_method | (int)_direction);
                }
            }
        }

    }
}
