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
using CH.Framework.Extensions;

namespace ChatHub.ViewModels
{
    public partial class BaseMapViewModel : AppViewModelBase
    {
        [ObservableProperty]
        private GraphicsOverlayCollection baseGrapchicsOverlays;

        [ObservableProperty]
        private Viewpoint baseViewpoint;

        [ObservableProperty]
        private Map baseMap;
        public Command<string> TextChangedCommand { get; }
        [ObservableProperty]
        private ObservableCollection<Suggestions> _filteredList;

        [ObservableProperty]
        private Suggestions _selectedItem;


        public BaseMapViewModel(IApiService appApiService) : base(appApiService)
        {
            BaseGrapchicsOverlays = new GraphicsOverlayCollection();
            FilteredList = new ObservableCollection<Suggestions>();
            BaseMap = new Map(BasemapStyle.ArcGISNavigation);
            BaseMap.InitialViewpoint = new Viewpoint(39.7684, -86.1581, 943299);
            TextChangedCommand = new Command<string>(FilterList);
        }

        private async void FilterList(string filter)
        {
            SelectedItem = null;
            if (filter.Length >= 4)
            {

                var Suggestions = await _appApiService.getSuggestions(filter);
                FilteredList.AddRange(Suggestions);
            }
        }

    }
}
