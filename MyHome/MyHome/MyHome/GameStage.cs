using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;

namespace MyHome
{
    class Stage01
    {
        static public int[,] stagedata ={
                {0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0},
                {0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0},
                {1  ,1  ,1  ,1  ,1  ,1  ,1  ,1  ,1  ,1  ,1  ,1  ,0  ,0},
                {0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0},
                {0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0},
                {0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,1  ,1  ,1  ,1},
                {0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,1  ,1  ,0  ,0  ,0},
                {0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,1  ,1  ,0  ,0  ,0  ,0},
                {5  ,1  ,1  ,0  ,0  ,0  ,0  ,1  ,1  ,0  ,0  ,0  ,0  ,0},
                {5  ,0  ,0  ,0  ,0  ,0  ,1  ,1  ,0  ,0  ,0  ,0  ,0  ,0},
                {5  ,0  ,0  ,0  ,0  ,1  ,1  ,0  ,0  ,0  ,0  ,5  ,1  ,1},
                {5  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,5  ,0  ,0},
                {5  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,5  ,0  ,0},
                {5  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,5  ,0  ,0},
                {1  ,1  ,1  ,1  ,1  ,1  ,1  ,1  ,1  ,1  ,1  ,5  ,1  ,1},
                {0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,5  ,0  ,0},
                {14 ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,5  ,0  ,0},
                {1  ,0  ,1  ,0  ,1  ,0  ,1  ,0  ,0  ,0  ,0  ,5  ,0  ,0},
                {1  ,0  ,1  ,0  ,1  ,0  ,1  ,1  ,0  ,0  ,0  ,5  ,0  ,0},
                {1  ,6  ,1  ,6  ,1  ,6  ,1  ,1  ,1  ,1  ,1  ,1  ,1  ,4}
            };
    }
    class Stage02
    {
        static public int[,] stagedata ={
                {0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0},
                {0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,14 ,0  ,0  ,0  ,0  ,0},
                {1  ,1  ,1  ,2  ,1  ,1  ,2  ,1  ,1  ,7  ,0  ,0  ,0  ,0},
                {0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,1  ,0  ,0  ,0  ,0  ,0},
                {0  ,0  ,0  ,0  ,0  ,0  ,0  ,6  ,1  ,0  ,0  ,0  ,1  ,0},
                {0  ,1  ,0  ,0  ,0  ,1  ,1  ,1  ,1  ,0  ,0  ,0  ,0  ,0},
                {0  ,0  ,1  ,10 ,1  ,0  ,0  ,8  ,0  ,0  ,0  ,1  ,0  ,0},
                {0  ,0  ,0  ,1  ,0  ,0  ,0  ,0  ,0  ,0  ,1  ,0  ,0  ,0},
                {1  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,1  ,0  ,0  ,0  ,0},
                {0  ,1  ,0  ,0  ,0  ,0  ,1  ,1  ,1  ,0  ,0  ,0  ,0  ,9},
                {0  ,3  ,1  ,0  ,0  ,1  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,13},
                {0  ,0  ,0  ,2  ,1  ,3  ,0  ,0  ,0  ,0  ,1  ,1  ,2  ,1},
                {0  ,0  ,0  ,13 ,1  ,0  ,0  ,0  ,0  ,1  ,1  ,3  ,0  ,3},
                {0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,1  ,1  ,0  ,0  ,0  ,0},
                {0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,4  ,3  ,0  ,0  ,0  ,0},
                {0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,4  ,0  ,0  ,0  ,0  ,0},
                {1  ,0  ,0  ,0  ,6  ,0  ,6  ,0  ,4  ,0  ,0  ,0  ,0  ,0},
                {1  ,0  ,1  ,1  ,1  ,1  ,1  ,1  ,1  ,1  ,1  ,1  ,1  ,0},
                {1  ,0  ,1  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0},
                {1  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0}
            };
    }
    class Stage03
    {
        static public int[,] stagedata ={
                {1  ,0  ,8  ,8  ,8  ,8  ,8  ,8  ,8  ,8  ,8  ,8  ,8  ,1},
                {1  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,1},
                {1  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,1},
                {1  ,2  ,2  ,2  ,2  ,2  ,2  ,2  ,2  ,2  ,2  ,2  ,2  ,1},
                {1  ,6  ,6  ,6  ,6  ,6  ,6  ,2  ,6  ,6  ,6  ,6  ,6  ,1},
                {1  ,1  ,1  ,1  ,1  ,1  ,1  ,2  ,1  ,1  ,1  ,1  ,1  ,1},
                {1  ,0  ,0  ,0  ,0  ,0  ,0  ,2  ,0  ,0  ,0  ,0  ,0  ,1},
                {1  ,14 ,0  ,0  ,0  ,0  ,0  ,2  ,0  ,0  ,0  ,0  ,14 ,1},
                {1  ,1  ,1  ,2  ,2  ,2  ,2  ,6  ,2  ,2  ,2  ,1  ,1  ,1},
                {1  ,0  ,0  ,0  ,0  ,0  ,0  ,1  ,0  ,0  ,0  ,0  ,0  ,1},
                {1  ,0  ,0  ,0  ,0  ,0  ,0  ,1  ,0  ,0  ,0  ,0  ,0  ,1},
                {1  ,0  ,0  ,0  ,0  ,6  ,0  ,1  ,1  ,1  ,1  ,1  ,0  ,1},
                {1  ,0  ,0  ,0  ,2  ,0  ,0  ,0  ,0  ,0  ,0  ,1  ,0  ,1},
                {1  ,0  ,0  ,6  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,1  ,0  ,1},
                {1  ,0  ,2  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,1  ,0  ,1},
                {1  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,1  ,0  ,1},
                {1  ,1  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,1  ,0  ,1},
                {1  ,0  ,2  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,1  ,0  ,1},
                {1  ,0  ,6  ,6  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,1  ,0  ,1},
                {1  ,0  ,0  ,0  ,2  ,1  ,1  ,1  ,1  ,1  ,4  ,1  ,4  ,1}
            };
    }
    class Stage04
    {
        static public int[,] stagedata ={
                {0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  },
                {0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  },
                {0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,14 },
                {1  ,1  ,1  ,0  ,1  ,1  ,0  ,1  ,1  ,0  ,1  ,0  ,6  ,1  },
                {0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,1  ,0  },
                {0  ,0  ,0  ,0  ,0  ,1  ,0  ,0  ,6  ,0  ,0  ,6  ,0  ,0  },
                {0  ,0  ,1  ,1  ,0  ,1  ,0  ,0  ,1  ,1  ,0  ,1  ,0  ,0  },
                {0  ,0  ,0  ,0  ,9  ,1  ,6  ,6  ,0  ,0  ,0  ,0  ,0  ,0  },
                {0  ,0  ,0  ,0  ,0  ,1  ,1  ,1  ,0  ,6  ,0  ,0  ,0  ,0  },
                {6  ,0  ,0  ,0  ,0  ,8  ,0  ,0  ,0  ,1  ,1  ,0  ,0  ,0  },
                {1  ,0  ,1  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,1  ,1  ,0  },
                {0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  },
                {0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  },
                {0  ,0  ,6  ,0  ,0  ,0  ,0  ,0  ,0  ,6  ,0  ,0  ,0  ,6  },
                {0  ,0  ,1  ,0  ,0  ,1  ,7  ,0  ,9  ,1  ,0  ,0  ,0  ,1  },
                {6  ,6  ,1  ,6  ,6  ,1  ,7  ,0  ,9  ,1  ,6  ,6  ,6  ,1  },
                {1  ,1  ,1  ,1  ,1  ,1  ,7  ,0  ,9  ,1  ,1  ,1  ,1  ,1  },
                {0  ,0  ,0  ,4  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  },
                {0  ,0  ,0  ,4  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  },
                {0  ,15 ,0  ,4  ,0  ,0  ,0  ,0  ,6  ,0  ,0  ,0  ,0  ,0  }
            };
    }

