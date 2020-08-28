using Android.OS;
using Android.Views;
using AndroidX.Fragment.App;

namespace Xamarin_SmoothBottomBar_App.Fragments
{
    class FourthFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Inflate the layout for this fragment
            return inflater.Inflate(Resource.Layout.fragment_fourth, container, false);
        }
    }
}