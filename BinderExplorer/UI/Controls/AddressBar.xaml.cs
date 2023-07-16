using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BinderExplorer.UI.Controls
{
    /// <summary>
    /// Interaction logic for AddressBar.xaml
    /// </summary>
    public partial class AddressBar : UserControl
    {
        #region Border Thickness

        /// <summary>
        /// The thickness of the border around the entire address bar.
        /// </summary>
        [Description("The thickness of the border around the entire address bar."), Category("Border Thickness")]
        public Thickness AddressBarBorderThickness
        {
            get
            {
                return (Thickness)GetValue(AddressBarBorderThicknessProperty);
            }
            set
            {
                SetValue(AddressBarBorderThicknessProperty, value);
            }
        }

        public static readonly DependencyProperty AddressBarBorderThicknessProperty =
            DependencyProperty.Register("AddressBarBorderThickness", typeof(Thickness), typeof(AddressBar), new PropertyMetadata(default(Thickness)));

        /// <summary>
        /// The thickness of the border around the entire set of seek buttons.
        /// </summary>
        [Description("The thickness of the border around the entire set of seek buttons."), Category("Border Thickness")]
        public Thickness SeekButtonsBorderThickness
        {
            get
            {
                return (Thickness)GetValue(SeekButtonsBorderThicknessProperty);
            }
            set
            {
                SetValue(SeekButtonsBorderThicknessProperty, value);
            }
        }

        public static readonly DependencyProperty SeekButtonsBorderThicknessProperty =
            DependencyProperty.Register("SeekButtonsBorderThickness", typeof(Thickness), typeof(AddressBar), new PropertyMetadata(default(Thickness)));

        /// <summary>
        /// The thickness of the border around the back button.
        /// </summary>
        [Description("The thickness of the border around the back button."), Category("Border Thickness")]
        public Thickness BackButtonBorderThickness
        {
            get
            {
                return (Thickness)GetValue(BackButtonBorderThicknessProperty);
            }
            set
            {
                SetValue(BackButtonBorderThicknessProperty, value);
            }
        }

        public static readonly DependencyProperty BackButtonBorderThicknessProperty =
            DependencyProperty.Register("BackButtonsBorderThickness", typeof(Thickness), typeof(AddressBar), new PropertyMetadata(default(Thickness)));

        /// <summary>
        /// The thickness of the border around the forward button.
        /// </summary>
        [Description("The thickness of the border around the forward button."), Category("Border Thickness")]
        public Thickness ForwardButtonBorderThickness
        {
            get
            {
                return (Thickness)GetValue(ForwardButtonBorderThicknessProperty);
            }
            set
            {
                SetValue(ForwardButtonBorderThicknessProperty, value);
            }
        }

        public static readonly DependencyProperty ForwardButtonBorderThicknessProperty =
            DependencyProperty.Register("ForwardButtonBorderThickness", typeof(Thickness), typeof(AddressBar), new PropertyMetadata(default(Thickness)));

        /// <summary>
        /// The thickness of the border around the up button.
        /// </summary>
        [Description("The thickness of the border around the up button."), Category("Border Thickness")]
        public Thickness UpButtonBorderThickness
        {
            get
            {
                return (Thickness)GetValue(UpButtonBorderThicknessProperty);
            }
            set
            {
                SetValue(UpButtonBorderThicknessProperty, value);
            }
        }

        public static readonly DependencyProperty UpButtonBorderThicknessProperty =
            DependencyProperty.Register("UpButtonBorderThickness", typeof(Thickness), typeof(AddressBar), new PropertyMetadata(default(Thickness)));

        /// <summary>
        /// The thickness of the border around the entire address box area.
        /// </summary>
        [Description("The thickness of the border around the entire address box area."), Category("Border Thickness")]
        public Thickness AddressBoxBorderThickness
        {
            get
            {
                return (Thickness)GetValue(AddressBoxBorderThicknessProperty);
            }
            set
            {
                SetValue(AddressBoxBorderThicknessProperty, value);
            }
        }

        public static readonly DependencyProperty AddressBoxBorderThicknessProperty =
            DependencyProperty.Register("AddressBoxBorderThickness", typeof(Thickness), typeof(AddressBar), new PropertyMetadata(default(Thickness)));

        /// <summary>
        /// The thickness of the border around the address combobox.
        /// </summary>
        [Description("The thickness of the border around the address combobox."), Category("Border Thickness")]
        public Thickness AddressComboBoxBorderThickness
        {
            get
            {
                return (Thickness)GetValue(AddressComboBoxBorderThicknessProperty);
            }
            set
            {
                SetValue(AddressComboBoxBorderThicknessProperty, value);
            }
        }

        public static readonly DependencyProperty AddressComboBoxBorderThicknessProperty =
            DependencyProperty.Register("AddressComboBoxBorderThickness", typeof(Thickness), typeof(AddressBar), new PropertyMetadata(default(Thickness)));

        /// <summary>
        /// The thickness of the border around the refresh button.
        /// </summary>
        [Description("The thickness of the border around the address combobox."), Category("Border Thickness")]
        public Thickness RefreshButtonBorderThickness
        {
            get
            {
                return (Thickness)GetValue(RefreshButtonBorderThicknessProperty);
            }
            set
            {
                SetValue(RefreshButtonBorderThicknessProperty, value);
            }
        }

        public static readonly DependencyProperty RefreshButtonBorderThicknessProperty =
            DependencyProperty.Register("RefreshButtonBorderThickness", typeof(Thickness), typeof(AddressBar), new PropertyMetadata(default(Thickness)));

        /// <summary>
        /// The thickness of the border around the search box.
        /// </summary>
        [Description("The thickness of the border around the search box."), Category("Border Thickness")]
        public Thickness SearchBoxBorderThickness
        {
            get
            {
                return (Thickness)GetValue(SearchBoxBorderThicknessProperty);
            }
            set
            {
                SetValue(SearchBoxBorderThicknessProperty, value);
            }
        }

        public static readonly DependencyProperty SearchBoxBorderThicknessProperty =
            DependencyProperty.Register("SearchBoxBorderThickness", typeof(Thickness), typeof(AddressBar), new PropertyMetadata(default(Thickness)));

        #endregion

        #region Brushes

        /// <summary>
        /// The brush used for the border around the entire address bar.
        /// </summary>
        [Description("The brush used for the border around the entire address bar."), Category("Border Brush")]
        public Brush AddressBarBorderBrush
        {
            get
            {
                return (Brush)GetValue(AddressBarBorderBrushProperty);
            }
            set
            {
                SetValue(AddressBarBorderBrushProperty, value);
            }
        }

        public static readonly DependencyProperty AddressBarBorderBrushProperty =
            DependencyProperty.Register("AddressBarBorderBrush", typeof(Brush), typeof(AddressBar), new PropertyMetadata(default(Brush)));

        /// <summary>
        /// The brush used for the border around the entire set of seek buttons.
        /// </summary>
        [Description("The brush used for the border around the entire set of seek buttons."), Category("Border Brush")]
        public Brush SeekButtonsBorderBrush
        {
            get
            {
                return (Brush)GetValue(SeekButtonsBorderBrushProperty);
            }
            set
            {
                SetValue(SeekButtonsBorderBrushProperty, value);
            }
        }

        public static readonly DependencyProperty SeekButtonsBorderBrushProperty =
            DependencyProperty.Register("SeekButtonsBorderBrush", typeof(Brush), typeof(AddressBar), new PropertyMetadata(default(Brush)));

        /// <summary>
        /// The brush used for the border around the back button.
        /// </summary>
        [Description("The brush used for the border around the back button."), Category("Border Brush")]
        public Brush BackButtonBorderBrush
        {
            get
            {
                return (Brush)GetValue(BackButtonBorderBrushProperty);
            }
            set
            {
                SetValue(BackButtonBorderBrushProperty, value);
            }
        }

        public static readonly DependencyProperty BackButtonBorderBrushProperty =
            DependencyProperty.Register("BackButtonBorderBrush", typeof(Brush), typeof(AddressBar), new PropertyMetadata(default(Brush)));

        /// <summary>
        /// The brush used for the border around the forward button.
        /// </summary>
        [Description("The brush used for the border around the forward button."), Category("Border Brush")]
        public Brush ForwardButtonBorderBrush
        {
            get
            {
                return (Brush)GetValue(ForwardButtonBorderBrushProperty);
            }
            set
            {
                SetValue(ForwardButtonBorderBrushProperty, value);
            }
        }

        public static readonly DependencyProperty ForwardButtonBorderBrushProperty =
            DependencyProperty.Register("ForwardButtonBorderBrush", typeof(Brush), typeof(AddressBar), new PropertyMetadata(default(Brush)));

        /// <summary>
        /// The brush used for the border around the entire address box area.
        /// </summary>
        [Description("The brush used for the border around the entire address box area."), Category("Border Brush")]
        public Brush AddressBoxBorderBrush
        {
            get
            {
                return (Brush)GetValue(AddressBoxBorderBrushProperty);
            }
            set
            {
                SetValue(AddressBoxBorderBrushProperty, value);
            }
        }

        public static readonly DependencyProperty AddressBoxBorderBrushProperty =
            DependencyProperty.Register("AddressBoxBorderBrush", typeof(Brush), typeof(AddressBar), new PropertyMetadata(default(Brush)));

        /// <summary>
        /// The brush used for the border around the up button.
        /// </summary>
        [Description("The brush used for the border around the up button."), Category("Border Brush")]
        public Brush UpButtonBorderBrush
        {
            get
            {
                return (Brush)GetValue(UpButtonBorderBrushProperty);
            }
            set
            {
                SetValue(UpButtonBorderBrushProperty, value);
            }
        }

        public static readonly DependencyProperty UpButtonBorderBrushProperty =
            DependencyProperty.Register("UpButtonBorderBrush", typeof(Brush), typeof(AddressBar), new PropertyMetadata(default(Brush)));

        /// <summary>
        /// The brush used for the border around the address combobox.
        /// </summary>
        [Description("The brush used for the border around the address combobox."), Category("Border Brush")]
        public Brush AddressComboBoxBorderBrush
        {
            get
            {
                return (Brush)GetValue(AddressComboBoxBorderBrushProperty);
            }
            set
            {
                SetValue(AddressComboBoxBorderBrushProperty, value);
            }
        }

        public static readonly DependencyProperty AddressComboBoxBorderBrushProperty =
            DependencyProperty.Register("AddressComboBoxBorderBrush", typeof(Brush), typeof(AddressBar), new PropertyMetadata(default(Brush)));

        /// <summary>
        /// The brush used for the border around the refresh button.
        /// </summary>
        [Description("The brush used for the border around the refresh button."), Category("Border Brush")]
        public Brush RefreshButtonBorderBrush
        {
            get
            {
                return (Brush)GetValue(RefreshButtonBorderBrushProperty);
            }
            set
            {
                SetValue(RefreshButtonBorderBrushProperty, value);
            }
        }

        public static readonly DependencyProperty RefreshButtonBorderBrushProperty =
            DependencyProperty.Register("RefreshButtonBorderBrush", typeof(Brush), typeof(AddressBar), new PropertyMetadata(default(Brush)));

        /// <summary>
        /// The brush used for the border around the search box.
        /// </summary>
        [Description("The brush used for the border around the search box."), Category("Border Brush")]
        public Brush SearchBoxBorderBrush
        {
            get
            {
                return (Brush)GetValue(SearchBoxBorderBrushProperty);
            }
            set
            {
                SetValue(SearchBoxBorderBrushProperty, value);
            }
        }

        public static readonly DependencyProperty SearchBoxBorderBrushProperty =
            DependencyProperty.Register("SearchBoxBorderBrush", typeof(Brush), typeof(AddressBar), new PropertyMetadata(default(Brush)));

        #endregion

        #region Events

        /*public event RoutedEventHandler? BackButtonClicked;

        protected virtual void OnBackButton_Clicked(RoutedEventArgs e)
        {
            BackButtonClicked?.Invoke(this, e);
        }

        public event RoutedEventHandler? ForwardButtonClicked;

        protected virtual void OnForwardButton_Clicked(RoutedEventArgs e)
        {
            ForwardButtonClicked?.Invoke(this, e);
        }

        public event RoutedEventHandler? UpButtonClicked;

        protected virtual void OnUpButton_Clicked(RoutedEventArgs e)
        {
            UpButtonClicked?.Invoke(this, e);
        }

        public event RoutedEventHandler? RefreshButtonClicked;

        protected virtual void OnRefreshButton_Clicked(RoutedEventArgs e)
        {
            RefreshButtonClicked?.Invoke(this, e);
        }

        public event TextChangedEventHandler? AddressComboBoxTextChanged;

        private void AddressComboBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            AddressComboBoxTextChanged?.Invoke(sender, e);
        }

        public event TextChangedEventHandler? SearchBoxTextChanged;

        protected virtual void OnSearchBox_TextChanged(TextChangedEventArgs e)
        {
            SearchBoxTextChanged?.Invoke(this, e);
        }*/

        #endregion

        public AddressBar()
        {
            InitializeComponent();
        }
    }
}