    class GameStage : GameScene
    {
        protected BitmapImage[] mPicture = new BitmapImage[16];
        protected BitmapImage[] mPicture2 = new BitmapImage[8];
        protected BitmapImage[] mPicture3 = new BitmapImage[4];

        //アニメーション用カウント
        int ani_swith = 0; 

        protected BitmapImage mBack = null;

        static protected int[,] mStage = Stage01.stagedata;

        Typeface mTypeface = new Typeface(new FontFamily("Arial"), FontStyles.Normal, FontWeights.Normal, FontStretches.Medium);
        System.Globalization.CultureInfo mCulture = System.Globalization.CultureInfo.GetCultureInfo("en-us");

        //  キャラクタクラス
        Player mPlayer;

        public GameStage()
        {
            //初期化
            for (int i = 0; i < mPicture.Length;++i )
            {
                mPicture[i] = null;
            }
            //  画像読み込み
            //  img フォルダからmap用のGIFを読む
            string cwd = System.IO.Directory.GetCurrentDirectory();
            string[] path = new[]{                
                System.IO.Directory.GetParent(cwd) + "\\img\\map\\00.gif",
                System.IO.Directory.GetParent(cwd) + "\\img\\map\\01.gif", 
                System.IO.Directory.GetParent(cwd) + "\\img\\map\\02.gif",
                System.IO.Directory.GetParent(cwd) + "\\img\\map\\03.gif",
                System.IO.Directory.GetParent(cwd) + "\\img\\map\\04.gif",
                System.IO.Directory.GetParent(cwd) + "\\img\\map\\05.gif",
                System.IO.Directory.GetParent(cwd) + "\\img\\map\\06.gif",
                System.IO.Directory.GetParent(cwd) + "\\img\\map\\07.gif", 
                System.IO.Directory.GetParent(cwd) + "\\img\\map\\08.gif",
                System.IO.Directory.GetParent(cwd) + "\\img\\map\\09.gif",
                System.IO.Directory.GetParent(cwd) + "\\img\\map\\10.gif",
                System.IO.Directory.GetParent(cwd) + "\\img\\map\\11.gif",
                System.IO.Directory.GetParent(cwd) + "\\img\\map\\12.gif",
                System.IO.Directory.GetParent(cwd) + "\\img\\map\\13.gif", 
                System.IO.Directory.GetParent(cwd) + "\\img\\map\\14.gif",
                System.IO.Directory.GetParent(cwd) + "\\img\\map\\15.gif"
            };

            //アニメーション用
            string[] anime1_path = new[]{                
                System.IO.Directory.GetParent(cwd) + "\\img\\map\\03-1.gif",
                System.IO.Directory.GetParent(cwd) + "\\img\\map\\03-2.gif", 
                System.IO.Directory.GetParent(cwd) + "\\img\\map\\03-3.gif",
                System.IO.Directory.GetParent(cwd) + "\\img\\map\\03-4.gif",
                System.IO.Directory.GetParent(cwd) + "\\img\\map\\03-5.gif",
                System.IO.Directory.GetParent(cwd) + "\\img\\map\\03-6.gif",
                System.IO.Directory.GetParent(cwd) + "\\img\\map\\03-7.gif",
                System.IO.Directory.GetParent(cwd) + "\\img\\map\\03-8.gif"
            };
            string[] anime2_path = new[]{ 
                System.IO.Directory.GetParent(cwd) + "\\img\\map\\14-1.gif",
                System.IO.Directory.GetParent(cwd) + "\\img\\map\\14-2.gif",
                System.IO.Directory.GetParent(cwd) + "\\img\\map\\14-3.gif"
            };

            for (int i = 0; i < path.Length; ++i)
            {
                mPicture[i] = new BitmapImage(new Uri(path[i]));
            }
            for (int i = 0; i < anime1_path.Length; ++i)
            {
                mPicture2[i] = new BitmapImage(new Uri(anime1_path[i]));
            }
            for (int i = 0; i < anime2_path.Length; ++i)
            {
                mPicture3[i] = new BitmapImage(new Uri(anime2_path[i]));
            }

            string path2 = System.IO.Directory.GetParent(cwd) + "\\img\\title\\back.gif";
            mBack = new BitmapImage(new Uri(path2));

            mPlayer = new Player();
        }

