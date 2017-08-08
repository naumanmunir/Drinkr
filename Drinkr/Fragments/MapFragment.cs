using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Gms.Maps;
using Android.Support.V4.App;
using Android.Gms.Maps.Model;

namespace Drinkr.Fragments
{
    public class MapFragment : Android.Support.V4.App.Fragment, IOnMapReadyCallback
    {
        private GoogleMap map;
         
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.Map, container, false);



            SupportMapFragment mapFrag = ((SupportMapFragment)FragmentManager.FindFragmentById(Resource.Id.map));

            if (mapFrag == null)
            {
                GoogleMapOptions gmo = new GoogleMapOptions()
                    .InvokeMapType(GoogleMap.MapTypeNormal)
                    .InvokeZoomControlsEnabled(false)
                    .InvokeCompassEnabled(true);

                Android.Support.V4.App.FragmentTransaction fragTx = FragmentManager.BeginTransaction();
                mapFrag = SupportMapFragment.NewInstance(gmo);
                fragTx.Add(Resource.Id.map, mapFrag, "map");
                fragTx.Commit();

            }

            mapFrag.GetMapAsync(this);

            return view;

        }

        public void OnMapReady(GoogleMap googleMap)
        {
            map = googleMap;

            if (map != null)
            {
                LatLng currPosition = new LatLng(40.71, -74.00);

                MarkerOptions markerOpt1 = new MarkerOptions();
                markerOpt1.SetPosition(currPosition);
                markerOpt1.SetTitle("Vimy Ridge");
                //map.MapType = GoogleMap.MapTypeSatellite;

                //CameraPosition cp = new CameraPosition(currPosition, 14, 0, 0);
                CameraUpdate cu = CameraUpdateFactory.NewLatLngZoom(currPosition, 14);
                map.MoveCamera(cu);
                map.AddMarker(markerOpt1);
            }

            
            
        }
    }
}