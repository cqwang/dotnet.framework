using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;

namespace GDIDemo
{
    public partial class FontForm : Form
    {
        public FontForm()
        {
            InitializeComponent();
        }

        #region Events

        //字体对话框加载时的初始化处理
        private void FontForm_Load(object sender, System.EventArgs e)
        {
            string tmp = string.Empty;
            //获取所有已经安装的字体系列
            InstalledFontCollection installedFontCollection = new InstalledFontCollection();
            FontFamily[] fontfamily = installedFontCollection.Families;
            int index = 0;
            //访问fontfamily数组的每一个成员
            foreach (FontFamily i in fontfamily)
            {
                //在字体列表框中添加字体系列名
                this.FontlistBox.Items.Add(i.Name);
                index++;
            }

            //色彩色彩微调控件的取值范围：最大值
            FontColor_A.Maximum = 255;
            FontColor_R.Maximum = 255;
            FontColor_G.Maximum = 255;
            FontColor_B.Maximum = 255;
            //最小值
            FontColor_A.Minimum = 0;
            FontColor_R.Minimum = 0;
            FontColor_G.Minimum = 0;
            FontColor_B.Minimum = 0;
            //设置色彩默认值　
            this.FontColor_A.Value = 255;
            this.FontColor_R.Value = 0;
            this.FontColor_G.Value = 0;
            this.FontColor_B.Value = 0;
            //字体大小微调控件取值范围
            this.FontSize.Minimum = 1;
            this.FontSize.Maximum = 100;

            //默认的字体风格为常规
            this.FontStyle_Regular.Checked = true;
            //默认的字体单位为点
            this.FontUnit_Dot.Checked = true;
            //默认的字体大小为12
            this.FontSize.Value = 12;
            //默认的字体系列为列表框中的第一个列表项
            this.FontlistBox.SelectedIndex = 0;
            this.RedrawFontPreviewWindow();
        }

        private void FontlistBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.RedrawFontPreviewWindow();
        }
        //根据用户对字体设置的信息，在预览框中进行字体显示
        public void RedrawFontPreviewWindow()
        {
            //如果未选择字体系列名称
            if (this.FontlistBox.SelectedIndex == -1)
                return;
            //示例字体输出效果的显示区域　
            Rectangle textOut = new Rectangle(0, 0,
                this.FontPreview.Width, this.FontPreview.Height);

            Graphics graphics = this.FontPreview.CreateGraphics();
            graphics.Clear(this.FontPreview.BackColor);
            //获取当前已经选择的字体系列名称及字体大小
            string font_name = this.FontlistBox.Text;
            decimal font_size = this.FontSize.Value;

            //使用灰色线条绘制基准线，以10*10像素为单位
            Pen pen = new Pen(Color.Gray);
            //水平线
            for (int i = 0; i < textOut.Height; i += 10)
                graphics.DrawLine(pen, 0, i, textOut.Width, i);
            //垂直线
            for (int i = 0; i < textOut.Width; i += 10)
                graphics.DrawLine(pen, i, 0, i, textOut.Height);

            //获取当前已经选择的字体大小单位
            GraphicsUnit font_uint = GraphicsUnit.Point;
            if (this.FontUnit_Document.Checked)
                font_uint = GraphicsUnit.Document;

            if (this.FontUnit_Inch.Checked)
                font_uint = GraphicsUnit.Inch;

            if (this.FontUnit_Millimeter.Checked)
                font_uint = GraphicsUnit.Millimeter;

            if (this.FontUnit_Pixel.Checked)
                font_uint = GraphicsUnit.Pixel;

            if (this.FontUnit_Dot.Checked)
                font_uint = GraphicsUnit.Point;

            if (this.FontUnit_World.Checked)
                font_uint = GraphicsUnit.World;

            //获取当前已经选择的字体风格
            FontStyle font_style = FontStyle.Regular;
            if (this.FontStyle_Regular.Checked)
                font_style |= FontStyle.Regular;

            if (this.FontStyle_Bold.Checked)
                font_style |= FontStyle.Bold;

            if (this.FontStyle_Italic.Checked)
                font_style |= FontStyle.Italic;

            if (this.FontStyle_Strikeout.Checked)
                font_style |= FontStyle.Strikeout;

            if (this.FontStyle_Underline.Checked)
                font_style |= FontStyle.Underline;

            //获取选择的字体色彩
            Color basecolor = Color.FromArgb((int)this.FontColor_R.Value,
                (int)this.FontColor_G.Value, (int)this.FontColor_B.Value);
            //根据选择的色彩构造输出文本时使用的画刷
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb((int)this.FontColor_A.Value, basecolor));

            //根据选择的字体信息构造字体
            FontFamily fontFamily = new FontFamily(font_name);
            Font font = new Font(fontFamily,
                (int)font_size, (FontStyle)font_style, font_uint);

            //设置文本输出格式：居中
            StringFormat fmt = new StringFormat();
            fmt.Alignment = StringAlignment.Center;
            fmt.LineAlignment = StringAlignment.Center;

            //在字体示意区域输出文本
            graphics.DrawString("GDI+程序设计", font, solidBrush, textOut, fmt);
        }

        private void FontSize_ValueChanged(object sender, System.EventArgs e)
        {
            this.RedrawFontPreviewWindow();
        }

        private void FontColor_A_ValueChanged(object sender, System.EventArgs e)
        {
            this.RedrawFontPreviewWindow();
        }

        private void FontColor_R_ValueChanged(object sender, System.EventArgs e)
        {
            this.RedrawFontPreviewWindow();
        }

        private void FontColor_G_ValueChanged(object sender, System.EventArgs e)
        {
            this.RedrawFontPreviewWindow();
        }

        private void FontColor_B_ValueChanged(object sender, System.EventArgs e)
        {
            this.RedrawFontPreviewWindow();
        }

        private void FontStyle_Regular_CheckedChanged(object sender, System.EventArgs e)
        {
            this.RedrawFontPreviewWindow();
        }

        private void FontStyle_Bold_CheckedChanged(object sender, System.EventArgs e)
        {
            this.RedrawFontPreviewWindow();
        }

        private void FontStyle_Italic_CheckedChanged(object sender, System.EventArgs e)
        {
            this.RedrawFontPreviewWindow();
        }

        private void FontStyle_Underline_CheckedChanged(object sender, System.EventArgs e)
        {
            this.RedrawFontPreviewWindow();
        }

        private void FontStyle_Strikeout_CheckedChanged(object sender, System.EventArgs e)
        {
            this.RedrawFontPreviewWindow();
        }

        private void FontUnit_Dot_CheckedChanged(object sender, System.EventArgs e)
        {
            this.RedrawFontPreviewWindow();
        }

        private void FontUnit_Inch_CheckedChanged(object sender, System.EventArgs e)
        {
            this.RedrawFontPreviewWindow();
        }

        private void FontUnit_Pixel_CheckedChanged(object sender, System.EventArgs e)
        {
            this.RedrawFontPreviewWindow();
        }

        private void FontUnit_Millimeter_CheckedChanged(object sender, System.EventArgs e)
        {
            this.RedrawFontPreviewWindow();
        }

        private void FontUnit_Display_CheckedChanged(object sender, System.EventArgs e)
        {
            this.RedrawFontPreviewWindow();
        }

        private void FontUnit_Document_CheckedChanged(object sender, System.EventArgs e)
        {
            this.RedrawFontPreviewWindow();
        }

        private void FontUnit_World_CheckedChanged(object sender, System.EventArgs e)
        {
            this.RedrawFontPreviewWindow();
        }

        #endregion
    }
}