        public override SceneExitCode Update()
        {
            return SceneExitCode.ExitDefault;
        }

        //  右当たり判定
        public static double R_HitCheck(double lx, double ty, double rx, double by)
        {
            //行番号・列番号の単位で上下左右の位置(範囲)を算出
            int t, l, r, b;
            t = (int)(ty * mStage.GetLength(0)) / 600;
            l = (int)(lx * mStage.GetLength(1)) / 630;
            b = (int)(by * mStage.GetLength(0)) / 600;
            r = (int)(rx * mStage.GetLength(1)) / 630;
            
            double left = Double.MaxValue;
            bool bHit = false;
            
            if (b < mStage.GetLength(0) && r < mStage.GetLength(1))
            {
                for (int row = t; row <= b; ++row)
                {
                    for (int col = l; col <= r; ++col)
                    {
                        //ブロックとヒットする時左端を返す
                        if (mStage[row, col] == 1)
                        {
                            double blx = (col * 630) / mStage.GetLength(1);
                            if (blx < left)
                            {
                                left = blx;
                            }
                            bHit = true;
                        }

                        //割れブロック
                        if (mStage[row, col] == 2)
                        {
                            if (StageState.mCrackBox[row, col] > 0)
                            {
                                double blx = (col * 630) / mStage.GetLength(1);
                                if (blx < left)
                                {
                                    left = blx;
                                }
                                bHit = true;
                            }
                        }

                        //スイッチブロック
                        if (mStage[row, col] == 4 && StageState.mLever == false)
                        {
                            double blx = (col * 630) / mStage.GetLength(1);
                            if (blx < left)
                            {
                                left = blx;
                            }
                            bHit = true;
                        }

                        //レバースイッチ
                        if (mStage[row, col] == 14)
                        {
                            StageState.mLever = true;
                        }

                        //死亡
                        if (mStage[row, col] == 6  || mStage[row, col] == 7  || 
                            mStage[row, col] == 8  || mStage[row, col] == 9  || 
                            mStage[row, col] == 10 || mStage[row, col] == 11 || 
                            mStage[row, col] == 12 || mStage[row, col] == 13 )
                        {
                            return 1000;
                        }
                    }
                }
            }
            //落下死亡
            if (b < mStage.GetLength(0) && r < mStage.GetLength(1))
            {
                for (int row = 0; row <= b; ++row)
                {
                    for (int col = l; col <= r; ++col)
                    {
                        if (mStage[row, col] == 3)
                        {
                            double tty = (int)(row * (600 / mStage.GetLength(0))) + StageState.mCrackBox[row, col];
                            double bby = (int)(row * (600 / mStage.GetLength(0))) + 5 + StageState.mCrackBox[row, col];
                            double blx = (col * 630) / mStage.GetLength(1);

                            if (((bby > ty && tty < ty) || (bby > by && tty < by)) && blx < rx)
                            {
                                return 1000;
                            }
                        }
                    }
                }
            }

            if(bHit){
                return left;
            }
            return 630; //ブロックとはヒットしない時
        }

