using System.Windows.Controls;

namespace CarRepairDesktop.Views
{
    public static class Navigator
    {
        private static Frame _mainFrame;

        public static void Init(Frame mainFrame)
        {
            _mainFrame = mainFrame;
        }

        public static void Move(Page page)
        {
            _mainFrame.Navigate(page);
        }

        public static void Back()
        {
            if(_mainFrame.CanGoBack) _mainFrame.GoBack();
        }
    }
}
