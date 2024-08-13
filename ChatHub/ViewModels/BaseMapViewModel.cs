using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.UI;
using Map = Esri.ArcGISRuntime.Mapping.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esri.ArcGISRuntime.Geometry;
using System.Collections.ObjectModel;
using ChatHub.Models;
using Esri.ArcGISRuntime.Symbology;
using CommunityToolkit.Maui.Core.Extensions;
using ChatHub.StoreSheets;
using CH.Framework.Extensions;

namespace ChatHub.ViewModels
{
    public partial class BaseMapViewModel : AppViewModelBase
    {
        [ObservableProperty]
        private GraphicsOverlayCollection baseGrapchicsOverlays;

        [ObservableProperty]
        public Map baseMap;
        public Command<string> TextChangedCommand { get; }
        [ObservableProperty]
        public ObservableCollection<Suggestions> _filteredList;
        [ObservableProperty]
        public bool isFilter = false;

        [ObservableProperty]
        public Suggestions _selectedItem;

        [ObservableProperty]
        public ObservableCollection<Stores> _storeList;


        public BaseMapViewModel(IApiService appApiService) : base(appApiService)
        {
            BaseGrapchicsOverlays = new GraphicsOverlayCollection();
            FilteredList = new ObservableCollection<Suggestions>();
            BaseMap = new Map(BasemapStyle.ArcGISNavigation);
            BaseMap.InitialViewpoint = new Viewpoint(30.3753, 69.3451, 19000000);
            TextChangedCommand = new Command<string>(FilterList);
        }

        private async void FilterList(string filter)
        {
            SelectedItem = null;
            //FilteredList = new ObservableCollection<Suggestions>();
            if (filter.Length >= 4)
            {
                var Suggestions = await _appApiService.getSuggestions(filter);
                FilteredList.Clear();
                FilteredList = Suggestions.ToObservableCollection();
                IsFilter = true;
            }
            else
                IsFilter = false;
            //var stores = await _appApiService.getStores();
            //StoreList = stores.ToObservableCollection();
            //GraphicsOverlay GraphicsOverlayObject = new();
            //GraphicsOverlayCollection overlays = new() { GraphicsOverlayObject };
            //foreach (var store in stores)
            //{
            //    BaseMap.InitialViewpoint = new Viewpoint(store.Longitude, store.Latitude, 43299);
            //    BaseGrapchicsOverlays = new GraphicsOverlayCollection();
            //    BaseGrapchicsOverlays = overlays;
            //    var StoresPoint = new MapPoint(store.Longitude, store.Latitude, SpatialReferences.Wgs84);
            //    TextSymbol NamePoint = new TextSymbol()
            //    {
            //        Text = store.Name,
            //        Color = System.Drawing.Color.Orange,
            //        HorizontalAlignment = Esri.ArcGISRuntime.Symbology.HorizontalAlignment.Justify,
            //        VerticalAlignment = Esri.ArcGISRuntime.Symbology.VerticalAlignment.Top,
            //        BackgroundColor = System.Drawing.Color.Transparent,
            //        FontWeight = Esri.ArcGISRuntime.Symbology.FontWeight.Bold,
            //        Size = 12
            //    };
            //    Uri symbolUri = new Uri("https://cdn-icons-png.flaticon.com/512/2838/2838709.png");
            //    var pointName = new Graphic(StoresPoint, NamePoint);
            //    PictureMarkerSymbol campsiteSymbol = new PictureMarkerSymbol(symbolUri)
            //    {
            //        Width = 20,
            //        Height = 20
            //    };
            //    Graphic campsiteGraphic = new Graphic(StoresPoint, campsiteSymbol);
            //    GraphicsOverlayObject.Graphics.Add(campsiteGraphic);
            //    GraphicsOverlayObject.Graphics.Add(pointName);
            //}
            //var sheet = new StorebottomSheet();
            //sheet.BindingContext = this;
            //await sheet.ShowAsync();
        }








    }
}