        //  左当たり判定(壁)
        public static double L_HitCheck(double lx, double ty, double rx, double by)
        {
            //行番号・列番号の単位で上下左右の位置(範囲)を算出
            int t, l, r, b;
            t = (int)(ty * mStage.GetLength(0)) / 600;
            l = (int)(lx * mStage.GetLength(1)) / 630;
            b = (int)(by * mStage.GetLength(0)) / 600;
            r = (int)(rx * mStage.GetLength(1)) / 630;

            double right = -Double.MaxValue;
            bool bHit = false;

            if (b < mStage.GetLength(0) && r < mStage.GetLength(1))
            {
                for (int row = t; row <= b; ++row)
                {
                    for (int col = l; col <= r; ++col)
                    {
                        //ブロックとヒットする時左端を返す
                        if (mStage[row, col] == 1)
                        {
                            double brx = ((col + 1) * 630) / mStage.GetLength(1);
                            if (brx > right)
                            {
                                right = brx;
                            }
                            bHit = true;
                        }

                        //割れブロック
                        if (mStage[row, col] == 2)
                        {
                            if (StageState.mCrackBox[row, col] > 0)
                            {
                                double brx = ((col + 1) * 630) / mStage.GetLength(1);
                                if (brx > right)
                                {
                                    right = brx;
                                }
                                bHit = true;
                            }
                        }

                        //スイッチブロック
                        if (mStage[row, col] == 4 && StageState.mLever == false)
                        {
                            double brx = ((col + 1) * 630) / mStage.GetLength(1);
                            if (brx > right)
                            {
                                right = brx;
                            }
                            bHit = true;
                        }

                        //レバースイッチ
                        if (mStage[row, col] == 14)
                        {
                            StageState.mLever = true;
                        }
                        
                        //死亡
                        if (mStage[row, col] == 6 || mStage[row, col] == 7 ||
                            mStage[row, col] == 8 || mStage[row, col] == 9 ||
                            mStage[row, col] == 10 || mStage[row, col] == 11 ||
                            mStage[row, col] == 12 || mStage[row, col] == 13)
                        {
                            return 1000;
                        }

                        //棺(ゲームクリア)
                        if (mStage[row, col] == 15)
                        {
                            double brx = (col * 630) / mStage.GetLength(1);
                            if (brx > right)
                            {
                                return 1001;
                            } 
                        }
                    }
                }
            }
            //落下死亡
            if (b < mStage.GetLength(0) && r < mStage.GetLength(1))
            {
                for (int row = 0; row <= b; ++row)
                {
                    for (int col = l; col <= r; ++col)
                    {
                        if (mStage[row, col] == 3)
                        {
                            double tty = (int)(row * (600 / mStage.GetLength(0))) + StageState.mCrackBox[row, col];
                            double bby = (int)(row * (600 / mStage.GetLength(0))) + 5 + StageState.mCrackBox[row, col];
                            double brx = ((col + 1) * 630) / mStage.GetLength(1);

                            if (((bby > ty && tty < ty) || (bby > by && tty < by)) && brx > lx)
                            {
                                return 1000;
                            }
                        }
                    }
                }
            }

            if(bHit){
                return right;
            }
            return 0; //ブロックとはヒットしない
        }

