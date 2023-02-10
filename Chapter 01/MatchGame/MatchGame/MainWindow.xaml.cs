﻿using System;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TextBlock lastClickedTextBlock = null;

        public MainWindow()
        {
            InitializeComponent();

            SetUpGame();
        }

        private void SetUpGame()
        {
            List<string> animalEmoji = new List<string>()
            {
                "🐙", "🐙",
                "🦊", "🦊",
                "🐇", "🐇",
                "🐓", "🐓",
                "🦖", "🦖",
                "🐬", "🐬",
                "🦔", "🦔",
                "🦝", "🦝",
            };

            Random randy = new Random();
            foreach (TextBlock tb in mainGrid.Children.OfType<TextBlock>())
            {
                int index = randy.Next(animalEmoji.Count);
                tb.Text = animalEmoji[index];
                animalEmoji.RemoveAt(index);
            }
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

                }
                else
                {
                    // not a match
                    lastClickedTextBlock.Visibility = Visibility.Visible;
                }
                lastClickedTextBlock = null;
            }
        }
    }
}
