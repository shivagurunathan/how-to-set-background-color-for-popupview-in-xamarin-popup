using Syncfusion.SfPullToRefresh.XForms;
using Syncfusion.XForms.Border;
using Syncfusion.XForms.ProgressBar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SfPullToRefresh
{
    public partial class MainPage : ContentPage
    {
        private SfCircularProgressBar progressbar;
        private SfBorder border;
        public MainPage()
        {
            InitializeComponent();
            this.progressbar = new SfCircularProgressBar();
            this.border = new SfBorder();


            this.border.BorderColor = Color.LightGray;
            this.border.BackgroundColor = Color.White;
            this.border.CornerRadius = 35;
            this.border.Content = this.progressbar;
            this.border.BorderWidth = 0.2;

            this.progressbar.SegmentCount = 10;
            this.progressbar.IndicatorInnerRadius = 0.5;
            this.progressbar.IndicatorOuterRadius = 0.7;
            this.progressbar.ShowProgressValue = true;
            this.progressbar.GapWidth = 0.5;
            this.progressbar.WidthRequest = 70;
            this.progressbar.HeightRequest = 55;
            this.progressbar.IndeterminateAnimationDuration = 750;

            var pullingTemplate = new DataTemplate(() =>
            {
                return new ViewCell { View = this.border };
            });

            this.pullToRefresh.Refreshing += this.PullToRefresh_Refreshing;
            this.pullToRefresh.Pulling += this.PullToRefresh_Pulling;

            this.pullToRefresh.PullingViewTemplate = pullingTemplate;
            this.pullToRefresh.RefreshingViewTemplate = pullingTemplate;
        }

        private async void pullToRefresh_Refreshing(object sender, EventArgs e)
        {
            pullToRefresh.IsRefreshing = true;
            await Task.Delay(new TimeSpan(0, 0, 3));
            viewModel.ItemsSourceRefresh();
            pullToRefresh.IsRefreshing = false;
        }

        private void PullToRefresh_Pulling(object sender, PullingEventArgs e)
        {
            this.progressbar.TrackInnerRadius = 0.8;
            this.progressbar.TrackOuterRadius = 0.1;
            this.progressbar.IsIndeterminate = false;
            this.progressbar.ProgressColor = Color.FromRgb(0, 124, 238);
            this.progressbar.TrackColor = Color.White;

            var absoluteProgress = Math.Abs(e.Progress);
            this.progressbar.Progress = absoluteProgress;
            this.progressbar.SetProgress(absoluteProgress, 1, Easing.CubicInOut);
        }

        private async void PullToRefresh_Refreshing(object sender, EventArgs e)
        {
            this.pullToRefresh.IsRefreshing = true;
            await this.AnimateRefresh();

            this.progressbar.TrackInnerRadius = 0.1;
            this.progressbar.TrackOuterRadius = 0.9;

            this.viewModel.ItemsSourceRefresh();
            this.pullToRefresh.IsRefreshing = false;
        }

        private async Task AnimateRefresh()
        {
            this.progressbar.Progress = 0;
            this.progressbar.IsIndeterminate = true;

            await Task.Delay(750);
            this.progressbar.ProgressColor = Color.Red;

            await Task.Delay(750);
            this.progressbar.ProgressColor = Color.Green;

            await Task.Delay(750);
            this.progressbar.ProgressColor = Color.Orange;

            await Task.Delay(750);
        }
    } 
}
