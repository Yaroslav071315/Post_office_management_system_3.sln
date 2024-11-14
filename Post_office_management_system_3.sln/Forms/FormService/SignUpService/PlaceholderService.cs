using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

//namespace Post_office_management_system_3.Services
//{
//    public static class PlaceholderService
//    {
//        public static readonly DependencyProperty PlaceholderTextProperty =
//            DependencyProperty.RegisterAttached(
//                "PlaceholderText",
//                typeof(string),
//                typeof(PlaceholderService),
//                new PropertyMetadata(string.Empty, OnPlaceholderTextChanged));

//        public static string GetPlaceholderText(DependencyObject obj)
//        {
//            return (string)obj.GetValue(PlaceholderTextProperty);
//        }

//        public static void SetPlaceholderText(DependencyObject obj, string value)
//        {
//            obj.SetValue(PlaceholderTextProperty, value);
//        }

//        private static void OnPlaceholderTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
//        {
//            if (d is TextBox textBox)
//            {
//                textBox.GotFocus += RemovePlaceholder;
//                textBox.LostFocus += ShowPlaceholder;

//                // Show the placeholder initially
//                ShowPlaceholder(textBox, null);
//            }
//        }

//        private static void ShowPlaceholder(object sender, RoutedEventArgs e)
//        {
//            if (sender is TextBox textBox && string.IsNullOrEmpty(textBox.Text))
//            {
//                textBox.Foreground = Brushes.Gray;
//                textBox.Text = GetPlaceholderText(textBox);
//            }
//        }

//        private static void RemovePlaceholder(object sender, RoutedEventArgs e)
//        {
//            if (sender is TextBox textBox && textBox.Text == GetPlaceholderText(textBox))
//            {
//                textBox.Text = string.Empty;
//                textBox.Foreground = Brushes.Black;
//            }
//        }
//    }
//}

namespace Post_office_management_system_3.Services
{
    public static class PlaceholderService
    {
        public static readonly DependencyProperty PlaceholderTextProperty =
            DependencyProperty.RegisterAttached(
                "PlaceholderText",
                typeof(string),
                typeof(PlaceholderService),
                new PropertyMetadata(string.Empty, OnPlaceholderTextChanged));

        public static string GetPlaceholderText(DependencyObject obj)
        {
            return (string)obj.GetValue(PlaceholderTextProperty);
        }

        public static void SetPlaceholderText(DependencyObject obj, string value)
        {
            obj.SetValue(PlaceholderTextProperty, value);
        }

        private static void OnPlaceholderTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBox textBox)
            {
                textBox.GotFocus += RemovePlaceholder;
                textBox.LostFocus += ShowPlaceholder;

                // Show the placeholder initially
                ShowPlaceholder(textBox, null);
            }
        }

        private static void ShowPlaceholder(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Foreground = Brushes.Gray;
                textBox.Text = GetPlaceholderText(textBox);
            }
        }

        private static void RemovePlaceholder(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Text == GetPlaceholderText(textBox))
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black;
            }
        }
    }
}