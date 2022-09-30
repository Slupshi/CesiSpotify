using System.Collections.Generic;
using System.Linq;
using CesiSpotify.Models;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace CesiSpotify.Graph
{
    public class CesifyGraphXAxis : Axis
    {
        public CesifyGraphXAxis(IEnumerable<SpotifyArtist> artists, string name) 
        {
            Labels = artists.Select(x => x.Name).ToList();
            LabelsRotation = 15;
            Name = name;
            NamePadding = new LiveChartsCore.Drawing.Padding(10, 10, 10, 20);
            NamePaint = new SolidColorPaint(SKColors.White);
            LabelsPaint = new SolidColorPaint(Properties.SpotifyLightGray);
        }
    }
}
