using System.Collections.Generic;
using CesiSpotify.Models;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using SkiaSharp;
using System.Linq;
using LiveCharts.Defaults;

namespace CesiSpotify.Graph
{
   public class PopularitySeries : ColumnSeries<ObservableValue>
   {
       public PopularitySeries(IEnumerable<SpotifyArtist> artists) 
       {
            Values = artists.Select(x => new ObservableValue(x.Popularity));
            Fill = new SolidColorPaint(SKColors.SpringGreen);
            TooltipLabelFormatter =  (chartPoint) => $"{chartPoint.PrimaryValue} %";
            Mapping = (value, point) =>
            {
                point.PrimaryValue = value.Value;
                point.SecondaryValue = point.Context.Index;
            };
       }
   }
}
