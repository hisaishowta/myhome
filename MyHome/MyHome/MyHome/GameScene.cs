using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace MyHome
{
    enum SceneExitCode
    {
        ExitDefault = 0,
        ExitPositive = 1,
        ExitNegative = 2
    };

    class GameScene
    {
        public GameScene()
        {
        }

        public virtual SceneExitCode Update()
        {
            return SceneExitCode.ExitDefault;
        }

        public virtual void Render(DrawingContext dc)
        {
        }
    }
}
