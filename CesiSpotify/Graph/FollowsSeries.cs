using System.Collections.Generic;
using System.Linq;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using SkiaSharp;
using CesiSpotify.Models;
using LiveCharts.Defaults;

namespace CesiSpotify.Graph
{
    public class FollowsSeries : ColumnSeries<ObservableValue>
    {
        public FollowsSeries(IEnumerable<SpotifyArtist> artists)
        {
            Values = artists.Select(x => new ObservableValue(x.FollowersCount));
            Fill = new SolidColorPaint(SKColors.SpringGreen);
            TooltipLabelFormatter = (chartPoint) => $"{chartPoint.PrimaryValue}";
            Mapping = (value, point) =>
            {
                point.PrimaryValue = value.Value;
                point.SecondaryValue = point.Context.Index;
            };
        }
    }
}
