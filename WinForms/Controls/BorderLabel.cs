/***********************************************************************
 * BorderLabel.cs - Simple Label Control with Border Effect            *
 *                                                                     *
 *   Author:      César Roberto de Souza                               *
 *   Email:       cesarsouza at gmail.com                              *
 *   Website:     http://www.comp.ufscar.br/~cesarsouza                *
 *                                                                     *      
 *  This code is distributed under the The Code Project Open License   *
 *  (CPOL) 1.02 or any later versions of this same license. By using   *
 *  this code you agree not to remove any of the original copyright,   *
 *  patent, trademark, and attribution notices and associated          *
 *  disclaimers that may appear in the Source Code or Executable Files *
 *                                                                     *
 *  The exact terms of this license can be found on The Code Project   *
 *   website: http://www.codeproject.com/info/cpol10.aspx              *
 *                                                                     *
 ***********************************************************************/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Text;
using System.Windows.Forms;


namespace cSouza.WinForms.Controls
{

    /// <summary>
    ///   Represents a Bordered label.
    /// </summary>
    public class BorderLabel : Label
    {
        private const string SizeTag = @"@#$";

        private float borderSize;
        private Color borderColor;

        private Pen drawPen;
        private SolidBrush forecolorBrush;

        private List<Tuple<string, float>> _texts = new List<Tuple<string,float>>();



        // Constructor
        //-----------------------------------------------------

        #region Constructor
        /// <summary>
        ///   Constructs a new BorderLabel object.
        /// </summary>
        public BorderLabel()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            this.borderSize = 1f;
            this.borderColor = Color.White;
            this.drawPen = new Pen(new SolidBrush(this.borderColor), borderSize);
            this.forecolorBrush = new SolidBrush(this.ForeColor);

            this.Invalidate();
        }
        #endregion



        // Public Properties
        //-----------------------------------------------------