        //  下当たり判定
        //  ladder:梯子を床とみなすかどうか
        public static double B_HitCheck(double lx, double ty, double rx, double by, bool ladder = true)
        {
            //行番号・列番号の単位で上下左右の位置(範囲)を算出
            int t, l, r, b;
            t = (int)(ty * mStage.GetLength(0)) / 600;
            l = (int)(lx * mStage.GetLength(1)) / 630;
            b = (int)(by * mStage.GetLength(0)) / 600;
            r = (int)(rx * mStage.GetLength(1)) / 630;

            bool bHit = false;
            double top = Double.MaxValue;
            int iBlock;

            if (b < mStage.GetLength(0) && r < mStage.GetLength(1))
            {
                for (int row = t; row <= b; ++row)
                {
                    for (int col = l; col <= r; ++col)
                    {
                        //ブロックとヒットする時返す
                        iBlock = mStage[row, col];
                        if (iBlock == 1 || iBlock == 5)
                        {
                            //プレイヤーと梯子の位置を判定するif文
                            if (iBlock == 1 || ladder)
                            {
                                bHit = true;
                                double bty = (double)((row * 600) / mStage.GetLength(0));
                                if (bty < top)
                                {
                                    top = bty;
                                }
                            }
                        }

                        //割れブロック
                        if (iBlock == 2)
                        {
                            if (StageState.mCrackBox[row, col] > 0)
                            {
                                bHit = true;
                                double bty = (double)((row * 600) / mStage.GetLength(0));
                                if (bty < top)
                                {
                                    top = bty;
                                }

                                if (StageState.mCrackBox[row, col] > 0 && StageState.mCrackBox[row, col] != -1)
                                {
                                    StageState.mCrackBox[row, col] += 1;
                                }
                                if (StageState.mCrackBox[row, col] > 8)
                                {
                                    StageState.mCrackBox[row, col] = -1;
                                }
                            }
                        }

                        //スイッチブロックとヒットする時返す
                        if (iBlock == 4)
                        {
                            if (iBlock == 4 && StageState.mLever == false)
                            {
                                bHit = true;
                                double bty = (double)((row * 600) / mStage.GetLength(0));
                                if (bty < top)
                                {
                                    top = bty;
                                }
                            }
                        }
                    }
                }
            }
            if (bHit)
            {
                return top - 45.0;
            }
            return 700;
        }

