using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Threading;

namespace MyHome
{
    class GameClear : GameScene
    {
        int mCount;

        BitmapImage [] mPicture = new BitmapImage[2];
        string [] path = new string[2];
        FormattedText mText = null;
        Typeface mTypeface = new Typeface(new FontFamily("Arial"), FontStyles.Normal, FontWeights.Normal, FontStretches.Medium);
        System.Globalization.CultureInfo mCulture = System.Globalization.CultureInfo.GetCultureInfo("en-us");
        RenderTargetBitmap mTarget = null;

        public GameClear()
        {
            Image screen = new Image();
            screen.Width = 630;    //  スクリーンの幅
            screen.Height = 600;    //  スクリーンの高
            mTarget = new RenderTargetBitmap
                ((int)screen.Width,
                (int)screen.Height,
                96.0,
                96.0,
                PixelFormats.Default);

            //  画像読み込み
            //  img フォルダからクリア.gifを読む
            string cwd = System.IO.Directory.GetCurrentDirectory();
            path[0] = System.IO.Directory.GetParent(cwd) + "\\img\\title\\end.gif";
            path[1] = System.IO.Directory.GetParent(cwd) + "\\img\\title\\clear2.gif";

            for (int i = 0; i < 2;++i )
            {
                mPicture[i] = new BitmapImage(new Uri(path[i]));
            }
            mText = new FormattedText("Push Enter Key",
                mCulture,
                FlowDirection.LeftToRight,
                mTypeface,
                50,
                Brushes.White);
            if (KeyState.Enter)
            {
                mCount = 0;
            }
        }

        public override SceneExitCode Update()
        {
            return SceneExitCode.ExitDefault;
        }
        public override void Render(DrawingContext dc)
        {
            DrawingVisual dv = new DrawingVisual();
            dc.DrawImage(mPicture[0], new Rect(0, 0, mPicture[0].Width, mPicture[0].Height));
            dc.DrawImage(mPicture[1], new Rect(0, -50, mPicture[1].Width, mPicture[1].Height));
            
            mCount = (mCount + 1) % 30;
            if (mCount < 15)
            {
                double x = (mTarget.Width - mText.Width) / 2;
                dc.DrawText(mText, new Point(x, 450));
            }
        }
    }
}