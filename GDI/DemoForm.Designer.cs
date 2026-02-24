using System.Windows.Forms;
namespace GDIDemo
{
    partial class DemoForm
    {
        #region 菜单栏和菜单项
        private MainMenu mainMenu1;
        private MenuItem menuItem1;
        private MenuItem FadeInOut;
        private MenuItem GrayScale;
        private MenuItem Inverse;
        private MenuItem Emboss;
        private MenuItem CreatePenFromBrush;
        private MenuItem menuItem2;
        private MenuItem DashStyle_Custom;
        private MenuItem Pen_Align;
        private MenuItem Pen_Tranform;
        private MenuItem Pen_LineCap;
        private MenuItem Pen_TransColor;
        private MenuItem menuItem3;
        private MenuItem Brush_SolidBrush;
        private MenuItem Brush_FillVurve;
        private MenuItem Brush_HatchBrush;
        private MenuItem Brush_EnumAllStyle;
        private MenuItem Brush_SetRenderingOrigin;
        private MenuItem Brush_Texture;
        private MenuItem Brush_Texture_WrapMode;
        private MenuItem Brush_TextureTransform;
        private MenuItem Brush_GetTextureMatrix;
        private MenuItem Brush_LinearGradientBrush;
        private MenuItem Brush_LinearArrange;
        private MenuItem Brush_LinearGradientMode;
        private MenuItem Brush_LinearAngle;
        private MenuItem Brush_LinearInterpolation;
        private MenuItem Brush_LinearCustomize;
        private MenuItem menuItem7;
        private MenuItem menuItem6;
        private MenuItem menuItem5;
        private MenuItem menuItem10;
        private MenuItem Brush_LinearGradientBrush_BellShape;
        private MenuItem menuItem4;
        private MenuItem Brush_PathGradientBrush_Star;
        private MenuItem Brush_PathGradientBrush_Star2;
        private MenuItem Brush_Using_MorePathGradientBrush;
        private MenuItem Brush_PathGradientBrush_WrapMode;
        private MenuItem Brush_PathGradientBrush_CenterPoint;
        private MenuItem Brush_PathGradientBrush_InterpolationColors;
        private MenuItem Brsuh_PathGradietBrush_Focus;
        private MenuItem Brush_PathGradientBrush_Transform;
        private MenuItem Brsuh_LinearGradientBrush_UsingGamma;
        private MenuItem menuItem8;
        private MenuItem Font_UsingFontInGDIPlus;
        private MenuItem Font_EnumAllFonts;
        private MenuItem menuItem9;
        private MenuItem Font_EnhanceFontDialog;
        private MenuItem Font_UsingTextRenderHint;
        private MenuItem Font_Privatefontcollection;
        private MenuItem Font_Privatefontcollection2;
        private MenuItem Font_IsStyleAvailable;
        private MenuItem Font_Size;
        private MenuItem Font_BaseLine;
        private MenuItem Font_DrawString;
        private MenuItem Font_MeasureString;
        private MenuItem Font_MeasureString2;
        private MenuItem Font_ColumnTextOut;
        private MenuItem Font_StirngTrimming;
        private MenuItem Font_TextOutClip;
        private MenuItem Font_MeasureCharacterRanges;
        private MenuItem Font_TextoutDirection;
        private MenuItem Font_TextAlignment;
        private MenuItem Font_TextAlignment2;
        private MenuItem Font_TextoutUsingTabs;
        private MenuItem Font_UsingTabs;
        private MenuItem Font_TextoutHotkeyPrefix;
        private MenuItem Font_TextoutShadow;
        private MenuItem Font_TextoutHashline;
        private MenuItem Font_TextoutTexture;
        private MenuItem Font_TextoutGradient;
        private MenuItem Path_Construct;
        private MenuItem Path_AddLines;
        private MenuItem Path_CloseFigure;
        private MenuItem Path_FillPath;
        private MenuItem Path_AddSubPath;
        private MenuItem Path_GetSubPath;
        private MenuItem Path_GetPoints;
        private MenuItem Path_PathData;
        private MenuItem Path_ViewPointFLAG;
        private MenuItem Path_SubPathRange;
        private MenuItem Path＿Flatten;
        private MenuItem Path_Warp;
        private MenuItem Path_Transform;
        private MenuItem Path_Widen;
        private MenuItem Path_WidenDemo;
        private MenuItem Region＿FromPath;
        private MenuItem Region_Calculate;
        private MenuItem Region_GetRects;
        private MenuItem menuItem11;
        private MenuItem Transform;
        private MenuItem TranslateTransform;
        private MenuItem RotateTransform;
        private MenuItem DrawWatch;
        private MenuItem ScaleTransform;
        private MenuItem RectScale;
        private MenuItem FontRotate;
        private MenuItem Matrix_ListElements;
        private MenuItem MatrixPos;
        private MenuItem Martrix_Invert;
        private MenuItem Matrix_Multiply;
        private MenuItem Matrix_TransformPoints;
        private MenuItem Matrix_TransformPoints2;
        private MenuItem Matrix_TransformVectors;
        private MenuItem Matrix_RotateAt;
        private MenuItem Matrix_Shear;
        private MenuItem Matrix_TextoutShear;
        private MenuItem Matrix_ChangeFontHeight;
        private MenuItem menuItem12;
        private MenuItem ColorMatrix＿Start;
        private MenuItem TranslateColor;
        private MenuItem ScaleColor;
        private MenuItem RotateColor;
        private MenuItem ColorShear;
        private MenuItem ColorRemap;
        private MenuItem SetRGBOutputChannel;
        private MenuItem menuItem13;
        private MenuItem Metafile;
        private MenuItem CroppingAndScaling;
        private MenuItem UsingInterpolationMode;
        private MenuItem RotateFlip;
        private MenuItem ImageSkewing;
        private MenuItem Cubeimage;
        private MenuItem ThumbnailImage;
        private MenuItem Clone;
        private MenuItem Picturescale;
        private MenuItem menuItem15;
        private MenuItem ImageAttributesSetNoOp;
        private MenuItem SetColorMatrices;
        private MenuItem SetOutputChannelColorProfile;
        private MenuItem Gammaadjust;
        private MenuItem SetOutputChannel;
        private MenuItem Colorkey;
        private MenuItem Setthreshold;
        private MenuItem AdjustedPalette;
        private MenuItem SetWrapMode;
        private MenuItem menuItem16;
        private MenuItem ListAllImageEncoders;
        private MenuItem ListImageEncoder_Detail;
        private MenuItem ListImageDecoder;
        private MenuItem GetEncoderParameter;
        private MenuItem GetAllEncoderParameter;
        private MenuItem menuItem17;
        private MenuItem MultipleFrameImage;
        private MenuItem SaveBmp2tif;
        private MenuItem SaveBMP2JPG;
        private MenuItem TransformingJPEG;
        private MenuItem GetImageFromMultyFrame;
        private MenuItem QueryImage;
        private MenuItem SetProp;
        private MenuItem menuItem18;
        private MenuItem OnCanvas;
        private MenuItem OnWood;
        private MenuItem Flashligt;
        private MenuItem BlurAndSharpen;
        #endregion

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.CreatePenFromBrush = new System.Windows.Forms.MenuItem();
            this.DashStyle_Custom = new System.Windows.Forms.MenuItem();
            this.Pen_Align = new System.Windows.Forms.MenuItem();
            this.Pen_Tranform = new System.Windows.Forms.MenuItem();
            this.Pen_LineCap = new System.Windows.Forms.MenuItem();
            this.Pen_TransColor = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.Brush_SolidBrush = new System.Windows.Forms.MenuItem();
            this.Brush_FillVurve = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.Brush_HatchBrush = new System.Windows.Forms.MenuItem();
            this.Brush_EnumAllStyle = new System.Windows.Forms.MenuItem();
            this.Brush_SetRenderingOrigin = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.Brush_Texture = new System.Windows.Forms.MenuItem();
            this.Brush_Texture_WrapMode = new System.Windows.Forms.MenuItem();
            this.Brush_TextureTransform = new System.Windows.Forms.MenuItem();
            this.Brush_GetTextureMatrix = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.Brush_LinearGradientBrush = new System.Windows.Forms.MenuItem();
            this.Brush_LinearArrange = new System.Windows.Forms.MenuItem();
            this.Brush_LinearInterpolation = new System.Windows.Forms.MenuItem();
            this.Brush_LinearGradientMode = new System.Windows.Forms.MenuItem();
            this.Brush_LinearAngle = new System.Windows.Forms.MenuItem();
            this.Brush_LinearCustomize = new System.Windows.Forms.MenuItem();
            this.Brush_LinearGradientBrush_BellShape = new System.Windows.Forms.MenuItem();
            this.Brsuh_LinearGradientBrush_UsingGamma = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.Brush_PathGradientBrush_Star = new System.Windows.Forms.MenuItem();
            this.Brush_PathGradientBrush_Star2 = new System.Windows.Forms.MenuItem();
            this.Brush_Using_MorePathGradientBrush = new System.Windows.Forms.MenuItem();
            this.Brush_PathGradientBrush_WrapMode = new System.Windows.Forms.MenuItem();
            this.Brush_PathGradientBrush_CenterPoint = new System.Windows.Forms.MenuItem();
            this.Brush_PathGradientBrush_InterpolationColors = new System.Windows.Forms.MenuItem();
            this.Brsuh_PathGradietBrush_Focus = new System.Windows.Forms.MenuItem();
            this.Brush_PathGradientBrush_Transform = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.Font_UsingFontInGDIPlus = new System.Windows.Forms.MenuItem();
            this.Font_EnumAllFonts = new System.Windows.Forms.MenuItem();
            this.Font_EnhanceFontDialog = new System.Windows.Forms.MenuItem();
            this.Font_UsingTextRenderHint = new System.Windows.Forms.MenuItem();
            this.Font_Privatefontcollection = new System.Windows.Forms.MenuItem();
            this.Font_Privatefontcollection2 = new System.Windows.Forms.MenuItem();
            this.Font_IsStyleAvailable = new System.Windows.Forms.MenuItem();
            this.Font_Size = new System.Windows.Forms.MenuItem();
            this.Font_BaseLine = new System.Windows.Forms.MenuItem();
            this.Font_DrawString = new System.Windows.Forms.MenuItem();
            this.Font_MeasureString = new System.Windows.Forms.MenuItem();
            this.Font_MeasureString2 = new System.Windows.Forms.MenuItem();
            this.Font_ColumnTextOut = new System.Windows.Forms.MenuItem();
            this.Font_StirngTrimming = new System.Windows.Forms.MenuItem();
            this.Font_TextOutClip = new System.Windows.Forms.MenuItem();
            this.Font_MeasureCharacterRanges = new System.Windows.Forms.MenuItem();
            this.Font_TextoutDirection = new System.Windows.Forms.MenuItem();
            this.Font_TextAlignment = new System.Windows.Forms.MenuItem();
            this.Font_TextAlignment2 = new System.Windows.Forms.MenuItem();
            this.Font_TextoutUsingTabs = new System.Windows.Forms.MenuItem();
            this.Font_UsingTabs = new System.Windows.Forms.MenuItem();
            this.Font_TextoutHotkeyPrefix = new System.Windows.Forms.MenuItem();
            this.Font_TextoutShadow = new System.Windows.Forms.MenuItem();
            this.Font_TextoutHashline = new System.Windows.Forms.MenuItem();
            this.Font_TextoutTexture = new System.Windows.Forms.MenuItem();
            this.Font_TextoutGradient = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.Path_Construct = new System.Windows.Forms.MenuItem();
            this.Path_AddLines = new System.Windows.Forms.MenuItem();
            this.Path_CloseFigure = new System.Windows.Forms.MenuItem();
            this.Path_FillPath = new System.Windows.Forms.MenuItem();
            this.Path_AddSubPath = new System.Windows.Forms.MenuItem();
            this.Path_GetSubPath = new System.Windows.Forms.MenuItem();
            this.Path_GetPoints = new System.Windows.Forms.MenuItem();
            this.Path_PathData = new System.Windows.Forms.MenuItem();
            this.Path_ViewPointFLAG = new System.Windows.Forms.MenuItem();
            this.Path_SubPathRange = new System.Windows.Forms.MenuItem();
            this.Path＿Flatten = new System.Windows.Forms.MenuItem();
            this.Path_Warp = new System.Windows.Forms.MenuItem();
            this.Path_Transform = new System.Windows.Forms.MenuItem();
            this.Path_Widen = new System.Windows.Forms.MenuItem();
            this.Path_WidenDemo = new System.Windows.Forms.MenuItem();
            this.Region＿FromPath = new System.Windows.Forms.MenuItem();
            this.Region_Calculate = new System.Windows.Forms.MenuItem();
            this.Region_GetRects = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.Transform = new System.Windows.Forms.MenuItem();
            this.TranslateTransform = new System.Windows.Forms.MenuItem();
            this.RotateTransform = new System.Windows.Forms.MenuItem();
            this.DrawWatch = new System.Windows.Forms.MenuItem();
            this.ScaleTransform = new System.Windows.Forms.MenuItem();
            this.RectScale = new System.Windows.Forms.MenuItem();
            this.FontRotate = new System.Windows.Forms.MenuItem();
            this.Matrix_ListElements = new System.Windows.Forms.MenuItem();
            this.MatrixPos = new System.Windows.Forms.MenuItem();
            this.Martrix_Invert = new System.Windows.Forms.MenuItem();
            this.Matrix_Multiply = new System.Windows.Forms.MenuItem();
            this.Matrix_TransformPoints = new System.Windows.Forms.MenuItem();
            this.Matrix_TransformPoints2 = new System.Windows.Forms.MenuItem();
            this.Matrix_TransformVectors = new System.Windows.Forms.MenuItem();
            this.Matrix_RotateAt = new System.Windows.Forms.MenuItem();
            this.Matrix_Shear = new System.Windows.Forms.MenuItem();
            this.Matrix_TextoutShear = new System.Windows.Forms.MenuItem();
            this.Matrix_ChangeFontHeight = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.ColorMatrix＿Start = new System.Windows.Forms.MenuItem();
            this.TranslateColor = new System.Windows.Forms.MenuItem();
            this.ScaleColor = new System.Windows.Forms.MenuItem();
            this.RotateColor = new System.Windows.Forms.MenuItem();
            this.ColorShear = new System.Windows.Forms.MenuItem();
            this.ColorRemap = new System.Windows.Forms.MenuItem();
            this.SetRGBOutputChannel = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.Metafile = new System.Windows.Forms.MenuItem();
            this.CroppingAndScaling = new System.Windows.Forms.MenuItem();
            this.UsingInterpolationMode = new System.Windows.Forms.MenuItem();
            this.RotateFlip = new System.Windows.Forms.MenuItem();
            this.ImageSkewing = new System.Windows.Forms.MenuItem();
            this.Cubeimage = new System.Windows.Forms.MenuItem();
            this.ThumbnailImage = new System.Windows.Forms.MenuItem();
            this.Clone = new System.Windows.Forms.MenuItem();
            this.Picturescale = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.ImageAttributesSetNoOp = new System.Windows.Forms.MenuItem();
            this.SetColorMatrices = new System.Windows.Forms.MenuItem();
            this.SetOutputChannelColorProfile = new System.Windows.Forms.MenuItem();
            this.Gammaadjust = new System.Windows.Forms.MenuItem();
            this.SetOutputChannel = new System.Windows.Forms.MenuItem();
            this.Colorkey = new System.Windows.Forms.MenuItem();
            this.Setthreshold = new System.Windows.Forms.MenuItem();
            this.AdjustedPalette = new System.Windows.Forms.MenuItem();
            this.SetWrapMode = new System.Windows.Forms.MenuItem();
            this.menuItem16 = new System.Windows.Forms.MenuItem();
            this.ListAllImageEncoders = new System.Windows.Forms.MenuItem();
            this.ListImageEncoder_Detail = new System.Windows.Forms.MenuItem();
            this.ListImageDecoder = new System.Windows.Forms.MenuItem();
            this.GetEncoderParameter = new System.Windows.Forms.MenuItem();
            this.GetAllEncoderParameter = new System.Windows.Forms.MenuItem();
            this.menuItem17 = new System.Windows.Forms.MenuItem();
            this.SaveBmp2tif = new System.Windows.Forms.MenuItem();
            this.SaveBMP2JPG = new System.Windows.Forms.MenuItem();
            this.TransformingJPEG = new System.Windows.Forms.MenuItem();
            this.MultipleFrameImage = new System.Windows.Forms.MenuItem();
            this.GetImageFromMultyFrame = new System.Windows.Forms.MenuItem();
            this.QueryImage = new System.Windows.Forms.MenuItem();
            this.SetProp = new System.Windows.Forms.MenuItem();
            this.menuItem18 = new System.Windows.Forms.MenuItem();
            this.FadeInOut = new System.Windows.Forms.MenuItem();
            this.GrayScale = new System.Windows.Forms.MenuItem();
            this.Inverse = new System.Windows.Forms.MenuItem();
            this.Emboss = new System.Windows.Forms.MenuItem();
            this.OnCanvas = new System.Windows.Forms.MenuItem();
            this.OnWood = new System.Windows.Forms.MenuItem();
            this.Flashligt = new System.Windows.Forms.MenuItem();
            this.BlurAndSharpen = new System.Windows.Forms.MenuItem();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem2,
																					  this.menuItem3,
																					  this.menuItem8,
																					  this.menuItem9,
																					  this.menuItem11,
																					  this.menuItem12,
																					  this.menuItem13,
																					  this.menuItem15,
																					  this.menuItem16,
																					  this.menuItem18});
            this.menuItem1.Text = "GDI+编程";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.CreatePenFromBrush,
																					  this.DashStyle_Custom,
																					  this.Pen_Align,
																					  this.Pen_Tranform,
																					  this.Pen_LineCap,
																					  this.Pen_TransColor});
            this.menuItem2.Text = "画笔";
            // 
            // CreatePenFromBrush
            // 
            this.CreatePenFromBrush.Index = 0;
            this.CreatePenFromBrush.Text = "从画刷中构造画笔";
            this.CreatePenFromBrush.Click += new System.EventHandler(this.CreatePenFromBrush_Click);
            // 
            // DashStyle_Custom
            // 
            this.DashStyle_Custom.Index = 1;
            this.DashStyle_Custom.Text = "自定义线型";
            this.DashStyle_Custom.Click += new System.EventHandler(this.DashStyle_Custom_Click);
            // 
            // Pen_Align
            // 
            this.Pen_Align.Index = 2;
            this.Pen_Align.Text = "画笔的对齐方式";
            this.Pen_Align.Click += new System.EventHandler(this.Pen_Align_Click);
            // 
            // Pen_Tranform
            // 
            this.Pen_Tranform.Index = 3;
            this.Pen_Tranform.Text = "画笔的缩放与旋转";
            this.Pen_Tranform.Click += new System.EventHandler(this.Pen_Tranform_Click);
            // 
            // Pen_LineCap
            // 
            this.Pen_LineCap.Index = 4;
            this.Pen_LineCap.Text = "画笔的线帽属性";
            this.Pen_LineCap.Click += new System.EventHandler(this.Pen_LineCap_Click);
            // 
            // Pen_TransColor
            // 
            this.Pen_TransColor.Index = 5;
            this.Pen_TransColor.Text = "画笔的透明度支持";
            this.Pen_TransColor.Click += new System.EventHandler(this.Pen_TransColor_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem5,
																					  this.menuItem10,
																					  this.menuItem7,
																					  this.menuItem6,
																					  this.menuItem4});
            this.menuItem3.Text = "画刷";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 0;
            this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.Brush_SolidBrush,
																					  this.Brush_FillVurve});
            this.menuItem5.Text = "单色画刷的使用";
            // 
            // Brush_SolidBrush
            // 
            this.Brush_SolidBrush.Index = 0;
            this.Brush_SolidBrush.Text = "简单的单色画刷";
            this.Brush_SolidBrush.Click += new System.EventHandler(this.Brush_SolidBrush_Click);
            // 
            // Brush_FillVurve
            // 
            this.Brush_FillVurve.Index = 1;
            this.Brush_FillVurve.Text = "填充正叶曲线";
            this.Brush_FillVurve.Click += new System.EventHandler(this.Brush_FillVurve_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 1;
            this.menuItem10.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.Brush_HatchBrush,
																					   this.Brush_EnumAllStyle,
																					   this.Brush_SetRenderingOrigin});
            this.menuItem10.Text = "影线画刷的使用";
            // 
            // Brush_HatchBrush
            // 
            this.Brush_HatchBrush.Index = 0;
            this.Brush_HatchBrush.Text = "影线画刷";
            this.Brush_HatchBrush.Click += new System.EventHandler(this.Brush_HatchBrush_Click);
            // 
            // Brush_EnumAllStyle
            // 
            this.Brush_EnumAllStyle.Index = 1;
            this.Brush_EnumAllStyle.Text = "枚举所有影线画刷风格";
            this.Brush_EnumAllStyle.Click += new System.EventHandler(this.Brush_EnumAllStyle_Click);
            // 
            // Brush_SetRenderingOrigin
            // 
            this.Brush_SetRenderingOrigin.Index = 2;
            this.Brush_SetRenderingOrigin.Text = "设置绘制原点";
            this.Brush_SetRenderingOrigin.Click += new System.EventHandler(this.Brush_SetRenderingOrigin_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 2;
            this.menuItem7.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.Brush_Texture,
																					  this.Brush_Texture_WrapMode,
																					  this.Brush_TextureTransform,
																					  this.Brush_GetTextureMatrix});
            this.menuItem7.Text = "纹理画刷";
            // 
            // Brush_Texture
            // 
            this.Brush_Texture.Index = 0;
            this.Brush_Texture.Text = "纹理画刷的基本使用";
            this.Brush_Texture.Click += new System.EventHandler(this.Brush_Texture_Click);
            // 
            // Brush_Texture_WrapMode
            // 
            this.Brush_Texture_WrapMode.Index = 1;
            this.Brush_Texture_WrapMode.Text = "纹理画刷的排列方式";
            this.Brush_Texture_WrapMode.Click += new System.EventHandler(this.Brush_Texture_WrapMode_Click);
            // 
            // Brush_TextureTransform
            // 
            this.Brush_TextureTransform.Index = 2;
            this.Brush_TextureTransform.Text = "纹理画刷的变换";
            this.Brush_TextureTransform.Click += new System.EventHandler(this.Brush_TextureTransform_Click);
            // 
            // Brush_GetTextureMatrix
            // 
            this.Brush_GetTextureMatrix.Index = 3;
            this.Brush_GetTextureMatrix.Text = "查询画刷的变换信息";
            this.Brush_GetTextureMatrix.Click += new System.EventHandler(this.Brush_GetTextureMatrix_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 3;
            this.menuItem6.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.Brush_LinearGradientBrush,
																					  this.Brush_LinearArrange,
																					  this.Brush_LinearInterpolation,
																					  this.Brush_LinearGradientMode,
																					  this.Brush_LinearAngle,
																					  this.Brush_LinearCustomize,
																					  this.Brush_LinearGradientBrush_BellShape,
																					  this.Brsuh_LinearGradientBrush_UsingGamma});
            this.menuItem6.Text = "线性渐变画刷的使用";
            // 
            // Brush_LinearGradientBrush
            // 
            this.Brush_LinearGradientBrush.Index = 0;
            this.Brush_LinearGradientBrush.Text = "线性渐变画刷";
            this.Brush_LinearGradientBrush.Click += new System.EventHandler(this.Brush_LinearGradientBrush_Click);
            // 
            // Brush_LinearArrange
            // 
            this.Brush_LinearArrange.Index = 1;
            this.Brush_LinearArrange.Text = "渐变画刷的不同填充方式";
            this.Brush_LinearArrange.Click += new System.EventHandler(this.Brush_LinearArrange_Click);
            // 
            // Brush_LinearInterpolation
            // 
            this.Brush_LinearInterpolation.Index = 2;
            this.Brush_LinearInterpolation.Text = "多色渐变画刷";
            this.Brush_LinearInterpolation.Click += new System.EventHandler(this.Brush_LinearInterpolation_Click);
            // 
            // Brush_LinearGradientMode
            // 
            this.Brush_LinearGradientMode.Index = 3;
            this.Brush_LinearGradientMode.Text = "使用渐变画刷的渐变模式";
            this.Brush_LinearGradientMode.Click += new System.EventHandler(this.Brush_LinearGradientMode_Click);
            // 
            // Brush_LinearAngle
            // 
            this.Brush_LinearAngle.Index = 4;
            this.Brush_LinearAngle.Text = "调整渐变线偏转角度";
            this.Brush_LinearAngle.Click += new System.EventHandler(this.Brush_LinearAngle_Click);
            // 
            // Brush_LinearCustomize
            // 
            this.Brush_LinearCustomize.Index = 5;
            this.Brush_LinearCustomize.Text = "自定义线性渐变画刷的渐变过程";
            this.Brush_LinearCustomize.Click += new System.EventHandler(this.Brush_LinearCustomize_Click);
            // 
            // Brush_LinearGradientBrush_BellShape
            // 
            this.Brush_LinearGradientBrush_BellShape.Index = 6;
            this.Brush_LinearGradientBrush_BellShape.Text = "钟形曲线渐变";
            this.Brush_LinearGradientBrush_BellShape.Click += new System.EventHandler(this.Brush_LinearGradientBrush_BellShape_Click);
            // 
            // Brsuh_LinearGradientBrush_UsingGamma
            // 
            this.Brsuh_LinearGradientBrush_UsingGamma.Index = 7;
            this.Brsuh_LinearGradientBrush_UsingGamma.Text = "启用Gamma校正";
            this.Brsuh_LinearGradientBrush_UsingGamma.Click += new System.EventHandler(this.Brsuh_LinearGradientBrush_UsingGamma_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 4;
            this.menuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.Brush_PathGradientBrush_Star,
																					  this.Brush_PathGradientBrush_Star2,
																					  this.Brush_Using_MorePathGradientBrush,
																					  this.Brush_PathGradientBrush_WrapMode,
																					  this.Brush_PathGradientBrush_CenterPoint,
																					  this.Brush_PathGradientBrush_InterpolationColors,
																					  this.Brsuh_PathGradietBrush_Focus,
																					  this.Brush_PathGradientBrush_Transform});
            this.menuItem4.Text = "路径渐变画刷";
            // 
            // Brush_PathGradientBrush_Star
            // 
            this.Brush_PathGradientBrush_Star.Index = 0;
            this.Brush_PathGradientBrush_Star.Text = "构造五星";
            this.Brush_PathGradientBrush_Star.Click += new System.EventHandler(this.Brush_PathGradientBrush_Star_Click);
            // 
            // Brush_PathGradientBrush_Star2
            // 
            this.Brush_PathGradientBrush_Star2.Index = 1;
            this.Brush_PathGradientBrush_Star2.Text = "构造五星(2)";
            this.Brush_PathGradientBrush_Star2.Click += new System.EventHandler(this.Brush_PathGradientBrush_Star2_Click);
            // 
            // Brush_Using_MorePathGradientBrush
            // 
            this.Brush_Using_MorePathGradientBrush.Index = 2;
            this.Brush_Using_MorePathGradientBrush.Text = "使用不同的路径渐变画刷";
            this.Brush_Using_MorePathGradientBrush.Click += new System.EventHandler(this.Brush_Using_MorePathGradientBrush_Click);
            // 
            // Brush_PathGradientBrush_WrapMode
            // 
            this.Brush_PathGradientBrush_WrapMode.Index = 3;
            this.Brush_PathGradientBrush_WrapMode.Text = "路径渐变画刷的排列方式";
            this.Brush_PathGradientBrush_WrapMode.Click += new System.EventHandler(this.Brush_PathGradientBrush_WrapMode_Click);
            // 
            // Brush_PathGradientBrush_CenterPoint
            // 
            this.Brush_PathGradientBrush_CenterPoint.Index = 4;
            this.Brush_PathGradientBrush_CenterPoint.Text = "更改路径渐变画刷的中心点";
            this.Brush_PathGradientBrush_CenterPoint.Click += new System.EventHandler(this.Brush_PathGradientBrush_CenterPoint_Click);
            // 
            // Brush_PathGradientBrush_InterpolationColors
            // 
            this.Brush_PathGradientBrush_InterpolationColors.Index = 5;
            this.Brush_PathGradientBrush_InterpolationColors.Text = "使用多色渐变";
            this.Brush_PathGradientBrush_InterpolationColors.Click += new System.EventHandler(this.Brush_PathGradientBrush_InterpolationColors_Click);
            // 
            // Brsuh_PathGradietBrush_Focus
            // 
            this.Brsuh_PathGradietBrush_Focus.Index = 6;
            this.Brsuh_PathGradietBrush_Focus.Text = "更改画刷的焦点缩放比例";
            this.Brsuh_PathGradietBrush_Focus.Click += new System.EventHandler(this.Brsuh_PathGradietBrush_Focus_Click);
            // 
            // Brush_PathGradientBrush_Transform
            // 
            this.Brush_PathGradientBrush_Transform.Index = 7;
            this.Brush_PathGradientBrush_Transform.Text = "路径渐变画刷的变换";
            this.Brush_PathGradientBrush_Transform.Click += new System.EventHandler(this.Brush_PathGradientBrush_Transform_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 2;
            this.menuItem8.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.Font_UsingFontInGDIPlus,
																					  this.Font_EnumAllFonts,
																					  this.Font_EnhanceFontDialog,
																					  this.Font_UsingTextRenderHint,
																					  this.Font_Privatefontcollection,
																					  this.Font_Privatefontcollection2,
																					  this.Font_IsStyleAvailable,
																					  this.Font_Size,
																					  this.Font_BaseLine,
																					  this.Font_DrawString,
																					  this.Font_MeasureString,
																					  this.Font_MeasureString2,
																					  this.Font_ColumnTextOut,
																					  this.Font_StirngTrimming,
																					  this.Font_TextOutClip,
																					  this.Font_MeasureCharacterRanges,
																					  this.Font_TextoutDirection,
																					  this.Font_TextAlignment,
																					  this.Font_TextAlignment2,
																					  this.Font_TextoutUsingTabs,
																					  this.Font_UsingTabs,
																					  this.Font_TextoutHotkeyPrefix,
																					  this.Font_TextoutShadow,
																					  this.Font_TextoutHashline,
																					  this.Font_TextoutTexture,
																					  this.Font_TextoutGradient});
            this.menuItem8.Text = "文本与字体";
            // 
            // Font_UsingFontInGDIPlus
            // 
            this.Font_UsingFontInGDIPlus.Index = 0;
            this.Font_UsingFontInGDIPlus.Text = "在GDI+中使用字体(&A)";
            this.Font_UsingFontInGDIPlus.Click += new System.EventHandler(this.Font_UsingFontInGDIPlus_Click);
            // 
            // Font_EnumAllFonts
            // 
            this.Font_EnumAllFonts.Index = 1;
            this.Font_EnumAllFonts.Text = "获取已安装的字体";
            this.Font_EnumAllFonts.Click += new System.EventHandler(this.Font_EnumAllFonts_Click);
            // 
            // Font_EnhanceFontDialog
            // 
            this.Font_EnhanceFontDialog.Index = 2;
            this.Font_EnhanceFontDialog.Text = "增强型字体选择对话框";
            this.Font_EnhanceFontDialog.Click += new System.EventHandler(this.Font_EnhanceFontDialog_Click);
            // 
            // Font_UsingTextRenderHint
            // 
            this.Font_UsingTextRenderHint.Index = 3;
            this.Font_UsingTextRenderHint.Text = "设置字体的边缘处理方式";
            this.Font_UsingTextRenderHint.Click += new System.EventHandler(this.Font_UsingTextRenderHint_Click);
            // 
            // Font_Privatefontcollection
            // 
            this.Font_Privatefontcollection.Index = 4;
            this.Font_Privatefontcollection.Text = "使用私有字体集合";
            this.Font_Privatefontcollection.Click += new System.EventHandler(this.Font_Privatefontcollection_Click);
            // 
            // Font_Privatefontcollection2
            // 
            this.Font_Privatefontcollection2.Index = 5;
            this.Font_Privatefontcollection2.Text = "在私有字体集合中使用多个字体";
            this.Font_Privatefontcollection2.Click += new System.EventHandler(this.Font_Privatefontcollection2_Click);
            // 
            // Font_IsStyleAvailable
            // 
            this.Font_IsStyleAvailable.Index = 6;
            this.Font_IsStyleAvailable.Text = "在私有字体集合中检查字体信息的可用性";
            this.Font_IsStyleAvailable.Click += new System.EventHandler(this.Font_IsStyleAvailable_Click);
            // 
            // Font_Size
            // 
            this.Font_Size.Index = 7;
            this.Font_Size.Text = "在程序中访问字体(系列)的大小信息";
            this.Font_Size.Click += new System.EventHandler(this.Font_Size_Click);
            // 
            // Font_BaseLine
            // 
            this.Font_BaseLine.Index = 8;
            this.Font_BaseLine.Text = "设置文本输出的基线";
            this.Font_BaseLine.Click += new System.EventHandler(this.Font_BaseLine_Click);
            // 
            // Font_DrawString
            // 
            this.Font_DrawString.Index = 9;
            this.Font_DrawString.Text = "使用GDI+绘制文本";
            this.Font_DrawString.Click += new System.EventHandler(this.Font_DrawString_Click);
            // 
            // Font_MeasureString
            // 
            this.Font_MeasureString.Index = 10;
            this.Font_MeasureString.Text = "测量文本";
            this.Font_MeasureString.Click += new System.EventHandler(this.Font_MeasureString_Click);
            // 
            // Font_MeasureString2
            // 
            this.Font_MeasureString2.Index = 11;
            this.Font_MeasureString2.Text = "计算指定区域中能够显示的字符总数及行数";
            this.Font_MeasureString2.Click += new System.EventHandler(this.Font_MeasureString2_Click);
            // 
            // Font_ColumnTextOut
            // 
            this.Font_ColumnTextOut.Index = 12;
            this.Font_ColumnTextOut.Text = "实现文件的分栏显示";
            this.Font_ColumnTextOut.Click += new System.EventHandler(this.Font_ColumnTextOut_Click);
            // 
            // Font_StirngTrimming
            // 
            this.Font_StirngTrimming.Index = 13;
            this.Font_StirngTrimming.Text = "字符串的去尾";
            this.Font_StirngTrimming.Click += new System.EventHandler(this.Font_StirngTrimming_Click);
            // 
            // Font_TextOutClip
            // 
            this.Font_TextOutClip.Index = 14;
            this.Font_TextOutClip.Text = "文本输出的剪裁修正";
            this.Font_TextOutClip.Click += new System.EventHandler(this.Font_TextOutClip_Click);
            // 
            // Font_MeasureCharacterRanges
            // 
            this.Font_MeasureCharacterRanges.Index = 15;
            this.Font_MeasureCharacterRanges.Text = "测量文本的局部输出区域";
            this.Font_MeasureCharacterRanges.Click += new System.EventHandler(this.Font_MeasureCharacterRanges_Click);
            // 
            // Font_TextoutDirection
            // 
            this.Font_TextoutDirection.Index = 16;
            this.Font_TextoutDirection.Text = "控制文本输出方向";
            this.Font_TextoutDirection.Click += new System.EventHandler(this.Font_TextoutDirection_Click);
            // 
            // Font_TextAlignment
            // 
            this.Font_TextAlignment.Index = 17;
            this.Font_TextAlignment.Text = "设置文本对齐方式";
            this.Font_TextAlignment.Click += new System.EventHandler(this.Font_TextAlignment_Click);
            // 
            // Font_TextAlignment2
            // 
            this.Font_TextAlignment2.Index = 18;
            this.Font_TextAlignment2.Text = "设置文本对齐方式(2)";
            this.Font_TextAlignment2.Click += new System.EventHandler(this.Font_TextAlignment2_Click);
            // 
            // Font_TextoutUsingTabs
            // 
            this.Font_TextoutUsingTabs.Index = 19;
            this.Font_TextoutUsingTabs.Text = "设置和获取制表符信息";
            this.Font_TextoutUsingTabs.Click += new System.EventHandler(this.Font_TextoutUsingTabs_Click);
            // 
            // Font_UsingTabs
            // 
            this.Font_UsingTabs.Index = 20;
            this.Font_UsingTabs.Text = "使用制表位进行表格输出";
            this.Font_UsingTabs.Click += new System.EventHandler(this.Font_UsingTabs_Click);
            // 
            // Font_TextoutHotkeyPrefix
            // 
            this.Font_TextoutHotkeyPrefix.Index = 21;
            this.Font_TextoutHotkeyPrefix.Text = "快捷键前导字符显示";
            this.Font_TextoutHotkeyPrefix.Click += new System.EventHandler(this.Font_TextoutHotkeyPrefix_Click);
            // 
            // Font_TextoutShadow
            // 
            this.Font_TextoutShadow.Index = 22;
            this.Font_TextoutShadow.Text = "阴影字特效";
            this.Font_TextoutShadow.Click += new System.EventHandler(this.Font_TextoutShadow_Click);
            // 
            // Font_TextoutHashline
            // 
            this.Font_TextoutHashline.Index = 23;
            this.Font_TextoutHashline.Text = "使用影线画刷绘制文本";
            this.Font_TextoutHashline.Click += new System.EventHandler(this.Font_TextoutHashline_Click);
            // 
            // Font_TextoutTexture
            // 
            this.Font_TextoutTexture.Index = 24;
            this.Font_TextoutTexture.Text = "绘制纹理字";
            this.Font_TextoutTexture.Click += new System.EventHandler(this.Font_TextoutTexture_Click);
            // 
            // Font_TextoutGradient
            // 
            this.Font_TextoutGradient.Index = 25;
            this.Font_TextoutGradient.Text = "使用渐变画刷绘制文本";
            this.Font_TextoutGradient.Click += new System.EventHandler(this.Font_TextoutGradient_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 3;
            this.menuItem9.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.Path_Construct,
																					  this.Path_AddLines,
																					  this.Path_CloseFigure,
																					  this.Path_FillPath,
																					  this.Path_AddSubPath,
																					  this.Path_GetSubPath,
																					  this.Path_GetPoints,
																					  this.Path_PathData,
																					  this.Path_ViewPointFLAG,
																					  this.Path_SubPathRange,
																					  this.Path＿Flatten,
																					  this.Path_Warp,
																					  this.Path_Transform,
																					  this.Path_Widen,
																					  this.Path_WidenDemo,
																					  this.Region＿FromPath,
																					  this.Region_Calculate,
																					  this.Region_GetRects});
            this.menuItem9.Text = "路径和区域";
            this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
            // 
            // Path_Construct
            // 
            this.Path_Construct.Index = 0;
            this.Path_Construct.Text = "构造路径";
            this.Path_Construct.Click += new System.EventHandler(this.Path_Construct_Click);
            // 
            // Path_AddLines
            // 
            this.Path_AddLines.Index = 1;
            this.Path_AddLines.Text = "在路径中添加多条线段";
            this.Path_AddLines.Click += new System.EventHandler(this.Path_AddLines_Click);
            // 
            // Path_CloseFigure
            // 
            this.Path_CloseFigure.Index = 2;
            this.Path_CloseFigure.Text = "封闭图形";
            this.Path_CloseFigure.Click += new System.EventHandler(this.Path_CloseFigure_Click);
            // 
            // Path_FillPath
            // 
            this.Path_FillPath.Index = 3;
            this.Path_FillPath.Text = "路径的填充";
            this.Path_FillPath.Click += new System.EventHandler(this.Path_FillPath_Click);
            // 
            // Path_AddSubPath
            // 
            this.Path_AddSubPath.Index = 4;
            this.Path_AddSubPath.Text = "添加子路径";
            this.Path_AddSubPath.Click += new System.EventHandler(this.Path_AddSubPath_Click);
            // 
            // Path_GetSubPath
            // 
            this.Path_GetSubPath.Index = 5;
            this.Path_GetSubPath.Text = "GraphicsPathIterator的基本使用";
            this.Path_GetSubPath.Click += new System.EventHandler(this.Path_GetSubPath_Click);
            // 
            // Path_GetPoints
            // 
            this.Path_GetPoints.Index = 6;
            this.Path_GetPoints.Text = "访问路径的点信息";
            this.Path_GetPoints.Click += new System.EventHandler(this.Path_GetPoints_Click);
            // 
            // Path_PathData
            // 
            this.Path_PathData.Index = 7;
            this.Path_PathData.Text = "同时获取端点坐标及类型信息";
            this.Path_PathData.Click += new System.EventHandler(this.Path_PathData_Click);
            // 
            // Path_ViewPointFLAG
            // 
            this.Path_ViewPointFLAG.Index = 8;
            this.Path_ViewPointFLAG.Text = "查看路径端点的标记信息";
            this.Path_ViewPointFLAG.Click += new System.EventHandler(this.Path_ViewPointFLAG_Click);
            // 
            // Path_SubPathRange
            // 
            this.Path_SubPathRange.Index = 9;
            this.Path_SubPathRange.Text = "标记路径区间";
            this.Path_SubPathRange.Click += new System.EventHandler(this.Path_SubPathRange_Click);
            // 
            // Path＿Flatten
            // 
            this.Path＿Flatten.Index = 10;
            this.Path＿Flatten.Text = "路径的展平";
            this.Path＿Flatten.Click += new System.EventHandler(this.Path＿Flatten_Click);
            // 
            // Path_Warp
            // 
            this.Path_Warp.Index = 11;
            this.Path_Warp.Text = "路径的扭曲";
            this.Path_Warp.Click += new System.EventHandler(this.Path_Warp_Click);
            // 
            // Path_Transform
            // 
            this.Path_Transform.Index = 12;
            this.Path_Transform.Text = "路径的线性变换";
            this.Path_Transform.Click += new System.EventHandler(this.Path_Transform_Click);
            // 
            // Path_Widen
            // 
            this.Path_Widen.Index = 13;
            this.Path_Widen.Text = "路径的拓宽";
            this.Path_Widen.Click += new System.EventHandler(this.Path_Widen_Click);
            // 
            // Path_WidenDemo
            // 
            this.Path_WidenDemo.Index = 14;
            this.Path_WidenDemo.Text = "路径的拓宽处理原理演示";
            this.Path_WidenDemo.Click += new System.EventHandler(this.Path_WidenDemo_Click);
            // 
            // Region＿FromPath
            // 
            this.Region＿FromPath.Index = 15;
            this.Region＿FromPath.Text = "从路径中创建文本区域";
            this.Region＿FromPath.Click += new System.EventHandler(this.Region＿FromPath_Click);
            // 
            // Region_Calculate
            // 
            this.Region_Calculate.Index = 16;
            this.Region_Calculate.Text = "区域的运算";
            this.Region_Calculate.Click += new System.EventHandler(this.Region_Calculate_Click);
            // 
            // Region_GetRects
            // 
            this.Region_GetRects.Index = 17;
            this.Region_GetRects.Text = "获取区域的组成矩形集";
            this.Region_GetRects.Click += new System.EventHandler(this.Region_GetRects_Click);
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 4;
            this.menuItem11.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.Transform,
																					   this.TranslateTransform,
																					   this.RotateTransform,
																					   this.DrawWatch,
																					   this.ScaleTransform,
																					   this.RectScale,
																					   this.FontRotate,
																					   this.Matrix_ListElements,
																					   this.MatrixPos,
																					   this.Martrix_Invert,
																					   this.Matrix_Multiply,
																					   this.Matrix_TransformPoints,
																					   this.Matrix_TransformPoints2,
																					   this.Matrix_TransformVectors,
																					   this.Matrix_RotateAt,
																					   this.Matrix_Shear,
																					   this.Matrix_TextoutShear,
																					   this.Matrix_ChangeFontHeight});
            this.menuItem11.Text = "GDI+的坐标变换";
            // 
            // Transform
            // 
            this.Transform.Index = 0;
            this.Transform.Text = "在GDI+使用坐标变换";
            this.Transform.Click += new System.EventHandler(this.Transform_Click);
            // 
            // TranslateTransform
            // 
            this.TranslateTransform.Index = 1;
            this.TranslateTransform.Text = "平移变换的实现";
            this.TranslateTransform.Click += new System.EventHandler(this.TranslateTransform_Click);
            // 
            // RotateTransform
            // 
            this.RotateTransform.Index = 2;
            this.RotateTransform.Text = "旋转图片";
            this.RotateTransform.Click += new System.EventHandler(this.RotateTransform_Click);
            // 
            // DrawWatch
            // 
            this.DrawWatch.Index = 3;
            this.DrawWatch.Text = "汽车里程表的绘制";
            this.DrawWatch.Click += new System.EventHandler(this.DrawWatch_Click);
            // 
            // ScaleTransform
            // 
            this.ScaleTransform.Index = 4;
            this.ScaleTransform.Text = "缩放变换的使用";
            this.ScaleTransform.Click += new System.EventHandler(this.ScaleTransform_Click);
            // 
            // RectScale
            // 
            this.RectScale.Index = 5;
            this.RectScale.Text = "矩形对象的缩放";
            this.RectScale.Click += new System.EventHandler(this.RectScale_Click);
            // 
            // FontRotate
            // 
            this.FontRotate.Index = 6;
            this.FontRotate.Text = "在GDI+中旋转输出文本";
            this.FontRotate.Click += new System.EventHandler(this.FontRotate_Click);
            // 
            // Matrix_ListElements
            // 
            this.Matrix_ListElements.Index = 7;
            this.Matrix_ListElements.Text = "查看矩阵的组成元素";
            this.Matrix_ListElements.Click += new System.EventHandler(this.Matrix_ListElements_Click_1);
            // 
            // MatrixPos
            // 
            this.MatrixPos.Index = 8;
            this.MatrixPos.Text = "使用矩阵的前置与后缀";
            this.MatrixPos.Click += new System.EventHandler(this.MatrixPos_Click);
            // 
            // Martrix_Invert
            // 
            this.Martrix_Invert.Index = 9;
            this.Martrix_Invert.Text = "逆矩阵在变换中的运用";
            this.Martrix_Invert.Click += new System.EventHandler(this.Martrix_Invert_Click);
            // 
            // Matrix_Multiply
            // 
            this.Matrix_Multiply.Index = 10;
            this.Matrix_Multiply.Text = "使用复合变换";
            this.Matrix_Multiply.Click += new System.EventHandler(this.Matrix_Multiply_Click);
            // 
            // Matrix_TransformPoints
            // 
            this.Matrix_TransformPoints.Index = 11;
            this.Matrix_TransformPoints.Text = "使用矩阵批量修改点信息\r\n \r\n";
            this.Matrix_TransformPoints.Click += new System.EventHandler(this.Matrix_TransformPoints_Click);
            // 
            // Matrix_TransformPoints2
            // 
            this.Matrix_TransformPoints2.Index = 12;
            this.Matrix_TransformPoints2.Text = "使用TransformPoints函数实现路径的变换\r\n \r\n";
            this.Matrix_TransformPoints2.Click += new System.EventHandler(this.Matrix_TransformPoints2_Click);
            // 
            // Matrix_TransformVectors
            // 
            this.Matrix_TransformVectors.Index = 13;
            this.Matrix_TransformVectors.Text = "普通矩阵运算与二维向量的矩阵运算";
            this.Matrix_TransformVectors.Click += new System.EventHandler(this.Matrix_TransformVectors_Click);
            // 
            // Matrix_RotateAt
            // 
            this.Matrix_RotateAt.Index = 14;
            this.Matrix_RotateAt.Text = "使用RotateAt函数";
            this.Matrix_RotateAt.Click += new System.EventHandler(this.Matrix_RotateAt_Click);
            // 
            // Matrix_Shear
            // 
            this.Matrix_Shear.Index = 15;
            this.Matrix_Shear.Text = "使用不同的投射变换显示图片";
            this.Matrix_Shear.Click += new System.EventHandler(this.Matrix_Shear_Click);
            // 
            // Matrix_TextoutShear
            // 
            this.Matrix_TextoutShear.Index = 16;
            this.Matrix_TextoutShear.Text = "投影字的特效输出";
            this.Matrix_TextoutShear.Click += new System.EventHandler(this.Matrix_TextoutShear_Click);
            // 
            // Matrix_ChangeFontHeight
            // 
            this.Matrix_ChangeFontHeight.Index = 17;
            this.Matrix_ChangeFontHeight.Text = "文字大小渐变输出特效";
            this.Matrix_ChangeFontHeight.Click += new System.EventHandler(this.Matrix_ChangeFontHeight_Click);
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 5;
            this.menuItem12.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.ColorMatrix＿Start,
																					   this.TranslateColor,
																					   this.ScaleColor,
																					   this.RotateColor,
																					   this.ColorShear,
																					   this.ColorRemap,
																					   this.SetRGBOutputChannel});
            this.menuItem12.Text = "GDI+的色彩变换";
            // 
            // ColorMatrix＿Start
            // 
            this.ColorMatrix＿Start.Index = 0;
            this.ColorMatrix＿Start.Text = "启用色彩变换矩阵";
            this.ColorMatrix＿Start.Click += new System.EventHandler(this.ColorMatrix＿Start_Click);
            // 
            // TranslateColor
            // 
            this.TranslateColor.Index = 1;
            this.TranslateColor.Text = "色彩平移运算";
            this.TranslateColor.Click += new System.EventHandler(this.TranslateColor_Click);
            // 
            // ScaleColor
            // 
            this.ScaleColor.Index = 2;
            this.ScaleColor.Text = "色彩的缩放运算";
            this.ScaleColor.Click += new System.EventHandler(this.ScaleColor_Click);
            // 
            // RotateColor
            // 
            this.RotateColor.Index = 3;
            this.RotateColor.Text = "色彩的三种旋转方式";
            this.RotateColor.Click += new System.EventHandler(this.RotateColor_Click);
            // 
            // ColorShear
            // 
            this.ColorShear.Index = 4;
            this.ColorShear.Text = "色彩的投射变换";
            this.ColorShear.Click += new System.EventHandler(this.ColorShear_Click);
            // 
            // ColorRemap
            // 
            this.ColorRemap.Index = 5;
            this.ColorRemap.Text = "色彩映射的程序实现";
            this.ColorRemap.Click += new System.EventHandler(this.ColorRemap_Click);
            // 
            // SetRGBOutputChannel
            // 
            this.SetRGBOutputChannel.Index = 6;
            this.SetRGBOutputChannel.Text = "使用色彩变换矩阵实现色彩输出通道";
            this.SetRGBOutputChannel.Click += new System.EventHandler(this.SetRGBOutputChannel_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 6;
            this.menuItem13.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.Metafile,
																					   this.CroppingAndScaling,
																					   this.UsingInterpolationMode,
																					   this.RotateFlip,
																					   this.ImageSkewing,
																					   this.Cubeimage,
																					   this.ThumbnailImage,
																					   this.Clone,
																					   this.Picturescale});
            this.menuItem13.Text = "图像的基本处理";
            // 
            // Metafile
            // 
            this.Metafile.Index = 0;
            this.Metafile.Text = "图元文件中的记录与回放";
            this.Metafile.Click += new System.EventHandler(this.Metafile_Click);
            // 
            // CroppingAndScaling
            // 
            this.CroppingAndScaling.Index = 1;
            this.CroppingAndScaling.Text = "图形的剪裁与缩放";
            this.CroppingAndScaling.Click += new System.EventHandler(this.CroppingAndScaling_Click);
            // 
            // UsingInterpolationMode
            // 
            this.UsingInterpolationMode.Index = 2;
            this.UsingInterpolationMode.Text = "使用不同的插值模式控制图形缩放质量";
            this.UsingInterpolationMode.Click += new System.EventHandler(this.UsingInterpolationMode_Click);
            // 
            // RotateFlip
            // 
            this.RotateFlip.Index = 3;
            this.RotateFlip.Text = "绘制镜像图片示例";
            this.RotateFlip.Click += new System.EventHandler(this.RotateFlip_Click);
            // 
            // ImageSkewing
            // 
            this.ImageSkewing.Index = 4;
            this.ImageSkewing.Text = "绘制映射图片";
            this.ImageSkewing.Click += new System.EventHandler(this.ImageSkewing_Click);
            // 
            // Cubeimage
            // 
            this.Cubeimage.Index = 5;
            this.Cubeimage.Text = "立方体贴图";
            this.Cubeimage.Click += new System.EventHandler(this.Cubeimage_Click);
            // 
            // ThumbnailImage
            // 
            this.ThumbnailImage.Index = 6;
            this.ThumbnailImage.Text = "GDI+中处理缩略图";
            this.ThumbnailImage.Click += new System.EventHandler(this.ThumbnailImage_Click);
            // 
            // Clone
            // 
            this.Clone.Index = 7;
            this.Clone.Text = "分块显示图片";
            this.Clone.Click += new System.EventHandler(this.Clone_Click);
            // 
            // Picturescale
            // 
            this.Picturescale.Index = 8;
            this.Picturescale.Text = "图片局部放大(缩小)显示";
            this.Picturescale.Click += new System.EventHandler(this.Picturescale_Click);
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 7;
            this.menuItem15.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.ImageAttributesSetNoOp,
																					   this.SetColorMatrices,
																					   this.SetOutputChannelColorProfile,
																					   this.Gammaadjust,
																					   this.SetOutputChannel,
																					   this.Colorkey,
																					   this.Setthreshold,
																					   this.AdjustedPalette,
																					   this.SetWrapMode});
            this.menuItem15.Text = "图像色彩信息的调整";
            // 
            // ImageAttributesSetNoOp
            // 
            this.ImageAttributesSetNoOp.Index = 0;
            this.ImageAttributesSetNoOp.Text = "色彩校正的启用与禁用";
            this.ImageAttributesSetNoOp.Click += new System.EventHandler(this.ImageAttributesSetNoOp_Click);
            // 
            // SetColorMatrices
            // 
            this.SetColorMatrices.Index = 1;
            this.SetColorMatrices.Text = "设置不同的色彩调整对象";
            this.SetColorMatrices.Click += new System.EventHandler(this.SetColorMatrices_Click);
            // 
            // SetOutputChannelColorProfile
            // 
            this.SetOutputChannelColorProfile.Index = 2;
            this.SetOutputChannelColorProfile.Text = "使用色彩配置文件进行色彩校正";
            this.SetOutputChannelColorProfile.Click += new System.EventHandler(this.SetOutputChannelColorProfile_Click);
            // 
            // Gammaadjust
            // 
            this.Gammaadjust.Index = 3;
            this.Gammaadjust.Text = "修改Gamma值进行图片输出";
            this.Gammaadjust.Click += new System.EventHandler(this.Gammaadjust_Click);
            // 
            // SetOutputChannel
            // 
            this.SetOutputChannel.Index = 4;
            this.SetOutputChannel.Text = "设置色彩输出通道";
            this.SetOutputChannel.Click += new System.EventHandler(this.SetOutputChannel_Click);
            // 
            // Colorkey
            // 
            this.Colorkey.Index = 5;
            this.Colorkey.Text = "使用关键色";
            this.Colorkey.Click += new System.EventHandler(this.Colorkey_Click);
            // 
            // Setthreshold
            // 
            this.Setthreshold.Index = 6;
            this.Setthreshold.Text = "阈值运用演示程序";
            this.Setthreshold.Click += new System.EventHandler(this.Setthreshold_Click);
            // 
            // AdjustedPalette
            // 
            this.AdjustedPalette.Index = 7;
            this.AdjustedPalette.Text = "获取色彩校正调色板";
            this.AdjustedPalette.Click += new System.EventHandler(this.AdjustedPalette_Click);
            // 
            // SetWrapMode
            // 
            this.SetWrapMode.Index = 8;
            this.SetWrapMode.Text = "设置色彩校正的环绕模式和颜色";
            this.SetWrapMode.Click += new System.EventHandler(this.SetWrapMode_Click);
            // 
            // menuItem16
            // 
            this.menuItem16.Index = 8;
            this.menuItem16.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.ListAllImageEncoders,
																					   this.ListImageEncoder_Detail,
																					   this.ListImageDecoder,
																					   this.GetEncoderParameter,
																					   this.GetAllEncoderParameter,
																					   this.menuItem17,
																					   this.SaveBmp2tif,
																					   this.SaveBMP2JPG,
																					   this.TransformingJPEG,
																					   this.MultipleFrameImage,
																					   this.GetImageFromMultyFrame,
																					   this.QueryImage,
																					   this.SetProp});
            this.menuItem16.Text = "图形的编码与解码";
            // 
            // ListAllImageEncoders
            // 
            this.ListAllImageEncoders.Index = 0;
            this.ListAllImageEncoders.Text = "输出编码器信息";
            this.ListAllImageEncoders.Click += new System.EventHandler(this.ListAllImageEncoders_Click);
            // 
            // ListImageEncoder_Detail
            // 
            this.ListImageEncoder_Detail.Index = 1;
            this.ListImageEncoder_Detail.Text = "输出编码器信息";
            this.ListImageEncoder_Detail.Click += new System.EventHandler(this.ListImageEncoder_Detail_Click);
            // 
            // ListImageDecoder
            // 
            this.ListImageDecoder.Index = 2;
            this.ListImageDecoder.Text = "列出系统可用的解码器信息";
            this.ListImageDecoder.Click += new System.EventHandler(this.ListImageDecoder_Click);
            // 
            // GetEncoderParameter
            // 
            this.GetEncoderParameter.Index = 3;
            this.GetEncoderParameter.Text = "查看将位图保存为JPEG时需要设置的参数信息";
            this.GetEncoderParameter.Click += new System.EventHandler(this.GetEncoderParameter_Click);
            // 
            // GetAllEncoderParameter
            // 
            this.GetAllEncoderParameter.Index = 4;
            this.GetAllEncoderParameter.Text = "查看所有的编码信息所需的参数列表";
            this.GetAllEncoderParameter.Click += new System.EventHandler(this.GetAllEncoderParameter_Click);
            // 
            // menuItem17
            // 
            this.menuItem17.Index = 5;
            this.menuItem17.Text = "将BMP文件另存为PNG格式的文件";
            this.menuItem17.Click += new System.EventHandler(this.menuItem17_Click);
            // 
            // SaveBmp2tif
            // 
            this.SaveBmp2tif.Index = 6;
            this.SaveBmp2tif.Text = "将BMP文件保存为TIF文件";
            this.SaveBmp2tif.Click += new System.EventHandler(this.SaveBmp2tif_Click);
            // 
            // SaveBMP2JPG
            // 
            this.SaveBMP2JPG.Index = 7;
            this.SaveBMP2JPG.Text = "使用不同的压缩质量保存JPEG文件";
            this.SaveBMP2JPG.Click += new System.EventHandler(this.SaveBMP2JPG_Click);
            // 
            // TransformingJPEG
            // 
            this.TransformingJPEG.Index = 8;
            this.TransformingJPEG.Text = "JPEG文件的保存与变换";
            this.TransformingJPEG.Click += new System.EventHandler(this.TransformingJPEG_Click);
            // 
            // MultipleFrameImage
            // 
            this.MultipleFrameImage.Index = 9;
            this.MultipleFrameImage.Text = "保存多帧图片";
            this.MultipleFrameImage.Click += new System.EventHandler(this.MultipleFrameImage_Click);
            // 
            // GetImageFromMultyFrame
            // 
            this.GetImageFromMultyFrame.Index = 10;
            this.GetImageFromMultyFrame.Text = "读取多帧图片的子图片";
            this.GetImageFromMultyFrame.Click += new System.EventHandler(this.GetImageFromMultyFrame_Click);
            // 
            // QueryImage
            // 
            this.QueryImage.Index = 11;
            this.QueryImage.Text = "获取图像属性列表";
            this.QueryImage.Click += new System.EventHandler(this.QueryImage_Click);
            // 
            // SetProp
            // 
            this.SetProp.Index = 12;
            this.SetProp.Text = "修改图片属性";
            this.SetProp.Click += new System.EventHandler(this.SetProp_Click);
            // 
            // menuItem18
            // 
            this.menuItem18.Index = 9;
            this.menuItem18.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.FadeInOut,
																					   this.GrayScale,
																					   this.Inverse,
																					   this.Emboss,
																					   this.OnCanvas,
																					   this.OnWood,
																					   this.Flashligt,
																					   this.BlurAndSharpen});
            this.menuItem18.Text = "图形特技处理";
            // 
            // FadeInOut
            // 
            this.FadeInOut.Index = 0;
            this.FadeInOut.Text = "淡入浅出";
            this.FadeInOut.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // GrayScale
            // 
            this.GrayScale.Index = 1;
            this.GrayScale.Text = "灰度处理与还原";
            this.GrayScale.Click += new System.EventHandler(this.GrayScale_Click);
            // 
            // Inverse
            // 
            this.Inverse.Index = 2;
            this.Inverse.Text = "底片(负片)滤镜";
            this.Inverse.Click += new System.EventHandler(this.Inverse_Click);
            // 
            // Emboss
            // 
            this.Emboss.Index = 3;
            this.Emboss.Text = "浮雕及雕刻";
            this.Emboss.Click += new System.EventHandler(this.Emboss_Click);
            // 
            // OnCanvas
            // 
            this.OnCanvas.Index = 4;
            this.OnCanvas.Text = "油画效果的制作";
            this.OnCanvas.Click += new System.EventHandler(this.OnCanvas_Click);
            // 
            // OnWood
            // 
            this.OnWood.Index = 5;
            this.OnWood.Text = "木刻滤镜";
            this.OnWood.Click += new System.EventHandler(this.OnWood_Click);
            // 
            // Flashligt
            // 
            this.Flashligt.Index = 6;
            this.Flashligt.Text = "强光照射滤镜";
            this.Flashligt.Click += new System.EventHandler(this.Flashligt_Click);
            // 
            // BlurAndSharpen
            // 
            this.BlurAndSharpen.Index = 7;
            this.BlurAndSharpen.Text = "柔化与锐化滤镜";
            this.BlurAndSharpen.Click += new System.EventHandler(this.BlurAndSharpen_Click);

            //DemoForm
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(560, 313);
            this.Menu = this.mainMenu1;
            this.Name = "DemoForm";
            this.Text = "DemoForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Resize += new System.EventHandler(this.DemoForm_Resize);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DemoForm_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        #endregion
    }
}