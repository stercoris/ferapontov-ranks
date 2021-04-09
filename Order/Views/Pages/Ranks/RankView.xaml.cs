﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Order.WPF.Views.Pages.Ranks
{
    /// <summary>
    /// Логика взаимодействия для RankView.xaml
    /// </summary>
    public partial class RankView : UserControl
    {
        public string GroupName{ get => groupName.ToString(); }

        public RankView()
        {
            InitializeComponent();
        }
        private void ExpandRankClick(object sender, System.Windows.RoutedEventArgs e)
        {
            if(groupName.IsEnabled == false)
            {
                groupName.IsEnabled = true;
                materialIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Done;
                ChangeRankAvatar.Visibility = Visibility.Visible;
            }
            else
            {
                groupName.IsEnabled = false;
                ChangeRankAvatar.Visibility = Visibility.Hidden;
                materialIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Create;
            }
          
            //double startPoint = ActualHeight;
            //double finishPoint = 150;
            //RotateTransform rotateTransform = new(180);
            //if (startPoint == finishPoint)
            //{
            //    finishPoint = 60;
            //    rotateTransform = new(0);
            //}
            //DoubleAnimation rankSizeAnimation = new();
            //rankSizeAnimation.From = startPoint;
            //rankSizeAnimation.To = finishPoint;
            //rankSizeAnimation.Duration = TimeSpan.FromSeconds(0.3);
            //BeginAnimation(Button.HeightProperty, rankSizeAnimation);
            //(sender as Button).RenderTransform = rotateTransform;
        }
        private void UserControl_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
           // DragDrop.DoDragDrop((UserControl)sender, (UserControl)sender, DragDropEffects.Move);
        }
    }
}
