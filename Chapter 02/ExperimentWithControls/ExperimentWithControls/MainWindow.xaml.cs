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

namespace ExperimentWithControls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            numberTextBlock.Text = numberTextBox.Text;
        }

        private void NumberTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out int result); // reject non-numeric input
        }

        private void SmallSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            numberTextBlock.Text = smallSlider.Value.ToString("0");
        }

        private void BigSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            numberTextBlock.Text = bigSlider.Value.ToString("000-000-0000");
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            numberTextBlock.Text = (sender as RadioButton)?.Content.ToString();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            numberTextBlock.Text = (e.AddedItems[0] as ListBoxItem)?.Content.ToString();
        }

        private void ReadOnlyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            numberTextBlock.Text = (readOnlyComboBox.SelectedItem as ListBoxItem)?.Content.ToString();
        }

        private void EditableComboBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            numberTextBlock.Text = editableComboBox.Text;
        }
    }
}
