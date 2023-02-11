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

namespace MatchGame
{
    using System.Windows.Threading;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TextBlock lastClickedTextBlock = null;
        private DispatcherTimer timer = new DispatcherTimer();
        private int tenthsOfSecondsElapsed = 0;
        private int numMatchesFound = 0;

        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(0.1);
            timer.Tick += Timer_Tick;
            SetUpGame();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timeTextBlock.Text = (++tenthsOfSecondsElapsed * 0.1).ToString("0.0s");
            if (numMatchesFound == 8)
            {
                timer.Stop();
                timeTextBlock.Text = timeTextBlock.Text + " - Play again?";
            }
        }

        private void SetUpGame()
        {
            List<string> animalEmoji = new List<string>()
            {
                "🐙", "🐙",
                "🦊", "🦊",
                "🐇", "🐇",
                "🦉", "🦉",
                "🦖", "🦖",
                "🐬", "🐬",
                "🦔", "🦔",
                "🦝", "🦝",
            };

            Random randy = new Random();
            foreach (TextBlock tb in mainGrid.Children.OfType<TextBlock>())
            {
                if (tb.Name == "timeTextBlock")
                {
                    continue;
                }
                tb.Visibility = Visibility.Visible;
                int index = randy.Next(animalEmoji.Count);
                tb.Text = animalEmoji[index];
                animalEmoji.RemoveAt(index);
            }

            timer.Start();
            tenthsOfSecondsElapsed = 0;
            numMatchesFound = 0;
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;

            if (lastClickedTextBlock == null)
            {
                // clicked first TextBlock of pair
                lastClickedTextBlock = tb;
                tb.Visibility = Visibility.Hidden;
            }
            else
            {
                // clicked second TextBlock of pair
                if (tb.Text == lastClickedTextBlock.Text)
                {
                    // match
                    tb.Visibility = Visibility.Hidden;
                    numMatchesFound++;

                }
                else
                {
                    // not a match
                    lastClickedTextBlock.Visibility = Visibility.Visible;
                }
                lastClickedTextBlock = null;
            }
        }

        private void TimeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (numMatchesFound == 8)
            {
                SetUpGame();
            }
        }
    }
}