        //  上当たり判定
        public static double T_HitCheck(double lx, double ty, double rx, double by)
        {
            if (ty <= 0)
            {
                return 0;
            }

            //行番号・列番号の単位で上下左右の位置(範囲)を算出
            int t, l, r, b;
            t = (int)(ty * mStage.GetLength(0)) / 600;
            l = (int)(lx * mStage.GetLength(1)) / 630;
            b = (int)(by * mStage.GetLength(0)) / 600;
            r = (int)(rx * mStage.GetLength(1)) / 630;

            bool bHit = false;
            double bottom = -Double.MaxValue;
            int iBlock;

            if (b < mStage.GetLength(0) && r < mStage.GetLength(1))
            {
                for (int row = t; row <= b; ++row)
                {
                    for (int col = l; col <= r; ++col)
                    {
                        //ブロックとヒットする時
                        iBlock = mStage[row, col];
                        if (iBlock == 1)
                        {
                            bHit = true;
                            double bby = (double)(((row + 1) * 600) / mStage.GetLength(0));
                            if (bby > bottom)
                                bottom = bby;
                        }

                        //割れブロック
                        if (iBlock == 2)
                        {
                            if (StageState.mCrackBox[row, col] > 0)
                            {
                                bHit = true;
                                double bby = (double)(((row + 1) * 600) / mStage.GetLength(0));
                                if (bby > bottom)
                                    bottom = bby;
                            }
                        }

                        //落下ブロック
                        for (int row2 = 0; row2 <= b; ++row2)
                        {
                            if (mStage[row2, col] == 3)
                            {
                                if (StageState.mCrackBox[row2, col] == 1)
                                {
                                    StageState.mCrackBox[row2, col] = 2;
                                }
                            }
                        }
                    }
                }
            }
            //落下死亡
            if (b < mStage.GetLength(0) && r < mStage.GetLength(1))
            {
                for (int row = 0; row <= b; ++row)
                {
                    for (int col = l; col <= r; ++col)
                    {
                        if (mStage[row, col] == 3)
                        {
                            double tty = (int)(row * (600 / mStage.GetLength(0))) + StageState.mCrackBox[row, col];
                            double bby = (int)(row * (600 / mStage.GetLength(0))) + 5 + StageState.mCrackBox[row, col];

                            if ((bby > ty && tty < ty) || (bby > by && tty < by))
                            {
                                return 1000;
                            }
                        }
                    }
                }
            }

            if (bHit)
            {
                return bottom;
            }
            return 0;
        }

        //  床確認用
        public static double floor_HitCheck(double lx, double ty, double rx, double by, bool ladder = true)
        {
            //行番号・列番号の単位で上下左右の位置(範囲)を算出
            int t, l, r, b;
            t = (int)(ty * mStage.GetLength(0)) / 600;
            l = (int)(lx * mStage.GetLength(1)) / 630;
            b = (int)(by * mStage.GetLength(0)) / 600;
            r = (int)(rx * mStage.GetLength(1)) / 630;

            bool bHit = false;
            double top = Double.MaxValue;

            if (b < mStage.GetLength(0) && r < mStage.GetLength(1))
            {
                for (int row = t; row <= b; ++row)
                {
                    for (int col = l; col <= r; ++col)
                    {
                        //ブロックとヒットする時返す
                        if (mStage[row, col] == 1)
                        {
                            bHit = true;
                            double bty = (double)((row * 600) / mStage.GetLength(0));
                            if (bty < top)
                            {
                                top = bty;
                            }
                        }
                    }
                }
            }
            if (bHit)
            {
                return top - 45.0;
            }
            return 700;
        }

