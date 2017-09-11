using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Threading;

namespace MyHome
{
    class GameOver : GameScene
    {
        int mCount;

        //  読み込んだ画像の保存場所
        BitmapImage mPicture = null;
        string path = null;
        FormattedText mText = null;
        Typeface mTypeface = new Typeface(new FontFamily("Arial"), FontStyles.Normal, FontWeights.Normal, FontStretches.Medium);
        System.Globalization.CultureInfo mCulture = System.Globalization.CultureInfo.GetCultureInfo("en-us");
        RenderTargetBitmap mTarget = null;

        public GameOver()
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
            //  img フォルダからGAMEOVERのgifを読む
            string cwd = System.IO.Directory.GetCurrentDirectory();
            path = System.IO.Directory.GetParent(cwd) + "\\img\\title\\gameover.gif";
            mPicture = new BitmapImage(new Uri(path));

            mText = new FormattedText("Push Enter Key",
                mCulture,
                FlowDirection.LeftToRight,
                mTypeface,
                30,
                Brushes.White);
            if(KeyState.Enter)
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
            dc.DrawImage(mPicture, new Rect(0, 0, mPicture.Width, mPicture.Height));

            mCount = (mCount + 1) % 30;
            if (mCount < 15)
            {
                double x = (mTarget.Width - mText.Width) / 2;
                dc.DrawText(mText, new Point(x, 450));
            }
        }
    }
}