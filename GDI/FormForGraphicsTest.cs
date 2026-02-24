using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace GDIDemo
{
    public partial class FormForGraphicsTest : Form
    {
        public FormForGraphicsTest()
        {
            InitializeComponent();
            //说明：当控件大小小于要绘制的图像时，图像会显示不完整。
            this.button1.Width = 200;
            this.button1.Height = 80;
        }

        /// <summary>
        /// 控件重绘操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Paint(object sender, PaintEventArgs e)
        {
            //this.button1.Text = "自动触发控件重绘";
            //e.Graphics.DrawEllipse(Pens.Red, 50, 50, 50, 50);
        }

        /// <summary>
        /// 窗体重绘操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormForGraphicsTest_Paint(object sender, PaintEventArgs e)
        {
            this.Text = "自动触发窗体重绘";
            e.Graphics.DrawEllipse(Pens.Red, 50, 50, 50, 50);

            //画笔
            Pen p = new Pen(Color.Blue, 2);

            Rectangle rec = new Rectangle(120, 120, 100, 150);
            e.Graphics.DrawEllipse(p, rec);
            //画刷
            Brush yellowBrush = new SolidBrush(Color.Yellow);
            e.Graphics.FillEllipse(yellowBrush, rec);
            
            e.Graphics.DrawLine(p, 10, 10, 100, 100);//直线
            e.Graphics.DrawRectangle(p, 10, 10, 100, 100);//矩形
            e.Graphics.DrawEllipse(p, 10, 10, 100, 100);//椭圆

            //剪切板矩形
            if (e.ClipRectangle.Top < 60 && e.ClipRectangle.Left < 60 
                && e.ClipRectangle.Bottom > 100 && e.ClipRectangle.Right>100)
            {
                p = new Pen(Color.Green, 5);
                e.Graphics.DrawRectangle(p, 100, 100, 100, 100);
            }
        }

        /// <summary>
        /// 重写窗体的绘图方法
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            //this.Text = "自动触发窗体重绘";
            //e.Graphics.DrawEllipse(Pens.Red, 50, 50, 50, 50);
            base.OnPaint(e);
        }

        /// <summary>
        /// 控件Click事件（只有去除相应窗体或控件的重绘代码，才能显示该事件绘图效果）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Text = "响应事件，绘制图形";
            this.Text = "响应事件，绘制图形";
            using (Graphics buttonGraphics = this.button1.CreateGraphics(), formGraphics = this.CreateGraphics())
            {
                buttonGraphics.DrawEllipse(Pens.Red, 50, 50, 50, 50);
                formGraphics.DrawEllipse(Pens.Red, 50, 50, 50, 50);
            }
        }

        /// <summary>
        /// 控件Click事件，用于更改已存在的图像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = @"..\..\Images\test.jpg";
                int len = DateTime.Now.Second;

                Bitmap tempMap = new Bitmap(fileName);
                Bitmap bitMap = new Bitmap(tempMap);
                tempMap.Dispose();

                using(Graphics g = Graphics.FromImage(bitMap))
                {
                    g.DrawEllipse(Pens.Red, len, len, len, len);
                }
                bitMap.Save(fileName);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
 

            
        }
    }
}