        //梯子判定、梯子の位置にいるときtrueを返すプログラムにする
        //lx(左端),ty(上端),rx(右端),by(下端)はプレイヤーの座標
        public static bool ladder(double lx, double ty, double rx, double by)
        {
            //  行番号・列番号の単位で上下左右の位置（範囲）を算出
            int t, l, r, b;
            l = (int)(lx * Stage01.stagedata.GetLength(1)) / 630;
            t = (int)(ty * Stage01.stagedata.GetLength(0)) / 600;
            r = (int)(rx * Stage01.stagedata.GetLength(1)) / 630;
            b = (int)(by * Stage01.stagedata.GetLength(0)) / 600;

            if (b < mStage.GetLength(0) && r < mStage.GetLength(1))
            {
                for (int row = t; row <= b; ++row)
                {
                    for (int col = l; col <= r; ++col)
                    {
                        //梯子の位置にいる時
                        if (mStage[row, col] == 5)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;   //  梯子の上にいない
        }
        public override void Render(DrawingContext dc)
        {
            switch (Selector.num)
            {
                case 1:
                    mStage = Stage01.stagedata;
                    break;
                case 2:
                    mStage = Stage02.stagedata;
                    break;
                case 3:
                    mStage = Stage03.stagedata;
                    break;
                case 4:
                    mStage = Stage04.stagedata;
                    break;
            }

            if(StageState.mLever == false){
                ani_swith = 0;
            }

            dc.DrawImage(mBack, new Rect(0, 0, mBack.Width, mBack.Height));

            //  ブロックの描画
            int lx = 0;
            int ty = 0;
            for (int i = 0,num=0; i < mStage.GetLength(0); ++i)
            {
                ty = (i * ((int)600 / mStage.GetLength(0)));
                for (int j = 0; j < mStage.GetLength(1); ++j)
                {
                    lx = (j * ((int)630 / mStage.GetLength(1)));
                    
                    //マップ描画
                    if (mStage[i, j] != 0 && mStage[i, j] != 2 && mStage[i, j] != 3 &&
                        mStage[i, j] != 4 && mStage[i, j] != 14)
                    {
                        dc.DrawImage(mPicture[mStage[i, j]],
                                    new Rect(
                                        lx,
                                        ty,
                                        mPicture[mStage[i, j]].Width,
                                        mPicture[mStage[i, j]].Height));
                    }

                    //割れブロック & 落下ブロック
                    if (StageState.mCrackCheck == false)
                    {
                        if (mStage[i, j] == 2 || mStage[i, j] == 3)
                        {
                            StageState.mCrackBox[i, j] = 1;
                        }
                        else
                        {
                            StageState.mCrackBox[i, j] = 0;
                        }
                        ++num;
                        if (num >= 280)
                        {
                            StageState.mCrackCheck = true;
                        }
                    }

                    if (mStage[i, j] == 2 && StageState.mCrackBox[i, j] > 0)
                    {
                        dc.DrawImage(mPicture[mStage[i, j]],
                                    new Rect(
                                        lx,
                                        ty,
                                        mPicture[mStage[i, j]].Width,
                                        mPicture[mStage[i, j]].Height));
                    }
                    if (StageState.mCrackBox[i, j] <= -1 && StageState.mCrackBox[i, j] >= -8)
                    {
                        dc.DrawImage(mPicture2[System.Math.Abs(StageState.mCrackBox[i, j]) - 1],
                                    new Rect(
                                        lx,
                                        ty,
                                        mPicture2[System.Math.Abs(StageState.mCrackBox[i, j]) - 1].Width,
                                        mPicture2[System.Math.Abs(StageState.mCrackBox[i, j]) - 1].Height));
                        StageState.mCrackBox[i, j] += -1;
                    }
                    else if (StageState.mCrackBox[i, j] < -9)
                    {
                        StageState.mCrackBox[i, j] = -10;
                    }
                    //―――――

                    //落下ブロック
                    if (mStage[i, j] == 3 && StageState.mCrackBox[i, j] == 1)
                    {
                        dc.DrawImage(mPicture[mStage[i, j]],
                                    new Rect(
                                        lx,
                                        ty,
                                        mPicture[mStage[i, j]].Width,
                                        mPicture[mStage[i, j]].Height));
                    }
                    if (mStage[i, j] == 3 && StageState.mCrackBox[i, j] >= 2)
                    {
                        dc.DrawImage(mPicture[mStage[i, j]],
                                    new Rect(
                                        lx,
                                        ty + StageState.mCrackBox[i, j],
                                        mPicture[mStage[i, j]].Width,
                                        mPicture[mStage[i, j]].Height));
                        if(StageState.mCrackBox[i, j] < 10)
                        {
                            StageState.mCrackBox[i, j] += 3;
                        }
                        else{
                            StageState.mCrackBox[i, j] += 10;
                        }
                    }
                    else if (ty - StageState.mCrackBox[i, j] > 600)
                    {
                        StageState.mCrackBox[i, j] = -10;
                    }
                    //―――――

                    //スイッチ
                    if (mStage[i, j] == 4 && StageState.mLever == false)
                    {
                        dc.DrawImage(mPicture[mStage[i, j]],
                                    new Rect(
                                        lx,
                                        ty,
                                        mPicture[mStage[i, j]].Width,
                                        mPicture[mStage[i, j]].Height));
                    }
                    //―――――

                    //スイッチブロック
                    if (mStage[i, j] == 14 && StageState.mLever == false)
                    {
                        dc.DrawImage(mPicture[mStage[i, j]],
                                    new Rect(
                                        lx,
                                        ty,
                                        mPicture[mStage[i, j]].Width,
                                        mPicture[mStage[i, j]].Height));
                    }
                    if (mStage[i, j] == 14 && StageState.mLever == true)
                    {
                        ++ani_swith;
                        if (ani_swith>10)
                        {
                            ani_swith = 10;
                        }
                        dc.DrawImage(mPicture3[ani_swith/5],
                                    new Rect(
                                        lx,
                                        ty,
                                        mPicture3[ani_swith / 5].Width,
                                        mPicture3[ani_swith / 5].Height));
                    }
                    //―――――
                }
            }

            //  キャラクタを動かす
            mPlayer.move();
            mPlayer.draw(dc);
        }
    }
}