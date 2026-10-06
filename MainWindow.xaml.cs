using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Stoper;

public partial class MainWindow : Window
{
    private readonly Stopwatch _stopwatch = new();
    private readonly DispatcherTimer _timer;
    private int _flagCount;

    public MainWindow()
    {
        InitializeComponent();

        _timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(10)
        };
        _timer.Tick += (_, _) => RefreshTime();
    }

    private void StartButton_Click(object sender, RoutedEventArgs e)
    {
        _stopwatch.Reset();
        _stopwatch.Start();
        _timer.Start();

        PauseButton.IsEnabled = true;
        PauseButton.Content = "Pauza";
        FlagButton.IsEnabled = true;
        StatusLabel.Text = "Działa";
        RefreshTime();
    }

    private void PauseButton_Click(object sender, RoutedEventArgs e)
    {
        if (_stopwatch.IsRunning)
        {
            _stopwatch.Stop();
            _timer.Stop();
            PauseButton.Content = "Wznów";
            StatusLabel.Text = "Wstrzymany";
        }
        else
        {
            _stopwatch.Start();
            _timer.Start();
            PauseButton.Content = "Pauza";
            StatusLabel.Text = "Działa";
        }

        RefreshTime();
    }

    private void FlagButton_Click(object sender, RoutedEventArgs e)
    {
        if (_stopwatch.Elapsed == TimeSpan.Zero && !_stopwatch.IsRunning)
        {
            return;
        }

        AddFlag(FormatTime(_stopwatch.Elapsed), isSixSeven: false);
    }

    private void SixSevenButton_Click(object sender, RoutedEventArgs e)
    {
        StatusLabel.Text = "six seven";
        AddFlag($"{FormatTime(_stopwatch.Elapsed)}  ·  67", isSixSeven: true);
    }

    private void AddFlag(string label, bool isSixSeven)
    {
        EmptyFlagsLabel.Visibility = Visibility.Collapsed;
        _flagCount++;
        FlagCountLabel.Text = _flagCount.ToString();

        var row = new Border
        {
            Background = new SolidColorBrush(isSixSeven
                ? Color.FromRgb(0x5A, 0x52, 0x3A)
                : Color.FromRgb(0x45, 0x48, 0x4E)),
            CornerRadius = new CornerRadius(8),
            Padding = new Thickness(12, 8, 12, 8),
            Margin = new Thickness(0, 0, 0, 8)
        };

        var grid = new Grid();
        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(44) });
        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

        var index = new TextBlock
        {
            Text = isSixSeven ? "67" : $"#{_flagCount:00}",
            Foreground = new SolidColorBrush(Color.FromRgb(0xC8, 0xC8, 0xC8)),
            VerticalAlignment = VerticalAlignment.Center,
            FontWeight = FontWeights.SemiBold
        };

        var time = new TextBlock
        {
            Text = label,
            Foreground = Brushes.White,
            FontFamily = new FontFamily("Consolas"),
            FontSize = 16,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Right
        };

        Grid.SetColumn(time, 1);
        grid.Children.Add(index);
        grid.Children.Add(time);
        row.Child = grid;
        FlagList.Children.Add(row);
    }

    private void RefreshTime()
    {
        TimeLabel.Text = FormatTime(_stopwatch.Elapsed);

        var seconds = _stopwatch.Elapsed.TotalSeconds;
        if (_stopwatch.IsRunning && seconds >= 6.7 && seconds < 6.8)
        {
            StatusLabel.Text = "six seven";
        }
    }

    private static string FormatTime(TimeSpan elapsed)
    {
        return elapsed.ToString(@"hh\:mm\:ss\.ff");
    }
}