        #region Public Properties

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                _texts = Parse(value);
            }
        }

        /// <summary>
        ///   The border's thickness
        /// </summary>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("The border's thickness")]
        [DefaultValue(1f)]
        public float BorderSize
        {
            get { return this.borderSize; }
            set
            {
                this.borderSize = value;
                if (value == 0)
                {
                    //If border size equals zero, disable the
                    // border by setting it as transparent
                    this.drawPen.Color = Color.Transparent;
                }
                else
                {
                    this.drawPen.Color = this.BorderColor;
                    this.drawPen.Width = value;
                }

                this.OnTextChanged(EventArgs.Empty);
            }
        }


        /// <summary>
        ///   The border color of this component
        /// </summary>
        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "White")]
        [Description("The border color of this component")]
        public Color BorderColor
        {
            get { return this.borderColor; }
            set
            {
                this.borderColor = value;

                if (this.BorderSize != 0)
                    this.drawPen.Color = value;

                this.Invalidate();
            }
        }

        #endregion



        // Public Methods
        //-----------------------------------------------------

        #region Public Methods
        /// <summary>
        /// Gets the size tag.
        /// </summary>
        /// <param name="tens">The tens.</param>
        /// <returns></returns>
        public static string GetSizeTag(int tens)
        {
            StringBuilder sb = new StringBuilder(SizeTag);
            while (tens != 0)
            {
                sb.Append(tens < 0 ? '-' : '+');
                if (tens < 0)
                    tens++;
                else
                    tens--;
            }

            return sb.ToString();
        }

        /// <summary>
        ///   Releases all resources used by this control
        /// </summary>
        /// <param name="disposing">True to release both managed and unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {

                if (this.forecolorBrush != null)
                    this.forecolorBrush.Dispose();

                if (this.drawPen != null)
                    this.drawPen.Dispose();

            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Gets the size of the measured.
        /// </summary>
        /// <returns></returns>
        public Size GetMeasuredSize(float? fontSize = null)
        {
            using (Graphics graphics = CreateGraphics())
            {
                return PaintTexts(graphics, true, fontSize);
            }
        }
        #endregion

        // Event Handling
        //-----------------------------------------------------

        #region Event Handling
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            this.Invalidate();
        }

        protected override void OnTextAlignChanged(EventArgs e)
        {
            base.OnTextAlignChanged(e);
            this.Invalidate();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            this.forecolorBrush.Color = base.ForeColor;
            base.OnForeColorChanged(e);
            this.Invalidate();
        }
        #endregion



        // Drawning Events
        //-----------------------------------------------------

        #region Drawning
        
        protected override void OnPaint(PaintEventArgs e)
        {
            if (BackColor == Color.Transparent)
            {
                PaintParentBackground(Parent, e);

                foreach (Control c in Parent.Controls)
                {
                    if (c == this)
                        continue;

                    if (Bounds.IntersectsWith(c.Bounds))
                    {
                        PaintParentBackground(c, e);
                    }
                }
            }

            PaintTexts(e.Graphics, false);
        }
        #endregion

        /// <summary>
        /// Paints the texts.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="measureOnly">if set to <c>true</c> [measure only].</param>
        /// <param name="fontSize">Size of the font.</param>
        /// <returns></returns>
        private Size PaintTexts(Graphics graphics, bool measureOnly, float? fontSize = null)
        {
            // Paint all texts
            Rectangle bounds = new Rectangle(Location, Size);
            bounds.X = Padding.Left;
            bounds.Y = Padding.Top;
            bounds.Width = ClientSize.Width - (Padding.Left + Padding.Right);
            bounds.Height = ClientSize.Height - (Padding.Top + Padding.Bottom);

            Size result = new Size();
            ContentAlignment textAlign = TextAlign;
            foreach (Tuple<string, float> textSize in _texts)
            {
                // Create font
                Font font = null;
                if ((textSize.Item2 == 1f) &&
                    (fontSize == null))
                {
                    font = Font;
                }
                else
                {
                    font = new Font(Font.FontFamily, (fontSize ?? Font.Size) * textSize.Item2, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
                }

                Size size = PaintText(graphics, textSize.Item1, font, bounds, measureOnly, textAlign);

                bounds.Width -= size.Width;
                result.Width += size.Width;
                if (size.Height > result.Height)
                    result.Height = size.Height;

                switch (TextAlign)
                {
                    case ContentAlignment.TopLeft:
                    case ContentAlignment.MiddleLeft:
                    case ContentAlignment.BottomLeft:
                        bounds.X += size.Width;
                        textAlign = ContentAlignment.TopLeft;
                        break;

                    default:
                        textAlign = ContentAlignment.TopRight;
                        break;
                }
                
            }
            
            result.Width += Padding.Left;
            result.Width += Padding.Right;
            result.Width += (int)BorderSize;
            result.Height += Padding.Top;
            result.Height += Padding.Bottom;
            result.Height += (int)BorderSize;
            return result;
        }

        private Size PaintText(Graphics graphics, string text, Font font, Rectangle bounds, bool measureOnly, ContentAlignment textAlign)
        {
            // First lets check if we indeed have text to draw.
            //  if we have no text, then we have nothing to do.
            if (text.Length == 0)
                return new Size();

            // Next, we measure how much space our drawning will use on the control.
            //  this is important so we can determine the correct position for our text.
            SizeF drawSize = graphics.MeasureString(text, font, new PointF(), StringFormat.GenericTypographic);

            if (!measureOnly)
            {
                // Secondly, lets begin setting the smoothing mode to AntiAlias, to
                // reduce image sharpening and compositing quality to HighQuality,
                // to improve our drawnings and produce a better looking image.

                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.CompositingQuality = CompositingQuality.HighQuality;

                // Now we can draw our text to a graphics path.
                //  
                //   PS: this is a tricky part: AddString() expects float emSize in pixel, but Font.Size
                //   measures it as points. So, we need to convert between points and pixels, which in
                //   turn requires detailed knowledge of the DPI of the device we are drawing on. 
                //
                //   The solution was to get the last value returned by the Graphics.DpiY property and
                //   divide by 72, since point is 1/72 of an inch, no matter on what device we draw.
                //
                //   The source of this solution can be seen on CodeProject's article
                //   'OSD window with animation effect' - http://www.codeproject.com/csharp/OSDwindow.asp 

                float fontSize = graphics.DpiY * font.SizeInPoints / 72;

                using (GraphicsPath drawPath = new GraphicsPath())
                {
                    PointF location = new PointF();

                    switch (textAlign)
                    {
                        case ContentAlignment.TopRight:
                        case ContentAlignment.MiddleRight:
                        case ContentAlignment.BottomRight:
                            location.X = bounds.Right - drawSize.Width;
                            break;

                        case ContentAlignment.TopCenter:
                        case ContentAlignment.MiddleCenter:
                        case ContentAlignment.BottomCenter:
                            location.X = bounds.X + ((bounds.Width - drawSize.Width) / 2f);
                            break;

                        default:
                            location.X = bounds.X;
                            break;
                    }

                    switch (textAlign)
                    {
                        case ContentAlignment.MiddleCenter:
                        case ContentAlignment.MiddleLeft:
                        case ContentAlignment.MiddleRight:
                            location.Y = bounds.Y + ((bounds.Height - drawSize.Height) / 2f);
                            break;

                        default:
                            location.Y = bounds.Y;
                            break;

                    }

                    drawPath.AddString(text, font.FontFamily, (int)font.Style, fontSize,
                        location, StringFormat.GenericTypographic);

                    // And finally, using our pen, all we have to do now
                    //  is draw our graphics path to the screen. Voilla!;
                    graphics.DrawPath(this.drawPen, drawPath);
                    graphics.FillPath(this.forecolorBrush, drawPath);
                }
            }

            return drawSize.ToSize();
        }

        private void PaintParentBackground(Control c, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(Location.X - c.Location.X, Location.Y - c.Location.Y,
                                            Width, Height);

            e.Graphics.TranslateTransform(-rect.X, -rect.Y);

            try
            {
                using (PaintEventArgs pea =
                            new PaintEventArgs(e.Graphics, rect))
                {
                    pea.Graphics.SetClip(rect);
                    InvokePaintBackground(c, pea);
                    InvokePaint(c, pea);
                }
            }
            finally
            {
                e.Graphics.TranslateTransform(rect.X, rect.Y);
            }
        }

        /// <summary>
        /// Parses the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        private List<Tuple<string, float>> Parse(string text)
        {
            List<Tuple<string, float>> result = new List<Tuple<string, float>>();

            if (string.IsNullOrEmpty(text))
                return result;

            int currentPos = 0;
            float currentSize = 1.0f;
            int nextTagIndex = -1;
            while ((nextTagIndex = text.IndexOf(SizeTag, currentPos)) > 0)
            {
                AddTextSize(result, text.Substring(currentPos, nextTagIndex - currentPos), currentSize);

                // Read all signs
                currentPos = nextTagIndex + SizeTag.Length;
                while (currentPos < text.Length)
                {
                    float mul = 0f;
                    if (text[currentPos] == '-')
                        mul = -1;
                    else
                        if (text[currentPos] == '+')
                            mul = 1;

                    if (mul == 0f)
                        break;

                    currentSize += mul * 0.1f;

                    currentPos++;
                }
            }

            AddTextSize(result, text.Substring(currentPos), currentSize);

            return result;
        }

        private void AddTextSize(List<Tuple<string, float>> texts, string text, float size)
        {
            texts.Add(new Tuple<string, float>(text, size));
        }

    }
}