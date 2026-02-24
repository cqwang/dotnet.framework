using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GDIDemo
{
    public partial class ImageForm : Form
    {
        Bitmap animatedImage = new Bitmap("SampleAnimation.gif");
        bool currentlyAnimating = false;

        public ImageForm()
        {
            InitializeComponent();
        }

        public void AnimateImage()
        {
            if (!currentlyAnimating)
            {
                ImageAnimator.Animate(animatedImage, new EventHandler(this.OnFrameChanged));
                currentlyAnimating = true;
            }
        }

        private void OnFrameChanged(object o, EventArgs e)
        {
            this.Invalidate();
        }

        private void ImageForm_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            //Begin the animation.
            AnimateImage();

            //Get the next frame ready for rendering.

            ImageAnimator.UpdateFrames();

            //Draw the next frame in the animation.

            e.Graphics.DrawImage(this.animatedImage, new Point(0, 0));

        }
    }
}
